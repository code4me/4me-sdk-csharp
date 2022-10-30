using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/risks/">risk</see> API endpoint.
    /// </summary>
    public class RiskHandler : BaseHandler<Risk, PredefinedOpenClosedFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me risk handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public RiskHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/risks", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me risk handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public RiskHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/risks", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Notes

        /// <summary>
        /// Get all notes related to a risk.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A list of notes.</returns>

        public List<Note> GetNotes(Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Note>(risk, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Organizations

        /// <summary>
        /// Get all related organization.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Organization> GetOrganizations(Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(risk, "organizations").Get(fieldNames);
        }

        /// <summary>
        /// Get all related organization.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="risk">The risk.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Organization> GetOrganizations(PredefinedOrganizationFilter filter, Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(risk, $"organizations/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add an organization.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <param name="organization">The organization to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddOrganization(Risk risk, Organization organization)
        {
            return CreateRelation(risk, "organizations", organization);
        }

        /// <summary>
        /// Remove an organization.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <param name="organization">The organization to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveOrganization(Risk risk, Organization organization)
        {
            return DeleteRelation(risk, "organizations", organization);
        }

        /// <summary>
        /// Remove all organizations.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllOrganizations(Risk risk)
        {
            return DeleteAllRelations(risk, "organizations");
        }

        #endregion

        #region Projects

        /// <summary>
        /// Get all related projects.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of projects.</returns>
        public List<Project> GetProjects(Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Project>(risk, "projects").Get(fieldNames);
        }

        /// <summary>
        /// Get all related projects.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="risk">The risk.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of projects.</returns>
        public List<Project> GetProjects(PredefinedProjectFilter filter, Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Project>(risk, $"projects/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a project.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <param name="project">The project to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddProject(Risk risk, Project project)
        {
            return CreateRelation(risk, "projects", project);
        }

        /// <summary>
        /// Remove a project.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <param name="project">The project to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveProject(Risk risk, Project project)
        {
            return DeleteRelation(risk, "projects", project);
        }

        /// <summary>
        /// Remove all projects.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllProjects(Risk risk)
        {
            return DeleteAllRelations(risk, "projects");
        }

        #endregion

        #region Services

        /// <summary>
        /// Get all related services.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of services.</returns>
        public List<Service> GetServices(Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Service>(risk, "services").Get(fieldNames);
        }

        /// <summary>
        /// Get all related services.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="risk">The risk.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of services.</returns>
        public List<Service> GetServices(PredefinedEnabledDisabledFilter filter, Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Service>(risk, $"services/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a service.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <param name="service">The service to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddService(Risk risk, Service service)
        {
            return CreateRelation(risk, "services", service);
        }

        /// <summary>
        /// Remove a service.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <param name="service">The service to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveService(Risk risk, Service service)
        {
            return DeleteRelation(risk, "services", service);
        }

        /// <summary>
        /// Remove all services.
        /// </summary>
        /// <param name="risk">The risk.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllServices(Risk risk)
        {
            return DeleteAllRelations(risk, "services");
        }

        #endregion
    }
}
