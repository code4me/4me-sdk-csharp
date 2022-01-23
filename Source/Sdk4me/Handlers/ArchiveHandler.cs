namespace Sdk4me
{
    public class ArchiveHandler : DefaultHandler<Archive>
    {
        private readonly string baseURL;

        public ArchiveHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/archive", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            this.baseURL = $"{Common.GetBaseUrl(environmentType)}/v1";
            this.SortOrder = SortOrder.CreatedAt;
        }

        public ArchiveHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/archive", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            this.baseURL = $"{Common.GetBaseUrl(environmentType)}/v1";
            this.SortOrder = SortOrder.CreatedAt;
        }

        public BaseItem Restore(Archive archive)
        {
            return Restore<BaseItem>(archive);
        }

        public T Restore<T>(Archive archive) where T : BaseItem, new()
        {
            DefaultHandler<T> handler = new DefaultHandler<T>($"{baseURL}{archive.Details.HypertextReference}", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.CustomWebRequest("restore", "POST");
        }

    }
}
