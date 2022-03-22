using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    public sealed class ArchiveHandler : IBaseHandler
    {
        private readonly AuthenticationTokenCollection authenticationTokens = null;
        private readonly string accountID = null;
        private readonly string url = null;
        private int itemsPerRequest = 25;
        private int maximumRecursiveRequests = 10;

        /// <summary>
        /// <para>Gets or sets the number of items returned in one request.</para>
        /// <para>The value must be at least 1 and maximum 100.</para>
        /// </summary>
        public int ItemsPerRequest
        {
            get => itemsPerRequest;
            set => itemsPerRequest = (value < 1 || value > 100) ? 25 : value;
        }

        /// <summary>
        /// <para>Gets or sets the number of recursive requests.</para>
        /// <para>The value must be at least 1 and maximum 1000.</para>
        /// </summary>
        public int MaximumRecursiveRequests
        {
            get => maximumRecursiveRequests;
            set => maximumRecursiveRequests = (value < 1 || value > 1000) ? 10 : value;
        }

        public ArchiveHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : this(new AuthenticationTokenCollection(authenticationToken), accountID, environmentType, environmentRegion, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ArchiveHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
        {
            //validate string argument values
            if (string.IsNullOrWhiteSpace(accountID))
                throw new ArgumentException($"'{nameof(accountID)}' cannot be null or whitespace.", nameof(accountID));

            //validate authentication tokens
            if (authenticationTokens is null)
                throw new ArgumentNullException(nameof(authenticationTokens));

            if (!authenticationTokens.Any())
                throw new ArgumentException($"'{nameof(authenticationTokens)}' cannot be empty.", nameof(authenticationTokens));

            //set global variables
            url = $"{EnvironmentURL.Get(environmentType, environmentRegion)}";
            this.authenticationTokens = authenticationTokens;
            this.accountID = accountID;
            this.itemsPerRequest = (itemsPerRequest < 1 || itemsPerRequest > 100) ? 25 : itemsPerRequest;
            this.maximumRecursiveRequests = (maximumRecursiveRequests < 1 || maximumRecursiveRequests > 1000) ? 10 : maximumRecursiveRequests;
        }

        public List<Archive> Get()
        {
            return new DefaultBaseHandler<Archive>($"{url}/archive", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests) { SortOrder = SortOrder.CreatedAt }.Get();
        }

        public BaseItem Restore(Archive archive)
        {
            return Restore<BaseItem>(archive);
        }

        public T Restore<T>(Archive archive) where T : BaseItem, new()
        {
            return new DefaultBaseHandler<T>($"{url}/{archive.Details.HypertextReference.Trim('/')}/restore", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests).Invoke("Post");
        }
    }
}
