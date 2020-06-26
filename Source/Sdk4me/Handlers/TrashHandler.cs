namespace Sdk4me
{
    public class TrashHandler : DefaultHandler<Trash>
    {
        private readonly string baseURL;

        public TrashHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/trash",  authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            baseURL = $"{Common.GetBaseUrl(environmentType)}/v1";
            this.SortOrder = SortOrder.CreatedAt;
        }

        public TrashHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/trash",  authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            baseURL = $"{Common.GetBaseUrl(environmentType)}/v1";
            this.SortOrder = SortOrder.CreatedAt;
        }

        public BaseItem Restore(Trash trash)
        {
            return Restore<BaseItem>(trash);
        }

        public T Restore<T>(Trash trash) where T : BaseItem, new()
        {
            DefaultHandler<T> handler = new DefaultHandler<T>($"{baseURL}{trash.Details.HypertextReference}", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.CustomWebRequest("restore", "POST");
        }
    }
}
