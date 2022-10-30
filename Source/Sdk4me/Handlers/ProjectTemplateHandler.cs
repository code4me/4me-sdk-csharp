using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/project_templates/">project template</see> API endpoint.
    /// </summary>
    public class ProjectTemplateHandler : BaseHandler<ProjectTemplate, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me project template handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ProjectTemplateHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/project_templates", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me project template handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ProjectTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/project_templates", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Phases

        /// <summary>
        /// Get all project template phases.
        /// </summary>
        /// <param name="projectTemplate">The project template.</param>
        /// <returns>A collection of project template phases.</returns>
        public List<ProjectTemplatePhase> GetPhases(ProjectTemplate projectTemplate)
        {
            return GetChildHandler<ProjectTemplatePhase>(projectTemplate, "phases", SortOrder.None).Get("*");
        }

        /// <summary>
        /// Add a project template phase.
        /// </summary>
        /// <param name="projectTemplate">The project template.</param>
        /// <param name="projectTemplatePhase">The project template phase to add.</param>
        /// <returns>An update project template phase.</returns>
        public ProjectTemplatePhase AddPhase(ProjectTemplate projectTemplate, ProjectTemplatePhase projectTemplatePhase)
        {
            return GetChildHandler<ProjectTemplatePhase>(projectTemplate, "phases").Insert(projectTemplatePhase);
        }

        /// <summary>
        /// Update a project template phase.
        /// </summary>
        /// <param name="projectTemplate">The project template.</param>
        /// <param name="projectTemplatePhase">The project template phase to update.</param>
        /// <returns>An update project template phase.</returns>
        public ProjectTemplatePhase UpdatePhase(ProjectTemplate projectTemplate, ProjectTemplatePhase projectTemplatePhase)
        {
            return GetChildHandler<ProjectTemplatePhase>(projectTemplate, "phases").Update(projectTemplatePhase);
        }

        /// <summary>
        /// Remove a project template phase.
        /// </summary>
        /// <param name="projectTemplate">The project template.</param>
        /// <param name="projectTemplatePhase">The project template phase to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeletePhase(ProjectTemplate projectTemplate, ProjectTemplatePhase projectTemplatePhase)
        {
            return GetChildHandler<ProjectTemplatePhase>(projectTemplate, "phases").Delete(projectTemplatePhase);
        }

        /// <summary>
        /// Remove all project template phases.
        /// </summary>
        /// <param name="projectTemplate">The project template.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllPhases(ProjectTemplate projectTemplate)
        {
            return GetChildHandler<ProjectTemplatePhase>(projectTemplate, "phases").DeleteAll();
        }

        #endregion

        #region Project task templates

        /// <summary>
        /// Get all project template tasks.
        /// </summary>
        /// <param name="projectTemplate">The project template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of project task template.</returns>
        public List<ProjectTaskTemplateRelation> GetProjectTaskTemplates(ProjectTemplate projectTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, "task_templates", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Get all project template tasks.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="projectTemplate">The project template.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of project task template.</returns>
        public List<ProjectTaskTemplateRelation> GetProjectTaskTemplates(PredefinedEnabledDisabledFilter filter, ProjectTemplate projectTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, $"task_templates/{filter.To4meString()}", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add a project task template to a project template.
        /// </summary>
        /// <param name="projectTemplate">The project template.</param>
        /// <param name="projectTaskTemplateRelation">The project task template relation object to add.</param>
        /// <returns>An updated project task template relation object.</returns>
        public ProjectTaskTemplateRelation AddProjectTaskTemplate(ProjectTemplate projectTemplate, ProjectTaskTemplateRelation projectTaskTemplateRelation)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, "task_templates").Insert(projectTaskTemplateRelation);
        }

        /// <summary>
        /// Update a project task template to a project template.
        /// </summary>
        /// <param name="projectTemplate">The project template.</param>
        /// <param name="projectTaskTemplateRelation">The project task template relation object to update.</param>
        /// <returns>An updated project task template relation object.</returns>
        public ProjectTaskTemplateRelation UpdateProjectTaskTemplate(ProjectTemplate projectTemplate, ProjectTaskTemplateRelation projectTaskTemplateRelation)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, "task_templates").Update(projectTaskTemplateRelation);
        }

        /// <summary>
        /// Delete a project task template from a project template.
        /// </summary>
        /// <param name="projectTemplate">The project template.</param>
        /// <param name="projectTaskTemplateRelation">The project task template relation object to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteProjectTaskTemplate(ProjectTemplate projectTemplate, ProjectTaskTemplateRelation projectTaskTemplateRelation)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, $"task_templates").Delete(projectTaskTemplateRelation);
        }

        /// <summary>
        /// Delete all project task templates from a project template.
        /// </summary>
        /// <param name="projectTemplate">The project template.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllProjectTaskTemplates(ProjectTemplate projectTemplate)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, $"task_templates").DeleteAll();
        }

        #endregion
    }
}
