using System.Collections.Generic;


namespace Sdk4me
{
    public class ReleaseHandler : BaseHandler<Release>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/releases";
        private static readonly string productionUrl = "https://api.4me.com/v1/releases";

        public ReleaseHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ReleaseHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region notes

        public List<Note> GetNotes(Release release, params string[] attributeNames)
        {
            BaseHandler<Note> handler = new BaseHandler<Note>($"{URL}/{release.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.CreatedAtAndID;
            return handler.Get(attributeNames);
        }

        #endregion

        #region changes

        public List<Change> GetChanges(Release release, params string[] attributeNames)
        {
            BaseHandler<Change> handler = new BaseHandler<Change>($"{URL}/{release.ID}/changes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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

    }
}
