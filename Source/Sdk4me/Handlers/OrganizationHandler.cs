using System.Collections.Generic;

namespace Sdk4me
{
    public class OrganizationHandler : BaseHandler<Organization, PredefinedOrganizationFilter>
    {
        public OrganizationHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/organizations", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public OrganizationHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/organizations", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region addresses

        public List<Address> GetAddresses(Organization organization, params string[] attributeNames)
        {
            DefaultHandler<Address> handler = new DefaultHandler<Address>($"{this.URL}/{organization.ID}/addresses", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Get(attributeNames);
        }

        public Address AddAddress(Organization organization, Address address)
        {
            DefaultHandler<Address> handler = new DefaultHandler<Address>($"{this.URL}/{organization.ID}/addresses", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(address);
        }

        public Address UpdateAddress(Organization organization, Address address)
        {
            DefaultHandler<Address> handler = new DefaultHandler<Address>($"{this.URL}/{organization.ID}/addresses", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(address);
        }

        public bool DeleteAddress(Organization organization, Address address)
        {
            DefaultHandler<Address> handler = new DefaultHandler<Address>($"{this.URL}/{organization.ID}/addresses", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(address);
        }

        public bool DeleteAllAddresses(Organization organization)
        {
            DefaultHandler<Address> handler = new DefaultHandler<Address>($"{this.URL}/{organization.ID}/addresses", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion

        #region contact

        public List<Contact> GetContacts(Organization organization, params string[] attributeNames)
        {
            DefaultHandler<Contact> handler = new DefaultHandler<Contact>($"{this.URL}/{organization.ID}/contacts", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public Contact AddContact(Organization organization, Contact contact)
        {
            DefaultHandler<Contact> handler = new DefaultHandler<Contact>($"{this.URL}/{organization.ID}/contacts", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(contact);
        }

        public Contact UpdateContact(Organization organization, Contact contact)
        {
            DefaultHandler<Contact> handler = new DefaultHandler<Contact>($"{this.URL}/{organization.ID}/contacts", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(contact);
        }

        public bool DeleteContact(Organization organization, Contact contact)
        {
            DefaultHandler<Contact> handler = new DefaultHandler<Contact>($"{this.URL}/{organization.ID}/contacts", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(contact);
        }

        public bool DeleteAllContacts(Organization organization)
        {
            DefaultHandler<Contact> handler = new DefaultHandler<Contact>($"{this.URL}/{organization.ID}/contact", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion

        #region organizations

        public List<Organization> GetChilderen(Organization organization, params string[] attributeNames)
        {
            DefaultHandler<Organization> handler = new DefaultHandler<Organization>($"{this.URL}/{organization.ID}/children", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region people

        public List<Person> GetPeople(Organization organization, params string[] attributeNames)
        {
            DefaultHandler<Person> handler = new DefaultHandler<Person>($"{this.URL}/{organization.ID}/people", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region service level agreements

        public List<ServiceLevelAgreement> GetServiceLevelAgreements(Organization organization, params string[] attributeNames)
        {
            DefaultHandler<ServiceLevelAgreement> handler = new DefaultHandler<ServiceLevelAgreement>($"{this.URL}/{organization.ID}/slas", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region time allocation

        public List<TimeAllocation> GetTimeAllocations(Organization organization, params string[] attributeNames)
        {
            DefaultHandler<TimeAllocation> handler = new DefaultHandler<TimeAllocation>($"{this.URL}/{organization.ID}/time_allocations", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
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
