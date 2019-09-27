using System.Collections.Generic;

namespace Sdk4me
{
    public class ChangeTemplateHandler : BaseHandler<ChangeTemplate, PredefinedChangeTemplateFilter>
    {
        private const string qualityUrl = "https://api.4me.qa/v1/change_templates";
        private const string productionUrl = "https://api.4me.com/v1/change_templates";

        public ChangeTemplateHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ChangeTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region changes

        public List<Change> GetChanges(ChangeTemplate changeTemplate, params string[] attributeNames)
        {
            DefaultHandler<Change> handler = new DefaultHandler<Change>($"{URL}/{changeTemplate.ID}/changes", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region task templates

        public List<TaskTemplate> GetTaskTemplates(ChangeTemplate changeTemplate, params string[] attributeNames)
        {
            DefaultHandler<TaskTemplate> handler = new DefaultHandler<TaskTemplate>($"{URL}/{changeTemplate.ID}/task_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Get(attributeNames);
        }

        public bool AddTaskTemplate(ChangeTemplate changeTemplate, TaskTemplate taskTemplate)
        {
            return CreateRelation(changeTemplate, "task_templates", taskTemplate);
        }

        public bool RemoveTaskTemplate(ChangeTemplate changeTemplate, TaskTemplate taskTemplate)
        {
            return DeleteRelation(changeTemplate, "task_templates", taskTemplate);
        }

        public bool RemoveAllTaskTemplates(ChangeTemplate changeTemplate)
        {
            return DeleteAllRelations(changeTemplate, "task_templates");
        }

        #endregion


    }
}
