using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/contracts/">contract</see> API endpoint.
    /// </summary>
    public class ContractHandler : BaseHandler<Contract, PredefinedActiveInactiveFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me contract handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ContractHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/contracts", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me contract handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ContractHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/contracts", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Configuration items

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(Contract contract, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(contract, "cis").Get(fieldNames);
        }

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="contract">The contract.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, Contract contract, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(contract, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a configuration item.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="configurationItem">The configuration item to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddConfigurationItem(Contract contract, ConfigurationItem configurationItem)
        {
            return CreateRelation(contract, "cis", configurationItem);
        }

        /// <summary>
        /// Remove a configuration item.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="configurationItem">The configuration item to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveConfigurationItem(Contract contract, ConfigurationItem configurationItem)
        {
            return DeleteRelation(contract, "cis", configurationItem);
        }

        /// <summary>
        /// Remove all configuration items.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllConfigurationItem(Contract contract)
        {
            return DeleteAllRelations(contract, "cis");
        }

        #endregion
    }
}
