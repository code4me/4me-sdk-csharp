using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/project_task_templates/">project task template</see> API endpoint.
    /// </summary>
    public class ProjectTaskTemplateHandler : BaseHandler<ProjectTaskTemplate, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me project task template handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ProjectTaskTemplateHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/project_task_templates", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me project task template handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ProjectTaskTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/project_task_templates", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Assignments

        /// <summary>
        /// Get all project task template assignments.
        /// </summary>
        /// <param name="projectTaskTemplate">The project task template.</param>
        /// <returns>A collection of project task template assignments.</returns>
        public List<ProjectTaskTemplateAssignment> GetAssignments(ProjectTaskTemplate projectTaskTemplate)
        {
            return GetChildHandler<ProjectTaskTemplateAssignment>(projectTaskTemplate, "assignments", SortOrder.None).Get("*");
        }

        /// <summary>
        /// Add a project task template assignment.
        /// </summary>
        /// <param name="projectTaskTemplate">The project task template.</param>
        /// <param name="projectTaskTemplateAssignment">The project task template assignment to add.</param>
        /// <returns>The updated project task template assignment.</returns>
        public ProjectTaskTemplateAssignment AddAssignment(ProjectTaskTemplate projectTaskTemplate, ProjectTaskTemplateAssignment projectTaskTemplateAssignment)
        {
            return GetChildHandler<ProjectTaskTemplateAssignment>(projectTaskTemplate, "assignments").Insert(projectTaskTemplateAssignment);
        }

        /// <summary>
        /// Update a project task template assignment.
        /// </summary>
        /// <param name="projectTaskTemplate">The project task template.</param>
        /// <param name="projectTaskTemplateAssignment">The project task template assignment to update.</param>
        /// <returns>The updated project task template assignment.</returns>
        public ProjectTaskTemplateAssignment UpdateAssignment(ProjectTaskTemplate projectTaskTemplate, ProjectTaskTemplateAssignment projectTaskTemplateAssignment)
        {
            return GetChildHandler<ProjectTaskTemplateAssignment>(projectTaskTemplate, "assignments").Update(projectTaskTemplateAssignment);
        }

        /// <summary>
        /// Remove a project task template assignment.
        /// </summary>
        /// <param name="projectTaskTemplate">The project task template.</param>
        /// <param name="projectTaskTemplateAssignment">The project task template assignment to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAssignment(ProjectTaskTemplate projectTaskTemplate, ProjectTaskTemplateAssignment projectTaskTemplateAssignment)
        {
            return GetChildHandler<ProjectTaskTemplateAssignment>(projectTaskTemplate, "assignments").Delete(projectTaskTemplateAssignment);
        }

        /// <summary>
        /// Remove all project task template assignments.
        /// </summary>
        /// <param name="projectTaskTemplate">The project task template.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllAssignments(ProjectTaskTemplate projectTaskTemplate)
        {
            return GetChildHandler<ProjectTaskTemplateAssignment>(projectTaskTemplate, "assignments").DeleteAll();
        }

        #endregion

        #region Project tasks

        /// <summary>
        /// Get all related project tasks.
        /// </summary>
        /// <param name="projectTaskTemplate">The project task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of project tasks.</returns>
        public List<ProjectTask> GetProjectTasks(ProjectTaskTemplate projectTaskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(projectTaskTemplate, "tasks").Get(fieldNames);
        }

        /// <summary>
        /// Get all related project tasks.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="projectTaskTemplate">The project task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of project tasks.</returns>
        public List<ProjectTask> GetProjectTasks(PredefinedTaskStatusFilter filter, ProjectTaskTemplate projectTaskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTask>(projectTaskTemplate, $"tasks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Project template

        /// <summary>
        /// Get all related project templates.
        /// </summary>
        /// <param name="projectTaskTemplate">The project task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of projects templates.</returns>
        public List<ProjectTemplate> GetProjectTemplates(ProjectTaskTemplate projectTaskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTemplate>(projectTaskTemplate, "project_templates").Get(fieldNames);
        }

        /// <summary>
        /// Get all related project templates.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="projectTaskTemplate">The project task template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of projects templates.</returns>
        public List<ProjectTemplate> GetProjectTemplates(PredefinedEnabledDisabledFilter filter, ProjectTaskTemplate projectTaskTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTemplate>(projectTaskTemplate, $"project_templates/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
