using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class SiteHandler : BaseHandler<Site, PredefinedSiteFilter>
    {
        public SiteHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/sites", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public SiteHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/sites", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region People

        public List<Person> GetPeople(Site site, params string[] fieldNames)
        {
            return GetChildHandler<Person>(site, "people").Get(fieldNames);
        }

        public List<Person> GetPeople(PredefinedEnabledDisabledFilter filter, Site site, params string[] fieldNames)
        {
            return GetChildHandler<Person>(site, $"people/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service level agreement

        public List<ServiceLevelAgreement> GetServiceLevelAgreements(Site site, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(site, "slas").Get(fieldNames);
        }

        public List<ServiceLevelAgreement> GetServiceLevelAgreements(PredefinedActiveInactiveFilter filter, Site site, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(site, $"slas/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
