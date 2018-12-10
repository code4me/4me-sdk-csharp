using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceLevelAgreementHandler : BaseHandler<ServiceLevelAgreement>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/slas";
        private static readonly string productionUrl = "https://api.4me.com/v1/slas";

        public ServiceLevelAgreementHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceLevelAgreementHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region organizations

        public List<Organization> GetOrganizations(ServiceLevelAgreement serviceLevelAgreement, params string[] attributeNames)
        {
            BaseHandler<Organization> handler = new BaseHandler<Organization>($"{URL}/{serviceLevelAgreement.ID}/organizations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddOrganization(ServiceLevelAgreement serviceLevelAgreement, Organization organization)
        {
            return CreateRelation(serviceLevelAgreement, "organizations", organization);
        }

        public bool RemoveOrganization(ServiceLevelAgreement serviceLevelAgreement, Organization organization)
        {
            return DeleteRelation(serviceLevelAgreement, "organizations", organization);
        }

        public bool RemoveAllOrganizations(ServiceLevelAgreement serviceLevelAgreement)
        {
            return DeleteAllRelations(serviceLevelAgreement, "organizations");
        }

        #endregion

        #region people

        public List<Person> GetPeople(ServiceLevelAgreement serviceLevelAgreement, params string[] attributeNames)
        {
            BaseHandler<Person> handler = new BaseHandler<Person>($"{URL}/{serviceLevelAgreement.ID}/people", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddPerson(ServiceLevelAgreement serviceLevelAgreement, Person person)
        {
            return CreateRelation(serviceLevelAgreement, "people", person);
        }
    
        public bool RemovePerson(ServiceLevelAgreement serviceLevelAgreement, Person person)
        {
            return DeleteRelation(serviceLevelAgreement, "people", person);
        }

        public bool RemoveAllPeople(ServiceLevelAgreement serviceLevelAgreement)
        {
            return DeleteAllRelations(serviceLevelAgreement, "people");
        }

        #endregion

        #region sites

        public List<Site> GetSites(ServiceLevelAgreement serviceLevelAgreement, params string[] attributeNames)
        {
            BaseHandler<Site> handler = new BaseHandler<Site>($"{URL}/{serviceLevelAgreement.ID}/sites", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddSite(ServiceLevelAgreement serviceLevelAgreement, Site site)
        {
            return CreateRelation(serviceLevelAgreement, "sites", site);
        }

        public bool RemoveSite(ServiceLevelAgreement serviceLevelAgreement, Site site)
        {
            return DeleteRelation(serviceLevelAgreement, "sites", site);
        }

        public bool RemoveAllSites(ServiceLevelAgreement serviceLevelAgreement)
        {
            return DeleteAllRelations(serviceLevelAgreement, "sites");
        }

        #endregion

    }
}
