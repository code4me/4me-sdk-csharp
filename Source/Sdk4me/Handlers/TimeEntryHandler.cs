namespace Sdk4me
{
    public class TimeEntryHandler : DefaultHandler<TimeEntry>
    {
        public TimeEntryHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/time_entries",  authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TimeEntryHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/time_entries",  authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region archive, trash and restore

        public TimeEntry Archive(TimeEntry timeEntry)
        {
            return CustomWebRequest($"{timeEntry.ID}/archive", "POST");
        }

        public TimeEntry Trash(TimeEntry timeEntry)
        {
            return CustomWebRequest($"{timeEntry.ID}/trash", "POST");
        }

        public TimeEntry Restore(Archive archive)
        {
            return CustomWebRequest($"{archive.Details.ID}/restore", "POST");
        }

        public TimeEntry Restore(Trash trash)
        {
            return CustomWebRequest($"{trash.Details.ID}/restore", "POST");
        }

        #endregion
    }
}
