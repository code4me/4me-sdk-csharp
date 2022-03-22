using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ContractHandler : BaseHandler<Contract, PredefinedActiveInactiveFilter>
    {
        public ContractHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/contracts", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ContractHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/contracts", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Configuration items

        public List<ConfigurationItem> GetConfigurationItems(Contract contract, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(contract, "cis").Get(fieldNames);
        }

        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, Contract contract, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(contract, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddConfigurationItem(Contract contract, ConfigurationItem configurationItem)
        {
            return CreateRelation(contract, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(Contract contract, ConfigurationItem configurationItem)
        {
            return DeleteRelation(contract, "cis", configurationItem);
        }

        public bool RemoveAllConfigurationItem(Contract contract)
        {
            return DeleteAllRelations(contract, "cis");
        }

        #endregion
    }
}
