using System.Collections.Generic;

namespace Sdk4me
{
    public class ConfigurationItemHandler : BaseHandler<ConfigurationItem, PredefinedConfigurationItemFilter>
    {
        public ConfigurationItemHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/cis", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ConfigurationItemHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/cis", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region configuration item relations

        public List<ConfigurationItemRelation> GetConfigurationItemRelations(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            DefaultHandler<ConfigurationItemRelation> handler = new DefaultHandler<ConfigurationItemRelation>($"{URL}/{configurationItem.ID}/ci_relations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public ConfigurationItemRelation AddConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            DefaultHandler<ConfigurationItemRelation> handler = new DefaultHandler<ConfigurationItemRelation>($"{URL}/{configurationItem.ID}/ci_relations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(configurationItemRelation);
        }

        public ConfigurationItemRelation UpdateConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            DefaultHandler<ConfigurationItemRelation> handler = new DefaultHandler<ConfigurationItemRelation>($"{URL}/{configurationItem.ID}/ci_relations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(configurationItemRelation);
        }

        public bool DeleteConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            DefaultHandler<ConfigurationItemRelation> handler = new DefaultHandler<ConfigurationItemRelation>($"{URL}/{configurationItem.ID}/ci_relations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(configurationItemRelation);
        }

        public bool DeleteAllConfigurationItemRelations(ConfigurationItem configurationItem)
        {
            DefaultHandler<ConfigurationItemRelation> handler = new DefaultHandler<ConfigurationItemRelation>($"{URL}/{configurationItem.ID}/ci_relations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion

        #region contracts

        public List<Contract> GetContracts(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            DefaultHandler<Contract> handler = new DefaultHandler<Contract>($"{URL}/{configurationItem.ID}/contracts", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
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

        #region problems

        public List<Problem> GetProblems(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            DefaultHandler<Problem> handler = new DefaultHandler<Problem>($"{URL}/{configurationItem.ID}/problems", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region requests

        public List<Request> GetRequests(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            DefaultHandler<Request> handler = new DefaultHandler<Request>($"{URL}/{configurationItem.ID}/requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }


        #endregion

        #region service instances

        public List<ServiceInstance> GetServiceInstances(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            DefaultHandler<ServiceInstance> handler = new DefaultHandler<ServiceInstance>($"{URL}/{configurationItem.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
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

        #region tasks

        public List<Task> GetTasks(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            DefaultHandler<Task> handler = new DefaultHandler<Task>($"{URL}/{configurationItem.ID}/tasks", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }


        #endregion

        #region user

        public List<Person> GetUsers(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            DefaultHandler<Person> handler = new DefaultHandler<Person>($"{URL}/{configurationItem.ID}/users", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
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
