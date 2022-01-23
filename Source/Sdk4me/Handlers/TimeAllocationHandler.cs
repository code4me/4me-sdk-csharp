using System.Collections.Generic;

namespace Sdk4me
{
    public class TimeAllocationHandler : BaseHandler<TimeAllocation, PredefinedTimeAllocationFilter>
    {
        public TimeAllocationHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/time_allocations", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TimeAllocationHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/time_allocations", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region customers

        public List<Organization> GetCustomers(TimeAllocation timeAllocation, params string[] attributeNames)
        {
            DefaultHandler<Organization> handler = new DefaultHandler<Organization>($"{this.URL}/{timeAllocation.ID}/customers", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddCustomer(TimeAllocation timeAllocation, Organization customer)
        {
            return CreateRelation(timeAllocation, "services", customer);
        }

        public bool RemoveCustomer(TimeAllocation timeAllocation, Organization customer)
        {
            return DeleteRelation(timeAllocation, "services", customer);
        }

        public bool RemoveAllCustomers(TimeAllocation timeAllocation)
        {
            return DeleteAllRelations(timeAllocation, "services");
        }

        #endregion

        #region services

        public List<Service> GetServices(TimeAllocation timeAllocation, params string[] attributeNames)
        {
            DefaultHandler<Service> handler = new DefaultHandler<Service>($"{this.URL}/{timeAllocation.ID}/services", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
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

        #region organizations

        public List<Organization> GetOrganizations(TimeAllocation timeAllocation, params string[] attributeNames)
        {
            DefaultHandler<Organization> handler = new DefaultHandler<Organization>($"{this.URL}/{timeAllocation.ID}/organizations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddOrganization(TimeAllocation timeAllocation, Organization organization)
        {
            return CreateRelation(timeAllocation, "organizations", organization);
        }

        public bool RemoveOrganization(TimeAllocation timeAllocation, Organization organization)
        {
            return DeleteRelation(timeAllocation, "organizations", organization);
        }

        public bool RemoveAllOrganization(TimeAllocation timeAllocation)
        {
            return DeleteAllRelations(timeAllocation, "services");
        }

        #endregion

    }
}
