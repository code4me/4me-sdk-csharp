using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectTemplateHandler : BaseHandler<ProjectTemplate>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/project_templates";
        private static readonly string productionUrl = "https://api.4me.com/v1/project_templates";

        public ProjectTemplateHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProjectTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region phases

        public List<ProjectTemplatePhase> GetProjectPhases(ProjectTemplate projectTemplate, params string[] attributeNames)
        {
            BaseHandler<ProjectTemplatePhase> handler = new BaseHandler<ProjectTemplatePhase>($"{URL}/{projectTemplate.ID}/phases", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.None;
            return handler.Get(attributeNames);
        }

        public bool AddProjectPhase(ProjectTemplate projectTemplate, ProjectTemplatePhase projectTemplatePhase)
        {
            return CreateRelation(projectTemplate, "phases", projectTemplatePhase);
        }

        public bool RemoveProjectPhase(ProjectTemplate projectTemplate, ProjectTemplatePhase projectTemplatePhase)
        {
            return DeleteRelation(projectTemplate, "phases", projectTemplatePhase);
        }

        public bool RemoveAllProjectPhases(ProjectTemplate projectTemplate)
        {
            return DeleteAllRelations(projectTemplate, "phases");
        }

        #endregion

        #region project tasks templates

        public List<ProjectTaskTemplateReference> GetProjectTaskTemplates(ProjectTemplate projectTemplate, params string[] attributeNames)
        {
            BaseHandler<ProjectTaskTemplateReference> handler = new BaseHandler<ProjectTaskTemplateReference>($"{URL}/{projectTemplate.ID}/task_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.None;
            return handler.Get(attributeNames);
        }

        public ProjectTaskTemplateReference AddProjectTaskTemplate(ProjectTemplate projectTemplate, ProjectTaskTemplate projectTaskTemplate, ProjectTemplatePhase projectTemplatePhase)
        {
            BaseHandler<ProjectTaskTemplateReference> handler = new BaseHandler<ProjectTaskTemplateReference>($"{URL}/{projectTemplate.ID}/task_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.CustomWebRequest($"?task_template_id={projectTaskTemplate.ID}&phase_name={projectTemplatePhase.Name}", "POST");
        }

        public ProjectTaskTemplateReference UpdateProjectTaskTemplate(ProjectTemplate projectTemplate, ProjectTaskTemplateReference projectTaskTemplateReference, ProjectTemplatePhase projectTemplatePhase)
        {
            BaseHandler<ProjectTaskTemplateReference> handler = new BaseHandler<ProjectTaskTemplateReference>($"{URL}/{projectTemplate.ID}/task_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.CustomWebRequest($"/{projectTaskTemplateReference.ID}?phase_name={projectTemplatePhase.Name}", "PATCH");
        }

        public bool DeleteProjectTaskTemplate(ProjectTemplate projectTemplate, ProjectTaskTemplateReference projectTaskTemplateReference)
        {
            BaseHandler<ProjectTaskTemplateReference> handler = new BaseHandler<ProjectTaskTemplateReference>($"{URL}/{projectTemplate.ID}/task_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(projectTaskTemplateReference);
        }

        public bool DeleteAllProjectTaskTemplates(ProjectTemplate projectTemplate)
        {
            BaseHandler<ProjectTaskTemplateReference> handler = new BaseHandler<ProjectTaskTemplateReference>($"{URL}/{projectTemplate.ID}/task_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion


    }
}
