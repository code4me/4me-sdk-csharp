using System.Collections.Generic;

namespace Sdk4me
{
    public class BroadcastHandler : BaseHandler<Broadcast, PredefinedBroadcastFilter>
    {
        public BroadcastHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/broadcasts", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public BroadcastHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/broadcasts", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region service instances

        public List<ServiceInstance> GetServiceInstances(Broadcast broadcast, params string[] attributeNames)
        {
            DefaultHandler<ServiceInstance> handler = new DefaultHandler<ServiceInstance>($"{URL}/{broadcast.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region teams

        public List<Team> GetTeams(Broadcast broadcast, params string[] attributeNames)
        {
            DefaultHandler<Team> handler = new DefaultHandler<Team>($"{URL}/{broadcast.ID}/teams", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region translations

        public List<BroadcastTranslation> GetTranslations(Broadcast broadcast, params string[] attributeNames)
        {
            DefaultHandler<BroadcastTranslation> handler = new DefaultHandler<BroadcastTranslation>($"{URL}/{broadcast.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public BroadcastTranslation AddTranslation(Broadcast broadcast, BroadcastTranslation broadcastTranslation)
        {
            DefaultHandler<BroadcastTranslation> handler = new DefaultHandler<BroadcastTranslation>($"{URL}/{broadcast.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(broadcastTranslation);
        }

        public BroadcastTranslation UpdateTranslation(Broadcast broadcast, BroadcastTranslation broadcastTranslation)
        {
            DefaultHandler<BroadcastTranslation> handler = new DefaultHandler<BroadcastTranslation>($"{URL}/{broadcast.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(broadcastTranslation);
        }

        public bool DeleteTranslation(Broadcast broadcast, BroadcastTranslation broadcastTranslation)
        {
            DefaultHandler<BroadcastTranslation> handler = new DefaultHandler<BroadcastTranslation>($"{URL}/{broadcast.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(broadcastTranslation);
        }

        #endregion
    }
}
