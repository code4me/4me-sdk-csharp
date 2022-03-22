namespace Sdk4me
{
    public class TimeEntryHandler : DefaultBaseHandler<TimeEntry>
    {
        public TimeEntryHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/time_entries", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TimeEntryHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/time_entries", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Archive, trash and restore

        public TimeEntry Archive(TimeEntry timeEntry)
        {
            return GetChildHandler<TimeEntry>(timeEntry, "archive").Invoke("Post");
        }

        public TimeEntry Trash(TimeEntry timeEntry)
        {
            return GetChildHandler<TimeEntry>(timeEntry, "trash").Invoke("Post");
        }

        public TimeEntry Restore(Archive archive)
        {
            return GetChildHandler<TimeEntry>(new TimeEntry() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        public TimeEntry Restore(Trash trash)
        {
            return GetChildHandler<TimeEntry>(new TimeEntry() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
