using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me
{
    public class SiteHandler : BaseHandler<Site, PredefinedSiteFilter>
    {
        private const string qualityUrl = "https://api.4me.qa/v1/sites";
        private const string productionUrl = "https://api.4me.com/v1/sites";

        public SiteHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public SiteHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region people

        public List<Person> GetPeople(Site site, params string[] attributeNames)
        {
            DefaultHandler<Person> handler = new DefaultHandler<Person>($"{URL}/{site.ID}/people", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
