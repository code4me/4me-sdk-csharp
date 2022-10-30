using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/archive/">archive</see> API endpoint.
    /// </summary>
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

        /// <summary>
        /// Create a new instance of the 4me archive handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public ArchiveHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : this(new AuthenticationTokenCollection(authenticationToken), accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me archive handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public ArchiveHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
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
            url = $"{EnvironmentURL.Get(environment, environmentRegion)}";
            this.authenticationTokens = authenticationTokens;
            this.accountID = accountID;
            this.itemsPerRequest = (itemsPerRequest < 1 || itemsPerRequest > 100) ? 25 : itemsPerRequest;
            this.maximumRecursiveRequests = (maximumRecursiveRequests < 1 || maximumRecursiveRequests > 1000) ? 10 : maximumRecursiveRequests;
        }

        /// <summary>
        /// Get all archived object.
        /// </summary>
        /// <returns></returns>
        public List<Archive> Get()
        {
            return new DefaultBaseHandler<Archive>($"{url}/archive", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests) { SortOrder = SortOrder.CreatedAt }.Get();
        }

        /// <summary>
        /// Restore an archived object.
        /// </summary>
        /// <param name="archive">The archived object.</param>
        /// <returns>The restored archived object.</returns>
        public BaseItem Restore(Archive archive)
        {
            return Restore<BaseItem>(archive);
        }

        /// <summary>
        /// Restore an archive object.
        /// </summary>
        /// <typeparam name="T">The type of object to restore.</typeparam>
        /// <param name="archive">The archive object.</param>
        /// <returns>A restored object.</returns>
        public T Restore<T>(Archive archive) where T : BaseItem, new()
        {
            return new DefaultBaseHandler<T>($"{url}/{archive.Details.HypertextReference.Trim('/')}/restore", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests).Invoke("Post");
        }
    }
}
