using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/organizations/">organization</see> API endpoint.
    /// </summary>
    public class OrganizationHandler : BaseHandler<Organization, PredefinedOrganizationFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me organization handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public OrganizationHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/organizations", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me organization handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public OrganizationHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/organizations", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Addresses

        /// <summary>
        /// Get all related addresses.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of addresses.</returns>
        public List<Address> GetAddresses(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Address>(organization, "addresses", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add an address.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="address">The address to add.</param>
        /// <returns>The updated address.</returns>
        public Address AddAddress(Organization organization, Address address)
        {
            return GetChildHandler<Address>(organization, "addresses").Insert(address);
        }

        /// <summary>
        /// Update an address.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="address">The address to update.</param>
        /// <returns>The updated address.</returns>
        public Address UpdateAddress(Organization organization, Address address)
        {
            return GetChildHandler<Address>(organization, "addresses").Update(address);
        }

        /// <summary>
        /// Delete an address.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="address">The address to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAddress(Organization organization, Address address)
        {
            return GetChildHandler<Address>(organization, "addresses").Delete(address);
        }

        /// <summary>
        /// Delete all addresses.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllAddresses(Organization organization)
        {
            return GetChildHandler<Address>(organization, "addresses").DeleteAll();
        }

        #endregion

        #region contacts 

        /// <summary>
        /// Get all related contacts.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of contact.</returns>
        public List<Contact> GetContacts(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Contact>(organization, "contacts", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add a contacts.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="contact">The contact to add.</param>
        /// <returns>The updated contact.</returns>
        public Contact AddContact(Organization organization, Contact contact)
        {
            return GetChildHandler<Contact>(organization, "contacts").Insert(contact);
        }

        /// <summary>
        /// Update a contacts.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="contact">The contact to update.</param>
        /// <returns>The updated contact.</returns>
        public Contact UpdateContact(Organization organization, Contact contact)
        {
            return GetChildHandler<Contact>(organization, "contacts").Update(contact);
        }

        /// <summary>
        /// Delete a contact.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="contact">The contact to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteContact(Organization organization, Contact contact)
        {
            return GetChildHandler<Contact>(organization, "contacts").Delete(contact);
        }

        /// <summary>
        /// Delete all contacts.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllContacts(Organization organization)
        {
            return GetChildHandler<Contact>(organization, "contacts").DeleteAll();
        }

        #endregion

        #region Organizations

        /// <summary>
        /// Get all child organizations.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Person> GetChildOrganizations(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, "children").Get(fieldNames);
        }

        /// <summary>
        /// Get all child organizations.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of organizations.</returns>
        public List<Person> GetChildOrganizations(PredefinedEnabledDisabledFilter filter, Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, $"children/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region People

        /// <summary>
        /// Get all related people.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetMembers(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, "people").Get(fieldNames);
        }

        /// <summary>
        /// Get all related people.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetMembers(PredefinedActiveInactiveFilter filter, Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, $"people/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Risks

        /// <summary>
        /// Get all related risks.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of risks.</returns>
        public List<Risk> GetRisks(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(organization, "risks").Get(fieldNames);
        }

        /// <summary>
        /// Get all related risks.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of risks.</returns>
        public List<Risk> GetRisks(PredefinedOpenClosedFilter filter, Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(organization, $"risks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service level agreements

        /// <summary>
        /// Get all related service level agreements.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreements.</returns>
        public List<Person> GetServiceLevelAgreements(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, "slas").Get(fieldNames);
        }

        /// <summary>
        /// Get all related service level agreements.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreements.</returns>
        public List<Person> GetServiceLevelAgreements(PredefinedActiveInactiveFilter filter, Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<Person>(organization, $"slas/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Time allocations

        /// <summary>
        /// Get all related time allocations.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of time allocations.</returns>
        public List<TimeAllocation> GetTimeAllocations(Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<TimeAllocation>(organization, "time_allocations").Get(fieldNames);
        }

        /// <summary>
        /// Get all related time allocations.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="organization">The organization.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of time allocations.</returns>
        public List<TimeAllocation> GetTimeAllocations(PredefinedOrganizationFilter filter, Organization organization, params string[] fieldNames)
        {
            return GetChildHandler<TimeAllocation>(organization, $"time_allocations/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a time allocation.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="timeAllocation">The time allocation to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddTimeAllocation(Organization organization, TimeAllocation timeAllocation)
        {
            return CreateRelation(organization, "time_allocations", timeAllocation);
        }

        /// <summary>
        /// Remove a time allocation.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="timeAllocation">The time allocation to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveTimeAllocation(Organization organization, TimeAllocation timeAllocation)
        {
            return DeleteRelation(organization, "time_allocations", timeAllocation);
        }

        /// <summary>
        /// Remove all time allocations.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllTimeAllocations(Organization organization)
        {
            return DeleteAllRelations(organization, "time_allocations");
        }

        #endregion    
    }
}
