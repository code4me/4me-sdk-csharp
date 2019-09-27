using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectTaskHandler : BaseHandler<ProjectTask, PredefinedProjectTaskFilter>
    {
        private const string qualityUrl = "https://api.4me.qa/v1/project_tasks";
        private const string productionUrl = "https://api.4me.com/v1/project_tasks";

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
            DefaultHandler<ProjectTaskAssignment> handler = new DefaultHandler<ProjectTaskAssignment>($"{URL}/{projectTask.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Get(attributeNames);
        }

        public ProjectTaskAssignment AddAssignment(ProjectTask projectTask, ProjectTaskAssignment assignment)
        {
            DefaultHandler<ProjectTaskAssignment> handler = new DefaultHandler<ProjectTaskAssignment>($"{URL}/{projectTask.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Insert(assignment);
        }

        public ProjectTaskAssignment UpdateAssignment(ProjectTask projectTask, ProjectTaskAssignment assignment)
        {
            DefaultHandler<ProjectTaskAssignment> handler = new DefaultHandler<ProjectTaskAssignment>($"{URL}/{projectTask.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Update(assignment);
        }

        public bool RemoveAssignment(ProjectTask projectTask, ProjectTaskAssignment assignment)
        {
            DefaultHandler<ProjectTaskAssignment> handler = new DefaultHandler<ProjectTaskAssignment>($"{URL}/{projectTask.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(assignment);
        }

        public bool RemoveAllAssignments(ProjectTask projectTask)
        {
            DefaultHandler<ProjectTaskAssignment> handler = new DefaultHandler<ProjectTaskAssignment>($"{URL}/{projectTask.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion

        #region notes

        public List<Note> GetNotes(ProjectTask projectTask, params string[] attributeNames)
        {
            DefaultHandler<Note> handler = new DefaultHandler<Note>($"{URL}/{projectTask.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.CreatedAt
            };
            return handler.Get(attributeNames);
        }

        #endregion

        #region predecessors

        public List<ProjectTask> GetPredecessors(ProjectTask projectTask, params string[] attributeNames)
        {
            DefaultHandler<ProjectTask> handler = new DefaultHandler<ProjectTask>($"{URL}/{projectTask.ID}/predecessors", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            DefaultHandler<ProjectTask> handler = new DefaultHandler<ProjectTask>($"{URL}/{projectTask.ID}/successors", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
