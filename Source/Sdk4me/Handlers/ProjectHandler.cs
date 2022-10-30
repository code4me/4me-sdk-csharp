using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/projects/">project</see> API endpoint.
    /// </summary>
    public class ProjectHandler : BaseHandler<Project, PredefinedProjectFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me project handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ProjectHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/projects", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me project handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ProjectHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/projects", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Workflows

        /// <summary>
        /// Get all related workflows of a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflows.</returns>
        public List<Workflow> GetWorkflows(Project project, params string[] fieldNames)
        {
            return GetChildHandler<Workflow>(project, "workflows").Get(fieldNames);
        }

        /// <summary>
        /// Add a workflow to a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="workflow">The workflow to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddWorkflow(Project project, Workflow workflow)
        {
            return CreateRelation(project, "workflows", workflow);
        }

        /// <summary>
        /// Remove a workflow from a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="workflow">The workflow to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveWorkflow(Project project, Workflow workflow)
        {
            return DeleteRelation(project, "workflows", workflow);
        }

        /// <summary>
        /// Remove all workflows from a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveWorkflows(Project project)
        {
            return DeleteAllRelations(project, "workflows");
        }

        #endregion

        #region Notes

        /// <summary>
        /// Get all notes related to a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of notes.</returns>
        public List<Note> GetNotes(Project project, params string[] fieldNames)
        {
            return GetChildHandler<Note>(project, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Phases

        /// <summary>
        /// Get all phases of a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>A collection of project phases.</returns>
        public List<ProjectPhase> GetPhases(Project project)
        {
            return GetChildHandler<ProjectPhase>(project, "phases", SortOrder.None).Get("*");
        }

        /// <summary>
        /// Add a phase to a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="projectPhase">The project phase to add.</param>
        /// <returns>The updated project phase.</returns>
        public ProjectPhase AddPhase(Project project, ProjectPhase projectPhase)
        {
            return GetChildHandler<ProjectPhase>(project, "phases").Insert(projectPhase);
        }

        /// <summary>
        /// Update a project phase.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="projectPhase">The project phase to update.</param>
        /// <returns>The updated project phase.</returns>
        public ProjectPhase UpdatePhase(Project project, ProjectPhase projectPhase)
        {
            return GetChildHandler<ProjectPhase>(project, "phases").Update(projectPhase);
        }

        /// <summary>
        /// Delete a project phase.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="projectPhase">The project phase to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeletePhase(Project project, ProjectPhase projectPhase)
        {
            return GetChildHandler<ProjectPhase>(project, "phases").Delete(projectPhase);
        }

        /// <summary>
        /// Delete all project phases.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllPhases(Project project)
        {
            return GetChildHandler<ProjectPhase>(project, "phases").DeleteAll();
        }

        #endregion

        #region Problems

        /// <summary>
        /// Get all problems related to a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of problems.</returns>
        public List<Problem> GetProblems(Project project, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(project, "problems").Get(fieldNames);
        }

        /// <summary>
        /// Get all problems related to a project.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="project">The project.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of problems.</returns>
        public List<Problem> GetProblems(PredefinedWorkflowProblemFilter filter, Project project, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(project, $"problems/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a problem to a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="problem">The problem to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddProblem(Project project, Problem problem)
        {
            return CreateRelation(project, "problems", problem);
        }

        /// <summary>
        /// Remove a problem from a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="problem">The problem to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveProblem(Project project, Problem problem)
        {
            return DeleteRelation(project, "problems", problem);
        }

        /// <summary>
        /// Remove all problems from a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllProblems(Project project)
        {
            return DeleteAllRelations(project, "problems");
        }

        #endregion

        #region Project tasks

        /// <summary>
        /// Get all related project tasks.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of project tasks.</returns>
        public List<ProjectTask> GetTasks(Project project, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(project, "tasks").Get(fieldNames);
        }

        /// <summary>
        /// Get all related project tasks.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="project">The project.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of project tasks.</returns>
        public List<ProjectTask> GetTasks(PredefinedTaskStatusFilter filter, Project project, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(project, $"tasks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Requests

        /// <summary>
        /// Get all request related to a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of requests.</returns>
        public List<Request> GetRequests(Project project, params string[] fieldNames)
        {
            return GetChildHandler<Request>(project, "requests").Get(fieldNames);
        }

        /// <summary>
        /// Get all request related to a project.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="project">The project.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of requests.</returns>
        public List<Request> GetRequests(PredefinedOpenCompletedFilter filter, Project project, params string[] fieldNames)
        {
            return GetChildHandler<Request>(project, $"requests/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a request to a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="request">The request to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddRequest(Project project, Request request)
        {
            return CreateRelation(project, "requests", request);
        }

        /// <summary>
        /// Remove a request from a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="request">The request to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveRequest(Project project, Request request)
        {
            return DeleteRelation(project, "requests", request);
        }

        /// <summary>
        /// Remove all requests from a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllRequests(Project project)
        {
            return DeleteAllRelations(project, "requests");
        }

        #endregion

        #region Risks

        /// <summary>
        /// Get all project risks.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of risks.</returns>
        public List<Risk> GetRisks(Project project, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(project, "risks").Get(fieldNames);
        }

        /// <summary>
        /// Get all project risks.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="project">The project.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of risks.</returns>
        public List<Risk> GetRisks(PredefinedOpenClosedFilter filter, Project project, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(project, $"risks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Archive, trash and restore

        /// <summary>
        /// Archive a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>The archived project.</returns>
        public Project Archive(Project project)
        {
            return GetChildHandler<Project>(project, "archive").Invoke("Post");
        }

        /// <summary>
        /// Trash a project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>The trashed project.</returns>
        public Project Trash(Project project)
        {
            return GetChildHandler<Project>(project, "trash").Invoke("Post");
        }

        /// <summary>
        /// Restore a project.
        /// </summary>
        /// <param name="archive">The archived project.</param>
        /// <returns>The restored project.</returns>
        public Project Restore(Archive archive)
        {
            return GetChildHandler<Project>(new Project() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        /// <summary>
        /// Restore a project.
        /// </summary>
        /// <param name="trash">The trashed project.</param>
        /// <returns>The restored project.</returns>
        public Project Restore(Trash trash)
        {
            return GetChildHandler<Project>(new Project() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
