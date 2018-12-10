using System.Collections.Generic;

namespace Sdk4me
{
    public class BroadcastHandler : BaseHandler<Broadcast>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/broadcasts";
        private static readonly string productionUrl = "https://api.4me.com/v1/broadcasts";

        public BroadcastHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public BroadcastHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region service instances

        public List<ServiceInstance> GetServiceInstances(Broadcast broadcast, params string[] attributeNames)
        {
            BaseHandler<ServiceInstance> handler = new BaseHandler<ServiceInstance>($"{URL}/{broadcast.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region teams

        public List<Team> GetTeams(Broadcast broadcast, params string[] attributeNames)
        {
            BaseHandler<Team> handler = new BaseHandler<Team>($"{URL}/{broadcast.ID}/teams", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region translations

        public List<BroadcastTranslation> GetTranslations(Broadcast broadcast, params string[] attributeNames)
        {
            BaseHandler<BroadcastTranslation> handler = new BaseHandler<BroadcastTranslation>($"{URL}/{broadcast.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public BroadcastTranslation AddTranslation(Broadcast broadcast, BroadcastTranslation broadcastTranslation)
        {
            BaseHandler<BroadcastTranslation> handler = new BaseHandler<BroadcastTranslation>($"{URL}/{broadcast.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(broadcastTranslation);
        }

        public BroadcastTranslation UpdateTranslation(Broadcast broadcast, BroadcastTranslation broadcastTranslation)
        {
            BaseHandler<BroadcastTranslation> handler = new BaseHandler<BroadcastTranslation>($"{URL}/{broadcast.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(broadcastTranslation);
        }

        public bool DeleteTranslation(Broadcast broadcast, BroadcastTranslation broadcastTranslation)
        {
            BaseHandler<BroadcastTranslation> handler = new BaseHandler<BroadcastTranslation>($"{URL}/{broadcast.ID}/translations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(broadcastTranslation);
        }

        #endregion
    }
}
