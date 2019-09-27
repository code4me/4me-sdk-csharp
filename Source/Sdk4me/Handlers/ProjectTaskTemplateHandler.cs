using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectTaskTemplateHandler : BaseHandler<ProjectTaskTemplate, PredefinedProjectTaskTemplateFilter>
    {
        private const string qualityUrl = "https://api.4me.qa/v1/project_task_templates";
        private const string productionUrl = "https://api.4me.com/v1/project_task_templates";

        public ProjectTaskTemplateHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProjectTaskTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region assignment

        public List<ProjectTaskTemplateAssignment> GetAssignments(ProjectTaskTemplate projectTaskTemplate, params string[] attributeNames)
        {
            DefaultHandler<ProjectTaskTemplateAssignment> handler = new DefaultHandler<ProjectTaskTemplateAssignment>($"{URL}/{projectTaskTemplate.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Get(attributeNames);
        }

        public ProjectTaskTemplateAssignment AddAssignment(ProjectTaskTemplate projectTaskTemplate, ProjectTaskTemplateAssignment assignment)
        {
            DefaultHandler<ProjectTaskTemplateAssignment> handler = new DefaultHandler<ProjectTaskTemplateAssignment>($"{URL}/{projectTaskTemplate.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Insert(assignment);
        }

        public ProjectTaskTemplateAssignment UpdateAssignment(ProjectTaskTemplate projectTaskTemplate, ProjectTaskTemplateAssignment assignment)
        {
            DefaultHandler<ProjectTaskTemplateAssignment> handler = new DefaultHandler<ProjectTaskTemplateAssignment>($"{URL}/{projectTaskTemplate.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Update(assignment);
        }

        public bool RemoveAssignment(ProjectTaskTemplate projectTaskTemplate, ProjectTaskTemplateAssignment assignment)
        {
            DefaultHandler<ProjectTaskTemplateAssignment> handler = new DefaultHandler<ProjectTaskTemplateAssignment>($"{URL}/{projectTaskTemplate.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(assignment);
        }

        public bool RemoveAllAssignments(ProjectTaskTemplate projectTaskTemplate)
        {
            DefaultHandler<ProjectTaskAssignment> handler = new DefaultHandler<ProjectTaskAssignment>($"{URL}/{projectTaskTemplate.ID}/assignments", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion

        #region project tasks

        public List<ProjectTask> GetProjectTasks(ProjectTaskTemplate projectTaskTemplate, params string[] attributeNames)
        {
            DefaultHandler<ProjectTask> handler = new DefaultHandler<ProjectTask>($"{URL}/{projectTaskTemplate.ID}/tasks", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region project templates

        public List<ProjectTemplate> GetProjectTemplates(ProjectTaskTemplate projectTaskTemplate, params string[] attributeNames)
        {
            DefaultHandler<ProjectTemplate> handler = new DefaultHandler<ProjectTemplate>($"{URL}/{projectTaskTemplate.ID}/project_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
