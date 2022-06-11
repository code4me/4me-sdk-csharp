namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/time_entries/">time entry</see> API endpoint.
    /// </summary>
    public class TimeEntryHandler : DefaultBaseHandler<TimeEntry>
    {
        /// <summary>
        /// Create a new instance of the 4me time entry handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TimeEntryHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/time_entries", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me time entry handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TimeEntryHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/time_entries", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Archive, trash and restore

        /// <summary>
        /// Archive a time entry.
        /// </summary>
        /// <param name="timeEntry">The time entry.</param>
        /// <returns>The archived time entry.</returns>
        public TimeEntry Archive(TimeEntry timeEntry)
        {
            return GetChildHandler<TimeEntry>(timeEntry, "archive").Invoke("Post");
        }

        /// <summary>
        /// Trash a time entry.
        /// </summary>
        /// <param name="timeEntry">The time entry.</param>
        /// <returns>The trashed time entry.</returns>
        public TimeEntry Trash(TimeEntry timeEntry)
        {
            return GetChildHandler<TimeEntry>(timeEntry, "trash").Invoke("Post");
        }

        /// <summary>
        /// Restore a time entry.
        /// </summary>
        /// <param name="archive">The archived time entry.</param>
        /// <returns>The restored time entry.</returns>
        public TimeEntry Restore(Archive archive)
        {
            return GetChildHandler<TimeEntry>(new TimeEntry() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        /// <summary>
        /// Restore a time entry.
        /// </summary>
        /// <param name="trash">The trashed time entry.</param>
        /// <returns>The restored time entry.</returns>
        public TimeEntry Restore(Trash trash)
        {
            return GetChildHandler<TimeEntry>(new TimeEntry() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
