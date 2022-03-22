using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class OrganizationHandler : BaseHandler<Organization, PredefinedOrganizationFilter>
    {
        public OrganizationHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/organizations", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public OrganizationHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/organizations", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Addresses

        public List<Address> GetAddresses(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Address>(organization, "addresses", SortOrder.None).Get(fieldNames);
        }

        public Address AddAddress(Organization organization, Address address)
        {
            return GetChildHandler<Address>(organization, "addresses").Insert(address);
        }

        public Address UpdateAddress(Organization organization, Address address)
        {
            return GetChildHandler<Address>(organization, "addresses").Update(address);
        }

        public bool DeleteAddress(Organization organization, Address address)
        {
            return GetChildHandler<Address>(organization, "addresses").Delete(address);
        }

        public bool DeleteAllAddresses(Organization organization)
        {
            return GetChildHandler<Address>(organization, "addresses").DeleteAll();
        }

        #endregion

        #region contacts 

        public List<Contact> GetContacts(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Contact>(organization, "contacts", SortOrder.None).Get(fieldNames);
        }

        public Contact AddContact(Organization organization, Contact contact)
        {
            return GetChildHandler<Contact>(organization, "contacts").Insert(contact);
        }

        public Contact UpdateContact(Organization organization, Contact contact)
        {
            return GetChildHandler<Contact>(organization, "contacts").Update(contact);
        }

        public bool DeleteContact(Organization organization, Contact contact)
        {
            return GetChildHandler<Contact>(organization, "contacts").Delete(contact);
        }

        public bool DeleteAllContacts(Organization organization)
        {
            return GetChildHandler<Contact>(organization, "contacts").DeleteAll();
        }

        #endregion

        #region Organizations

        public List<Person> GetChildOrganizations(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, "children").Get(fieldNames);
        }

        public List<Person> GetChildOrganizations(PredefinedEnabledDisabledFilter filter, Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, $"children/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region People

        public List<Person> GetMembers(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, "people").Get(fieldNames);
        }

        public List<Person> GetMembers(PredefinedActiveInactiveFilter filter, Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, $"people/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Risks

        public List<Risk> GetRisks(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(organization, "risks").Get(fieldNames);
        }

        public List<Risk> GetRisks(PredefinedOpenClosedFilter filter, Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(organization, $"risks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service level agreements

        public List<Person> GetServiceLevelAgreements(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, "slas").Get(fieldNames);
        }

        public List<Person> GetServiceLevelAgreements(PredefinedActiveInactiveFilter filter, Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, $"slas/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Time allocations

        public List<TimeAllocation> GetTimeAllocations(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<TimeAllocation>(organization, "time_allocations").Get(fieldNames);
        }

        public List<TimeAllocation> GetTimeAllocations(PredefinedOrganizationFilter filter, Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<TimeAllocation>(organization, $"time_allocations/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddTimeAllocation(Organization organization, TimeAllocation timeAllocation)
        {
            return CreateRelation(organization, "time_allocations", timeAllocation);
        }

        public bool RemoveTimeAllocation(Organization organization, TimeAllocation timeAllocation)
        {
            return DeleteRelation(organization, "time_allocations", timeAllocation);
        }

        public bool RemoveAllTimeAllocations(Organization organization)
        {
            return DeleteAllRelations(organization, "time_allocations");
        }

        #endregion    
    }
}
