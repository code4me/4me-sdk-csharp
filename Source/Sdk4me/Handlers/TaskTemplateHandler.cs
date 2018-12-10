using System.Collections.Generic;

namespace Sdk4me
{
    public class TaskTemplateHandler : BaseHandler<TaskTemplate>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/task_templates";
        private static readonly string productionUrl = "https://api.4me.com/v1/task_templates";

        public TaskTemplateHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TaskTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region change templates

        public List<ChangeTemplate> GetTaskTemplates(TaskTemplate taskTemplate, params string[] attributeNames)
        {
            BaseHandler<ChangeTemplate> handler = new BaseHandler<ChangeTemplate>($"{URL}/{taskTemplate.ID}/change_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(TaskTemplate taskTemplate, params string[] attributeNames)
        {
            BaseHandler<ConfigurationItem> handler = new BaseHandler<ConfigurationItem>($"{URL}/{taskTemplate.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            BaseHandler<ServiceInstance> handler = new BaseHandler<ServiceInstance>($"{URL}/{taskTemplate.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            BaseHandler<Task> handler = new BaseHandler<Task>($"{URL}/{taskTemplate.ID}/tasks", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region approvals

        public List<Approval> GetApprovals(TaskTemplate taskTemplate, params string[] attributeNames)
        {
            BaseHandler<Approval> handler = new BaseHandler<Approval>($"{URL}/{taskTemplate.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public Approval AddApproval(TaskTemplate taskTemplate, Approval approval)
        {
            BaseHandler<Approval> handler = new BaseHandler<Approval>($"{URL}/{taskTemplate.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.None;
            return handler.Insert(approval);
        }

        public Approval UpdateApproval(TaskTemplate taskTemplate, Approval approval)
        {
            BaseHandler<Approval> handler = new BaseHandler<Approval>($"{URL}/{taskTemplate.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            handler.SortOrder = SortOrder.None;
            return handler.Update(approval);
        }

        public bool RemoveApproval(TaskTemplate taskTemplate, Approval approval)
        {
            BaseHandler<Approval> handler = new BaseHandler<Approval>($"{URL}/{taskTemplate.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(approval);
        }

        public bool RemoveAllApprovals(TaskTemplate taskTemplate)
        {
            BaseHandler<Approval> handler = new BaseHandler<Approval>($"{URL}/{taskTemplate.ID}/approvals", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion
    }
}
