using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/workflows/">workflow</see> API endpoint.
    /// </summary>
    public class WorkflowHandler : BaseHandler<Workflow, PredefinedWorkflowFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me workflow handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public WorkflowHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/workflows", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me workflow handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public WorkflowHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/workflows", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Phases

        /// <summary>
        /// Get all workflow phases.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflow phases.</returns>
        public List<WorkflowPhase> GetPhases(Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowPhase>(workflow, "phases", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add a phase to a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="workflowPhase">The workflow phase to add.</param>
        /// <returns>An updated workflow phase.</returns>
        public WorkflowPhase AddPhase(Workflow workflow, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflow, "phases").Insert(workflowPhase);
        }

        /// <summary>
        /// Update a phase of a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="workflowPhase">The workflow phase to update.</param>
        /// <returns>An updated workflow phase.</returns>
        public WorkflowPhase UpdatePhase(Workflow workflow, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflow, "phases").Update(workflowPhase);
        }

        /// <summary>
        /// Delete a phase from a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="workflowPhase">The workflow phase to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeletePhase(Workflow workflow, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflow, "phases").Delete(workflowPhase);
        }

        /// <summary>
        /// Delete all phases from a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllPhases(Workflow workflow)
        {
            return GetChildHandler<WorkflowPhase>(workflow, "phases").DeleteAll();
        }

        #endregion

        #region Requests

        /// <summary>
        /// Get all requests.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of requests.</returns>
        public List<Request> GetRequests(Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Request>(workflow, "requests").Get(fieldNames);
        }

        /// <summary>
        /// Get all requests.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="workflow">The workflow.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of requests.</returns>
        public List<Request> GetRequests(PredefinedOpenCompletedFilter filter, Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Request>(workflow, $"requests/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a request to a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="request">The request to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddRequest(Workflow workflow, Request request)
        {
            return CreateRelation(workflow, "requests", request);
        }

        /// <summary>
        /// Remove a request from a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="request">The request to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveRequest(Workflow workflow, Request request)
        {
            return DeleteRelation(workflow, "requests", request);
        }

        /// <summary>
        /// Remove all requests from a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllRequests(Workflow workflow)
        {
            return DeleteAllRelations(workflow, "requests");
        }

        #endregion

        #region Problems

        /// <summary>
        /// Get all problems.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of problems.</returns>
        public List<Problem> GetProblems(Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(workflow, "problems").Get(fieldNames);
        }

        /// <summary>
        /// Get all problems.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="workflow">The workflow.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of problems.</returns>
        public List<Problem> GetProblems(PredefinedWorkflowProblemFilter filter, Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(workflow, $"problems/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a problem to a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="problem">The problem to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddProblem(Workflow workflow, Problem problem)
        {
            return CreateRelation(workflow, "problems", problem);
        }

        /// <summary>
        /// Remove a problem from a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="problem">The problem to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveProblem(Workflow workflow, Problem problem)
        {
            return DeleteRelation(workflow, "problems", problem);
        }

        /// <summary>
        /// Remove all problems from a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllProblems(Workflow workflow)
        {
            return DeleteAllRelations(workflow, "problems");
        }

        #endregion

        #region Notes

        /// <summary>
        /// Get all notes related to a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of notes.</returns>
        public List<Note> GetNotes(Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Note>(workflow, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Tasks

        /// <summary>
        /// Get all related tasks.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of tasks.</returns>
        public List<Task> GetTasks(Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Task>(workflow, "tasks").Get(fieldNames);
        }

        /// <summary>
        /// Get all related tasks.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="workflow">The workflow.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of tasks.</returns>
        public List<Task> GetTasks(PredefinedTaskStatusFilter filter, Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Task>(workflow, $"tasks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Archive, trash and restore

        /// <summary>
        /// Archive a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <returns>The archived workflow.</returns>
        public Workflow Archive(Workflow workflow)
        {
            return GetChildHandler<Workflow>(workflow, "archive").Invoke("Post");
        }

        /// <summary>
        /// Trash a workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <returns>The trashed workflow.</returns>
        public Workflow Trash(Workflow workflow)
        {
            return GetChildHandler<Workflow>(workflow, "trash").Invoke("Post");
        }

        /// <summary>
        /// Restore a workflow.
        /// </summary>
        /// <param name="archive">The archived workflow.</param>
        /// <returns>The restored workflow.</returns>
        public Workflow Restore(Archive archive)
        {
            return GetChildHandler<Workflow>(new Workflow() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        /// <summary>
        /// Restore a workflow.
        /// </summary>
        /// <param name="trash">The trashed workflow.</param>
        /// <returns>The restored workflow.</returns>
        public Workflow Restore(Trash trash)
        {
            return GetChildHandler<Workflow>(new Workflow() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
