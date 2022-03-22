using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class TaskHandler : BaseHandler<Task, PredefinedTaskFilter>
    {
        public TaskHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/tasks", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TaskHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/tasks", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Approvals

        public List<TaskTemplateApproval> GetApprovals(Task task, params string[] fieldNames)
        {
            return GetChildHandler<TaskTemplateApproval>(task, "approvals", SortOrder.None).Get(fieldNames);
        }

        public TaskTemplateApproval AddApproval(Task task, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(task, "approvals").Insert(taskTemplateApproval);
        }

        public TaskTemplateApproval UpdateApproval(Task task, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(task, "approvals").Update(taskTemplateApproval);
        }

        public bool RemoveApproval(Task task, TaskTemplateApproval taskTemplateApproval)
        {
            return GetChildHandler<TaskTemplateApproval>(task, "approvals").Delete(taskTemplateApproval);
        }

        public bool RemoveAllApprovals(Task task)
        {
            return GetChildHandler<Contact>(task, "approvals").DeleteAll();
        }

        #endregion

        #region Configuration items

        public List<ConfigurationItem> GetConfigurationItems(Task task, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(task, "cis").Get(fieldNames);
        }

        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, Task task, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(task, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddConfigurationItem(Task task, ConfigurationItem configurationItem)
        {
            return CreateRelation(task, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(Task task, ConfigurationItem configurationItem)
        {
            return DeleteRelation(task, "cis", configurationItem);
        }

        public bool RemoveConfigurationItems(Task task)
        {
            return DeleteAllRelations(task, "cis");
        }

        #endregion

        #region Notes

        public List<Note> GetNotes(Task task, params string[] fieldNames)
        {
            return GetChildHandler<Note>(task, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Predecessors

        public List<Task> GetPredecessors(Task task, params string[] fieldNames)
        {
            return GetChildHandler<Task>(task, "predecessors").Get(fieldNames);
        }

        public bool AddPredecessor(Task task, Task predecessor)
        {
            return CreateRelation(task, "predecessors", predecessor);
        }

        public bool RemovePredecessor(Task task, Task predecessor)
        {
            return DeleteRelation(task, "predecessors", predecessor);
        }

        public bool RemoveAllPredecessors(Task task)
        {
            return DeleteAllRelations(task, "predecessors");
        }

        #endregion

        #region Services instances

        public List<ServiceInstance> GetServiceInstances(Task task, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(task, "service_instances").Get(fieldNames);
        }

        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, Task task, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(task, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddServiceInstance(Task task, ConfigurationItem configurationItem)
        {
            return CreateRelation(task, "service_instances", configurationItem);
        }

        public bool RemoveServiceInstance(Task task, ConfigurationItem configurationItem)
        {
            return DeleteRelation(task, "service_instances", configurationItem);
        }

        public bool RemoveServiceInstances(Task task)
        {
            return DeleteAllRelations(task, "service_instances");
        }

        #endregion

        #region Successors

        public List<Task> GetSuccessors(Task task, params string[] fieldNames)
        {
            return GetChildHandler<Task>(task, "successors").Get(fieldNames);
        }

        public bool AddSuccessor(Task task, Task successor)
        {
            return CreateRelation(task, "successors", successor);
        }

        public bool RemoveSuccessor(Task task, Task successor)
        {
            return DeleteRelation(task, "successors", successor);
        }

        public bool RemoveAllSuccessors(Task task)
        {
            return DeleteAllRelations(task, "successors");
        }

        #endregion
    }
}
