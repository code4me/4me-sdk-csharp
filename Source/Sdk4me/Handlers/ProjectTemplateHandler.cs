using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectTemplateHandler : BaseHandler<ProjectTemplate, PredefinedEnabledDisabledFilter>
    {
        public ProjectTemplateHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/project_templates", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProjectTemplateHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/project_templates", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Phases

        public List<ProjectTemplatePhase> GetPhases(ProjectTemplate projectTemplate)
        {
            return GetChildHandler<ProjectTemplatePhase>(projectTemplate, "phases", SortOrder.None).Get("*");
        }

        public ProjectTemplatePhase AddPhase(ProjectTemplate projectTemplate, ProjectTemplatePhase projectTemplatePhase)
        {
            return GetChildHandler<ProjectTemplatePhase>(projectTemplate, "phases").Insert(projectTemplatePhase);
        }

        public ProjectTemplatePhase UpdatePhase(ProjectTemplate projectTemplate, ProjectTemplatePhase projectTemplatePhase)
        {
            return GetChildHandler<ProjectTemplatePhase>(projectTemplate, "phases").Update(projectTemplatePhase);
        }

        public bool DeletePhase(ProjectTemplate projectTemplate, ProjectTemplatePhase projectTemplatePhase)
        {
            return GetChildHandler<ProjectTemplatePhase>(projectTemplate, "phases").Delete(projectTemplatePhase);
        }

        public bool DeleteAllPhases(ProjectTemplate projectTemplate)
        {
            return GetChildHandler<ProjectTemplatePhase>(projectTemplate, "phases").DeleteAll();
        }

        #endregion

        #region Project task templates

        public List<ProjectTaskTemplateRelation> GetProjectTaskTemplates(ProjectTemplate projectTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, "task_templates", SortOrder.None).Get(fieldNames);
        }

        public List<ProjectTaskTemplateRelation> GetProjectTaskTemplates(PredefinedEnabledDisabledFilter filter, ProjectTemplate projectTemplate, params string[] fieldNames)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, $"task_templates/{filter.To4meString()}", SortOrder.None).Get(fieldNames);
        }

        public ProjectTaskTemplateRelation AddProjectTaskTemplate(ProjectTemplate projectTemplate, ProjectTaskTemplateRelation projectTaskTemplateRelation)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, "task_templates").Insert(projectTaskTemplateRelation);
        }

        public ProjectTaskTemplateRelation UpdateProjectTaskTemplate(ProjectTemplate projectTemplate, ProjectTaskTemplateRelation projectTaskTemplateRelation)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, "task_templates").Update(projectTaskTemplateRelation);
        }

        public bool DeleteProjectTaskTemplate(ProjectTemplate projectTemplate, ProjectTaskTemplateRelation projectTaskTemplateRelation)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, $"task_templates").Delete(projectTaskTemplateRelation);
        }

        public bool DeleteAllProjectTaskTemplates(ProjectTemplate projectTemplate)
        {
            return GetChildHandler<ProjectTaskTemplateRelation>(projectTemplate, $"task_templates").DeleteAll();
        }

        #endregion
    }
}
