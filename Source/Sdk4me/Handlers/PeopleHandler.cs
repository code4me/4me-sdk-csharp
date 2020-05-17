using System.Collections.Generic;

namespace Sdk4me
{
    public class PeopleHandler : BaseHandler<Person, PredefinedPeopleFilter>
    {
        public PeopleHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/people", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public PeopleHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/people", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region addresses

        public List<Address> GetAddresses(Person person)
        {
            DefaultHandler<Address> handler = new DefaultHandler<Address>($"{URL}/{person.ID}/addresses", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Get();
        }

        public Address AddAddress(Person person, Address address)
        {
            DefaultHandler<Address> handler = new DefaultHandler<Address>($"{URL}/{person.ID}/addresses", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(address);
        }

        public Address UpdateAddress(Person person, Address address)
        {
            DefaultHandler<Address> handler = new DefaultHandler<Address>($"{URL}/{person.ID}/addresses", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(address);
        }

        public bool DeleteAddress(Person person, Address address)
        {
            DefaultHandler<Address> handler = new DefaultHandler<Address>($"{URL}/{person.ID}/addresses", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(address);
        }

        public bool DeleteAllAddresses(Person person)
        {
            DefaultHandler<Address> handler = new DefaultHandler<Address>($"{URL}/{person.ID}/addresses", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion

        #region configuration item coverages

        public List<ConfigurationItem> GetConfigurationItemCoverages(Person person, params string[] attributeNames)
        {
            DefaultHandler<ConfigurationItem> handler = new DefaultHandler<ConfigurationItem>($"{URL}/{person.ID}/ci_coverages", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(Person person, params string[] attributeNames)
        {
            DefaultHandler<ConfigurationItem> handler = new DefaultHandler<ConfigurationItem>($"{URL}/{person.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddConfigurationItem(Person person, ConfigurationItem configurationItem)
        {
            return CreateRelation(person, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(Person person, ConfigurationItem configurationItem)
        {
            return DeleteRelation(person, "cis", configurationItem);
        }

        public bool RemoveAllConfigurationItems(Person person)
        {
            return DeleteAllRelations(person, "cis");
        }

        #endregion

        #region contacts

        public List<Contact> GetContacts(Person person)
        {
            DefaultHandler<Contact> handler = new DefaultHandler<Contact>($"{URL}/{person.ID}/contacts", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            return handler.Get();

        }

        public Contact InsertContact(Person person, Contact contact)
        {
            DefaultHandler<Contact> handler = new DefaultHandler<Contact>($"{URL}/{person.ID}/contacts", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Insert(contact);
        }

        public Contact UpdateContact(Person person, Contact contact)
        {
            DefaultHandler<Contact> handler = new DefaultHandler<Contact>($"{URL}/{person.ID}/contacts", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Update(contact);
        }

        public bool DeleteContact(Person person, Contact contact)
        {
            DefaultHandler<Contact> handler = new DefaultHandler<Contact>($"{URL}/{person.ID}/contacts", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Delete(contact);
        }
    
        public bool DeleteAllContacts(Person person)
        {
            DefaultHandler<Contact> handler = new DefaultHandler<Contact>($"{URL}/{person.ID}/contact", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.DeleteAll();
        }

        #endregion

        #region me

        public Person GetMe()
        {
            DefaultHandler<Person> handler = new DefaultHandler<Person>($"{URL}/me", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            List<Person> result = handler.Get("*");
            return result.Count.Equals(1) ? result[0] : null;
        }

        #endregion

        #region permissions

        public List<Permission> GetAccountPermissions(Person person)
        {
            DefaultHandler<Permission> handler = new DefaultHandler<Permission>($"{URL}/{person.ID}/permissions", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None,
                AlwaysAsList = true
            };
            return handler.Get();
        }

        public Permission GetAccountPermission(Person person, Account account)
        {
            DefaultHandler<Permission> handler = new DefaultHandler<Permission>($"{URL}/{person.ID}/permissions/{account.ID}", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests)
            {
                SortOrder = SortOrder.None
            };
            List<Permission> result = handler.Get();
            return result.Count.Equals(1) ? result[0] : null;
        }

        public Permission AddAccountPermission(Person person, Account account, AccessRoleType accessRoles)
        {
            return AddAccountPermission(person, new Permission()
            {
                Account = account,
                Roles = accessRoles
            });
        }

        public Permission AddAccountPermission(Person person, Permission permission)
        {
            DefaultHandler<Permission> handler = new DefaultHandler<Permission>($"{URL}/{person.ID}/permissions", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.CustomWebRequest($"/{permission.Account.ID}?roles={permission.GetRolesInSingleString()}", "POST");
        }

        public Permission UpdateAccountPermission(Person person, Account account, AccessRoleType accessRoles)
        {
            return UpdateAccountPermission(person, new Permission()
            {
                Account = account,
                Roles = accessRoles
            });
        }

        public Permission UpdateAccountPermission(Person person, Permission permission)
        {
            DefaultHandler<Permission> handler = new DefaultHandler<Permission>($"{URL}/{person.ID}/permissions", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.CustomWebRequest($"/{permission.Account.ID}?roles={permission.GetRolesInSingleString()}", "PATCH");
        }

        public bool RemoveAccountPermission(Person person, Account account, AccessRoleType accessRoles)
        {
            return RemoveAccountPermission(person, new Permission()
            {
                Account = account,
                Roles = accessRoles
            });
        }

        public bool RemoveAccountPermission(Person person, Permission permission)
        {
            DefaultHandler<Permission> handler = new DefaultHandler<Permission>($"{URL}/{person.ID}/permissions", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.CustomWebRequest($"/{permission.Account.ID}?roles={permission.GetRolesInSingleString()}", "DELETE") == null;
        }

        public bool RemoveAccountPermissions(Person person, Account account)
        {
            return DeleteAllRelations(person, $"permissions/{account.ID}");
        }

        public bool RemoveAllAccountPermissions(Person person)
        {
            return DeleteAllRelations(person, "permissions");
        }

        #endregion

        #region service coverages

        public List<Service> GetServiceCoverages(Person person, params string[] attributeNames)
        {
            DefaultHandler<Service> handler = new DefaultHandler<Service>($"{URL}/{person.ID}/service_coverages", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region service instance coverages

        public List<ServiceInstance> GetServiceInstanceCoverages(Person person, params string[] attributeNames)
        {
            DefaultHandler<ServiceInstance> handler = new DefaultHandler<ServiceInstance>($"{URL}/{person.ID}/service_instance_coverages", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region SLA coverages

        public List<ServiceLevelAgreement> GetServiceLevelAgreementCoverages(Person person, params string[] attributeNames)
        {
            DefaultHandler<ServiceLevelAgreement> handler = new DefaultHandler<ServiceLevelAgreement>($"{URL}/{person.ID}/sla_coverages", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region teams

        public List<Team> GetTeams(Person person, params string[] attributeNames)
        {
            DefaultHandler<Team> handler = new DefaultHandler<Team>($"{URL}/{person.ID}/teams", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddTeam(Person person, Team team)
        {
            return CreateRelation(person, "teams", team);
        }

        public bool RemoveTeam(Person person, Team team)
        {
            return DeleteRelation(person, "teams", team);
        }

        public bool RemoveAllTeams(Person person)
        {
            return DeleteAllRelations(person, "teams");
        }

        #endregion
    }
}
