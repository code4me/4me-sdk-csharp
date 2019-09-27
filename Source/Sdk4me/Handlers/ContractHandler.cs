using System.Collections.Generic;

namespace Sdk4me
{
    public class ContractHandler : BaseHandler<Contract, PredefinedContractFilter>
    {
        private const string qualityUrl = "https://api.4me.qa/v1/contracts";
        private const string productionUrl = "https://api.4me.com/v1/contracts";

        public ContractHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ContractHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(Contract contract, params string[] attributeNames)
        {
            DefaultHandler<ConfigurationItem> handler = new DefaultHandler<ConfigurationItem>($"{URL}/{contract.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddConfigurationItem(Contract contract, ConfigurationItem configurationItem)
        {
            return CreateRelation(contract, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(Contract contract, ConfigurationItem configurationItem)
        {
            return DeleteRelation(contract, "cis", configurationItem);
        }

        public bool RemoveAllConfigurationItems(Contract contract)
        {
            return DeleteAllRelations(contract, "cis");
        }

        #endregion

    }
}
