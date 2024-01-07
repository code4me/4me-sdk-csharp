using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/notes/note_reactions/">note reactions</see> API endpoint.
    /// </summary>
    public class NoteReactionHandler : IBaseHandler
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
        /// Create a new instance of the 4me account handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public NoteReactionHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : this(new AuthenticationTokenCollection(authenticationToken), accountID, environment, environmentRegion, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me account handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public NoteReactionHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
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
        /// Get all reactions for a note.
        /// </summary>
        /// <param name="noteReference">The reference to a note object.</param>
        /// <returns>A list of all note reactions.</returns>
        public List<NoteReaction> Get(Note noteReference)
        {
            DefaultBaseHandler<NoteReaction> handler = new DefaultBaseHandler<NoteReaction>($"{url}/notes/{noteReference.ID}/note_reactions", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests, SortOrder.None);
            return handler.Get();
        }

        /// <summary>
        /// Add a reaction to a note.
        /// </summary>
        /// <param name="noteReaction">The reaction to add.</param>
        /// <returns>The newly created note.</returns>
        public NoteReaction Add(NoteReaction noteReaction)
        {
            DefaultBaseHandler<NoteReaction> handler = new DefaultBaseHandler<NoteReaction>($"{url}/note_reactions", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests);
            return handler.Insert(noteReaction);
        }

        /// <summary>
        /// Delete a note reaction
        /// </summary>
        /// <param name="noteReaction"></param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool Delete(NoteReaction noteReaction)
        {
            DefaultBaseHandler<NoteReaction> handler = new DefaultBaseHandler<NoteReaction>($"{url}/note_reactions", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests);
            return handler.Delete(noteReaction);
        }
    }
}
