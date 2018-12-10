namespace Sdk4me
{
    public class TrashHandler : BaseHandler<Trash>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/trash";
        private static readonly string productionUrl = "https://api.4me.com/v1/trash";

        public TrashHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            this.SortOrder = SortOrder.CreatedAtAndID;
        }

        public TrashHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            this.SortOrder = SortOrder.CreatedAtAndID;
        }
    }
}
