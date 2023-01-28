using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/releases/">release</see> API endpoint.
    /// </summary>
    public class ReleaseHandler : BaseHandler<Release, PredefinedReleaseFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me release handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ReleaseHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/releases", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me release handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ReleaseHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/releases", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Notes

        /// <summary>
        /// Get all notes related to a release.
        /// </summary>
        /// <param name="release">The release.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of notes.</returns>
        public List<Note> GetNotes(Release release, params string[] fieldNames)
        {
            return GetChildHandler<Note>(release, "notes", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add a note to a release.
        /// </summary>
        /// <param name="release">The release.</param>
        /// <param name="item">The note to add.</param>
        public void AddNote(Release release, NoteCreate item)
        {
            BaseItem retval = GetChildHandler<NoteCreate>(release, "notes", SortOrder.None).Insert(item);
            item.ID = retval.ID;
        }

        #endregion

        #region Workflows

        /// <summary>
        /// Get all workflows related to a release.
        /// </summary>
        /// <param name="release">The release.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflows.</returns>
        public List<Workflow> GetWorkflows(Release release, params string[] fieldNames)
        {
            return GetChildHandler<Workflow>(release, "workflows").Get(fieldNames);
        }

        /// <summary>
        /// Get all workflows related to a release.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="release">The release.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflows.</returns>
        public List<Workflow> GetWorkflows(PredefinedOpenClosedFilter filter, Release release, params string[] fieldNames)
        {
            return GetChildHandler<Workflow>(release, $"workflows/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a workflow to a release.
        /// </summary>
        /// <param name="release">The release.</param>
        /// <param name="workflow">The workflow to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddWorkflow(Release release, Workflow workflow)
        {
            return CreateRelation(release, "workflows", workflow);
        }

        /// <summary>
        /// Remove a workflow from a release.
        /// </summary>
        /// <param name="release">The release.</param>
        /// <param name="workflow">The workflow to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveWorkflow(Release release, Workflow workflow)
        {
            return DeleteRelation(release, "workflows", workflow);
        }

        /// <summary>
        /// Remove all workflows from a release.
        /// </summary>
        /// <param name="release">The release.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveWorkflows(Release release)
        {
            return DeleteAllRelations(release, "workflows");
        }

        #endregion

        #region Archive, trash and restore

        /// <summary>
        /// Archive a release.
        /// </summary>
        /// <param name="release">The release.</param>
        /// <returns>The archived release.</returns>
        public Release Archive(Release release)
        {
            return GetChildHandler<Release>(release, "archive").Invoke("Post");
        }

        /// <summary>
        /// Trash a release.
        /// </summary>
        /// <param name="release">The release.</param>
        /// <returns>The trashed release.</returns>
        public Release Trash(Release release)
        {
            return GetChildHandler<Release>(release, "trash").Invoke("Post");
        }

        /// <summary>
        /// Restore a release.
        /// </summary>
        /// <param name="archive">The archived release.</param>
        /// <returns>The restored release.</returns>
        public Release Restore(Archive archive)
        {
            return GetChildHandler<Release>(new Release() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        /// <summary>
        /// Restore a release.
        /// </summary>
        /// <param name="trash">The trashed release.</param>
        /// <returns>The restored release.</returns>
        public Release Restore(Trash trash)
        {
            return GetChildHandler<Release>(new Release() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
