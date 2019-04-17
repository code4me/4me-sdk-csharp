using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectTaskHandler : BaseHandler<ProjectTask>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/project_tasks";
        private static readonly string productionUrl = "https://api.4me.com/v1/project_tasks";

        public ProjectTaskHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProjectTaskHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region assignment

        public List<ProjectTaskAssignment> GetAssignments(ProjectTask projectTask, params string[] attributeNames)
        {
            BaseHandler<ProjectTaskAssignment> handler = new BaseHandler<ProjectTaskAssignment>($"{URL}/{projectTask.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.None;
            return handler.Get(attributeNames);
        }

        public ProjectTaskAssignment AddAssignment(ProjectTask projectTask, ProjectTaskAssignment assignment)
        {
            BaseHandler<ProjectTaskAssignment> handler = new BaseHandler<ProjectTaskAssignment>($"{URL}/{projectTask.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.None;
            return handler.Insert(assignment);
        }

        public ProjectTaskAssignment UpdateAssignment(ProjectTask projectTask, ProjectTaskAssignment assignment)
        {
            BaseHandler<ProjectTaskAssignment> handler = new BaseHandler<ProjectTaskAssignment>($"{URL}/{projectTask.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.None;
            return handler.Update(assignment);
        }

        public bool RemoveAssignment(ProjectTask projectTask, ProjectTaskAssignment assignment)
        {
            BaseHandler<ProjectTaskAssignment> handler = new BaseHandler<ProjectTaskAssignment>($"{URL}/{projectTask.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(assignment);
        }

        public bool RemoveAllAssignments(ProjectTask projectTask)
        {
            BaseHandler<ProjectTaskAssignment> handler = new BaseHandler<ProjectTaskAssignment>($"{URL}/{projectTask.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion

        #region notes

        public List<Note> GetNotes(ProjectTask projectTask, params string[] attributeNames)
        {
            BaseHandler<Note> handler = new BaseHandler<Note>($"{URL}/{projectTask.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.CreatedAt;
            return handler.Get(attributeNames);
        }

        #endregion

        #region predecessors

        public List<ProjectTask> GetPredecessors(ProjectTask projectTask, params string[] attributeNames)
        {
            BaseHandler<ProjectTask> handler = new BaseHandler<ProjectTask>($"{URL}/{projectTask.ID}/predecessors", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddPredecessor(ProjectTask projectTask, ProjectTask predecessorProjectTask)
        {
            return CreateRelation(projectTask, "predecessors", predecessorProjectTask);
        }

        public bool RemovePredecessor(ProjectTask projectTask, ProjectTask predecessorProjectTask)
        {
            return DeleteRelation(projectTask, "predecessors", predecessorProjectTask);
        }

        public bool RemoveAllPredecessors(ProjectTask projectTask)
        {
            return DeleteAllRelations(projectTask, "predecessors");
        }

        #endregion

        #region successors

        public List<ProjectTask> GetSuccessors(ProjectTask projectTask, params string[] attributeNames)
        {
            BaseHandler<ProjectTask> handler = new BaseHandler<ProjectTask>($"{URL}/{projectTask.ID}/successors", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddSuccessor(ProjectTask projectTask, ProjectTask successorProjectTask)
        {
            return CreateRelation(projectTask, "predecessors", successorProjectTask);
        }

        public bool RemoveSuccessor(ProjectTask projectTask, ProjectTask successorProjectTask)
        {
            return DeleteRelation(projectTask, "predecessors", successorProjectTask);
        }

        public bool RemoveAllSuccessors(ProjectTask projectTask)
        {
            return DeleteAllRelations(projectTask, "predecessors");
        }

        #endregion
    }
}
