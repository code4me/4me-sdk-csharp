using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceLevelAgreementHandler : BaseHandler<ServiceLevelAgreement, PredefinedActiveInactiveFilter>
    {
        public ServiceLevelAgreementHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/slas", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceLevelAgreementHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/slas", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Customer representatives

        public List<Person> GetCustomerRepresentatives(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Person>(serviceLevelAgreement, "customer_representatives").Get(fieldNames);
        }

        public bool AddCustomerRepresentative(ServiceLevelAgreement serviceLevelAgreement, Person customerRepresentatives)
        {
            return CreateRelation(serviceLevelAgreement, "customer_representatives", customerRepresentatives);
        }

        public bool RemoveCustomerRepresentative(ServiceLevelAgreement serviceLevelAgreement, Person customerRepresentatives)
        {
            return DeleteRelation(serviceLevelAgreement, "customer_representatives", customerRepresentatives);
        }

        public bool RemoveAllCustomerRepresentatives(ServiceLevelAgreement serviceLevelAgreement)
        {
            return DeleteAllRelations(serviceLevelAgreement, "customer_representatives");
        }

        #endregion

        #region Organizations

        public List<Organization> GetOrganizations(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(serviceLevelAgreement, "organizations").Get(fieldNames);
        }

        public List<Organization> GetOrganizations(PredefinedServiceLevelAgreementOrganizationFilter filter, ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(serviceLevelAgreement, $"organizations/{filter.To4meString()}").Get(fieldNames);
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

        #region People

        public List<Person> GetPeople(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Person>(serviceLevelAgreement, "people").Get(fieldNames);
        }

        public List<Person> GetPeople(PredefinedServiceLevelAgreementPeopleFilter filter, ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Person>(serviceLevelAgreement, $"people/{filter.To4meString()}").Get(fieldNames);
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

        #region Sites

        public List<Site> GetSites(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Site>(serviceLevelAgreement, "sites").Get(fieldNames);
        }

        public List<Site> GetSites(PredefinedEnabledDisabledFilter filter, ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Site>(serviceLevelAgreement, $"sites/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddSite(ServiceLevelAgreement serviceLevelAgreement, Site site)
        {
            return CreateRelation(serviceLevelAgreement, "sites", site);
        }

        public bool RemoveSite(ServiceLevelAgreement serviceLevelAgreement, Site Site)
        {
            return DeleteRelation(serviceLevelAgreement, "sites", Site);
        }

        public bool RemoveAllSites(ServiceLevelAgreement serviceLevelAgreement)
        {
            return DeleteAllRelations(serviceLevelAgreement, "sites");
        }

        #endregion

        #region Skill pools

        public List<SkillPool> GetSkillPools(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<SkillPool>(serviceLevelAgreement, "skill_pools").Get(fieldNames);
        }

        public List<SkillPool> GetSkillPools(PredefinedEnabledDisabledFilter filter, ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<SkillPool>(serviceLevelAgreement, $"skill_pools/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddSkillPool(ServiceLevelAgreement serviceLevelAgreement, SkillPool skillPool)
        {
            return CreateRelation(serviceLevelAgreement, "skill_pools", skillPool);
        }

        public bool RemoveSkillPool(ServiceLevelAgreement serviceLevelAgreement, SkillPool skillPool)
        {
            return DeleteRelation(serviceLevelAgreement, "skill_pools", skillPool);
        }

        public bool RemoveAllSkillPools(ServiceLevelAgreement serviceLevelAgreement)
        {
            return DeleteAllRelations(serviceLevelAgreement, "skill_pools");
        }

        #endregion
    }
}
