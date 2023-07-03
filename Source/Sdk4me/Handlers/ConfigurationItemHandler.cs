using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/configuration_items/">configuration item</see> API endpoint.
    /// </summary>
    public class ConfigurationItemHandler : BaseHandler<ConfigurationItem, PredefinedConfigurationItemFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me configuration item handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ConfigurationItemHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/cis", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me configuration item handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ConfigurationItemHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/cis", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Configuration item relations

        /// <summary>
        /// Get all configuration item relations.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <returns>A list of configuration item relations.</returns>
        public List<ConfigurationItemRelation> GetConfigurationItemRelations(ConfigurationItem configurationItem)
        {
            return GetChildHandler<ConfigurationItemRelation>(configurationItem, "ci_relations", SortOrder.None).Get();
        }

        /// <summary>
        /// Add a configuration item relation.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="relatedConfigurationItem">The related configuration item.</param>
        /// <param name="relationType">The relation type.</param>
        /// <returns>A configuration item relation.</returns>
        public ConfigurationItemRelation AddConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItem relatedConfigurationItem, ConfigurationItemRelationType relationType)
        {
            return AddConfigurationItemRelation(configurationItem, new ConfigurationItemRelation() { ConfigurationItem = relatedConfigurationItem, RelationType = relationType });
        }

        /// <summary>
        /// Add a configuration item relation.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="configurationItemRelation">The configuration item relational object.</param>
        /// <returns>A configuration item relation.</returns>
        public ConfigurationItemRelation AddConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            return GetChildHandler<ConfigurationItemRelation>(configurationItem, "ci_relations").Insert(configurationItemRelation);
        }

        /// <summary>
        /// Update a configuration item relation.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="configurationItemRelation">The configuration item relational object.</param>
        /// <returns>A configuration item relation.</returns>
        public ConfigurationItemRelation UpdateConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            return GetChildHandler<ConfigurationItemRelation>(configurationItem, "ci_relations").Update(configurationItemRelation);
        }

        /// <summary>
        /// Delete a configuration item relation.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="configurationItemRelation">The configuration item relational object.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            return GetChildHandler<ConfigurationItemRelation>(configurationItem, "ci_relations").Delete(configurationItemRelation);
        }

        /// <summary>
        /// Delete all configuration item relations.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllConfigurationItemRelations(ConfigurationItem configurationItem)
        {
            return GetChildHandler<ConfigurationItemRelation>(configurationItem, "ci_relations").DeleteAll();
        }

        #endregion

        #region Contracts

        /// <summary>
        /// Get all contracts.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of contracts.</returns>
        public List<Contract> GetContracts(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Contract>(configurationItem, "contracts").Get(fieldNames);
        }

        /// <summary>
        /// Get all contracts.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="contract">The contract to add.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of contracts.</returns>
        public List<Contract> GetContracts(PredefinedActiveInactiveFilter filter, ConfigurationItem contract, params string[] fieldNames)
        {
            return GetChildHandler<Contract>(contract, $"contracts/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a contract.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="contract">The contract to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddContract(ConfigurationItem configurationItem, Contract contract)
        {
            return CreateRelation(configurationItem, "contracts", contract);
        }

        /// <summary>
        /// Remove a contract.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="contract">The contract to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveContract(ConfigurationItem configurationItem, Contract contract)
        {
            return DeleteRelation(configurationItem, "contracts", contract);
        }

        /// <summary>
        /// Remove all contracts.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllContracts(ConfigurationItem configurationItem)
        {
            return DeleteAllRelations(configurationItem, "contracts");
        }

        #endregion

        #region Problems

        /// <summary>
        /// Get all related problems.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of problems.</returns>
        public List<Problem> GetProblems(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(configurationItem, "problems").Get(fieldNames);
        }

        /// <summary>
        /// Get all related problems.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of problems.</returns>
        public List<Problem> GetProblems(PredefinedWorkflowProblemFilter filter, ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(configurationItem, $"problems/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Requests

        /// <summary>
        /// Get all related requests.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of requests.</returns>
        public List<Request> GetRequests(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Request>(configurationItem, "requests").Get(fieldNames);
        }

        /// <summary>
        /// Get all related requests.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of requests.</returns>
        public List<Request> GetRequests(PredefinedOpenCompletedFilter filter, ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Request>(configurationItem, $"requests/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service instances

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(configurationItem, "service_instances").Get(fieldNames);
        }

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(configurationItem, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a service instance.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="serviceInstance">The service instance to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddServiceInstance(ConfigurationItem configurationItem, ServiceInstance serviceInstance)
        {
            return CreateRelation(configurationItem, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove a service instance.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="serviceInstance">The service instance to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveServiceInstance(ConfigurationItem configurationItem, ServiceInstance serviceInstance)
        {
            return DeleteRelation(configurationItem, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove all service instances.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllServiceInstances(ConfigurationItem configurationItem)
        {
            return DeleteAllRelations(configurationItem, "service_instances");
        }

        #endregion

        #region Tasks

        /// <summary>
        /// Get all related tasks.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of tasks.</returns>
        public List<Task> GetTasks(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Task>(configurationItem, "tasks").Get(fieldNames);
        }

        /// <summary>
        /// Get all related tasks.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of tasks.</returns>
        public List<Task> GetMembers(PredefinedTaskStatusFilter filter, ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Task>(configurationItem, $"tasks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Users

        /// <summary>
        /// Get all related users.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of users.</returns>
        public List<Person> GetUsers(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Person>(configurationItem, "users").Get(fieldNames);
        }

        /// <summary>
        /// Get all related users.
        /// </summary>
        /// <param name="filter">A predefined filter.</param>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of users.</returns>
        public List<Person> GetUsers(PredefinedConfigurationItemUserFilter filter, ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Person>(configurationItem, $"users/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a user.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="person">The user to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddUser(ConfigurationItem configurationItem, Person person)
        {
            return CreateRelation(configurationItem, "users", person);
        }

        /// <summary>
        /// Remove a user.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <param name="person">The user to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveUser(ConfigurationItem configurationItem, Person person)
        {
            return DeleteRelation(configurationItem, "users", person);
        }

        /// <summary>
        /// Remove all users.
        /// </summary>
        /// <param name="configurationItem">The configuration item.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllUsers(ConfigurationItem configurationItem)
        {
            return DeleteAllRelations(configurationItem, "users");
        }

        #endregion
    }
}
