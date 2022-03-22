using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
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

        public MeHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : this(new AuthenticationTokenCollection(authenticationToken), accountID, environmentType, environmentRegion, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public MeHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
        {
            personHandler = new DefaultBaseHandler<Person>($"{EnvironmentURL.Get(environmentType, environmentRegion)}/me", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests);
            requestHandler = new DefaultBaseHandler<Request>($"{EnvironmentURL.Get(environmentType, environmentRegion)}/me/requested_by_or_for_me", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            myInboxHandler = new DefaultBaseHandler<InboxItem>($"{EnvironmentURL.Get(environmentType, environmentRegion)}/me/my_inbox", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            myTeamInboxHandler = new DefaultBaseHandler<InboxItem>($"{EnvironmentURL.Get(environmentType, environmentRegion)}/me/my_teams_inbox", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
        }

        public Person Get()
        {
            return personHandler.Get().FirstOrDefault();
        }

        public List<Request> RequestByOrForMe(params string[] fieldNames)
        {
            return requestHandler.Get(fieldNames);
        }

        public List<InboxItem> GetMyInbox()
        {
            return myInboxHandler.Get();
        }

        public List<InboxItem> GetMyTeamsInbox()
        {
            return myTeamInboxHandler.Get();
        }
    }
}
