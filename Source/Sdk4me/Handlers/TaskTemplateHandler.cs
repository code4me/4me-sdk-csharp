using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class TaskTemplateHandler : BaseHandler<TaskTemplate, PredefinedEnabledDisabledFilter>
    {
        public TaskTemplateHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/task_templates", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TaskTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/task_templates", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Approvals

        public List<TaskTemplateApproval> GetApprovals(TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<TaskTemplateApproval>(taskTemplate, "approvals", SortOrder.None).Get(fieldNames);
        }

        public TaskTemplateApproval AddApproval(TaskTemplate taskTemplate, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(taskTemplate, "approvals").Insert(taskTemplateApproval);
        }

        public TaskTemplateApproval UpdateApproval(TaskTemplate taskTemplate, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(taskTemplate, "approvals").Update(taskTemplateApproval);
        }

        public bool RemoveApproval(TaskTemplate taskTemplate, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(taskTemplate, "approvals").Delete(taskTemplateApproval);
        }

        public bool RemoveAllApprovals(TaskTemplate taskTemplate)
        {
            return GetChildHandler<Contact>(taskTemplate, "approvals").DeleteAll();
        }

        #endregion

        #region Workflow templates

        public List<WorkflowTemplate> GetWorkflowTemplates(TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowTemplate>(taskTemplate, "workflow_templates").Get(fieldNames);
        }

        public List<WorkflowTemplate> GetWorkflowTemplates(PredefinedEnabledDisabledFilter filter, TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowTemplate>(taskTemplate, $"workflow_templates/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Configuration items

        public List<ConfigurationItem> GetConfigurationItems(TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(taskTemplate, "cis").Get(fieldNames);
        }

        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(taskTemplate, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddConfigurationItem(TaskTemplate taskTemplate, ConfigurationItem configurationItem)
        {
            return CreateRelation(taskTemplate, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(TaskTemplate taskTemplate, ConfigurationItem configurationItem)
        {
            return DeleteRelation(taskTemplate, "cis", configurationItem);
        }

        public bool RemoveConfigurationItems(TaskTemplate taskTemplate)
        {
            return DeleteAllRelations(taskTemplate, "cis");
        }

        #endregion

        #region Services instances

        public List<ServiceInstance> GetServiceInstances(TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(taskTemplate, "service_instances").Get(fieldNames);
        }

        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(taskTemplate, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddServiceInstance(TaskTemplate taskTemplate, ConfigurationItem configurationItem)
        {
            return CreateRelation(taskTemplate, "service_instances", configurationItem);
        }

        public bool RemoveServiceInstance(TaskTemplate taskTemplate, ConfigurationItem configurationItem)
        {
            return DeleteRelation(taskTemplate, "service_instances", configurationItem);
        }

        public bool RemoveServiceInstances(TaskTemplate taskTemplate)
        {
            return DeleteAllRelations(taskTemplate, "service_instances");
        }

        #endregion

        #region Tasks

        public List<Task> GetTasks(TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Task>(taskTemplate, "tasks").Get(fieldNames);
        }

        public List<Task> GetMembers(PredefinedTaskStatusFilter filter, TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Task>(taskTemplate, $"tasks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
