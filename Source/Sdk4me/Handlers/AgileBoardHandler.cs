using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/agile_boards/">agile board</see> API endpoint.
    /// </summary>
    public class AgileBoardHandler : BaseHandler<AgileBoard, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me agile board handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public AgileBoardHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/agile_boards", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me agile board handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public AgileBoardHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/agile_boards", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Columns

        /// <summary>
        /// Get all agile board columns.
        /// </summary>
        /// <param name="agileBoard">The agile board.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of agile board columns.</returns>
        public List<AgileBoardColumn> GetColumns(AgileBoard agileBoard, params string[] fieldNames)
        {
            return GetChildHandler<AgileBoardColumn>(agileBoard, "agile_board_columns").Get(fieldNames);
        }

        /// <summary>
        /// Add an agile board column.
        /// </summary>
        /// <param name="agileBoard">The agile board.</param>
        /// <param name="agileBoardColumn">The agile board column.</param>
        /// <returns>The updated agile board column.</returns>
        public AgileBoardColumn AddColumn(AgileBoard agileBoard, AgileBoardColumn agileBoardColumn)
        {
            return GetChildHandler<AgileBoardColumn>(agileBoard, "agile_board_columns").Insert(agileBoardColumn);
        }

        /// <summary>
        /// Update an agile board column.
        /// </summary>
        /// <param name="agileBoard">The agile board.</param>
        /// <param name="agileBoardColumn">The agile board column.</param>
        /// <returns>The updated agile board column.</returns>
        public AgileBoardColumn UpdateColumn(AgileBoard agileBoard, AgileBoardColumn agileBoardColumn)
        {
            return GetChildHandler<AgileBoardColumn>(agileBoard, "agile_board_columns").Update(agileBoardColumn);
        }

        /// <summary>
        /// Delete an agile board column.
        /// </summary>
        /// <param name="agileBoard">The agile board.</param>
        /// <param name="agileBoardColumn">The agile board column.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteColumn(AgileBoard agileBoard, AgileBoardColumn agileBoardColumn)
        {
            return GetChildHandler<AgileBoardColumn>(agileBoard, "agile_board_columns").Delete(agileBoardColumn);
        }

        #endregion
    }
}
