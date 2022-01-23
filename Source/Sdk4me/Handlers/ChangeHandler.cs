using System.Collections.Generic;

namespace Sdk4me
{
    public class ChangeHandler : BaseHandler<Change, PredefinedChangeFilter>
    {
        public ChangeHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/changes", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ChangeHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/changes", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region notes

        public List<Note> GetNotes(Change change, params string[] attributeNames)
        {
            DefaultHandler<Note> handler = new DefaultHandler<Note>($"{this.URL}/{change.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.CreatedAt
            };
            return handler.Get(attributeNames);
        }

        #endregion

        #region requests

        public List<Request> GetRequests(Change change, params string[] attributeNames)
        {
            DefaultHandler<Request> handler = new DefaultHandler<Request>($"{this.URL}/{change.ID}/requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            DefaultHandler<Problem> handler = new DefaultHandler<Problem>($"{this.URL}/{change.ID}/problems", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            DefaultHandler<Task> handler = new DefaultHandler<Task>($"{this.URL}/{change.ID}/tasks", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region archive, trash and restore

        public Change Archive(Change change)
        {
            return CustomWebRequest($"{change.ID}/archive", "POST");
        }

        public Change Trash(Change change)
        {
            return CustomWebRequest($"{change.ID}/trash", "POST");
        }

        public Change Restore(Archive archive)
        {
            return CustomWebRequest($"{archive.Details.ID}/restore", "POST");
        }

        public Change Restore(Trash trash)
        {
            return CustomWebRequest($"{trash.Details.ID}/restore", "POST");
        }

        #endregion
    }
}
