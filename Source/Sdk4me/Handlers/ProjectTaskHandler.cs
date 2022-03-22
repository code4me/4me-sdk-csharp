using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectTaskHandler : BaseHandler<ProjectTask, PredefinedProjectTaskFilter>
    {
        public ProjectTaskHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/project_tasks", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProjectTaskHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/project_tasks", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Assignments

        public List<ProjectTaskAssignment> GetAssignments(ProjectTask projectTask)
        {
            return GetChildHandler<ProjectTaskAssignment>(projectTask, "assignments", SortOrder.None).Get("*");
        }

        public ProjectTaskAssignment AddAssignment(ProjectTask projectTask, ProjectTaskAssignment projectTaskAssignment)
        {
            return GetChildHandler<ProjectTaskAssignment>(projectTask, "assignments").Insert(projectTaskAssignment);
        }

        public ProjectTaskAssignment UpdateAssignment(ProjectTask projectTask, ProjectTaskAssignment projectTaskAssignment)
        {
            return GetChildHandler<ProjectTaskAssignment>(projectTask, "assignments").Update(projectTaskAssignment);
        }

        public bool DeleteAssignment(ProjectTask projectTask, ProjectTaskAssignment projectTaskAssignment)
        {
            return GetChildHandler<ProjectTaskAssignment>(projectTask, "assignments").Delete(projectTaskAssignment);
        }

        public bool DeleteAllAssignments(ProjectTask projectTask)
        {
            return GetChildHandler<ProjectTaskAssignment>(projectTask, "assignments").DeleteAll();
        }

        #endregion

        #region Notes

        public List<Note> GetNotes(ProjectTask projectTask, params string[] fieldNames)
        {
            return GetChildHandler<Note>(projectTask, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Predecessors

        public List<ProjectTask> GetPredecessors(ProjectTask projectTask, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(projectTask, "predecessors").Get(fieldNames);
        }

        public bool AddPredecessor(ProjectTask projectTask, ProjectTask predecessor)
        {
            return CreateRelation(projectTask, "predecessors", predecessor);
        }

        public bool RemovePredecessor(ProjectTask projectTask, ProjectTask predecessor)
        {
            return DeleteRelation(projectTask, "predecessors", predecessor);
        }

        public bool RemoveAllPredecessors(ProjectTask projectTask)
        {
            return DeleteAllRelations(projectTask, "predecessors");
        }

        #endregion

        #region Successors

        public List<ProjectTask> GetSuccessors(ProjectTask projectTask, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(projectTask, "successors").Get(fieldNames);
        }

        public bool AddSuccessor(ProjectTask projectTask, ProjectTask successor)
        {
            return CreateRelation(projectTask, "successors", successor);
        }

        public bool RemoveSuccessor(ProjectTask projectTask, ProjectTask successor)
        {
            return DeleteRelation(projectTask, "successors", successor);
        }

        public bool RemoveAllSuccessors(ProjectTask projectTask)
        {
            return DeleteAllRelations(projectTask, "successors");
        }

        #endregion
    }
}
