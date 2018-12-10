using System.Collections.Generic;

namespace Sdk4me
{
    public class ConfigurationItemHandler : BaseHandler<ConfigurationItem>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/cis";
        private static readonly string productionUrl = "https://api.4me.com/v1/cis";

        public ConfigurationItemHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ConfigurationItemHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region configuration item relations

        public List<ConfigurationItemRelation> GetConfigurationItemRelations(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            BaseHandler<ConfigurationItemRelation> handler = new BaseHandler<ConfigurationItemRelation>($"{URL}/{configurationItem.ID}/ci_relations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public ConfigurationItemRelation AddConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            BaseHandler<ConfigurationItemRelation> handler = new BaseHandler<ConfigurationItemRelation>($"{URL}/{configurationItem.ID}/ci_relations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(configurationItemRelation);
        }

        public ConfigurationItemRelation UpdateConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            BaseHandler<ConfigurationItemRelation> handler = new BaseHandler<ConfigurationItemRelation>($"{URL}/{configurationItem.ID}/ci_relations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(configurationItemRelation);
        }

        public bool DeleteConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation)
        {
            BaseHandler<ConfigurationItemRelation> handler = new BaseHandler<ConfigurationItemRelation>($"{URL}/{configurationItem.ID}/ci_relations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(configurationItemRelation);
        }

        public bool DeleteAllConfigurationItemRelations(ConfigurationItem configurationItem)
        {
            BaseHandler<ConfigurationItemRelation> handler = new BaseHandler<ConfigurationItemRelation>($"{URL}/{configurationItem.ID}/ci_relations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion

        #region contracts

        public List<Contract> GetContracts(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            BaseHandler<Contract> handler = new BaseHandler<Contract>($"{URL}/{configurationItem.ID}/contracts", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            BaseHandler<Problem> handler = new BaseHandler<Problem>($"{URL}/{configurationItem.ID}/problems", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region requests

        public List<Request> GetRequests(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            BaseHandler<Request> handler = new BaseHandler<Request>($"{URL}/{configurationItem.ID}/requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }


        #endregion

        #region service instances

        public List<ServiceInstance> GetServiceInstances(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            BaseHandler<ServiceInstance> handler = new BaseHandler<ServiceInstance>($"{URL}/{configurationItem.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            BaseHandler<Task> handler = new BaseHandler<Task>($"{URL}/{configurationItem.ID}/tasks", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }


        #endregion

        #region user

        public List<Person> GetUsers(ConfigurationItem configurationItem, params string[] attributeNames)
        {
            BaseHandler<Person> handler = new BaseHandler<Person>($"{URL}/{configurationItem.ID}/users", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
