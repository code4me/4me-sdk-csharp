using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/project_tasks/">project task</see> API endpoint.
    /// </summary>
    public class ProjectTaskHandler : BaseHandler<ProjectTask, PredefinedProjectTaskFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me project task handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ProjectTaskHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/project_tasks", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me project task handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ProjectTaskHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/project_tasks", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Assignments

        /// <summary>
        /// Get all project task assignments.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <returns>A collection of project task assignments.</returns>
        public List<ProjectTaskAssignment> GetAssignments(ProjectTask projectTask)
        {
            return GetChildHandler<ProjectTaskAssignment>(projectTask, "assignments", SortOrder.None).Get("*");
        }

        /// <summary>
        /// Add a project task assignment.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="projectTaskAssignment">The project task assignment.</param>
        /// <returns>The updated project task assignment.</returns>
        public ProjectTaskAssignment AddAssignment(ProjectTask projectTask, ProjectTaskAssignment projectTaskAssignment)
        {
            return GetChildHandler<ProjectTaskAssignment>(projectTask, "assignments").Insert(projectTaskAssignment);
        }

        /// <summary>
        /// Update a project task assignment.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="projectTaskAssignment">The project task assignment.</param>
        /// <returns>The updated project task assignment.</returns>
        public ProjectTaskAssignment UpdateAssignment(ProjectTask projectTask, ProjectTaskAssignment projectTaskAssignment)
        {
            return GetChildHandler<ProjectTaskAssignment>(projectTask, "assignments").Update(projectTaskAssignment);
        }

        /// <summary>
        /// Remove a project task assignment.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="projectTaskAssignment">The project task assignment.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAssignment(ProjectTask projectTask, ProjectTaskAssignment projectTaskAssignment)
        {
            return GetChildHandler<ProjectTaskAssignment>(projectTask, "assignments").Delete(projectTaskAssignment);
        }

        /// <summary>
        /// Remove all project task assignments.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllAssignments(ProjectTask projectTask)
        {
            return GetChildHandler<ProjectTaskAssignment>(projectTask, "assignments").DeleteAll();
        }

        #endregion

        #region Notes

        /// <summary>
        /// Get all notes related to a project task.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of notes.</returns>
        public List<Note> GetNotes(ProjectTask projectTask, params string[] fieldNames)
        {
            return GetChildHandler<Note>(projectTask, "notes", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add a note to a project task.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="item">The note to add.</param>
        public void AddNote(ProjectTask projectTask, NoteCreate item)
        {
            BaseItem retval = GetChildHandler<NoteCreate>(projectTask, "notes", SortOrder.None).Insert(item);
            item.ID = retval.ID;
        }

        #endregion

        #region Predecessors

        /// <summary>
        /// Get all project task predecessors.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of project tasks.</returns>
        public List<ProjectTask> GetPredecessors(ProjectTask projectTask, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(projectTask, "predecessors").Get(fieldNames);
        }

        /// <summary>
        /// Add a project task predecessor.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="predecessor">The project task predecessor to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddPredecessor(ProjectTask projectTask, ProjectTask predecessor)
        {
            return CreateRelation(projectTask, "predecessors", predecessor);
        }

        /// <summary>
        /// Remove a project task predecessor.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="predecessor">The project task predecessor to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemovePredecessor(ProjectTask projectTask, ProjectTask predecessor)
        {
            return DeleteRelation(projectTask, "predecessors", predecessor);
        }

        /// <summary>
        /// Remove all project task predecessors.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllPredecessors(ProjectTask projectTask)
        {
            return DeleteAllRelations(projectTask, "predecessors");
        }

        #endregion

        #region Sprint backlog items

        /// <summary>
        /// Get all sprint backlog items related to a project task.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of sprint backlog items.</returns>
        public List<SprintBacklogItem> GetSprintBacklogItems(ProjectTask projectTask, params string[] fieldNames)
        {
            return GetChildHandler<SprintBacklogItem>(projectTask, "sprint_backlog_items").Get(fieldNames);
        }

        #endregion

        #region Successors

        /// <summary>
        /// Get all project task successors.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of project tasks.</returns>
        public List<ProjectTask> GetSuccessors(ProjectTask projectTask, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(projectTask, "successors").Get(fieldNames);
        }

        /// <summary>
        /// Add a project task successor.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="successor">The project task successor to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddSuccessor(ProjectTask projectTask, ProjectTask successor)
        {
            return CreateRelation(projectTask, "successors", successor);
        }

        /// <summary>
        /// Remove a project task successor.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <param name="successor">The project task successor to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveSuccessor(ProjectTask projectTask, ProjectTask successor)
        {
            return DeleteRelation(projectTask, "successors", successor);
        }

        /// <summary>
        /// Remove all project task successors.
        /// </summary>
        /// <param name="projectTask">The project task.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllSuccessors(ProjectTask projectTask)
        {
            return DeleteAllRelations(projectTask, "successors");
        }

        #endregion
    }
}
