using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectTaskTemplateHandler : BaseHandler<ProjectTaskTemplate, PredefinedEnabledDisabledFilter>
    {
        public ProjectTaskTemplateHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/project_task_templates", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProjectTaskTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/project_task_templates", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Assignments

        public List<ProjectTaskTemplateAssignment> GetAssignments(ProjectTaskTemplate projectTaskTemplate)
        {
            return GetChildHandler<ProjectTaskTemplateAssignment>(projectTaskTemplate, "assignments", SortOrder.None).Get("*");
        }

        public ProjectTaskTemplateAssignment AddAssignment(ProjectTaskTemplate projectTaskTemplate, ProjectTaskTemplateAssignment projectTaskTemplateAssignment)
        {
            return GetChildHandler<ProjectTaskTemplateAssignment>(projectTaskTemplate, "assignments").Insert(projectTaskTemplateAssignment);
        }

        public ProjectTaskTemplateAssignment UpdateAssignment(ProjectTaskTemplate projectTaskTemplate, ProjectTaskTemplateAssignment projectTaskTemplateAssignment)
        {
            return GetChildHandler<ProjectTaskTemplateAssignment>(projectTaskTemplate, "assignments").Update(projectTaskTemplateAssignment);
        }

        public bool DeleteAssignment(ProjectTaskTemplate projectTaskTemplate, ProjectTaskTemplateAssignment projectTaskTemplateAssignment)
        {
            return GetChildHandler<ProjectTaskTemplateAssignment>(projectTaskTemplate, "assignments").Delete(projectTaskTemplateAssignment);
        }

        public bool DeleteAllAssignments(ProjectTaskTemplate projectTaskTemplate)
        {
            return GetChildHandler<ProjectTaskTemplateAssignment>(projectTaskTemplate, "assignments").DeleteAll();
        }

        #endregion

        #region Project tasks

        public List<ProjectTask> GetProjectTasks(ProjectTaskTemplate projectTaskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(projectTaskTemplate, "tasks").Get(fieldNames);
        }

        public List<ProjectTask> GetProjectTasks(PredefinedTaskStatusFilter filter, ProjectTaskTemplate projectTaskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(projectTaskTemplate, $"tasks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Project template

        public List<ProjectTemplate> GetProjectTemplates(ProjectTaskTemplate projectTaskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTemplate>(projectTaskTemplate, "project_templates").Get(fieldNames);
        }

        public List<ProjectTemplate> GetProjectTemplates(PredefinedEnabledDisabledFilter filter, ProjectTaskTemplate projectTaskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTemplate>(projectTaskTemplate, $"project_templates/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
