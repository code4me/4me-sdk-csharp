using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/people/me/">me</see> API endpoint.
    /// </summary>
    public class MeHandler : IBaseHandler
    {
        private readonly DefaultBaseHandler<Person> personHandler;
        private readonly DefaultBaseHandler<Request> requestHandler;
        private readonly DefaultBaseHandler<InboxItem> myInboxHandler;
        private readonly DefaultBaseHandler<InboxItem> myTeamInboxHandler;

        /// <summary>
        /// <para>Gets or sets the number of items returned in one request.</para>
        /// <para>The value must be at least 1 and maximum 100.</para>
        /// </summary>
        public int ItemsPerRequest
        {
            get => personHandler.ItemsPerRequest;
            set => personHandler.ItemsPerRequest = (value < 1 || value > 100) ? 25 : value;
        }

        /// <summary>
        /// <para>Gets or sets the number of recursive requests.</para>
        /// <para>The value must be at least 1 and maximum 1000.</para>
        /// </summary>
        public int MaximumRecursiveRequests
        {
            get => personHandler.MaximumRecursiveRequests;
            set => personHandler.MaximumRecursiveRequests = (value < 1 || value > 1000) ? 50 : value;
        }

        /// <summary>
        /// Create a new instance of the 4me me handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public MeHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : this(new AuthenticationTokenCollection(authenticationToken), accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me me handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public MeHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
        {
            personHandler = new DefaultBaseHandler<Person>($"{EnvironmentURL.Get(environment, environmentRegion)}/me", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests);
            requestHandler = new DefaultBaseHandler<Request>($"{EnvironmentURL.Get(environment, environmentRegion)}/me/requested_by_or_for_me", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            myInboxHandler = new DefaultBaseHandler<InboxItem>($"{EnvironmentURL.Get(environment, environmentRegion)}/me/my_inbox", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            myTeamInboxHandler = new DefaultBaseHandler<InboxItem>($"{EnvironmentURL.Get(environment, environmentRegion)}/me/my_teams_inbox", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
        }

        /// <summary>
        /// Get me.
        /// </summary>
        /// <returns></returns>
        public Person Get()
        {
            return personHandler.Get().FirstOrDefault();
        }

        /// <summary>
        /// Get all request by or for me.
        /// </summary>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of requests.</returns>
        public List<Request> RequestByOrForMe(params string[] fieldNames)
        {
            return requestHandler.Get(fieldNames);
        }

        /// <summary>
        /// Get my inbox.
        /// </summary>
        /// <returns>A collection of inbox items.</returns>
        public List<InboxItem> GetMyInbox()
        {
            return myInboxHandler.Get();
        }

        /// <summary>
        /// Get my teams inbox.
        /// </summary>
        /// <returns>A collection of inbox items.</returns>
        public List<InboxItem> GetMyTeamsInbox()
        {
            return myTeamInboxHandler.Get();
        }
    }
}
