using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Sdk4me
{
    public class BaseHandler<T, X> : IBaseHandler where T : BaseItem, new() where X : Enum
    {
        private readonly string url = null;
        private readonly string allAttributeNames = null;
        private readonly JsonSerializer serializer = new JsonSerializer();
        private readonly int minimumDurationPerRequestInMiliseconds = 116;
        private readonly AuthenticationTokenCollection authenticationTokens = null;
        private readonly string accountID = null;
        private readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private AuthenticationToken currentToken = null;
        private string responseAttributeNames = null;
        private int itemsPerRequest = 100;
        private int maximumRecursiveRequests = 50;
        private SortOrder responseSorting = SortOrder.UpdatedAt;
        private bool alwaysAsList = false;
        private int startTickCount = 0;

        /// <summary>
        /// <para>Gets or sets the amount of items returned in one request.</para>
        /// <para>The value must be at least 1 and maximum 100.</para>
        /// </summary>
        public int ItemsPerRequest
        {
            get => itemsPerRequest;
            set => itemsPerRequest = (value < 1 || value > 100) ? 100 : value;
        }

        /// <summary>
        /// <para>Gets or sets the amount of recursive requests.</para>
        /// <para>The value must be at least 1 and maximum 1000.</para>
        /// </summary>
        public int MaximumRecursiveRequests
        {
            get => maximumRecursiveRequests;
            set => maximumRecursiveRequests = (value < 1 || value > 1000) ? 50 : value;
        }

        /// <summary>
        /// Force to parse the web response as a list.
        /// </summary>
        public bool AlwaysAsList
        {
            get => alwaysAsList;
            set => alwaysAsList = value;
        }

        /// <summary>
        /// Returns a collection of known the 4me authentication tokens.
        /// </summary>
        protected AuthenticationTokenCollection AuthenticationTokens
        {
            get => authenticationTokens;
        }

        /// <summary>
        /// Returns the 4me environment.
        /// </summary>
        protected string AccountID
        {
            get => accountID;
        }

        /// <summary>
        /// Returns the 4me API URL used.
        /// </summary>
        protected string URL
        {
            get => url;
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
        /// Creates a new instance of the 4me BaseHandler.
        /// </summary>
        /// <param name="apiURL">The 4me API URL to be used.</param>
        /// <param name="authenticationToken">The 4me authentication object.</param>
        /// <param name="accountID">The 4me account name.</param>
        /// <param name="itemsPerRequest">The amount of items returned in one requests.</param>
        /// <param name="maximumRecursiveRequests">The amount of recursive requests.</param>
        public BaseHandler(string apiURL, AuthenticationToken authenticationToken, string accountID, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
            : this(apiURL, new AuthenticationTokenCollection(authenticationToken), accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Creates a new instance of the 4me BaseHandler.
        /// </summary>
        /// <param name="apiURL">The 4me API URL to be used.</param>
        /// <param name="authenticationTokens">A collection of 4me authorization objects.</param>
        /// <param name="accountID">The 4me account name.</param>
        /// <param name="itemsPerRequest">The amount of items returned in one requests.</param>
        /// <param name="maximumRecursiveRequests">The amount of recursive requests.</param>
        public BaseHandler(string apiURL, AuthenticationTokenCollection authenticationTokens, string accountID, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
        {
            //VALIDATE STRING ARGUMENTS
            if (string.IsNullOrWhiteSpace(apiURL))
                throw new ArgumentException($"'{nameof(apiURL)}' cannot be null or whitespace.", nameof(apiURL));
            
            if (string.IsNullOrWhiteSpace(accountID))
                throw new ArgumentException($"'{nameof(accountID)}' cannot be null or whitespace.", nameof(accountID));
            
            if (!Uri.TryCreate(apiURL, UriKind.Absolute, out Uri uriResult) || uriResult.Scheme != Uri.UriSchemeHttps)
                throw new ArgumentException($"'{nameof(apiURL)}' is invalid.", nameof(apiURL));

            //SET GLOBAL VARIABLES
            this.url = apiURL;
            this.authenticationTokens = authenticationTokens ?? throw new ArgumentNullException(nameof(authenticationTokens));
            this.accountID = accountID;
            this.itemsPerRequest = (itemsPerRequest < 1 || itemsPerRequest > 100) ? 100 : itemsPerRequest;
            this.maximumRecursiveRequests = (maximumRecursiveRequests < 1 || maximumRecursiveRequests > 1000) ? 50 : maximumRecursiveRequests;

            //SET FIELD ATTRIBUTE (BASE ON ALL PROPERTIES OF T)
            this.allAttributeNames = (new T()).GetAllAttributeNames();

            //FORCE TLS 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="ID">The identifier of the object.</param>
        /// <returns>The object that matches the specified identifier.</returns>
        public T Get(long ID)
        {
            SetResponseAttributes(null);
            return GetByIdentifier(ID);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="attributeNames">An array of attributes names to be requested. If no attribute names are specified the default attributes will be returned. Use * to get all attribute values.</param>
        /// <returns>A collection of objects.</returns>
        public List<T> Get(params string[] attributeNames)
        {
            SetResponseAttributes(attributeNames);
            return Get(null, null, null, this.maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="predefinedFilter">A predefined filter value.</param>
        /// <param name="attributeNames">An array of attributes names to be requested. If no attribute names are specified the default attributes will be returned. Use * to get all attribute values.</param>
        /// <returns>A collection of objects.</returns>
        public List<T> Get(X predefinedFilter, params string[] attributeNames)
        {
            SetResponseAttributes(attributeNames);
            return Get(Common.ConvertTo4mePredefinedFilter(predefinedFilter), null, null, this.maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="filter">The filter for the request.</param>
        /// <param name="attributeNames">An array of attributes names to be requested. If no attribute names are specified the default attributes will be returned. Use * to get all attribute values.</param>
        /// <returns>A collection of objects.</returns>
        public List<T> Get(Filter filter, params string[] attributeNames)
        {
            SetResponseAttributes(attributeNames);
            return Get(null, new FilterCollection() { filter }, null, this.maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="predefinedFilter">A predefined filter value.</param>
        /// <param name="filter">The filter for the request.</param>
        /// <param name="attributeNames">An array of attributes names to be requested. If no attribute names are specified the default attributes will be returned. Use * to get all attribute values.</param>
        /// <returns>A collection of objects.</returns>
        public List<T> Get(X predefinedFilter, Filter filter, params string[] attributeNames)
        {
            SetResponseAttributes(attributeNames);
            return Get(Common.ConvertTo4mePredefinedFilter(predefinedFilter), new FilterCollection() { filter }, null, this.maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="filters">The filters for the request.</param>
        /// <param name="attributeNames">An array of attributes names to be requested. If no attribute names are specified the default attributes will be returned. Use * to get all attribute values.</param>
        /// <returns>A collection of objects.</returns>
        public List<T> Get(FilterCollection filters, params string[] attributeNames)
        {
            SetResponseAttributes(attributeNames);
            return Get(null, filters, null, this.maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="predefinedFilter">A predefined filter value.</param>
        /// <param name="filters">The filters for the request.</param>
        /// <param name="attributeNames">An array of attributes names to be requested. If no attribute names are specified the default attributes will be returned. Use * to get all attribute values.</param>
        /// <returns>A collection of objects.</returns>
        public List<T> Get(X predefinedFilter, FilterCollection filters, params string[] attributeNames)
        {
            SetResponseAttributes(attributeNames);
            return Get(Common.ConvertTo4mePredefinedFilter(predefinedFilter), filters, null, this.maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="ID">The identifier of the object.</param>
        /// <returns>The object that matches the specified identifier.</returns>
        private T GetByIdentifier(long ID)
        {
            //SET DEFAULT VALUE
            T retval = default;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}", url, ID);

            //BUILD WEB REQUEST
            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "GET");
                RegisterTime();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //SINGLE RECORD
                    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                    {
                        using (JsonTextReader jsonTextReader = new JsonTextReader(stream))
                        {
                            retval = (T)serializer.Deserialize(jsonTextReader, typeof(T));
                        }
                    }

                    //STORE TOKEN INFORMATION
                    SetCurrentTokenValues(response.Headers);

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    Sleep();

                    //RESET INCLUDED DURING SERIALIZATION
                    retval.ResetIncludedDuringSerialization();
                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            //RETURN RESULT
            return retval;
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="predefinedFilter">A predefined filter value.</param>
        /// <param name="filters">The filters used during the request.</param>
        /// <param name="nextPageUrl">The 'next page' URL. This should always be null; unless it is a recursive call.</param>
        /// <param name="recursiveRequestCount">The amount of recursive requests.</param>
        /// <returns>The 4me web service query result set.</returns>
        private List<T> Get(string predefinedFilter, FilterCollection filters, string nextPageUrl, int recursiveRequestCount)
        {
            List<T> retval = new List<T>();

            if (recursiveRequestCount == 0)
                return retval;

            //BUILD REQUEST URL
            if (nextPageUrl == null)
            {
                //VALIDATE FILTERS
                if (filters is null)
                    filters = new FilterCollection();

                nextPageUrl = string.Format("{0}?per_page={1}", this.url, itemsPerRequest);
                if (predefinedFilter != null)
                    nextPageUrl = string.Format("{0}/{1}?per_page={2}", this.url, predefinedFilter, itemsPerRequest);
                if (responseSorting != SortOrder.None)
                    nextPageUrl += string.Format("&sort={0}", GetSortOrderStringValue(responseSorting));
                for (int i = 0; i < filters.Count; i++)
                    nextPageUrl += string.Format("&{0}", filters[i].GetFilter());
                if (responseAttributeNames != null)
                    nextPageUrl += string.Format("&fields={0}", responseAttributeNames);
            }

            //BUILD WEB REQUEST
            try
            {
                HttpWebRequest request = BuildWebRequest(nextPageUrl, "GET");
                RegisterTime();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.Headers["x-pagination-total-entries"] != null || this.alwaysAsList)
                    {
                        //GET NEXT URL FROM LINK HEADER
                        nextPageUrl = LinkHeader.LinksFromHeader(response.Headers["Link"]).NextLink;

                        //MULTIPLE RECORDS
                        using (StreamReader responseStream = new StreamReader(response.GetResponseStream()))
                        {
                            using (JsonTextReader jsonTextReader = new JsonTextReader(responseStream))
                            {
                                retval.AddRange((List<T>)serializer.Deserialize(jsonTextReader, typeof(List<T>)));
                            }
                        }
                    }
                    else
                    {
                        //SET NEXT URL
                        nextPageUrl = null;

                        //SINGLE RECORD
                        using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                        {
                            using (JsonTextReader jsonTextReader = new JsonTextReader(stream))
                            {
                                retval.Add((T)serializer.Deserialize(jsonTextReader, typeof(T)));
                            }
                        }
                    }

                    //STORE TOKEN INFORMATION
                    SetCurrentTokenValues(response.Headers);

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    Sleep();

                    //RESET INCLUDED DURING SERIALIZATION
                    for (int i = 0; i < retval.Count; i++)
                        retval[i].ResetIncludedDuringSerialization();
                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            //CONTINUE NEXT REQUEST CYCLE
            if (nextPageUrl != null)
                retval.AddRange(Get(predefinedFilter, filters, nextPageUrl, recursiveRequestCount - 1));

            //RETURN RESULT
            return retval;
        }

        /// <summary>
        /// Use the search endpoint of the 4me web service. 
        /// </summary>
        /// <param name="text">The text to search for.</param>
        /// <param name="onBehalfOf">Search on behalf of.</param>
        /// <param name="searchTypes">Returns a list of search results.</param>
        /// <returns>A collection of search items.</returns>
        internal List<SearchResult> Search(string text, Person onBehalfOf = null, params SearchType[] searchTypes)
        {
            return Search(text, onBehalfOf, null, maximumRecursiveRequests, string.Join(",", Common.ConvertTo4meAttributeName(searchTypes)));
        }

        /// <summary>
        /// Use the search endpoint of the 4me web service.
        /// </summary>
        /// <param name="text">The text to search for.</param>
        /// <param name="onBehalfOf">Search on behalf of.</param>
        /// <param name="nextPageUrl">The 'next page' URL. This should always be null; unless it is a recursive call.</param>
        /// <param name="recursiveRequestCount">The amount of recursive requests.</param>
        /// <param name="searchTypes">Returns a list of search results.</param>
        /// <returns>A collection of search items.</returns>
        private List<SearchResult> Search(string text, Person onBehalfOf, string nextPageUrl, int recursiveRequestCount, string types)
        {
            List<SearchResult> retval = new List<SearchResult>();

            //VALIDATE
            if (string.IsNullOrWhiteSpace(text))
                throw new NullReferenceException(nameof(text));

            //BUILD REQUEST URL
            if (nextPageUrl == null)
            {
                nextPageUrl = string.Format("{0}?per_page={1}", url, itemsPerRequest);
                nextPageUrl += string.Format("&q={0}", Uri.EscapeDataString(text));
                if (!string.IsNullOrWhiteSpace(types))
                    nextPageUrl += string.Format("&types={0}", types);
                if (onBehalfOf != null)
                    nextPageUrl += string.Format("&on_behalf={0}", onBehalfOf.ID);
            }

            //BUILD WEB REQUEST
            try
            {
                HttpWebRequest request = BuildWebRequest(nextPageUrl, "GET", false);
                RegisterTime();

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    nextPageUrl = LinkHeader.LinksFromHeader(response.Headers["Link"]).NextLink;

                    using (StreamReader responseStream = new StreamReader(response.GetResponseStream()))
                    {
                        using (JsonTextReader jsonTextReader = new JsonTextReader(responseStream))
                        {
                            retval.AddRange((List<SearchResult>)serializer.Deserialize(jsonTextReader, typeof(List<SearchResult>)));
                        }
                    }

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    Sleep();
                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            if (nextPageUrl != null && recursiveRequestCount > 1)
                retval.AddRange(Search(text, onBehalfOf, nextPageUrl, recursiveRequestCount - 1, types));

            //RETURN RESULT
            return retval;
        }

        /// <summary>
        /// Delete an object in 4me.
        /// </summary>
        /// <param name="item">The object to delete.</param>
        /// <returns>True in case of success otherwise false/</returns>
        public bool Delete(T item)
        {
            bool retval = false;

            //IS NULL
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}", url, item.ID);
            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "DELETE");
                RegisterTime();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //GET RESPONSE
                    retval = response.StatusCode == HttpStatusCode.NoContent;

                    //STORE TOKEN INFORMATION
                    SetCurrentTokenValues(response.Headers);

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    Sleep();

                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            return retval;
        }

        /// <summary>
        /// Delete all objects in 4me.
        /// </summary>
        /// <returns>True in case of success otherwise false.</returns>
        public bool DeleteAll()
        {
            bool retval = false;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}", url);

            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "DELETE");
                RegisterTime();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //GET RESPONSE
                    retval = response.StatusCode == HttpStatusCode.NoContent;

                    //STORE TOKEN INFORMATION
                    SetCurrentTokenValues(response.Headers);

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    Sleep();
                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            return retval;
        }

        /// <summary>
        /// Insert a new object in 4me.
        /// </summary>
        /// <param name="item">The object to create.</param>
        /// <returns>A new instance of the created object.</returns>
        public T Insert(T item)
        {
            //IS NULL
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            //SHOULD SERIALIZE?
            if (!item.ShouldSendApiRequest())
            {
                DebugWriteLine("POST", "None of the attribute values changed, request canceled");
                return item;
            }

            //SET DEFAULT VALUE
            T retval = default;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}", url);
            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "POST");
                request.ContentType = "application/json";
                item.RemoveIdentifierDuringSerialization();
                serializer.ContractResolver = new Sdk4meContractResolver(item.IncludeDuringSerialization);
                RegisterTime();

                //WRITE CONTENT
                using (StreamWriter requestStream = new StreamWriter(request.GetRequestStream()))
                {
                    using (JsonTextWriter jsonTextWriter = new JsonTextWriter(requestStream))
                    {
                        serializer.Serialize(jsonTextWriter, item, typeof(T));
                    }
                }

                //READ CONTENT
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //SINGLE RECORD
                    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                    {
                        using (JsonTextReader jsonTextReader = new JsonTextReader(stream))
                        {
                            retval = (T)serializer.Deserialize(jsonTextReader, typeof(T));
                        }
                    }

                    //STORE TOKEN INFORMATION
                    SetCurrentTokenValues(response.Headers);

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    Sleep();
                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            retval?.ResetIncludedDuringSerialization();
            return retval;
        }

        /// <summary>
        /// Update an object in 4me.
        /// </summary>
        /// <param name="item">The object to be updated.</param>
        /// <returns>A new instance of the updated object.</returns>
        public T Update(T item)
        {
            //IS NULL
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            //SHOULD SERIALIZE?
            if (!item.ShouldSendApiRequest())
            {
                DebugWriteLine("PATCH", "None of the attribute values changed, request canceled");
                return item;
            }

            //SET DEFAULT VALUE
            T retval = default;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}", url, item.ID);

            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "PATCH");
                request.ContentType = "application/json";
                item.IncludeIdentifierDuringSerialization();
                serializer.ContractResolver = new Sdk4meContractResolver(item.IncludeDuringSerialization);
                RegisterTime();

                //WRITE CONTENT
                using (StreamWriter requestStream = new StreamWriter(request.GetRequestStream()))
                {
                    using (JsonTextWriter jsonTextWriter = new JsonTextWriter(requestStream))
                    {
                        serializer.Serialize(jsonTextWriter, item, typeof(T));
                    }
                }

                //GET CONTENT
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //SINGLE RECORD
                    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                    {
                        using (JsonTextReader jsonTextReader = new JsonTextReader(stream))
                        {
                            retval = (T)serializer.Deserialize(jsonTextReader, typeof(T));
                        }
                    }

                    //STORE TOKEN INFORMATION
                    SetCurrentTokenValues(response.Headers);

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    Sleep();
                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            retval?.ResetIncludedDuringSerialization();
            return retval;
        }

        /// <summary>
        /// A custom web request without request data.
        /// </summary>
        /// <param name="appendToURL">An addition to the 4me API URL value specified during object handler creation.</param>
        /// <param name="method">The protocol method used in the web request.</param>
        /// <returns>A new object instance based upon the response.</returns>
        internal T CustomWebRequest(string appendToURL, string method)
        {
            //SET DEFAULT VALUE
            T retval = default;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}", url.TrimEnd('/'), appendToURL.TrimEnd('/'));
            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, method);
                RegisterTime();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //SINGLE RECORD
                    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                    {
                        using (JsonTextReader jsonTextReader = new JsonTextReader(stream))
                        {
                            retval = (T)serializer.Deserialize(jsonTextReader, typeof(T));
                        }
                    }

                    //STORE TOKEN INFORMATION
                    SetCurrentTokenValues(response.Headers);

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    Sleep();
                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            retval?.ResetIncludedDuringSerialization();
            return retval;
        }

        /// <summary>
        /// Create a relation between 2 objects.
        /// </summary>
        /// <param name="item">The item to create the relation for.</param>
        /// <param name="relationObjectType">The object type (4me name) of the relation.</param>
        /// <param name="relationItem">The identifier of the object type of the relation.</param>
        /// <returns>True in case of success, otherwise false.</returns>
        protected bool CreateRelation(T item, string relationObjectType, BaseItem relationItem)
        {
            if (string.IsNullOrWhiteSpace(relationObjectType))
                throw new ArgumentException($"'{nameof(relationObjectType)}' cannot be null or whitespace.", nameof(relationObjectType));

            bool retval = false;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}/{2}/{3}", url, item.ID, relationObjectType, relationItem.ID);
            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "POST");
                RegisterTime();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //GET RESPONSE
                    retval = response.StatusCode == HttpStatusCode.OK;

                    //STORE TOKEN INFORMATION
                    SetCurrentTokenValues(response.Headers);

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    Sleep();
                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            return retval;
        }

        /// <summary>
        /// Delete a relation between two objects.
        /// </summary>
        /// <param name="item">The item to delete the relation from.</param>
        /// <param name="relationObjectType">The object type (4me name) of the relation.</param>
        /// <param name="relationObjectIdentifier">The identifier of the object type of the relations, or null to delete all relations for the specified object type.</param>
        /// <returns>True in case of success, otherwise false.</returns>
        protected bool DeleteRelation(T item, string relationObjectType, BaseItem relationItem)
        {
            //IS NULL OR WHITESPACE
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (relationItem is null)
                throw new ArgumentNullException(nameof(relationItem));
            if (string.IsNullOrWhiteSpace(relationObjectType))
                throw new ArgumentException($"'{nameof(relationObjectType)}' cannot be null or whitespace.", nameof(relationObjectType));

            bool retval = false;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}/{2}/{3}", url, item.ID, relationObjectType, relationItem.ID);
            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "DELETE");
                RegisterTime();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //GET RESPONSE
                    retval = response.StatusCode == HttpStatusCode.NoContent;

                    //STORE TOKEN INFORMATION
                    SetCurrentTokenValues(response.Headers);

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    Sleep();
                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            return retval;
        }

        /// <summary>
        /// Delete all relations from the object.
        /// </summary>
        /// <param name="item">The item to delete the relation from.</param>
        /// <param name="relationObjectType">The object type (4me name) of the relation.</param>
        /// <returns>True in case of success, otherwise false.</returns>
        protected bool DeleteAllRelations(T item, string relationObjectType)
        {
            //IS NULL OR WHITESPACE
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrWhiteSpace(relationObjectType))
                throw new ArgumentException($"'{nameof(relationObjectType)}' cannot be null or whitespace.", nameof(relationObjectType));

            bool retval = false;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}/{2}", url, item.ID, relationObjectType);
            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "DELETE");
                RegisterTime();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //GET RESPONSE
                    retval = response.StatusCode == HttpStatusCode.NoContent;

                    //STORE TOKEN INFORMATION
                    SetCurrentTokenValues(response.Headers);

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    Sleep();
                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            return retval;
        }

        /// <summary>
        /// Create a WebRequest object.
        /// </summary>
        /// <param name="requestUrl">The 4me API URL to be used.</param>
        /// <param name="method">The protocol method used in the web request.</param>
        /// <returns>A HttpWebRequest.</returns>
        private HttpWebRequest BuildWebRequest(string requestUrl, string method, bool useMultipleToken = true)
        {
            DebugWriteLine(method, requestUrl);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.PreAuthenticate = true;
            if (useMultipleToken || this.currentToken == null)
                this.currentToken = this.authenticationTokens.Get();
            request.Headers["Authorization"] = this.currentToken?.Token;
            request.Method = method;
            if (!string.IsNullOrWhiteSpace(this.accountID))
                request.Headers["X-4me-Account"] = this.accountID;
            return request;
        }

        /// <summary>
        /// Saves the current the web header value "x-ratelimit-limit", "x-ratelimit-remaining" and "X-RateLimit-Reset" to the currently used token.
        /// </summary>
        /// <param name="webHeaders"></param>
        private void SetCurrentTokenValues(WebHeaderCollection webHeaders)
        {
            currentToken.RequestLimit = Convert.ToInt32(webHeaders["x-ratelimit-limit"]);
            currentToken.RequestsRemaining = Convert.ToInt32(webHeaders["x-ratelimit-remaining"]);
            currentToken.RequestLimitReset = epoch.AddSeconds(Convert.ToInt64(webHeaders["X-RateLimit-Reset"])).ToLocalTime();
            currentToken.UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Stores the current Environment.TickCount value.
        /// </summary>
        private void RegisterTime()
        {
            startTickCount = Environment.TickCount;
        }

        /// <summary>
        /// Puts the current thread in sleep for 116 milliseconds minus the elapsed milliseconds between now an the value stored via the RegisterStartTime method.
        /// <param name="method">The name of the method calling the PauseTime method. This information will be written to the trace listeners in the Listeners collection.</param>
        /// </summary>
        private void Sleep()
        {
            int endTickCount = Environment.TickCount;

            //THE TICKCOUNTER JUMPED BACK TO Int32.MinValue
            if (endTickCount <= this.startTickCount)
            {
                DebugWriteLine("", "Response time: unknown");
                System.Threading.Thread.Sleep(minimumDurationPerRequestInMiliseconds);
            }
            else
            {
                DebugWriteLine("", $"Response time: {endTickCount - this.startTickCount} ms");
                int sleepTicks = minimumDurationPerRequestInMiliseconds - (endTickCount - this.startTickCount);
                if (sleepTicks > 0)
                {
                    DebugWriteLine("", $"Force thread sleep: {sleepTicks} ms");
                    System.Threading.Thread.Sleep(sleepTicks);
                }
            }
        }

        /// <summary>
        /// Specify the attribute names that should be returned in the web response.
        /// </summary>
        /// <param name="attributeNames">An array of attributes names.</param>
        private void SetResponseAttributes(string[] attributeNames)
        {
            //USE PROVIDED ATTRIBUTE NAMES (IF NOT NULL OR EMTPY ARRA)
            if (attributeNames != null && attributeNames.GetUpperBound(0) > -1)
            {
                //* = ALL ATTRIBUTES
                if (Array.IndexOf(attributeNames, "*") > -1)
                    this.responseAttributeNames = this.allAttributeNames;
                else
                    this.responseAttributeNames = string.Join(",", Common.ConvertTo4meAttributeNames(attributeNames));
            }
            else
            {
                this.responseAttributeNames = null;
            }
        }

        /// <summary>
        /// Returns an exception based on the WebException response stream.
        /// </summary>
        /// <param name="webException">The WebException to read from.</param>
        /// <returns>An exception.</returns>
        private Sdk4meException ConvertWebException(WebException webException)
        {
            try
            {
                using (StreamReader stream = new StreamReader(webException.Response.GetResponseStream()))
                {
                    using (JsonTextReader jsonTextReader = new JsonTextReader(stream))
                    {
                        WebResponseException exception = (WebResponseException)serializer.Deserialize(jsonTextReader, typeof(WebResponseException));
                        return new Sdk4meException(exception.Message, exception.Errors, webException);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Sdk4meException(webException.Message ?? ex.Message ?? "", webException);
            }
        }

        /// <summary>
        /// Converts a SortOrder value to string sorting value for the web request.
        /// </summary>
        /// <param name="sortOrder">The SortOrder value to be used.</param>
        private static string GetSortOrderStringValue(SortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.ID:
                    return "id";

                case SortOrder.CreatedAt:
                    return "created_at";

                case SortOrder.CreatedAtAndID:
                    return "created_at,id";

                case SortOrder.UpdatedAt:
                    return "updated_at";

                case SortOrder.UpdatedAtAndID:
                    return "updated_at,id";

                default:
                    return "";
            }
        }

        /// <summary>
        /// Writes debug information to the trace listeners in the Listeners collection.
        /// </summary>
        /// <param name="method">The method invoked.</param>
        /// <param name="message">The output message.</param>
        private static void DebugWriteLine(string method, string message)
        {
            try
            {
                Debug.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}\t{method}\t{message}");
            }
            catch
            {

            }
        }
    }
}
