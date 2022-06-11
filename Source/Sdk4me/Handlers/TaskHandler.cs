using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/tasks/">task</see> API endpoint.
    /// </summary>
    public class TaskHandler : BaseHandler<Task, PredefinedTaskFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me task handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TaskHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/tasks", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me task handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public TaskHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/tasks", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Approvals

        /// <summary>
        /// Get all task approvals.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of task approvals.</returns>
        public List<TaskTemplateApproval> GetApprovals(Task task, params string[] fieldNames)
        {
            return GetChildHandler<TaskTemplateApproval>(task, "approvals", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add a task approval.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="taskTemplateApproval">The task approval to add.</param>
        /// <returns>An updated task approval.</returns>
        public TaskTemplateApproval AddApproval(Task task, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(task, "approvals").Insert(taskTemplateApproval);
        }

        /// <summary>
        /// Update a task approval.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="taskTemplateApproval">The task approval to update.</param>
        /// <returns>An updated task approval.</returns>
        public TaskTemplateApproval UpdateApproval(Task task, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(task, "approvals").Update(taskTemplateApproval);
        }

        /// <summary>
        /// Delete a task approval.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="taskTemplateApproval">The task approval to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveApproval(Task task, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(task, "approvals").Delete(taskTemplateApproval);
        }

        /// <summary>
        /// Delete all task approvals.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllApprovals(Task task)
        {
            return GetChildHandler<Contact>(task, "approvals").DeleteAll();
        }

        #endregion

        #region Configuration items

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(Task task, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(task, "cis").Get(fieldNames);
        }

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="task">The task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, Task task, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(task, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a configuration item to a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="configurationItem">The configuration item to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddConfigurationItem(Task task, ConfigurationItem configurationItem)
        {
            return CreateRelation(task, "cis", configurationItem);
        }

        /// <summary>
        /// Remove a configuration item from a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="configurationItem">The configuration item to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveConfigurationItem(Task task, ConfigurationItem configurationItem)
        {
            return DeleteRelation(task, "cis", configurationItem);
        }

        /// <summary>
        /// Remove all configuration items from a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveConfigurationItems(Task task)
        {
            return DeleteAllRelations(task, "cis");
        }

        #endregion

        #region Notes

        /// <summary>
        /// Get all notes related to a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of notes.</returns>
        public List<Note> GetNotes(Task task, params string[] fieldNames)
        {
            return GetChildHandler<Note>(task, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Predecessors

        /// <summary>
        /// Get all predecessors of a task,
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of tasks.</returns>
        public List<Task> GetPredecessors(Task task, params string[] fieldNames)
        {
            return GetChildHandler<Task>(task, "predecessors").Get(fieldNames);
        }

        /// <summary>
        /// Add a predecessor to a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="predecessor">The predecessor to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddPredecessor(Task task, Task predecessor)
        {
            return CreateRelation(task, "predecessors", predecessor);
        }

        /// <summary>
        /// Remove a predecessor from a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="predecessor">The predecessor to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemovePredecessor(Task task, Task predecessor)
        {
            return DeleteRelation(task, "predecessors", predecessor);
        }

        /// <summary>
        /// Remove all predecessor from a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllPredecessors(Task task)
        {
            return DeleteAllRelations(task, "predecessors");
        }

        #endregion

        #region Services instances

        /// <summary>
        /// Get all service instances of a task,
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(Task task, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(task, "service_instances").Get(fieldNames);
        }

        /// <summary>
        /// Get all service instances of a task,
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="task">The task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, Task task, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(task, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a service instance to a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="serviceInstance">The service instance to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddServiceInstance(Task task, ServiceInstance serviceInstance)
        {
            return CreateRelation(task, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove a service instance from a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="serviceInstance">The service instance to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveServiceInstance(Task task, ServiceInstance serviceInstance)
        {
            return DeleteRelation(task, "service_instances", serviceInstance);
        }

        /// <summary>
        /// Remove all service instances from a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveServiceInstances(Task task)
        {
            return DeleteAllRelations(task, "service_instances");
        }

        #endregion

        #region Successors

        /// <summary>
        /// Get all successors of a task,
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of tasks.</returns>
        public List<Task> GetSuccessors(Task task, params string[] fieldNames)
        {
            return GetChildHandler<Task>(task, "successors").Get(fieldNames);
        }

        /// <summary>
        /// Add a successor to a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="successor">The successor to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddSuccessor(Task task, Task successor)
        {
            return CreateRelation(task, "successors", successor);
        }

        /// <summary>
        /// Remove a successor from a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="successor">The successor to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveSuccessor(Task task, Task successor)
        {
            return DeleteRelation(task, "successors", successor);
        }

        /// <summary>
        /// Remove all successors from a task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllSuccessors(Task task)
        {
            return DeleteAllRelations(task, "successors");
        }

        #endregion
    }
}
