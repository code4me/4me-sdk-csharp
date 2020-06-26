using System.Collections.Generic;


namespace Sdk4me
{
    public class ReleaseHandler : BaseHandler<Release, PredefinedReleaseFilter>
    {
        public ReleaseHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/releases", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ReleaseHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/releases", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region notes

        public List<Note> GetNotes(Release release, params string[] attributeNames)
        {
            DefaultHandler<Note> handler = new DefaultHandler<Note>($"{URL}/{release.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.CreatedAt
            };
            return handler.Get(attributeNames);
        }

        #endregion

        #region changes

        public List<Change> GetChanges(Release release, params string[] attributeNames)
        {
            DefaultHandler<Change> handler = new DefaultHandler<Change>($"{URL}/{release.ID}/changes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddChange(Release release, Change change)
        {
            return CreateRelation(release, "changes", change);
        }
    
        public bool RemoveChange(Release release, Change change)
        {
            return DeleteRelation(release, "changes", change);
        }

        public bool RemoveAllChanges(Release release)
        {
            return DeleteAllRelations(release, "changes");
        }

        #endregion

        #region archive, trash and restore

        public Release Archive(Release release)
        {
            return CustomWebRequest($"{release.ID}/archive", "POST");
        }

        public Release Trash(Release release)
        {
            return CustomWebRequest($"{release.ID}/trash", "POST");
        }

        public Release Restore(Archive archive)
        {
            return CustomWebRequest($"{archive.Details.ID}/restore", "POST");
        }

        public Release Restore(Trash trash)
        {
            return CustomWebRequest($"{trash.Details.ID}/restore", "POST");
        }

        #endregion
    }
}
