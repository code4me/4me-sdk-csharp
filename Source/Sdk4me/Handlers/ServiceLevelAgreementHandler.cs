using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/service_level_agreements/">service level agreement</see> API endpoint.
    /// </summary>
    public class ServiceLevelAgreementHandler : BaseHandler<ServiceLevelAgreement, PredefinedActiveInactiveFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me service level agreement handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceLevelAgreementHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/slas", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me service level agreement handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceLevelAgreementHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/slas", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Customer representatives

        /// <summary>
        /// Get all customer representatives.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetCustomerRepresentatives(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Person>(serviceLevelAgreement, "customer_representatives").Get(fieldNames);
        }

        /// <summary>
        /// Add a customer representative.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="customerRepresentatives">The customer representative to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddCustomerRepresentative(ServiceLevelAgreement serviceLevelAgreement, Person customerRepresentatives)
        {
            return CreateRelation(serviceLevelAgreement, "customer_representatives", customerRepresentatives);
        }

        /// <summary>
        /// Remove a customer representative.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="customerRepresentatives">The customer representative to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveCustomerRepresentative(ServiceLevelAgreement serviceLevelAgreement, Person customerRepresentatives)
        {
            return DeleteRelation(serviceLevelAgreement, "customer_representatives", customerRepresentatives);
        }

        /// <summary>
        /// Remove all customer representatives.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllCustomerRepresentatives(ServiceLevelAgreement serviceLevelAgreement)
        {
            return DeleteAllRelations(serviceLevelAgreement, "customer_representatives");
        }

        #endregion

        #region Effort class rate ID

        /// <summary>
        /// Get all related effort class rate IDs.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of effort class rate IDs.</returns>
        public List<EffortClassRateID> GetEffortClassRateIDs(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<EffortClassRateID>(serviceLevelAgreement, "effort_class_rateIDs", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add an effort class charge ID.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="effortClassRateID">The effort class rate ID to add.</param>
        /// <returns>The updated effort class charge ID.</returns>
        public EffortClassRateID AddEffortClassRateID(ServiceLevelAgreement serviceLevelAgreement, EffortClassRateID effortClassRateID)
        {
            return GetChildHandler<EffortClassRateID>(serviceLevelAgreement, "effort_class_rateIDs").Insert(effortClassRateID);
        }

        /// <summary>
        /// Update an effort class charge ID.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="effortClassRateID">The effort class rate ID to update.</param>
        /// <returns>The updated effort class charge ID.</returns>
        public EffortClassRateID UpdateEffortClassRateID(ServiceLevelAgreement serviceLevelAgreement, EffortClassRateID effortClassRateID)
        {
            return GetChildHandler<EffortClassRateID>(serviceLevelAgreement, "effort_class_rateIDs").Update(effortClassRateID);
        }

        /// <summary>
        /// Delete an effort class charge ID.
        /// </summary>
        /// <param name="serviceLevelAgreement">The person.</param>
        /// <param name="effortClassRateID">The effort class rate ID to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteEffortClassRateID(ServiceLevelAgreement serviceLevelAgreement, EffortClassRateID effortClassRateID)
        {
            return GetChildHandler<EffortClassRateID>(serviceLevelAgreement, "effort_class_rateIDs").Delete(effortClassRateID);
        }

        #endregion

        #region Organizations

        /// <summary>
        /// Get all related organizations.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Organization> GetOrganizations(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(serviceLevelAgreement, "organizations").Get(fieldNames);
        }

        /// <summary>
        /// Get all related organizations.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Organization> GetOrganizations(PredefinedServiceLevelAgreementOrganizationFilter filter, ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(serviceLevelAgreement, $"organizations/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add an organization.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="organization">The organization to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddOrganization(ServiceLevelAgreement serviceLevelAgreement, Organization organization)
        {
            return CreateRelation(serviceLevelAgreement, "organizations", organization);
        }

        /// <summary>
        /// Remove an organization.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="organization">The organization to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveOrganization(ServiceLevelAgreement serviceLevelAgreement, Organization organization)
        {
            return DeleteRelation(serviceLevelAgreement, "organizations", organization);
        }

        /// <summary>
        /// Remove all organizations.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllOrganizations(ServiceLevelAgreement serviceLevelAgreement)
        {
            return DeleteAllRelations(serviceLevelAgreement, "organizations");
        }

        #endregion

        #region People

        /// <summary>
        /// Get all people.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetPeople(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Person>(serviceLevelAgreement, "people").Get(fieldNames);
        }

        /// <summary>
        /// Get all people.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetPeople(PredefinedServiceLevelAgreementPeopleFilter filter, ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Person>(serviceLevelAgreement, $"people/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a person.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="person">The person to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddPerson(ServiceLevelAgreement serviceLevelAgreement, Person person)
        {
            return CreateRelation(serviceLevelAgreement, "people", person);
        }

        /// <summary>
        /// Remove a person.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="person">The person to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemovePerson(ServiceLevelAgreement serviceLevelAgreement, Person person)
        {
            return DeleteRelation(serviceLevelAgreement, "people", person);
        }

        /// <summary>
        /// Remove all people.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllPeople(ServiceLevelAgreement serviceLevelAgreement)
        {
            return DeleteAllRelations(serviceLevelAgreement, "people");
        }

        #endregion

        #region service instances

        /// <summary>
        /// Get all parent service instances of a service level agreement.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<ServiceLevelAgreementServiceInstanceRelation> GetServiceInstances(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreementServiceInstanceRelation>(serviceLevelAgreement, "service_instances").Get(fieldNames);
        }

        /// <summary>
        /// Add a service instance relation.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="serviceLevelAgreementServiceInstanceRelation">The service instance relation.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public ServiceLevelAgreementServiceInstanceRelation AddServiceInstance(ServiceLevelAgreement serviceLevelAgreement, ServiceLevelAgreementServiceInstanceRelation serviceLevelAgreementServiceInstanceRelation)
        {
            return GetChildHandler<ServiceLevelAgreementServiceInstanceRelation>(serviceLevelAgreement, "service_instances").Insert(serviceLevelAgreementServiceInstanceRelation);
        }

        /// <summary>
        /// Update a service instance relation.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="serviceLevelAgreementServiceInstanceRelation">The service instance relation.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public ServiceLevelAgreementServiceInstanceRelation UpdateServiceInstance(ServiceLevelAgreement serviceLevelAgreement, ServiceLevelAgreementServiceInstanceRelation serviceLevelAgreementServiceInstanceRelation)
        {
            return GetChildHandler<ServiceLevelAgreementServiceInstanceRelation>(serviceLevelAgreement, "service_instances").Update(serviceLevelAgreementServiceInstanceRelation);
        }

        /// <summary>
        /// Delete a service instance relation.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="serviceLevelAgreementServiceInstanceRelation">The service instance relation.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteServiceInstance(ServiceLevelAgreement serviceLevelAgreement, ServiceLevelAgreementServiceInstanceRelation serviceLevelAgreementServiceInstanceRelation)
        {
            return GetChildHandler<ServiceLevelAgreementServiceInstanceRelation>(serviceLevelAgreement, "service_instances").Delete(serviceLevelAgreementServiceInstanceRelation);
        }

        /// <summary>
        /// Delete all service instance relations.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteServiceInstances(ServiceLevelAgreement serviceLevelAgreement)
        {
            return GetChildHandler<ServiceLevelAgreementServiceInstanceRelation>(serviceLevelAgreement, "service_instances").DeleteAll();
        }

        #endregion

        #region Sites

        /// <summary>
        /// Get all sites.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of sites.</returns>
        public List<Site> GetSites(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Site>(serviceLevelAgreement, "sites").Get(fieldNames);
        }

        /// <summary>
        /// Get all sites.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of sites.</returns>
        public List<Site> GetSites(PredefinedEnabledDisabledFilter filter, ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<Site>(serviceLevelAgreement, $"sites/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a site.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="site">The site to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddSite(ServiceLevelAgreement serviceLevelAgreement, Site site)
        {
            return CreateRelation(serviceLevelAgreement, "sites", site);
        }

        /// <summary>
        /// Remove a site.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="site">The site to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveSite(ServiceLevelAgreement serviceLevelAgreement, Site site)
        {
            return DeleteRelation(serviceLevelAgreement, "sites", site);
        }

        /// <summary>
        /// Remove all sites.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllSites(ServiceLevelAgreement serviceLevelAgreement)
        {
            return DeleteAllRelations(serviceLevelAgreement, "sites");
        }

        #endregion

        #region Skill pools

        /// <summary>
        /// Get all skill pools.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of skill pools.</returns>
        public List<SkillPool> GetSkillPools(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<SkillPool>(serviceLevelAgreement, "skill_pools").Get(fieldNames);
        }

        /// <summary>
        /// Get all skill pools.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of skill pools.</returns>
        public List<SkillPool> GetSkillPools(PredefinedEnabledDisabledFilter filter, ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<SkillPool>(serviceLevelAgreement, $"skill_pools/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a skill pool.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="skillPool">The skill pool to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddSkillPool(ServiceLevelAgreement serviceLevelAgreement, SkillPool skillPool)
        {
            return CreateRelation(serviceLevelAgreement, "skill_pools", skillPool);
        }

        /// <summary>
        /// Remove a skill pool.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="skillPool">The skill pool to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveSkillPool(ServiceLevelAgreement serviceLevelAgreement, SkillPool skillPool)
        {
            return DeleteRelation(serviceLevelAgreement, "skill_pools", skillPool);
        }

        /// <summary>
        /// Remove all skill pools.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllSkillPools(ServiceLevelAgreement serviceLevelAgreement)
        {
            return DeleteAllRelations(serviceLevelAgreement, "skill_pools");
        }

        #endregion

        #region Standard service request activity ID

        /// <summary>
        /// Get all related standard service request activity IDs.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of standard service request activity ID.</returns>
        public List<StandardServiceRequestActivityID> GetStandardServiceRequestActivityIDs(ServiceLevelAgreement serviceLevelAgreement, params string[] fieldNames)
        {
            return GetChildHandler<StandardServiceRequestActivityID>(serviceLevelAgreement, "standard_service_request_activityIDs", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add a standard service request activity ID.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="standardServiceRequestActivityID">The standard service request activity ID to add.</param>
        /// <returns>The updated standard service request activity ID.</returns>
        public StandardServiceRequestActivityID AddStandardServiceRequestActivityID(ServiceLevelAgreement serviceLevelAgreement, StandardServiceRequestActivityID standardServiceRequestActivityID)
        {
            return GetChildHandler<StandardServiceRequestActivityID>(serviceLevelAgreement, "standard_service_request_activityIDs").Insert(standardServiceRequestActivityID);
        }

        /// <summary>
        /// Update a standard service request activity ID.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="standardServiceRequestActivityID">The standard service request activity ID to update.</param>
        /// <returns>The updated standard service request activity ID.</returns>
        public StandardServiceRequestActivityID UpdateStandardServiceRequestActivityID(ServiceLevelAgreement serviceLevelAgreement, StandardServiceRequestActivityID standardServiceRequestActivityID)
        {
            return GetChildHandler<StandardServiceRequestActivityID>(serviceLevelAgreement, "standard_service_request_activityIDs").Update(standardServiceRequestActivityID);
        }

        /// <summary>
        /// Delete a standard service request activity ID.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement.</param>
        /// <param name="standardServiceRequestActivityID">The standard service request activity ID to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteStandardServiceRequestActivityID(ServiceLevelAgreement serviceLevelAgreement, StandardServiceRequestActivityID standardServiceRequestActivityID)
        {
            return GetChildHandler<StandardServiceRequestActivityID>(serviceLevelAgreement, "standard_service_request_activityIDs").Delete(standardServiceRequestActivityID);
        }

        #endregion
    }
}
