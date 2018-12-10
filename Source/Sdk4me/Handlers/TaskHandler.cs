using System.Collections.Generic;

namespace Sdk4me
{
    public class TaskHandler : BaseHandler<Task>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/tasks";
        private static readonly string productionUrl = "https://api.4me.com/v1/tasks";

        public TaskHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TaskHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region notes

        public List<Note> GetNotes(Task task, params string[] attributeNames)
        {
            BaseHandler<Note> handler = new BaseHandler<Note>($"{URL}/{task.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region configuration items

        public List<ConfigurationItem> GetPeople(Task task, params string[] attributeNames)
        {
            BaseHandler<ConfigurationItem> handler = new BaseHandler<ConfigurationItem>($"{URL}/{task.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            BaseHandler<Task> handler = new BaseHandler<Task>($"{URL}/{task.ID}/predecessors", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            BaseHandler<Task> handler = new BaseHandler<Task>($"{URL}/{task.ID}/successors", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
    }
}
