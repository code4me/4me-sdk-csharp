using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ReleaseHandler : BaseHandler<Release, PredefinedReleaseFilter>
    {
        public ReleaseHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/releases", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ReleaseHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/releases", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Notes

        public List<Note> GetNotes(Release release, params string[] fieldNames)
        {
            return GetChildHandler<Note>(release, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Workflows

        public List<Workflow> GetWorkflows(Release release, params string[] fieldNames)
        {
            return GetChildHandler<Workflow>(release, "workflows").Get(fieldNames);
        }

        public List<Workflow> GetWorkflows(PredefinedOpenClosedFilter filter, Release release, params string[] fieldNames)
        {
            return GetChildHandler<Workflow>(release, $"workflows/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddWorkflow(Release release, Workflow workflow)
        {
            return CreateRelation(release, "workflows", workflow);
        }

        public bool RemoveWorkflow(Release release, Workflow workflow)
        {
            return DeleteRelation(release, "workflows", workflow);
        }

        public bool RemoveWorkflows(Release release)
        {
            return DeleteAllRelations(release, "workflows");
        }

        #endregion

        #region Archive, trash and restore

        public Release Archive(Release release)
        {
            return GetChildHandler<Release>(release, "archive").Invoke("Post");
        }

        public Release Trash(Release release)
        {
            return GetChildHandler<Release>(release, "trash").Invoke("Post");
        }

        public Release Restore(Archive archive)
        {
            return GetChildHandler<Release>(new Release() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        public Release Restore(Trash trash)
        {
            return GetChildHandler<Release>(new Release() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
