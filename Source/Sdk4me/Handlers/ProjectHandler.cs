using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectHandler : BaseHandler<Project, PredefinedProjectFilter>
    {
        public ProjectHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/projects", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProjectHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/projects", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Workflows

        public List<Workflow> GetWorkflows(Project project, params string[] fieldNames)
        {
            return GetChildHandler<Workflow>(project, "workflows").Get(fieldNames);
        }

        public bool AddWorkflow(Project project, Workflow workflow)
        {
            return CreateRelation(project, "workflows", workflow);
        }

        public bool RemoveWorkflow(Project project, Workflow workflow)
        {
            return DeleteRelation(project, "workflows", workflow);
        }

        public bool RemoveWorkflows(Project project)
        {
            return DeleteAllRelations(project, "workflows");
        }

        #endregion

        #region Notes

        public List<Note> GetNotes(Project project, params string[] fieldNames)
        {
            return GetChildHandler<Note>(project, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Phases

        public List<ProjectPhase> GetPhases(Project project)
        {
            return GetChildHandler<ProjectPhase>(project, "phases", SortOrder.None).Get("*");
        }

        public ProjectPhase AddPhase(Project project, ProjectPhase projectPhase)
        {
            return GetChildHandler<ProjectPhase>(project, "phases").Insert(projectPhase);
        }

        public ProjectPhase UpdatePhase(Project project, ProjectPhase projectPhase)
        {
            return GetChildHandler<ProjectPhase>(project, "phases").Update(projectPhase);
        }

        public bool DeletePhase(Project project, ProjectPhase projectPhase)
        {
            return GetChildHandler<ProjectPhase>(project, "phases").Delete(projectPhase);
        }

        public bool DeleteAllPhases(Project project)
        {
            return GetChildHandler<ProjectPhase>(project, "phases").DeleteAll();
        }

        #endregion

        #region Problems

        public List<Problem> GetProblems(Project project, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(project, "problems").Get(fieldNames);
        }

        public List<Problem> GetProblems(PredefinedWorkflowProblemFilter filter, Project project, params string[] fieldNames)
        {
            return GetChildHandler<Problem>(project, $"problems/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddProblem(Project project, Problem problem)
        {
            return CreateRelation(project, "problems", problem);
        }

        public bool RemoveProblem(Project project, Problem problem)
        {
            return DeleteRelation(project, "problems", problem);
        }

        public bool RemoveAllProblems(Project project)
        {
            return DeleteAllRelations(project, "problems");
        }

        #endregion

        #region Project tasks

        public List<ProjectTask> GetTasks(Project project, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(project, "tasks").Get(fieldNames);
        }

        public List<ProjectTask> GetTasks(PredefinedTaskStatusFilter filter, Project project, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(project, $"tasks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Requests

        public List<Request> GetRequests(Project project, params string[] fieldNames)
        {
            return GetChildHandler<Request>(project, "requests").Get(fieldNames);
        }

        public List<Request> GetRequests(PredefinedOpenCompletedFilter filter, Project project, params string[] fieldNames)
        {
            return GetChildHandler<Request>(project, $"requests/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddRequest(Project project, Request request)
        {
            return CreateRelation(project, "requests", request);
        }

        public bool RemoveRequest(Project project, Request request)
        {
            return DeleteRelation(project, "requests", request);
        }

        public bool RemoveAllRequests(Project project)
        {
            return DeleteAllRelations(project, "requests");
        }

        #endregion

        #region Risks

        public List<Risk> GetRisks(Project project, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(project, "risks").Get(fieldNames);
        }

        public List<Risk> GetRisks(PredefinedOpenClosedFilter filter, Project project, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(project, $"risks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Archive, trash and restore

        public Project Archive(Project project)
        {
            return GetChildHandler<Project>(project, "archive").Invoke("Post");
        }

        public Project Trash(Project project)
        {
            return GetChildHandler<Project>(project, "trash").Invoke("Post");
        }

        public Project Restore(Archive archive)
        {
            return GetChildHandler<Project>(new Project() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        public Project Restore(Trash trash)
        {
            return GetChildHandler<Project>(new Project() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
