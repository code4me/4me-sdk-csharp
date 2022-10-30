using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/task_templates/">task template</see> API endpoint.
    /// </summary>
    public class TaskTemplateHandler : BaseHandler<TaskTemplate, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me task template handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TaskTemplateHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/task_templates", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me task template handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TaskTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/task_templates", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Approvals

        /// <summary>
        /// Get all task template approvals.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of task template approvals.</returns>
        public List<TaskTemplateApproval> GetApprovals(TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<TaskTemplateApproval>(taskTemplate, "approvals", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add a task template approval.
        /// </summary>
        /// <param name="taskTemplate">The task.</param>
        /// <param name="taskTemplateApproval">The task template approval to add.</param>
        /// <returns>An updated task template approval.</returns>
        public TaskTemplateApproval AddApproval(TaskTemplate taskTemplate, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(taskTemplate, "approvals").Insert(taskTemplateApproval);
        }

        /// <summary>
        /// Update a task template approval.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="taskTemplateApproval">The task template approval to update.</param>
        /// <returns>An updated task template approval.</returns>
        public TaskTemplateApproval UpdateApproval(TaskTemplate taskTemplate, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(taskTemplate, "approvals").Update(taskTemplateApproval);
        }

        /// <summary>
        /// Delete a task template approval.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="taskTemplateApproval">The task template approval to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveApproval(TaskTemplate taskTemplate, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(taskTemplate, "approvals").Delete(taskTemplateApproval);
        }

        /// <summary>
        /// Delete all task template approvals.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllApprovals(TaskTemplate taskTemplate)
        {
            return GetChildHandler<Contact>(taskTemplate, "approvals").DeleteAll();
        }

        #endregion

        #region Workflow templates

        /// <summary>
        /// Get all related workflow templates.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflow templates.</returns>
        public List<WorkflowTemplate> GetWorkflowTemplates(TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowTemplate>(taskTemplate, "workflow_templates").Get(fieldNames);
        }

        /// <summary>
        /// Get all related workflow templates.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflow templates.</returns>
        public List<WorkflowTemplate> GetWorkflowTemplates(PredefinedEnabledDisabledFilter filter, TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowTemplate>(taskTemplate, $"workflow_templates/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Configuration items

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(taskTemplate, "cis").Get(fieldNames);
        }

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(taskTemplate, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a configuration item to a task template.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="configurationItem">The configuration item to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddConfigurationItem(TaskTemplate taskTemplate, ConfigurationItem configurationItem)
        {
            return CreateRelation(taskTemplate, "cis", configurationItem);
        }

        /// <summary>
        /// Remove a configuration item from a task template.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="configurationItem">The configuration item to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveConfigurationItem(TaskTemplate taskTemplate, ConfigurationItem configurationItem)
        {
            return DeleteRelation(taskTemplate, "cis", configurationItem);
        }

        /// <summary>
        /// Remove all configuration items from a task template.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveConfigurationItems(TaskTemplate taskTemplate)
        {
            return DeleteAllRelations(taskTemplate, "cis");
        }

        #endregion

        #region Services instances

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(taskTemplate, "service_instances").Get(fieldNames);
        }

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(taskTemplate, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a service instance to a task template.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="serviceInstance">The service instance to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddServiceInstance(TaskTemplate taskTemplate, ServiceInstance serviceInstance)
        {
            return CreateRelation(taskTemplate, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove a service instance from a task template.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="serviceInstance">The service instance to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveServiceInstance(TaskTemplate taskTemplate, ServiceInstance serviceInstance)
        {
            return DeleteRelation(taskTemplate, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove all service instances from a task template.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveServiceInstances(TaskTemplate taskTemplate)
        {
            return DeleteAllRelations(taskTemplate, "service_instances");
        }

        #endregion

        #region Tasks

        /// <summary>
        /// Get all tasks created with a task template.
        /// </summary>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of tasks.</returns>
        public List<Task> GetTasks(TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Task>(taskTemplate, "tasks").Get(fieldNames);
        }

        /// <summary>
        /// Get all tasks created with a task template.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="taskTemplate">The task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of tasks.</returns>
        public List<Task> GetMembers(PredefinedTaskStatusFilter filter, TaskTemplate taskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Task>(taskTemplate, $"tasks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
