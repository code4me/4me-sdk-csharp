using System.Collections.Generic;

namespace Sdk4me
{
    public class TaskHandler : BaseHandler<Task, PredefinedTaskFilter>
    {
        public TaskHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/tasks",  authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TaskHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/tasks",  authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region notes

        public List<Note> GetNotes(Task task, params string[] attributeNames)
        {
            DefaultHandler<Note> handler = new DefaultHandler<Note>($"{URL}/{task.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.CreatedAt
            };
            return handler.Get(attributeNames);
        }

        #endregion

        #region configuration items

        public List<ConfigurationItem> GetPeople(Task task, params string[] attributeNames)
        {
            DefaultHandler<ConfigurationItem> handler = new DefaultHandler<ConfigurationItem>($"{URL}/{task.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddConfigurationItem(Task task, ConfigurationItem configurationItem)
        {
            return CreateRelation(task, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(Task task, ConfigurationItem configurationItem)
        {
            return DeleteRelation(task, "cis", configurationItem);
        }

        public bool RemoveAllConfigurationItems(Task task)
        {
            return DeleteAllRelations(task, "cis");
        }

        #endregion

        #region predecessors

        public List<Task> GetPredecessors(Task task, params string[] attributeNames)
        {
            DefaultHandler<Task> handler = new DefaultHandler<Task>($"{URL}/{task.ID}/predecessors", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddPredecessor(Task task, Task predecessorTask)
        {
            return CreateRelation(task, "predecessors", predecessorTask);
        }

        public bool RemovePredecessor(Task task, Task predecessorTask)
        {
            return DeleteRelation(task, "predecessors", predecessorTask);
        }

        public bool RemoveAllPredecessors(Task task)
        {
            return DeleteAllRelations(task, "predecessors");
        }

        #endregion

        #region successors

        public List<Task> GetSuccessors(Task task, params string[] attributeNames)
        {
            DefaultHandler<Task> handler = new DefaultHandler<Task>($"{URL}/{task.ID}/successors", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddSuccessor(Task task, Task successorTask)
        {
            return CreateRelation(task, "predecessors", successorTask);
        }

        public bool RemoveSuccessor(Task task, Task successorTask)
        {
            return DeleteRelation(task, "predecessors", successorTask);
        }

        public bool RemoveAllSuccessors(Task task)
        {
            return DeleteAllRelations(task, "predecessors");
        }

        #endregion

        #region approval

        public List<TaskApproval> GetApprovals(Task task, params string[] attributeNames)
        {
            DefaultHandler<TaskApproval> handler = new DefaultHandler<TaskApproval>($"{URL}/{task.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Get(attributeNames);
        }

        public TaskApproval AddApproval(Task task, TaskApproval approval)
        {
            DefaultHandler<TaskApproval> handler = new DefaultHandler<TaskApproval>($"{URL}/{task.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(approval);
        }

        public TaskApproval UpdateApproval(Task task, TaskApproval approval)
        {
            DefaultHandler<TaskApproval> handler = new DefaultHandler<TaskApproval>($"{URL}/{task.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(approval);
        }

        public bool RemoveApproval(Task task, TaskApproval approval)
        {
            DefaultHandler<TaskApproval> handler = new DefaultHandler<TaskApproval>($"{URL}/{task.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(approval);
        }

        public bool RemoveAllApprovals(Task task)
        {
            DefaultHandler<TaskApproval> handler = new DefaultHandler<TaskApproval>($"{URL}/{task.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion
    }
}
