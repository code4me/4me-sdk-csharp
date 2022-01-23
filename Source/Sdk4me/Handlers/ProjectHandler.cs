using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectHandler : BaseHandler<Project, PredefinedProjectFilter>
    {
        public ProjectHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/projects", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProjectHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/projects", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region changes

        public List<Change> GetChanges(Project project, params string[] attributeNames)
        {
            DefaultHandler<Change> handler = new DefaultHandler<Change>($"{this.URL}/{project.ID}/changes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddChange(Project project, Change change)
        {
            return CreateRelation(project, "changes", change);
        }

        public bool RemoveChange(Project project, Change change)
        {
            return DeleteRelation(project, "changes", change);
        }

        public bool RemoveAllChanges(Project project)
        {
            return DeleteAllRelations(project, "changes");
        }

        #endregion

        #region notes

        public List<Note> GetNotes(Project project, params string[] attributeNames)
        {
            DefaultHandler<Note> handler = new DefaultHandler<Note>($"{this.URL}/{project.ID}/notes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.CreatedAt
            };
            return handler.Get(attributeNames);
        }

        #endregion

        #region phases

        public List<ProjectPhase> GetProjectPhases(Project project, params string[] attributeNames)
        {
            DefaultHandler<ProjectPhase> handler = new DefaultHandler<ProjectPhase>($"{this.URL}/{project.ID}/phases", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Get(attributeNames);
        }

        public bool AddProjectPhase(Project project, ProjectPhase projectPhase)
        {
            return CreateRelation(project, "phases", projectPhase);
        }

        public bool RemoveProjectPhase(Project project, ProjectPhase projectPhase)
        {
            return DeleteRelation(project, "phases", projectPhase);
        }

        public bool RemoveAllProjectPhases(Project project)
        {
            return DeleteAllRelations(project, "phases");
        }

        #endregion

        #region problems

        public List<Problem> GetProblems(Project project, params string[] attributeNames)
        {
            DefaultHandler<Problem> handler = new DefaultHandler<Problem>($"{this.URL}/{project.ID}/problems", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);

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

        #region tasks

        public List<ProjectTask> GetProjectTasks(Project project, params string[] attributeNames)
        {
            DefaultHandler<ProjectTask> handler = new DefaultHandler<ProjectTask>($"{this.URL}/{project.ID}/tasks", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region requests

        public List<Request> GetRequests(Project project, params string[] attributeNames)
        {
            DefaultHandler<Request> handler = new DefaultHandler<Request>($"{this.URL}/{project.ID}/requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
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

    }
}
