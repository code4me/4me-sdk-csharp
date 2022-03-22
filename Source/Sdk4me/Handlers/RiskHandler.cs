using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class RiskHandler : BaseHandler<Risk, PredefinedOpenClosedFilter>
    {
        public RiskHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/risks", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public RiskHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/risks", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Notes

        public List<Note> GetNotes(Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Note>(risk, "notes", SortOrder.None).Get(fieldNames);
        }

        #endregion

        #region Organizations

        public List<Organization> GetOrganizations(Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(risk, "organizations").Get(fieldNames);
        }

        public List<Organization> GetOrganizations(PredefinedOrganizationFilter filter, Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(risk, $"organizations/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddOrganization(Risk risk, Organization organization)
        {
            return CreateRelation(risk, "organizations", organization);
        }

        public bool RemoveOrganization(Risk risk, Organization organization)
        {
            return DeleteRelation(risk, "organizations", organization);
        }

        public bool RemoveAllOrganizations(Risk risk)
        {
            return DeleteAllRelations(risk, "organizations");
        }

        #endregion

        #region Projects

        public List<Project> GetProjects(Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Project>(risk, "projects").Get(fieldNames);
        }

        public List<Project> GetProjects(PredefinedProjectFilter filter, Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Project>(risk, $"projects/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddProject(Risk risk, Project service)
        {
            return CreateRelation(risk, "projects", service);
        }

        public bool RemoveProject(Risk risk, Project service)
        {
            return DeleteRelation(risk, "projects", service);
        }

        public bool RemoveAllProjects(Risk risk)
        {
            return DeleteAllRelations(risk, "projects");
        }

        #endregion

        #region Services

        public List<Service> GetServices(Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Service>(risk, "services").Get(fieldNames);
        }

        public List<Service> GetServices(PredefinedEnabledDisabledFilter filter, Risk risk, params string[] fieldNames)
        {
            return GetChildHandler<Service>(risk, $"services/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddService(Risk risk, Service service)
        {
            return CreateRelation(risk, "services", service);
        }

        public bool RemoveService(Risk risk, Service service)
        {
            return DeleteRelation(risk, "services", service);
        }

        public bool RemoveAllServices(Risk risk)
        {
            return DeleteAllRelations(risk, "services");
        }

        #endregion
    }
}
