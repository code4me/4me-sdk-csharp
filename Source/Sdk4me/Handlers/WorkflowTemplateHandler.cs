using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class WorkflowTemplateHandler : BaseHandler<WorkflowTemplate, PredefinedEnabledDisabledFilter>
    {
        public WorkflowTemplateHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/workflow_templates", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public WorkflowTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/workflow_templates", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Workflow

        public List<Workflow> GetWorkflows(WorkflowTemplate workflowTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Workflow>(workflowTemplate, "workflows").Get(fieldNames);
        }

        public List<Workflow> GetWorkflows(PredefinedEnabledDisabledFilter filter, WorkflowTemplate workflowTemplate, params string[] fieldNames)
        {
            return GetChildHandler<Workflow>(workflowTemplate, $"workflows/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Phases

        public List<WorkflowPhase> GetPhases(WorkflowTemplate workflowTemplate, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowPhase>(workflowTemplate, "phases", SortOrder.None).Get(fieldNames);
        }

        public WorkflowPhase AddPhase(WorkflowTemplate workflowTemplate, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflowTemplate, "phases").Insert(workflowPhase);
        }

        public WorkflowPhase UpdatePhase(WorkflowTemplate workflowTemplate, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflowTemplate, "phases").Update(workflowPhase);
        }

        public bool DeletePhase(WorkflowTemplate workflowTemplate, WorkflowPhase workflowPhase)
        {
            return GetChildHandler<WorkflowPhase>(workflowTemplate, "phases").Delete(workflowPhase);
        }

        public bool DeleteAllPhases(WorkflowTemplate workflowTemplate)
        {
            return GetChildHandler<WorkflowPhase>(workflowTemplate, "phases").DeleteAll();
        }

        #endregion

        #region Task templates relations

        public List<TaskTemplateRelation> GetTaskTemplateRelations(WorkflowTemplate workflowTemplate, params string[] fieldNames)
        {
            return GetChildHandler<TaskTemplateRelation>(workflowTemplate, "task_template_relations").Get(fieldNames);
        }

        public TaskTemplateRelation AddTaskTemplateRelation(WorkflowTemplate workflowTemplate, TaskTemplateRelation taskTemplateReplation)
        {
            return GetChildHandler<TaskTemplateRelation>(workflowTemplate, "task_template_relations").Insert(taskTemplateReplation);
        }

        public TaskTemplateRelation UpdateTaskTemplateRelation(WorkflowTemplate workflowTemplate, TaskTemplateRelation taskTemplateReplation)
        {
            return GetChildHandler<TaskTemplateRelation>(workflowTemplate, "task_template_relations").Update(taskTemplateReplation);
        }

        public bool DeleteTaskTemplateRelation(WorkflowTemplate workflowTemplate, TaskTemplateRelation taskTemplateReplation)
        {
            return GetChildHandler<TaskTemplateRelation>(workflowTemplate, "task_template_relations").Delete(taskTemplateReplation);
        }

        public bool DeleteAllTaskTemplateRelations(WorkflowTemplate workflowTemplate)
        {
            return GetChildHandler<TaskTemplateRelation>(workflowTemplate, "task_template_relations").DeleteAll();
        }

        #endregion
    }
}
