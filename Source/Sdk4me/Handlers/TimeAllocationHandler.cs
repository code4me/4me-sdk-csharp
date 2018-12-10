﻿using System.Collections.Generic;


namespace Sdk4me
{
    public class TimeAllocationHandler : BaseHandler<TimeAllocation>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/time_allocations";
        private static readonly string productionUrl = "https://api.4me.com/v1/time_allocations";

        public TimeAllocationHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public TimeAllocationHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region customers

        public List<Organization> GetCustomers(TimeAllocation timeAllocation, params string[] attributeNames)
        {
            BaseHandler<Organization> handler = new BaseHandler<Organization>($"{URL}/{timeAllocation.ID}/customers", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            BaseHandler<Service> handler = new BaseHandler<Service>($"{URL}/{timeAllocation.ID}/services", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            BaseHandler<Organization> handler = new BaseHandler<Organization>($"{URL}/{timeAllocation.ID}/organizations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
