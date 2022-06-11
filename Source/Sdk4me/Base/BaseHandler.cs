#if NET5_0_OR_GREATER
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Sdk4me.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace Sdk4me
{
    /// <summary>
    /// The base API handler.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="X">The predefined filter enumerator.</typeparam>
    public abstract class BaseHandler<T, X> : IBaseHandler where T : BaseItem, new() where X : Enum
    {
        private readonly bool traceEnabled = Trace.Listeners != null && Trace.Listeners.Count > 0;
        private readonly string applicationJsonMediaType = "application/json";
        private readonly DateTime epochDateTimeMinValue = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly string allFieldNames = null;
        private readonly HttpClient client = new HttpClient();
        private readonly JsonSerializer serializer = new JsonSerializer();
        private readonly string url;
        private readonly string storageFacilityUrl;
        private readonly AuthenticationTokenCollection authenticationTokens;
        private readonly string accountID;
        private readonly Type currentType = typeof(T);
        private readonly Type currentCollectionType = typeof(List<T>);
        private AuthenticationToken currentToken = null;
        private SortOrder responseSorting = SortOrder.UpdatedAt;
        private string responseFieldNames = null;
        private int itemsPerRequest = 25;
        private int maximumRecursiveRequests = 10;
        private bool alwaysAsList = false;

        /// <summary>
        /// <para>Gets or sets the number of items returned in one request.</para>
        /// <para>The value must be at least 1 and maximum 100.</para>
        /// </summary>
        public int ItemsPerRequest
        {
            get => itemsPerRequest;
            set => itemsPerRequest = (value < 1 || value > 100) ? 25 : value;
        }

        /// <summary>
        /// <para>Gets or sets the number of recursive requests.</para>
        /// <para>The value must be at least 1 and maximum 1000.</para>
        /// </summary>
        public int MaximumRecursiveRequests
        {
            get => maximumRecursiveRequests;
            set => maximumRecursiveRequests = (value < 1 || value > 1000) ? 10 : value;
        }

        /// <summary>
        /// Force to parse the API response as a list.
        /// </summary>
        public bool AlwaysAsList
        {
            get => alwaysAsList;
            set => alwaysAsList = value;
        }

        /// <summary>
        /// <para>Gets or sets the web response sorting.</para>
        /// <para>The default sorting is on the "updated_at" attribute.</para>
        /// </summary>
        public SortOrder SortOrder
        {
            get => responseSorting;
            set => responseSorting = value;
        }

        /// <summary>
        /// Returns the <see cref="AuthenticationToken"/> collection.
        /// </summary>
        protected AuthenticationTokenCollection AuthenticationTokens
        {
            get => authenticationTokens;
        }

        /// <summary>
        /// Returns the 4me account identifier.
        /// </summary>
        protected string AccountID
        {
            get => accountID;
        }

        /// <summary>
        /// Returns the 4me API URL.
        /// </summary>
        protected string URL
        {
            get => url;
        }

        #region constructors

        /// <summary>
        /// Create a new instance of the <see cref="BaseHandler{T, X}"/>.
        /// </summary>
        /// <param name="endPointUrl">The API end point URL.</param>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me Account ID.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public BaseHandler(string endPointUrl, AuthenticationToken authenticationToken, string accountID, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : this(endPointUrl, new AuthenticationTokenCollection(authenticationToken), accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the <see cref="DefaultBaseHandler{T}"/>.
        /// </summary>
        /// <param name="endPointUrl">The API end point URL.</param>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me Account ID.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public BaseHandler(string endPointUrl, AuthenticationTokenCollection authenticationTokens, string accountID, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
        {
            //validate string argument values
            if (string.IsNullOrWhiteSpace(accountID))
                throw new ArgumentException($"'{nameof(accountID)}' cannot be null or whitespace.", nameof(accountID));

            //validate the url
            if (string.IsNullOrWhiteSpace(endPointUrl))
                throw new ArgumentException($"'{nameof(endPointUrl)}' cannot be null or whitespace.", nameof(endPointUrl));

            if (!Uri.TryCreate(endPointUrl, UriKind.Absolute, out Uri uriResult) || uriResult.Scheme != Uri.UriSchemeHttps)
                throw new ArgumentException($"'{nameof(endPointUrl)}' is invalid.", nameof(endPointUrl));

            //set storage facility url
            storageFacilityUrl = EnvironmentURL.GetStorageFacilityUrl(endPointUrl);

            //validate authentication tokens
            if (authenticationTokens is null)
                throw new ArgumentNullException(nameof(authenticationTokens));

            if (!authenticationTokens.Any())
                throw new ArgumentException($"'{nameof(authenticationTokens)}' cannot be empty.", nameof(authenticationTokens));

            //json converter settings
            serializer.Converters.Add(new StringEnumConverter());

            //set global variables
            url = endPointUrl.TrimEnd('/');
            this.authenticationTokens = authenticationTokens;
            this.accountID = accountID;
            this.itemsPerRequest = (itemsPerRequest < 1 || itemsPerRequest > 100) ? 25 : itemsPerRequest;
            this.maximumRecursiveRequests = (maximumRecursiveRequests < 1 || maximumRecursiveRequests > 1000) ? 10 : maximumRecursiveRequests;

            //get all field names for the current type
            allFieldNames = new T().GetAllFieldNames();
        }

        #endregion

        #region get a child handler

        /// <summary>
        /// Get a <see cref="DefaultBaseHandler{T}"/> with a relation to the item.
        /// </summary>
        /// <typeparam name="H"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="endPointName">The endpoint for the child relational item.</param>
        /// <returns>Returns a <see cref="DefaultBaseHandler{T}"/> with a relation to the item object handler.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        protected DefaultBaseHandler<H> GetChildHandler<H>(T item, string endPointName) where H : BaseItem, new()
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrEmpty(endPointName))
                throw new ArgumentException($"'{nameof(endPointName)}' cannot be null or empty.", nameof(endPointName));

            return new DefaultBaseHandler<H>($"{url}/{item.ID}/{endPointName.Trim('/')}", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests, responseSorting);
        }

        /// <summary>
        /// Get a <see cref="DefaultBaseHandler{T}"/> with a relation to the item.
        /// </summary>
        /// <typeparam name="H"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="endPointName">The endpoint for the child relational item.</param>
        /// <param name="sortOrder">The sort order of the handler.</param>
        /// <returns>Returns a <see cref="DefaultBaseHandler{T}"/> with a relation to the item object handler.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        protected DefaultBaseHandler<H> GetChildHandler<H>(T item, string endPointName, SortOrder sortOrder) where H : BaseItem, new()
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrEmpty(endPointName))
                throw new ArgumentException($"'{nameof(endPointName)}' cannot be null or empty.", nameof(endPointName));

            return new DefaultBaseHandler<H>($"{url}/{item.ID}/{endPointName.Trim('/')}", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests, sortOrder);
        }

        #endregion

        #region get methods

        /// <summary>
        /// Query the 4me web services.
        /// </summary>
        /// <param name="ID">The identifier of the object.</param>
        /// <returns>The object that matches the identifier.</returns>
        /// <exception cref="Sdk4meException"></exception>
        public T Get(long ID)
        {
            SetResponseFieldNames(null);
            return Get(null, null, $"{url}/{ID}", 1).FirstOrDefault();
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="fieldNames">An array of field names to be requested. If no field names are specified the default fields will be returned. Use * to get all fields.</param>
        /// <returns>A collection of objects.</returns>
        /// <exception cref="Sdk4meException"></exception>
        public List<T> Get(params string[] fieldNames)
        {
            SetResponseFieldNames(fieldNames);
            return Get(null, null, null, maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="predefinedFilter">A predefined filter value.</param>
        /// <param name="fieldNames">An array of field names to be requested. If no field names are specified the default fields will be returned. Use * to get all fields.</param>
        /// <returns>A collection of objects.</returns>
        /// <exception cref="Sdk4meException"></exception>
        public List<T> Get(X predefinedFilter, params string[] fieldNames)
        {
            SetResponseFieldNames(fieldNames);
            return Get(predefinedFilter.To4meString(), null, null, maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="filter">The filter for the request.</param>
        /// <param name="fieldNames">An array of field names to be requested. If no field names are specified the default fields will be returned. Use * to get all fields.</param>
        /// <returns>A collection of objects.</returns>
        /// <exception cref="Sdk4meException"></exception>
        public List<T> Get(Filter filter, params string[] fieldNames)
        {
            SetResponseFieldNames(fieldNames);
            return Get(null, new FilterCollection() { filter }, null, maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="predefinedFilter">A predefined filter value.</param>
        /// <param name="filter">The filter for the request.</param>
        /// <param name="fieldNames">An array of field names to be requested. If no field names are specified the default fields will be returned. Use * to get all fields.</param>
        /// <returns>A collection of objects.</returns>
        /// <exception cref="Sdk4meException"></exception>
        public List<T> Get(X predefinedFilter, Filter filter, params string[] fieldNames)
        {
            SetResponseFieldNames(fieldNames);
            return Get(predefinedFilter.To4meString(), new FilterCollection() { filter }, null, maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="filters">The filters for the request.</param>
        /// <param name="fieldNames">An array of field names to be requested. If no field names are specified the default fields will be returned. Use * to get all fields.</param>
        /// <returns>A collection of objects.</returns>
        /// <exception cref="Sdk4meException"></exception>
        public List<T> Get(FilterCollection filters, params string[] fieldNames)
        {
            SetResponseFieldNames(fieldNames);
            return Get(null, filters, null, maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="predefinedFilter">A predefined filter value.</param>
        /// <param name="filters">The filters for the request.</param>
        /// <param name="fieldNames">An array of field names to be requested. If no field names are specified the default fields will be returned. Use * to get all fields.</param>
        /// <returns>A collection of objects.</returns>
        /// <exception cref="Sdk4meException"></exception>
        public List<T> Get(X predefinedFilter, FilterCollection filters, params string[] fieldNames)
        {
            SetResponseFieldNames(fieldNames);
            return Get(predefinedFilter.To4meString(), filters, null, maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="predefinedFilter">A predefined filter value.</param>
        /// <param name="filters">The filters used during the request.</param>
        /// <param name="nextPageUrl">The 'next page' URL. This should always be null; unless it is a recursive call.</param>
        /// <param name="recursiveRequestCount">The amount of recursive requests.</param>
        /// <returns>A collection of objects.</returns>
        /// <exception cref="Sdk4meException"></exception>
        private List<T> Get(string predefinedFilter, FilterCollection filters, string nextPageUrl, int recursiveRequestCount)
        {
            List<T> retval = new List<T>();

            if (recursiveRequestCount < 1)
                return retval;

            if (nextPageUrl == null)
            {
                if (filters is null)
                    filters = new FilterCollection();

                nextPageUrl = (predefinedFilter == null) ? $"{url}{(url.Contains('?') ? "&" : "?")}per_page={itemsPerRequest}" : $"{url}/{predefinedFilter}?per_page={itemsPerRequest}";
                if (responseSorting != SortOrder.None)
                    nextPageUrl += $"&sort={responseSorting.To4meString()}";
                for (int i = 0; i < filters.Count; i++)
                    nextPageUrl += $"&{filters[i].GetFilter()}";
                if (responseFieldNames != null)
                    nextPageUrl += $"&fields={responseFieldNames}";
            }

            using (HttpRequestMessage requestMessage = CreateHttpRequest(HttpMethod.Get, nextPageUrl))
            {
                nextPageUrl = null;

                using (HttpResponseMessage responseMessage = SendHttpRequest(requestMessage))
                {
                    if (responseMessage.Headers.TryGetValues("X-Pagination-Total-Entries", out _) || alwaysAsList)
                    {
                        if (responseMessage.Headers.TryGetValues("Link", out IEnumerable<string> linkHeaderValue))
                            nextPageUrl = HttpHeaderLink.GetLinksFromHeader(linkHeaderValue.FirstOrDefault()).NextLink;

                        retval.AddRange(GetHttpContentAsCollection(responseMessage));
                    }
                    else
                    {
                        retval.Add(GetHttpContentAsItem(responseMessage));
                    }

                    for (int i = 0; i < retval.Count; i++)
                        retval[i].ResetPropertySerializationCollection();
                }
            }

            if (nextPageUrl != null)
                retval.AddRange(Get(predefinedFilter, filters, nextPageUrl, recursiveRequestCount - 1));

            return retval;
        }

        #endregion

        #region insert and update methods

        /// <summary>
        /// Creates a new object in 4me.
        /// </summary>
        /// <param name="item">The object to create.</param>
        /// <returns>A new instance of the created object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        public T Insert(T item)
        {
            return InsertOrUpdate(HttpMethod.Post, item);
        }

        /// <summary>
        /// Update an object in 4me.
        /// </summary>
        /// <param name="item">The object to be updated.</param>
        /// <returns>A new instance of the updated object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        public T Update(T item)
        {
            return InsertOrUpdate(HttpMethod.Patch, item);
        }

        /// <summary>
        /// Create or updates an object in 4me.
        /// </summary>
        /// <param name="method">The http method.</param>
        /// <param name="item">The object to be created or updated.</param>
        /// <returns>A new instance of the created object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        private T InsertOrUpdate(HttpMethod method, T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (!item.HasChanged)
                return item;

            string requestUrl = method == HttpMethod.Post ? url : $"{url}/{item.ID}";
            serializer.ContractResolver = new ContractResolver(item.PropertySerializationCollection, method != HttpMethod.Post);

            using (HttpRequestMessage requestMessage = CreateHttpRequest(method, requestUrl))
            {
                using (HttpResponseMessage responseMessage = SendHttpRequest(requestMessage, item))
                {
                    T retval = GetHttpContentAsItem(responseMessage);
                    retval?.ResetPropertySerializationCollection();
                    return retval;
                }
            }
        }

        /// <summary>
        /// Send a request without any content to the 4me API.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <returns>The object in case of success; otherwise false.</returns>
        public T Invoke(string httpMethod)
        {
            using (HttpRequestMessage requestMessage = CreateHttpRequest(new HttpMethod(httpMethod.ToUpperInvariant()), url))
            {
                using (HttpResponseMessage responseMessage = SendHttpRequest(requestMessage))
                {
                    T retval = GetHttpContentAsItem(responseMessage);
                    retval?.ResetPropertySerializationCollection();
                    return retval;
                }
            }
        }

        /// <summary>
        /// Send a request without any content to the 4me API.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <returns>True on any HTTP success status code; otherwise false.</returns>
        public bool InvokeNoContent(string httpMethod)
        {
            using (HttpRequestMessage requestMessage = CreateHttpRequest(new HttpMethod(httpMethod.ToUpperInvariant()), url))
            {
                using (HttpResponseMessage responseMessage = SendHttpRequest(requestMessage))
                {
                    return responseMessage.IsSuccessStatusCode;
                }
            }
        }

        #endregion

        #region delete methods

        /// <summary>
        /// Delete a linked 4me object.
        /// </summary>
        /// <param name="item">The object to delete.</param>
        /// <returns>True is case of success; otherwise false.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        public bool Delete(T item)
        {
            return Delete(item, false);
        }

        /// <summary>
        /// Delete all linked 4me objects.
        /// </summary>
        /// <returns>True is case of success; otherwise false.</returns>
        /// <exception cref="Sdk4meException"></exception>
        public bool DeleteAll()
        {
            return Delete(null, true);
        }

        /// <summary>
        /// Delete one or all linked 4me objects.
        /// </summary>
        /// <param name="item">The object to delete.</param>
        /// <param name="allItems">True to delete all items, when true the item value will be ignored."/></param>
        /// <returns>True is case of success; otherwise false.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        private bool Delete(T item, bool allItems)
        {
            if (!allItems && item is null)
                throw new ArgumentNullException(nameof(item));

            using (HttpRequestMessage request = CreateHttpRequest(HttpMethod.Delete, allItems ? url : $"{url}/{item.ID}"))
            {
                using (HttpResponseMessage response = SendHttpRequest(request))
                {
                    return response.StatusCode == HttpStatusCode.NoContent;
                }
            }
        }

        #endregion

        #region relational methods

        /// <summary>
        /// Create a relation between 2 objects.
        /// </summary>
        /// <param name="item">The item to create the relation for.</param>
        /// <param name="relationObjectName">The object type (4me name) of the relation.</param>
        /// <param name="relationItem">The related item.</param>
        /// <returns>True in case of success, otherwise false.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        protected bool CreateRelation(T item, string relationObjectName, BaseItem relationItem)
        {
            if (string.IsNullOrWhiteSpace(relationObjectName))
                throw new ArgumentException($"'{nameof(relationObjectName)}' cannot be null or whitespace.", nameof(relationObjectName));
            if (relationItem is null)
                throw new ArgumentNullException(nameof(relationItem));

            return UpdateRelation(HttpMethod.Post, item, relationObjectName, relationItem);
        }

        /// <summary>
        /// Delete a relation between two objects.
        /// </summary>
        /// <param name="item">The item to delete the relation from.</param>
        /// <param name="relationObjectName">The object type (4me name) of the relation.</param>
        /// <param name="relationItem">The related item.</param>
        /// <returns>True in case of success, otherwise false.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        protected bool DeleteRelation(T item, string relationObjectName, BaseItem relationItem)
        {
            if (string.IsNullOrWhiteSpace(relationObjectName))
                throw new ArgumentException($"'{nameof(relationObjectName)}' cannot be null or whitespace.", nameof(relationObjectName));
            if (relationItem is null)
                throw new ArgumentNullException(nameof(relationItem));

            return UpdateRelation(HttpMethod.Delete, item, relationObjectName, relationItem);
        }

        /// <summary>
        /// Delete all relations from the object.
        /// </summary>
        /// <param name="item">The item to delete the relation from.</param>
        /// <param name="relationObjectName">The object type (4me name) of the relation.</param>
        /// <returns>True in case of success, otherwise false.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        protected bool DeleteAllRelations(T item, string relationObjectName)
        {
            if (string.IsNullOrWhiteSpace(relationObjectName))
                throw new ArgumentException($"'{nameof(relationObjectName)}' cannot be null or whitespace.", nameof(relationObjectName));

            return UpdateRelation(HttpMethod.Delete, item, relationObjectName, null);
        }

        /// <summary>
        /// Add or Delete a relation between objects.
        /// </summary>
        /// <param name="method">The http method.</param>
        /// <param name="item">The item to delete the relation from.</param>
        /// <param name="relationObjectName">The object type (4me name) of the relation.</param>
        /// <param name="relationItem">The related item.</param>
        /// <returns>True in case of success, otherwise false.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        private bool UpdateRelation(HttpMethod method, T item, string relationObjectName, BaseItem relationItem)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            string requestUrl = $"{url}/{item.ID}/{relationObjectName}";
            if (relationItem != null)
                requestUrl += $"/{relationItem.ID}";

            using (HttpRequestMessage requestMessage = CreateHttpRequest(method, requestUrl))
            {
                using (HttpResponseMessage responseMessage = SendHttpRequest(requestMessage))
                {
                    return responseMessage.StatusCode == HttpStatusCode.OK || responseMessage.StatusCode == HttpStatusCode.NoContent;
                }
            }
        }

        #endregion

        #region storage

        /// <summary>
        /// Upload a file to 4me storage.
        /// </summary>
        /// <param name="path">The file to be uploaded.</param>
        /// <param name="contentType">The content type of the file.</param>
        /// <param name="key">The reference key of the file storage.</param>
        /// <param name="size">The size, in bytes, of the file.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        /// <exception cref="Exception"></exception>
        public bool UploadAttachment(string path, string contentType, out string key, out long size)
        {
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
                throw new FileNotFoundException(path);

            StorageFacility storageFacility = GetStorageFacility();
            if (storageFacility != null)
            {
                if (file.Length >= storageFacility.SizeLimit)
                    throw new Sdk4meException($"File size exceeded, the maximum size is {storageFacility.SizeLimit} byte");

                MultipartFormDataContent multipartContent = new MultipartFormDataContent
                {
                    { new StringContent(contentType), "Content-Type" },
                    { new StringContent(storageFacility.Cloud.ACL), "acl" },
                    { new StringContent(storageFacility.Cloud.Key), "key" },
                    { new StringContent(storageFacility.Cloud.Policy), "policy" },
                    { new StringContent(storageFacility.Cloud.SuccessActionStatus), "success_action_status" },
                    { new StringContent(storageFacility.Cloud.Algorithm), "x-amz-algorithm" },
                    { new StringContent(storageFacility.Cloud.Credential), "x-amz-credential" },
                    { new StringContent(storageFacility.Cloud.Date), "x-amz-date" },
                    { new StringContent(storageFacility.Cloud.ServerSideEncryption), "x-amz-server-side-encryption" },
                    { new StringContent(storageFacility.Cloud.Signature), "x-amz-signature" },
                    { new ByteArrayContent(File.ReadAllBytes(file.FullName)), "file", file.Name }
                };

                using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, storageFacility.UploadUri) { Content = multipartContent })
                {
                    WriteDebug(requestMessage);
                    using (HttpResponseMessage responseMessage = client.Send(requestMessage))
                    {
                        using (StreamReader reader = new StreamReader(responseMessage.Content.ReadAsStream()))
                        {
                            string data = reader.ReadToEnd();

                            Match match = Regex.Match(data, "(?<=<Key>)(.*?)(?=</Key>)");
                            if (match.Success)
                            {
                                key = match.Value;
                                size = file.Length;
                                return true;
                            }
                            else
                            {
                                throw new Exception(data);
                            }
                        }
                    }
                }
            }
            else
            {
                key = null;
                size = 0;
                return false;
            }
        }

        /// <summary>
        /// Delete a file.
        /// </summary>
        /// <param name="item">The item to which the files belong.</param>
        /// <param name="attachmentType">The attachment type.</param>
        /// <param name="attachment">The attachment to be deleted.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        public bool DeleteAttachment(T item, AttachmentType attachmentType, Attachment attachment)
        {
            return DeleteAttachment(item, attachmentType, new List<Attachment> { attachment });
        }

        /// <summary>
        /// Delete a collection of files.
        /// </summary>
        /// <param name="item">The item to which the files belong.</param>
        /// <param name="attachmentType">The attachment type.</param>
        /// <param name="attachments">The list of files to be deleted.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Sdk4meException"></exception>
        public bool DeleteAttachment(T item, AttachmentType attachmentType, List<Attachment> attachments)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (attachments is null)
                throw new ArgumentNullException(nameof(attachments));

            JArray data = new JArray();
            foreach (Attachment attachment in attachments)
                data.Add(new JObject() { { "key", attachment.Key }, { "_destroy", true } });
            JObject jsonObject = new JObject { { $"{attachmentType.To4meString()}_attachments", data } };

            using (HttpRequestMessage requestMessage = CreateHttpRequest(HttpMethod.Patch, $"{url}/{item.ID}"))
            {
                using (HttpResponseMessage responseMessage = SendHttpRequest(requestMessage, jsonObject))
                {
                    return responseMessage.IsSuccessStatusCode;
                }
            }
        }

        /// <summary>
        /// Request a storage facility object.
        /// </summary>
        /// <returns>A <see cref="StorageFacility"/> item when successful; otherwise null.</returns>
        /// <exception cref="Sdk4meException"></exception>
        private StorageFacility GetStorageFacility()
        {
            using (HttpRequestMessage requestMessage = CreateHttpRequest(HttpMethod.Get, storageFacilityUrl))
            {
                using (HttpResponseMessage responseMessage = SendHttpRequest(requestMessage))
                {
                    if (responseMessage.IsSuccessStatusCode && responseMessage.Content.Headers.ContentType.MediaType == applicationJsonMediaType)
                    {
                        using (StreamReader streamReader = new StreamReader(responseMessage.Content.ReadAsStream()))
                        {
                            using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                            {
                                return (StorageFacility)serializer.Deserialize(jsonTextReader, TypeReferences.StorageFacilityType);
                            }
                        }
                    }
                    else if (responseMessage.Content.Headers.ContentType.MediaType == applicationJsonMediaType)
                    {
                        using (StreamReader streamReader = new StreamReader(responseMessage.Content.ReadAsStream()))
                            throw new Sdk4meException(streamReader.ReadToEnd());
                    }

                    return null;
                }
            }
        }

        #endregion

        #region Audit

        /// <summary>
        /// Get the audit trail.
        /// </summary>
        /// <param name="item">The 4me object.</param>
        /// <returns>Return the <see cref="AuditTrail"/>.</returns>
        public virtual List<AuditTrail> GetAuditTrail(T item)
        {
            return GetChildHandler<AuditTrail>(item, "audit", SortOrder = SortOrder.None).Get();
        }

        #endregion

        #region http helper methods

        /// <summary>
        /// Reads the <see cref="HttpResponseMessage"/> content stream and deserialize it.
        /// </summary>
        /// <param name="responseMessage">The http response message.</param>
        /// <returns>Returns the object.</returns>
        private T GetHttpContentAsItem(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode == HttpStatusCode.NoContent)
                return null;

            using (StreamReader streamReader = new StreamReader(responseMessage.Content.ReadAsStream()))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                {
                    return (T)serializer.Deserialize(jsonTextReader, currentType);
                }
            }
        }

        /// <summary>
        /// Reads the <see cref="HttpResponseMessage"/> content stream and deserialize it into <see cref="List{T}"/>.
        /// </summary>
        /// <param name="responseMessage">The http response message.</param>
        /// <returns>Returns <see cref="List{T}"/> object.</returns>
        private List<T> GetHttpContentAsCollection(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode == HttpStatusCode.NoContent)
                return new List<T>();

            using (StreamReader streamReader = new StreamReader(responseMessage.Content.ReadAsStream()))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                {
                    return (List<T>)serializer.Deserialize(jsonTextReader, currentCollectionType);
                }
            }
        }

        /// <summary>
        /// Create the a new <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestUri">A string that represents the request System.Uri.</param>
        /// <param name="useAnyAuthenticationToken">Use the <see cref="AuthenticationToken"/> with the highest X-RateLimit-Remaining header value.</param>
        /// <returns>The customized 4me HTTP request message.</returns>
        private HttpRequestMessage CreateHttpRequest(HttpMethod httpMethod, string requestUri, bool useAnyAuthenticationToken = true)
        {
            HttpRequestMessage retval = new HttpRequestMessage(httpMethod, requestUri);
            if (useAnyAuthenticationToken || currentToken is null)
                currentToken = authenticationTokens.Get();
            retval.Headers.Authorization = new AuthenticationHeaderValue("Bearer", currentToken.Token);
            retval.Headers.Add("X-4me-Account", accountID);
            return retval;
        }

        /// <summary>
        /// Create an send an <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="requestMessage">The http request message.</param>
        /// <param name="content">The JSON data to send as http request content.</param>
        /// <returns>The <see cref="HttpRequestMessage"/> object.</returns>
        private HttpResponseMessage SendHttpRequest(HttpRequestMessage requestMessage, JObject content)
        {
            WriteDebug(requestMessage);
            HttpResponseMessage retval;

            Sleep.RegisterStartTime();

            if (content is null)
            {
                retval = client.Send(requestMessage);
            }
            else
            {
                string data = content.ToString(Formatting.None);

                if (traceEnabled)
                    WriteDebug(data);

                requestMessage.Content = new StringContent(data, Encoding.UTF8, applicationJsonMediaType);
                retval = client.Send(requestMessage);
            }

            if (!retval.IsSuccessStatusCode && retval.Content.Headers.ContentType.MediaType == applicationJsonMediaType)
            {
                using (StreamReader streamReader = new StreamReader(retval.Content.ReadAsStream()))
                    throw new Sdk4meException(streamReader.ReadToEnd());
            }

            UpdateAccountRateLimits(retval);
            Sleep.SleepRemainingTime();

            return retval;
        }

        /// <summary>
        /// Create an send an <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="requestMessage">The http request message.</param>
        /// <param name="item">The item to send as http request content.</param>
        /// <returns>The <see cref="HttpRequestMessage"/> object.</returns>
        private HttpResponseMessage SendHttpRequest(HttpRequestMessage requestMessage, T item = default)
        {
            WriteDebug(requestMessage);
            HttpResponseMessage retval;

            Sleep.RegisterStartTime();

            if (item is null)
            {
                retval = client.Send(requestMessage);
            }
            else
            {
                if (traceEnabled)
                {
                    using (StringWriter writer = new StringWriter())
                    {
                        serializer.Serialize(writer, item, currentType);
                        WriteDebug(writer.ToString());
                    }
                }

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (StreamWriter streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(false), 16384, true))
                    {
                        using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter) { Formatting = Formatting.None })
                        {
                            serializer.Serialize(jsonTextWriter, item, currentType);
                            jsonTextWriter.Flush();
                        }
                    }
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    HttpContent httpContent = new StreamContent(memoryStream);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue(applicationJsonMediaType);
                    requestMessage.Content = httpContent;

                    retval = client.Send(requestMessage);
                }
            }

            if (!retval.IsSuccessStatusCode && retval.Content.Headers.ContentType.MediaType == applicationJsonMediaType)
            {
                using (StreamReader streamReader = new StreamReader(retval.Content.ReadAsStream()))
                    throw new Sdk4meException(streamReader.ReadToEnd());
            }

            UpdateAccountRateLimits(retval);
            Sleep.SleepRemainingTime();

            return retval;
        }

        /// <summary>
        /// Updates the current token's rate limit information.
        /// </summary>
        /// <param name="responseMessage">The <see cref="HttpRequestMessage"/> reference.</param>
        private void UpdateAccountRateLimits(HttpResponseMessage responseMessage)
        {
            if (responseMessage != null)
            {
                currentToken.RequestLimit = Convert.ToInt32(responseMessage.Headers.GetValues("X-RateLimit-Limit").First());
                currentToken.RequestsRemaining = Convert.ToInt32(responseMessage.Headers.GetValues("X-RateLimit-Remaining").First());
                currentToken.RequestLimitReset = epochDateTimeMinValue.AddSeconds(Convert.ToInt64(responseMessage.Headers.GetValues("X-RateLimit-Reset").First())).ToLocalTime();
            }
        }

        /// <summary>
        /// Specify the attribute names that should be returned in the web response.
        /// </summary>
        /// <param name="fieldNames">An array of attributes names.</param>
        private void SetResponseFieldNames(string[] fieldNames)
        {
            if (fieldNames != null && fieldNames.Length > 0)
                responseFieldNames = fieldNames.Contains("*") ? allFieldNames : string.Join(",", fieldNames.To4meString());
            else
                responseFieldNames = null;
        }

        #endregion

        /// <summary>
        /// Writes a message to the trace listeners in the System.Diagnostics.Trace.Listeners collection.
        /// </summary>
        /// <param name="requestMessage">The debug http request message.</param>
        private void WriteDebug(HttpRequestMessage requestMessage)
        {
            try
            {
                if (traceEnabled)
                    Trace.WriteLine($"{requestMessage.Method} \"{requestMessage.RequestUri.AbsoluteUri}\"");
            }
            catch
            {
            }
        }

        /// <summary>
        /// Writes a message to the trace listeners in the System.Diagnostics.Trace.Listeners collection.
        /// </summary>
        /// <param name="message">The debug message.</param>
        private void WriteDebug(string message)
        {
            try
            {
                if (traceEnabled && !string.IsNullOrWhiteSpace(message))
                    Trace.WriteLine(message);
            }
            catch
            {
            }
        }
    }
}

#endif