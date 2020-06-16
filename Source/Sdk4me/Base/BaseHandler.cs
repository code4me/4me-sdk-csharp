using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

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
        /// <param name="accountID">The 4me account identifier, in case no accountID specified (null) it uses the account in which the token's identity exists.</param>
        /// <param name="itemsPerRequest">The amount of items returned in one requests.</param>
        /// <param name="maximumRecursiveRequests">The amount of recursive requests.</param>
        public BaseHandler(string apiURL, AuthenticationToken authenticationToken, string accountID = null, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
            : this(apiURL, new AuthenticationTokenCollection(authenticationToken), accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Creates a new instance of the 4me BaseHandler.
        /// </summary>
        /// <param name="apiURL">The 4me API URL to be used.</param>
        /// <param name="authenticationTokens">A collection of 4me authorization objects.</param>
        /// <param name="accountID">The 4me account identifier, in case no accountID specified (null) it uses the account in which the token's identity exists.</param>
        /// <param name="itemsPerRequest">The amount of items returned in one requests.</param>
        /// <param name="maximumRecursiveRequests">The amount of recursive requests.</param>
        public BaseHandler(string apiURL, AuthenticationTokenCollection authenticationTokens, string accountID = null, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
        {
            //SET GLOBAL VARIABLES
            this.url = apiURL;
            this.authenticationTokens = authenticationTokens;
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
            return Get(null, null, 1, this.maximumRecursiveRequests);
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
            return Get(Common.ConvertTo4mePredefinedFilter(predefinedFilter), null, 1, this.maximumRecursiveRequests);
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
            return Get(null, new FilterCollection() { filter }, 1, this.maximumRecursiveRequests);
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
            return Get(Common.ConvertTo4mePredefinedFilter(predefinedFilter), new FilterCollection() { filter }, 1, this.maximumRecursiveRequests);
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
            return Get(null, filters, 1, this.maximumRecursiveRequests);
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
            return Get(Common.ConvertTo4mePredefinedFilter(predefinedFilter), filters, 1, this.maximumRecursiveRequests);
        }

        /// <summary>
        /// Query the 4me web service.
        /// </summary>
        /// <param name="ID">The identifier of the object.</param>
        /// <returns>The object that matches the specified identifier.</returns>
        private T GetByIdentifier(long ID)
        {
            T retval = default;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}", url, ID);

            //WRITE DEBUG
            DebugWriteLine("GET", requestURL);

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
                    PauseTime("GET");

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
        /// <param name="page">The current page for the request.</param>
        /// <param name="recursiveRequestCount">The amount of recursive requests.</param>
        /// <returns>A collection of items with a maximum count of (page * requestCount).</returns>
        private List<T> Get(string predefinedFilter, FilterCollection filters, int page, int recursiveRequestCount)
        {
            List<T> retval = new List<T>();
            int totalRecords = 0;

            if (recursiveRequestCount == 0)
                return retval;

            //VALIDATE FILTERS
            if (filters == null)
                filters = new FilterCollection();

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}?page={1}&per_page={2}", url, page, itemsPerRequest);
            if (predefinedFilter != null)
                requestURL = string.Format("{0}/{1}?page={2}&per_page={3}", url, predefinedFilter, page, itemsPerRequest);
            if (responseSorting != SortOrder.None)
                requestURL += string.Format("&sort={0}", GetSortOrderStringValue(responseSorting));
            for (int i = 0; i < filters.Count; i++)
                requestURL += string.Format("&{0}", filters[i].GetFilter());
            if (responseAttributeNames != null)
                requestURL += string.Format("&fields={0}", responseAttributeNames);

            //WRITE DEBUG
            DebugWriteLine("GET", requestURL);

            //BUILD WEB REQUEST
            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "GET");
                RegisterTime();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.Headers["x-pagination-total-entries"] != null || alwaysAsList)
                    {
                        //GET TOTAL RECORDS
                        totalRecords = Convert.ToInt32(response.Headers["X-Pagination-Total-Entries"]);

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
                    PauseTime("GET");

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
            if (page * itemsPerRequest < totalRecords)
                retval.AddRange(Get(predefinedFilter, filters, page + 1, recursiveRequestCount - 1));

            //RETURN RESULT
            return retval;
        }

        internal List<SearchResult> Search(string text, params SearchType[] searchTypes)
        {
            //TODO: implement multi value on id's and enumerators for search and other types
            return Search(text, null, null, maximumRecursiveRequests, string.Join(",", Common.ConvertTo4meAttributeName(searchTypes)));
        }


        /// <summary>
        /// Use the search endpoint of the 4me web service.
        /// </summary>
        /// <param name="text">The text to search for.</param>
        /// <param name="onBehalfOf">Search on behalf of.</param>
        /// <param name="page">The page identifier value.</param>
        /// <param name="recursiveRequestCount">The amount of recursive requests.</param>
        /// <param name="searchTypes">Returns a list of search results.</param>
        /// <returns>A collection of search items.</returns>
        private List<SearchResult> Search(string text, string onBehalfOf, string page, int recursiveRequestCount, string types)
        {
            List<SearchResult> retval = new List<SearchResult>();
            string nextPage = null;

            //BUILD REQUEST URL
            string requestURL = url;
            if (string.IsNullOrWhiteSpace(page))
                requestURL += string.Format("?per_page={0}", itemsPerRequest);
            else
                requestURL += string.Format("?page={0}&per_page={1}", page, itemsPerRequest);
            requestURL += string.Format("&q={0}", Uri.EscapeDataString(text));
            if (!string.IsNullOrWhiteSpace(types))
                requestURL += string.Format("&types={0}", types);
            if (!string.IsNullOrWhiteSpace(onBehalfOf))
                requestURL += string.Format("&on_behalf_of={0}", onBehalfOf);

            //WRITE DEBUG
            DebugWriteLine("GET", requestURL);

            //BUILD WEB REQUEST
            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "GET", false);
                RegisterTime();

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    nextPage = response.Headers["X-Pagination-Next-Page"];

                    using (StreamReader responseStream = new StreamReader(response.GetResponseStream()))
                    {
                        using (JsonTextReader jsonTextReader = new JsonTextReader(responseStream))
                        {
                            retval.AddRange((List<SearchResult>)serializer.Deserialize(jsonTextReader, typeof(List<SearchResult>)));
                        }
                    }

                    //PAUSE AS 4ME ALLOWS ONLY 10 REQUEST PER SECOND
                    PauseTime("GET");
                }
            }
            catch (WebException ex)
            {
                throw ConvertWebException(ex);
            }

            if (recursiveRequestCount > 1 && !string.IsNullOrWhiteSpace(nextPage))
                retval.AddRange(Search(text, onBehalfOf, nextPage, recursiveRequestCount - 1, types));

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

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}", url, item.ID);

            //WRITE DEBUG
            DebugWriteLine("DELETE", requestURL);

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
                    PauseTime("DELETE");

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
        /// <returns>True in case of success otherwise false/</returns>
        public bool DeleteAll()
        {
            bool retval = false;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}", url);

            //WRITE DEBUG
            DebugWriteLine("DELETE", requestURL);

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
                    PauseTime("DELETE");
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
            //DEFINE DEFAULT VALUE
            T retval = default;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}", url);

            //WRITE DEBUG
            DebugWriteLine("POST", requestURL);

            //SHOULD SERIALIZE?
            if (!item.ShouldSendApiRequest())
            {
                DebugWriteLine("POST", "None of the attribute values changed, request canceled");
                return item;
            }

            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "POST");
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
                    PauseTime("POST");
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
            //DEFINE DEFAULT VALUE
            T retval = default;

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}", url, item.ID);

            //WRITE DEBUG
            DebugWriteLine("PATCH", requestURL);

            //SHOULD SERIALIZE?
            if (!item.ShouldSendApiRequest())
            {
                DebugWriteLine("PATCH", "None of the attribute values changed, request canceled");
                return item;
            }

            try
            {
                HttpWebRequest request = BuildWebRequest(requestURL, "PATCH");
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
                    PauseTime("PATCH");
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
            T retval = default;

            //BUILD REQUEST URL
            if (appendToURL.StartsWith("/"))
                appendToURL = appendToURL.Remove(0, 1);
            string requestURL = string.Format("{0}/{1}", url, appendToURL);

            //WRITE DEBUG
            DebugWriteLine(method, requestURL);

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
                    PauseTime(method);
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
            bool retval = false;

            if (string.IsNullOrWhiteSpace(relationObjectType))
            {
                DebugWriteLine("POST", "relationObjectType is null or blank.");
                return false;
            }

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}/{2}/{3}", url, item.ID, relationObjectType, relationItem.ID);

            //WRITE DEBUG
            DebugWriteLine("POST", requestURL);


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
                    PauseTime("POST");
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
            bool retval = false;

            if (string.IsNullOrWhiteSpace(relationObjectType))
            {
                DebugWriteLine("DELETE", "relationObjectType is null or blank.");
                return false;
            }

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}/{2}/{3}", url, item.ID, relationObjectType, relationItem.ID);

            //WRITE DEBUG
            DebugWriteLine("DELETE", requestURL);

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
                    PauseTime("DELETE");
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
            bool retval = false;

            if (string.IsNullOrWhiteSpace(relationObjectType))
            {
                DebugWriteLine("DELETE", "relationObjectType is null or blank.");
                return false;
            }

            //BUILD REQUEST URL
            string requestURL = string.Format("{0}/{1}/{2}", url, item.ID, relationObjectType);

            //WRITE DEBUG
            DebugWriteLine("DELETE", requestURL);


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
                    PauseTime("DELETE");
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.PreAuthenticate = true;
            if (useMultipleToken || currentToken == null)
                currentToken = this.authenticationTokens.Get();
            request.Headers["Authorization"] = currentToken?.BasicAuthenticationToken;
            request.ContentType = "application/json";
            request.Method = method;
            if (!string.IsNullOrWhiteSpace(accountID))
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
        private void PauseTime(string method)
        {
            int endTickCount = Environment.TickCount;

            //THE TICKCOUNTER JUMPED BACK TO Int32.MinValue
            if (endTickCount <= startTickCount)
            {
                DebugWriteLine(method, "Response time: unknown");
                System.Threading.Thread.Sleep(minimumDurationPerRequestInMiliseconds);
            }
            else
            {
                DebugWriteLine(method, $"Response time: {endTickCount - startTickCount} ms");
                int sleepTicks = minimumDurationPerRequestInMiliseconds - (endTickCount - startTickCount);
                if (sleepTicks > 0)
                {
                    DebugWriteLine(method, $"Force thread sleep: {sleepTicks} ms");
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
                    this.responseAttributeNames = allAttributeNames;
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
                return new Sdk4meException(ex.Message, webException);
            }
        }

        /// <summary>
        /// Converts a SortOrder value to string sorting value for the web request.
        /// </summary>
        /// <param name="sortOrder">The SortOrder value to be used.</param>
        private string GetSortOrderStringValue(SortOrder sortOrder)
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
        private void DebugWriteLine(string method, string message)
        {
            try
            {
                Debug.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff")}\t{method}\t{message}");
            }
            catch
            {

            }
        }
    }
}
