using System.Collections.Generic;

namespace Sdk4me
{
    public class TaskTemplateHandler : BaseHandler<TaskTemplate, PredefinedTaskTemplateFilter>
    {
        public TaskTemplateHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/task_templates",  authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TaskTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/task_templates",  authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region change templates

        public List<ChangeTemplate> GetChangeTemplates(TaskTemplate taskTemplate, params string[] attributeNames)
        {
            DefaultHandler<ChangeTemplate> handler = new DefaultHandler<ChangeTemplate>($"{URL}/{taskTemplate.ID}/change_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(TaskTemplate taskTemplate, params string[] attributeNames)
        {
            DefaultHandler<ConfigurationItem> handler = new DefaultHandler<ConfigurationItem>($"{URL}/{taskTemplate.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddConfigurationItem(TaskTemplate taskTemplate, ConfigurationItem configurationItem)
        {
            return CreateRelation(taskTemplate, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(TaskTemplate taskTemplate, ConfigurationItem configurationItem)
        {
            return DeleteRelation(taskTemplate, "cis", configurationItem);
        }
    
        public bool RemoveAllConfigurationItems(TaskTemplate taskTemplate)
        {
            return DeleteAllRelations(taskTemplate, "cis");
        }

        #endregion

        #region service instances

        public List<ServiceInstance> GetServiceInstances(TaskTemplate taskTemplate, params string[] attributeNames)
        {
            DefaultHandler<ServiceInstance> handler = new DefaultHandler<ServiceInstance>($"{URL}/{taskTemplate.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddServiceInstance(TaskTemplate taskTemplate, ServiceInstance serviceInstance)
        {
            return CreateRelation(taskTemplate, "service_instances", serviceInstance);
        }

        public bool RemoveServiceInstance(TaskTemplate taskTemplate, ServiceInstance serviceInstance)
        {
            return DeleteRelation(taskTemplate, "service_instances", serviceInstance);
        }

        public bool RemoveAllServiceInstances(TaskTemplate taskTemplate)
        {
            return DeleteAllRelations(taskTemplate, "service_instances");
        }

        #endregion

        #region tasks

        public List<Task> GetTasks(TaskTemplate taskTemplate, params string[] attributeNames)
        {
            DefaultHandler<Task> handler = new DefaultHandler<Task>($"{URL}/{taskTemplate.ID}/tasks", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region approvals

        public List<TaskTemplateApproval> GetApprovals(TaskTemplate taskTemplate, params string[] attributeNames)
        {
            DefaultHandler<TaskTemplateApproval> handler = new DefaultHandler<TaskTemplateApproval>($"{URL}/{taskTemplate.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Get(attributeNames);
        }

        public TaskTemplateApproval AddApproval(TaskTemplate taskTemplate, TaskTemplateApproval approval)
        {
            DefaultHandler<TaskTemplateApproval> handler = new DefaultHandler<TaskTemplateApproval>($"{URL}/{taskTemplate.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(approval);
        }

        public TaskTemplateApproval UpdateApproval(TaskTemplate taskTemplate, TaskTemplateApproval approval)
        {
            DefaultHandler<TaskTemplateApproval> handler = new DefaultHandler<TaskTemplateApproval>($"{URL}/{taskTemplate.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(approval);
        }

        public bool RemoveApproval(TaskTemplate taskTemplate, TaskTemplateApproval approval)
        {
            DefaultHandler<TaskTemplateApproval> handler = new DefaultHandler<TaskTemplateApproval>($"{URL}/{taskTemplate.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(approval);
        }

        public bool RemoveAllApprovals(TaskTemplate taskTemplate)
        {
            DefaultHandler<TaskTemplateApproval> handler = new DefaultHandler<TaskTemplateApproval>($"{URL}/{taskTemplate.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion
    }
}
