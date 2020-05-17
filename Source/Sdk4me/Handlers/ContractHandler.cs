using System.Collections.Generic;

namespace Sdk4me
{
    public class ContractHandler : BaseHandler<Contract, PredefinedContractFilter>
    {
        public ContractHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/contracts", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ContractHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/contracts", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
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
