using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class TimeAllocationHandler : BaseHandler<TimeAllocation, PredefinedEnabledDisabledFilter>
    {
        public TimeAllocationHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/time_allocations", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TimeAllocationHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/time_allocations", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Customers

        public List<Organization> GetCustomers(TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timeAllocation, "customers").Get(fieldNames);
        }

        public List<Organization> GetCustomers(PredefinedEnabledDisabledFilter filter, TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timeAllocation, $"customers/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddCustomer(TimeAllocation timeAllocation, Organization customer)
        {
            return CreateRelation(timeAllocation, "customers", customer);
        }

        public bool RemoveCustomer(TimeAllocation timeAllocation, Organization customer)
        {
            return DeleteRelation(timeAllocation, "customers", customer);
        }

        public bool RemoveAllCustomers(TimeAllocation timeAllocation)
        {
            return DeleteAllRelations(timeAllocation, "customers");
        }

        #endregion

        #region Services

        public List<Service> GetServices(TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Service>(timeAllocation, "services").Get(fieldNames);
        }

        public List<Service> GetServices(PredefinedEnabledDisabledFilter filter, TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Service>(timeAllocation, $"services/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddService(TimeAllocation timeAllocation, Service service)
        {
            return CreateRelation(timeAllocation, "services", service);
        }

        public bool RemoveService(TimeAllocation timeAllocation, Service service)
        {
            return DeleteRelation(timeAllocation, "services", service);
        }

        public bool RemoveAllServices(TimeAllocation timeAllocation)
        {
            return DeleteAllRelations(timeAllocation, "services");
        }

        #endregion

        #region Organizations

        public List<Organization> GetOrganizations(TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timeAllocation, "organizations").Get(fieldNames);
        }

        public List<Organization> GetOrganizations(PredefinedEnabledDisabledFilter filter, TimeAllocation timeAllocation, params string[] fieldNames)
        {
            return GetChildHandler<Organization>(timeAllocation, $"organizations/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddOrganization(TimeAllocation timeAllocation, Organization organization)
        {
            return CreateRelation(timeAllocation, "organizations", organization);
        }

        public bool RemoveOrganization(TimeAllocation timeAllocation, Organization organization)
        {
            return DeleteRelation(timeAllocation, "organizations", organization);
        }

        public bool RemoveAllOrganizations(TimeAllocation timeAllocation)
        {
            return DeleteAllRelations(timeAllocation, "organizations");
        }

        #endregion
    }
}
