using System.Collections.Generic;

namespace Sdk4me
{
    public class AgileBoardHandler : BaseHandler<AgileBoard, PredefinedEnabledDisabledFilter>
    {
        public AgileBoardHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/agile_boards", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public AgileBoardHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/agile_boards", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Columns

        public List<AgileBoardColumn> GetColumns(AgileBoard agileBoard, params string[] fieldNames)
        {
            return GetChildHandler<AgileBoardColumn>(agileBoard, "agile_board_columns").Get(fieldNames);
        }

        public AgileBoardColumn AddColumn(AgileBoard agileBoard, AgileBoardColumn agileBoardColumn)
        {
            return GetChildHandler<AgileBoardColumn>(agileBoard, "agile_board_columns").Insert(agileBoardColumn);
        }

        public AgileBoardColumn UpdateColumn(AgileBoard agileBoard, AgileBoardColumn agileBoardColumn)
        {
            return GetChildHandler<AgileBoardColumn>(agileBoard, "agile_board_columns").Update(agileBoardColumn);
        }

        public bool DeleteColumn(AgileBoard agileBoard, AgileBoardColumn agileBoardColumn)
        {
            return GetChildHandler<AgileBoardColumn>(agileBoard, "agile_board_columns").Delete(agileBoardColumn);
        }

        #endregion
    }
}
