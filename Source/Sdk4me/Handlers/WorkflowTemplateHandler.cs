using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/workflow_templates/">workflow template</see> API endpoint.
    /// </summary>
    public class WorkflowTemplateHandler : BaseHandler<WorkflowTemplate, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me workflow template handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public WorkflowTemplateHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/workflow_templates", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me workflow template handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public WorkflowTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/workflow_templates", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Workflow

        /// <summary>
        /// Get all related workflows.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflow templates.</returns>
        public List<Workflow> GetWorkflows(WorkflowTemplate workflowTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Workflow>(workflowTemplate, "workflows").Get(fieldNames);
        }

        /// <summary>
        /// Get all related workflows.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflow templates.</returns>
        public List<Workflow> GetWorkflows(PredefinedEnabledDisabledFilter filter, WorkflowTemplate workflowTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Workflow>(workflowTemplate, $"workflows/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Phases

        /// <summary>
        /// Get all workflow template phases.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflow template phases.</returns>
        public List<WorkflowPhase> GetPhases(WorkflowTemplate workflowTemplate, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowPhase>(workflowTemplate, "phases", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add a phase to a workflow template.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <param name="workflowPhase">The workflow phase to add.</param>
        /// <returns>An updated workflow phase.</returns>
        public WorkflowPhase AddPhase(WorkflowTemplate workflowTemplate, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflowTemplate, "phases").Insert(workflowPhase);
        }

        /// <summary>
        /// Update a phase of a workflow template.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <param name="workflowPhase">The workflow phase to update.</param>
        /// <returns>An updated workflow phase.</returns>
        public WorkflowPhase UpdatePhase(WorkflowTemplate workflowTemplate, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflowTemplate, "phases").Update(workflowPhase);
        }

        /// <summary>
        /// Delete a phase from a workflow template.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <param name="workflowPhase">The workflow phase to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeletePhase(WorkflowTemplate workflowTemplate, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflowTemplate, "phases").Delete(workflowPhase);
        }

        /// <summary>
        /// Delete all phases from a workflow template.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllPhases(WorkflowTemplate workflowTemplate)
        {
            return GetChildHandler<WorkflowPhase>(workflowTemplate, "phases").DeleteAll();
        }

        #endregion

        #region Task templates relations

        /// <summary>
        /// Get all workflow template relations.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflow template relations.</returns>
        public List<TaskTemplateRelation> GetTaskTemplateRelations(WorkflowTemplate workflowTemplate, params string[] fieldNames)
        {
            return GetChildHandler<TaskTemplateRelation>(workflowTemplate, "task_template_relations").Get(fieldNames);
        }

        /// <summary>
        /// Add a new workflow template relation.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <param name="taskTemplateReplation">The workflow template relation to add.</param>
        /// <returns>An updated workflow template relation.</returns>
        public TaskTemplateRelation AddTaskTemplateRelation(WorkflowTemplate workflowTemplate, TaskTemplateRelation taskTemplateReplation)
        {
            return GetChildHandler<TaskTemplateRelation>(workflowTemplate, "task_template_relations").Insert(taskTemplateReplation);
        }

        /// <summary>
        /// Update a new workflow template relation.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <param name="taskTemplateReplation">The workflow template relation to update.</param>
        /// <returns>An updated workflow template relation.</returns>
        public TaskTemplateRelation UpdateTaskTemplateRelation(WorkflowTemplate workflowTemplate, TaskTemplateRelation taskTemplateReplation)
        {
            return GetChildHandler<TaskTemplateRelation>(workflowTemplate, "task_template_relations").Update(taskTemplateReplation);
        }

        /// <summary>
        /// Delete a new workflow template relation.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <param name="taskTemplateReplation">The workflow template relation to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteTaskTemplateRelation(WorkflowTemplate workflowTemplate, TaskTemplateRelation taskTemplateReplation)
        {
            return GetChildHandler<TaskTemplateRelation>(workflowTemplate, "task_template_relations").Delete(taskTemplateReplation);
        }

        /// <summary>
        /// Delete all workflow template relations.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllTaskTemplateRelations(WorkflowTemplate workflowTemplate)
        {
            return GetChildHandler<TaskTemplateRelation>(workflowTemplate, "task_template_relations").DeleteAll();
        }

        #endregion
    }
}
