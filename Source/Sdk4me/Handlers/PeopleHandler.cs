using Sdk4me.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/people/">people</see> API endpoint.
    /// </summary>
    public class PeopleHandler : BaseHandler<Person, PredefinedPeopleFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me people handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public PeopleHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/people", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me people handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public PeopleHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/people", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Addresses

        /// <summary>
        /// Get all related addresses.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of addresses.</returns>
        public List<Address> GetAddresses(Person person, params string[] fieldNames)
        {
            return GetChildHandler<Address>(person, "addresses", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add an address.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="address">The address to add.</param>
        /// <returns>The updated address.</returns>
        public Address AddAddress(Person person, Address address)
        {
            return GetChildHandler<Address>(person, "addresses").Insert(address);
        }

        /// <summary>
        /// Update an address.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="address">The address to update.</param>
        /// <returns>The updated address.</returns>
        public Address UpdateAddress(Person person, Address address)
        {
            return GetChildHandler<Address>(person, "addresses").Update(address);
        }

        /// <summary>
        /// Delete an address.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="address">The address to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAddress(Person person, Address address)
        {
            return GetChildHandler<Address>(person, "addresses").Delete(address);
        }

        /// <summary>
        /// Delete all addresses.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllAddresses(Person person)
        {
            return GetChildHandler<Address>(person, "addresses").DeleteAll();
        }

        #endregion

        #region Configuration item coverage

        /// <summary>
        /// Get all related configuration item coverage.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration item coverages.</returns>
        public List<ConfigurationItem> GetConfigurationItemCoverage(Person person, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(person, "ci_coverages").Get(fieldNames);
        }

        #endregion

        #region Configuration items

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(Person person, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(person, "cis").Get(fieldNames);
        }

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, Person person, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(person, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a configuration item.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="configurationItem">The configuration item to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddConfigurationItem(Person person, ConfigurationItem configurationItem)
        {
            return CreateRelation(person, "cis", configurationItem);
        }

        /// <summary>
        /// Remove a configuration item.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="configurationItem">The configuration item to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveConfigurationItem(Person person, ConfigurationItem configurationItem)
        {
            return DeleteRelation(person, "cis", configurationItem);
        }

        /// <summary>
        /// Remove all configuration items.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllConfigurationItem(Person person)
        {
            return DeleteAllRelations(person, "cis");
        }

        #endregion

        #region contacts 

        /// <summary>
        /// Get all related contacts.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of contacts.</returns>
        public List<Contact> GetContacts(Person person, params string[] fieldNames)
        {
            return GetChildHandler<Contact>(person, "contacts", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add a contact.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="contact">The contact to add.</param>
        /// <returns>The updated contact.</returns>
        public Contact AddContact(Person person, Contact contact)
        {
            return GetChildHandler<Contact>(person, "contacts").Insert(contact);
        }

        /// <summary>
        /// Update a contact.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="contact">The contact to update.</param>
        /// <returns>The updated contact.</returns>
        public Contact UpdateContact(Person person, Contact contact)
        {
            return GetChildHandler<Contact>(person, "contacts").Update(contact);
        }

        /// <summary>
        /// Delete a contact.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="contact">The contact to delete.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteContact(Person person, Contact contact)
        {
            return GetChildHandler<Contact>(person, "contacts").Delete(contact);
        }

        /// <summary>
        /// Delete all contacts.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteAllContacts(Person person)
        {
            return GetChildHandler<Contact>(person, "contacts").DeleteAll();
        }

        #endregion

        #region Permissions

        /// <summary>
        /// Get all account permissions.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>A collection of account permissions.</returns>
        public List<AccountPermission> GetAccountPermissions(Person person)
        {
            DefaultBaseHandler<AccountPermission> handler = GetChildHandler<AccountPermission>(person, "permissions");
            handler.SortOrder = SortOrder.None;
            handler.AlwaysAsList = true;
            return handler.Get();
        }

        /// <summary>
        /// Get all account permissions.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="accountIdentifier">The 4me account ID.</param>
        /// <returns>A collection of account permissions.</returns>
        public AccountPermission GetAccountPermissions(Person person, string accountIdentifier)
        {
            return GetAccountPermissions(person, new AccountReference() { ID = accountIdentifier });
        }

        /// <summary>
        /// Get all account permissions.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="account">The 4me account.</param>
        /// <returns>A collection of account permissions.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public AccountPermission GetAccountPermissions(Person person, AccountReference account)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            return GetChildHandler<AccountPermission>(person, $"permissions/{account.ID}", SortOrder.None).Get().FirstOrDefault();
        }

        /// <summary>
        /// Get all people with roles.
        /// </summary>
        /// <param name="accessRoles">The access role.</param>
        /// <param name="accountSelection">The account selection.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetPeopleWithRoles(AccessRoles accessRoles, AccountSelection accountSelection, params string[] fieldNames)
        {
            if (accountSelection == AccountSelection.CurrentAccountAndDirectoryAccount)
                return new DefaultBaseHandler<Person>($"{URL}?roles={string.Join(",", accessRoles.Get4meStringCollection())}", AuthenticationTokens, AccountID, ItemsPerRequest, MaximumRecursiveRequests).Get(fieldNames);
            else
                return new DefaultBaseHandler<Person>($"{URL}/all_with_roles?roles={string.Join(",", accessRoles.Get4meStringCollection())}", AuthenticationTokens, AccountID, ItemsPerRequest, MaximumRecursiveRequests).Get(fieldNames);
        }

        /// <summary>
        /// Add one or more roles.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="account">The 4me account.</param>
        /// <param name="accessRoles">The access roles to add.</param>
        /// <returns>The updated account permissions.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public AccountPermission AddAccountPermission(Person person, AccountReference account, AccessRoles accessRoles)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            return AddAccountPermission(person, new AccountPermission() { Account = account, Roles = accessRoles });
        }

        /// <summary>
        /// Add one or more roles.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="permissions">The account permissions.</param>
        /// <returns>The updated account permissions.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public AccountPermission AddAccountPermission(Person person, AccountPermission permissions)
        {
            if (permissions is null)
                throw new ArgumentNullException(nameof(permissions));

            return GetChildHandler<AccountPermission>(person, $"permissions/{permissions.Account.ID}?roles={string.Join(",", permissions.Roles.Get4meStringCollection())}").Invoke("Post");
        }

        /// <summary>
        /// Update one or more roles.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="account">The 4me account.</param>
        /// <param name="accessRoles">The access roles to update.</param>
        /// <returns>The updated account permissions.</returns>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public AccountPermission UpdateAccountPermission(Person person, AccountReference account, AccessRoles accessRoles)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            return UpdateAccountPermission(person, new AccountPermission() { Account = account, Roles = accessRoles });
        }

        /// <summary>
        /// Update one or more roles.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="permissions">The account permissions.</param>
        /// <returns>The updated account permissions.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public AccountPermission UpdateAccountPermission(Person person, AccountPermission permissions)
        {
            if (permissions is null)
                throw new ArgumentNullException(nameof(permissions));

            return GetChildHandler<AccountPermission>(person, $"permissions/{permissions.Account.ID}?roles={string.Join(",", permissions.Roles.Get4meStringCollection())}").Invoke("Patch");
        }

        /// <summary>
        /// Remove all roles for a specific account.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="account">The 4me account ID.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAccountPermission(Person person, AccountReference account)
        {
            return GetChildHandler<AccountPermission>(person, $"permissions/{account.ID}").Invoke("Delete") == null;
        }

        /// <summary>
        /// Remove all roles for all accounts.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllAccountPermissions(Person person)
        {
            return GetChildHandler<AccountPermission>(person, "permissions").Invoke("Delete") == null;
        }

        #endregion

        #region Service coverage

        /// <summary>
        /// Get all related service coverages.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service coverages.</returns>
        public List<Service> GetServiceCoverage(Person person, params string[] fieldNames)
        {
            return GetChildHandler<Service>(person, "service_coverages").Get(fieldNames);
        }

        #endregion

        #region Service instance coverage

        /// <summary>
        /// Get all related service instance coverages.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instance coverages.</returns>
        public List<ServiceInstance> GetServiceInstanceCoverage(Person person, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(person, "service_instance_coverages").Get(fieldNames);
        }

        #endregion

        #region Service level agreement coverage

        /// <summary>
        /// Get all related service level agreement coverages.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreement coverages.</returns>
        public List<ServiceLevelAgreement> GetServiceLevelAgreementCoverage(Person person, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(person, "sla_coverages").Get(fieldNames);
        }

        #endregion

        #region Teams 

        /// <summary>
        /// Get all teams.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of teams.</returns>
        public List<Team> GetTeams(Person person, params string[] fieldNames)
        {
            return GetChildHandler<Team>(person, "teams").Get(fieldNames);
        }

        /// <summary>
        /// Get all teams.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of teams.</returns>
        public List<Team> GetTeams(PredefinedEnabledDisabledFilter filter, Person person, params string[] fieldNames)
        {
            return GetChildHandler<Team>(person, $"teams/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a person to a team.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="team">The team.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddTeam(Person person, Team team)
        {
            return CreateRelation(person, "teams", team);
        }

        /// <summary>
        /// Remove a person from a team.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="team">The team.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveTeam(Person person, Team team)
        {
            return DeleteRelation(person, "teams", team);
        }

        /// <summary>
        /// Remove a person from all teams.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllTeams(Person person)
        {
            return DeleteAllRelations(person, "teams");
        }

        #endregion

        #region Skill pools

        /// <summary>
        /// Get all skill pools for a person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of skill pools.</returns>
        public List<SkillPool> GetSkillPools(Person person, params string[] fieldNames)
        {
            return GetChildHandler<SkillPool>(person, "skill_pools").Get(fieldNames);
        }

        /// <summary>
        /// Get all skill pools for a person.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="person">The person.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of skill pools.</returns>
        public List<SkillPool> GetSkillPools(PredefinedEnabledDisabledFilter filter, Person person, params string[] fieldNames)
        {
            return GetChildHandler<SkillPool>(person, $"skill_pools/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a skill pool to a person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="skillPool">The skill pool.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddSkillPool(Person person, SkillPool skillPool)
        {
            return CreateRelation(person, "skill_pools", skillPool);
        }

        /// <summary>
        /// Remove a skill pool from a person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="skillPool">The skill pool.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveSkillPool(Person person, SkillPool skillPool)
        {
            return DeleteRelation(person, "skill_pools", skillPool);
        }

        /// <summary>
        /// Remove all skill pools from a person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllSkillPools(Person person)
        {
            return DeleteAllRelations(person, "skill_pools");
        }

        #endregion

        #region Archive, trash and restore

        /// <summary>
        /// Archive a person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>The archived person.</returns>
        public Person Archive(Person person)
        {
            return GetChildHandler<Person>(person, "archive").Invoke("Post");
        }

        /// <summary>
        /// Trash a person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>The trashed person.</returns>
        public Person Trash(Person person)
        {
            return GetChildHandler<Person>(person, "trash").Invoke("Post");
        }

        /// <summary>
        /// Restore a person.
        /// </summary>
        /// <param name="archive">The archive person.</param>
        /// <returns>The restored person.</returns>
        public Person Restore(Archive archive)
        {
            return GetChildHandler<Person>(new Person() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        /// <summary>
        /// Restore a person.
        /// </summary>
        /// <param name="trash">The trashed person.</param>
        /// <returns>The restored person.</returns>
        public Person Restore(Trash trash)
        {
            return GetChildHandler<Person>(new Person() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
