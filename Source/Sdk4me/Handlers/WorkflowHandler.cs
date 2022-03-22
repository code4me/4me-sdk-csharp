using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class WorkflowHandler : BaseHandler<Workflow, PredefinedWorkflowFilter>
    {
        public WorkflowHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/workflows", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public WorkflowHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/workflows", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Phases

        public List<WorkflowPhase> GetPhases(Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowPhase>(workflow, "phases", SortOrder.None).Get(fieldNames);
        }

        public WorkflowPhase AddPhase(Workflow workflow, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflow, "phases").Insert(workflowPhase);
        }

        public WorkflowPhase UpdatePhase(Workflow workflow, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflow, "phases").Update(workflowPhase);
        }

        public bool DeletePhase(Workflow workflow, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflow, "phases").Delete(workflowPhase);
        }

        public bool DeleteAllPhases(Workflow workflow)
        {
            return GetChildHandler<WorkflowPhase>(workflow, "phases").DeleteAll();
        }

        #endregion

        #region Requests

        public List<Request> GetRequests(Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Request>(workflow, "requests").Get(fieldNames);
        }

        public List<Request> GetRequests(PredefinedOpenCompletedFilter filter, Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Request>(workflow, $"requests/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddRequest(Workflow workflow, Request request)
        {
            return CreateRelation(workflow, "requests", request);
        }

        public bool RemoveRequest(Workflow workflow, Request request)
        {
            return DeleteRelation(workflow, "requests", request);
        }

        public bool RemoveAllRequests(Workflow workflow)
        {
            return DeleteAllRelations(workflow, "requests");
        }

        #endregion

        #region Problems

        public List<Problem> GetProblems(Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(workflow, "problems").Get(fieldNames);
        }

        public List<Problem> GetProblems(PredefinedWorkflowProblemFilter filter, Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(workflow, $"problems/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddProblem(Workflow workflow, Problem problem)
        {
            return CreateRelation(workflow, "problems", problem);
        }

        public bool RemoveProblem(Workflow workflow, Problem problem)
        {
            return DeleteRelation(workflow, "problems", problem);
        }

        public bool RemoveAllProblems(Workflow workflow)
        {
            return DeleteAllRelations(workflow, "problems");
        }

        #endregion

        #region Notes

        public List<Note> GetNotes(Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Note>(workflow, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Tasks

        public List<Task> GetTasks(Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Task>(workflow, "tasks").Get(fieldNames);
        }

        public List<Task> GetTasks(PredefinedTaskStatusFilter filter, Workflow workflow, params string[] fieldNames)
        {
            return GetChildHandler<Task>(workflow, $"tasks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Archive, trash and restore

        public Workflow Archive(Workflow workflow)
        {
            return GetChildHandler<Workflow>(workflow, "archive").Invoke("Post");
        }

        public Workflow Trash(Workflow workflow)
        {
            return GetChildHandler<Workflow>(workflow, "trash").Invoke("Post");
        }

        public Workflow Restore(Archive archive)
        {
            return GetChildHandler<Workflow>(new Workflow() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        public Workflow Restore(Trash trash)
        {
            return GetChildHandler<Workflow>(new Workflow() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion

    }
}
