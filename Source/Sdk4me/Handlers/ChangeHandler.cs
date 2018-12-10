using System.Collections.Generic;

namespace Sdk4me
{
    public class ChangeHandler : BaseHandler<Change>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/changes";
        private static readonly string productionUrl = "https://api.4me.com/v1/changes";

        public ChangeHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ChangeHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region notes

        public List<Note> GetNotes(Change change, params string[] attributeNames)
        {
            BaseHandler<Note> handler = new BaseHandler<Note>($"{URL}/{change.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.CreatedAtAndID;
            return handler.Get(attributeNames);
        }

        #endregion

        #region requests

        public List<Request> GetRequests(Change change, params string[] attributeNames)
        {
            BaseHandler<Request> handler = new BaseHandler<Request>($"{URL}/{change.ID}/requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);

        }

        public bool AddRequest(Change change, Request request)
        {
            return CreateRelation(change, "requests", request);
        }

        public bool RemoveRequest(Change change, Request request)
        {
            return DeleteRelation(change, "requests", request);
        }

        public bool RemoveAllRequests(Change change)
        {
            return DeleteAllRelations(change, "requests");
        }


        #endregion

        #region problems

        public List<Problem> GetProblems(Change change, params string[] attributeNames)
        {
            BaseHandler<Problem> handler = new BaseHandler<Problem>($"{URL}/{change.ID}/problems", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);

        }

        public bool AddProblem(Change change, Problem problem)
        {
            return CreateRelation(change, "problems", problem);
        }

        public bool RemoveProblem(Change change, Problem problem)
        {
            return DeleteRelation(change, "problems", problem);
        }

        public bool RemoveAllProblems(Change change)
        {
            return DeleteAllRelations(change, "problems");
        }

        #endregion

        #region tasks
    
        public List<Task> GetTasks(Change change, params string[] attributeNames)
        {
            BaseHandler<Task> handler = new BaseHandler<Task>($"{URL}/{change.ID}/tasks", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

    }
}
