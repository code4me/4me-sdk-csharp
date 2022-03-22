using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ConfigurationItemHandler : BaseHandler<ConfigurationItem, PredefinedConfigurationItemFilter>
    {
        public ConfigurationItemHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/cis", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ConfigurationItemHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/cis", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Configuration item relations

        public List<ConfigurationItemRelation> GetConfigurationItemRelations(ConfigurationItem configurationItem)
        {
            return GetChildHandler<ConfigurationItemRelation>(configurationItem, "ci_relations", SortOrder.None).Get();
        }

        public ConfigurationItemRelation AddConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItem relatedConfigurationItem, ConfigurationitemRelationType relationType)
        {
            return AddConfigurationItemRelation(configurationItem, new ConfigurationItemRelation() { ConfigurationItem = relatedConfigurationItem, RelationType = relationType });
        }

        public ConfigurationItemRelation AddConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            return GetChildHandler<ConfigurationItemRelation>(configurationItem, "ci_relations").Insert(configurationItemRelation);
        }

        public ConfigurationItemRelation UpdateConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            return GetChildHandler<ConfigurationItemRelation>(configurationItem, "ci_relations").Update(configurationItemRelation);
        }

        public bool DeleteConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            return GetChildHandler<ConfigurationItemRelation>(configurationItem, "ci_relations").Delete(configurationItemRelation);
        }

        public bool DeleteAllConfigurationItemRelations(ConfigurationItem configurationItem)
        {
            return GetChildHandler<ConfigurationItemRelation>(configurationItem, "ci_relations").DeleteAll();
        }

        #endregion

        #region Contracts

        public List<Contract> GetContracts(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Contract>(configurationItem, "contracts").Get(fieldNames);
        }

        public List<Contract> GetContracts(PredefinedActiveInactiveFilter filter, ConfigurationItem contract, params string[] fieldNames)
        {
            return GetChildHandler<Contract>(contract, $"contracts/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddContract(ConfigurationItem configurationItem, Contract contract)
        {
            return CreateRelation(configurationItem, "contracts", contract);
        }

        public bool RemoveContract(ConfigurationItem configurationItem, Contract contract)
        {
            return DeleteRelation(configurationItem, "contracts", contract);
        }

        public bool RemoveAllContracts(ConfigurationItem configurationItem)
        {
            return DeleteAllRelations(configurationItem, "contracts");
        }

        #endregion

        #region Problems

        public List<Problem> GetProblems(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(configurationItem, "problems").Get(fieldNames);
        }

        public List<Problem> GetProblems(PredefinedWorkflowProblemFilter filter, ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(configurationItem, $"problems/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Requests

        public List<Request> GetRequests(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Request>(configurationItem, "requests").Get(fieldNames);
        }

        public List<Request> GetRequests(PredefinedOpenCompletedFilter filter, ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Request>(configurationItem, $"requests/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service instances

        public List<ServiceInstance> GetServiceInstances(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(configurationItem, "service_instances").Get(fieldNames);
        }

        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(configurationItem, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddServiceInstance(ConfigurationItem configurationItem, ServiceInstance serviceInstance)
        {
            return CreateRelation(configurationItem, "service_instances", serviceInstance);
        }

        public bool RemoveServiceInstance(ConfigurationItem configurationItem, ServiceInstance serviceInstance)
        {
            return DeleteRelation(configurationItem, "service_instances", serviceInstance);
        }

        public bool RemoveAllServiceInstances(ConfigurationItem configurationItem)
        {
            return DeleteAllRelations(configurationItem, "service_instances");
        }

        #endregion

        #region Tasks

        public List<Task> GetTasks(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Task>(configurationItem, "tasks").Get(fieldNames);
        }

        public List<Task> GetMembers(PredefinedTaskStatusFilter filter, ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Task>(configurationItem, $"tasks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Users

        public List<Person> GetUsers(ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Person>(configurationItem, "users").Get(fieldNames);
        }

        public List<Person> GetUsers(PredefinedConfigurationItemUserFilter filter, ConfigurationItem configurationItem, params string[] fieldNames)
        {
            return GetChildHandler<Person>(configurationItem, $"users/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddUser(ConfigurationItem configurationItem, Person person)
        {
            return CreateRelation(configurationItem, "users", person);
        }

        public bool RemoveUser(ConfigurationItem configurationItem, Person person)
        {
            return DeleteRelation(configurationItem, "users", person);
        }

        public bool RemoveAllUsers(ConfigurationItem configurationItem)
        {
            return DeleteAllRelations(configurationItem, "users");
        }

        #endregion
    }
}
