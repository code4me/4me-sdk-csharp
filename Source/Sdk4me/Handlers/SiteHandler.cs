using System.Collections.Generic;

namespace Sdk4me
{
    public class SiteHandler : BaseHandler<Site, PredefinedSiteFilter>
    {
        public SiteHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/sites", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public SiteHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/sites", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region people

        public List<Person> GetPeople(Site site, params string[] attributeNames)
        {
            DefaultHandler<Person> handler = new DefaultHandler<Person>($"{this.URL}/{site.ID}/people", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
