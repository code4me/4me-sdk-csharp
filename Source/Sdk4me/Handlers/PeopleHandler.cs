using Sdk4me.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    public class PeopleHandler : BaseHandler<Person, PredefinedPeopleFilter>
    {
        public PeopleHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/people", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public PeopleHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/people", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Addresses

        public List<Address> GetAddresses(Person person, params string[] fieldNames)
        {
            return GetChildHandler<Address>(person, "addresses", SortOrder.None).Get(fieldNames);
        }

        public Address AddAddress(Person person, Address address)
        {
            return GetChildHandler<Address>(person, "addresses").Insert(address);
        }

        public Address UpdateAddress(Person person, Address address)
        {
            return GetChildHandler<Address>(person, "addresses").Update(address);
        }

        public bool DeleteAddress(Person person, Address address)
        {
            return GetChildHandler<Address>(person, "addresses").Delete(address);
        }

        public bool DeleteAllAddresses(Person person)
        {
            return GetChildHandler<Address>(person, "addresses").DeleteAll();
        }

        #endregion

        #region Configuration item coverage

        public List<ConfigurationItem> GetConfigurationItemCoverage(Person person, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(person, "ci_coverages").Get(fieldNames);
        }

        #endregion

        #region Configuration items

        public List<ConfigurationItem> GetConfigurationItems(Person person, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(person, "cis").Get(fieldNames);
        }

        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, Person person, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(person, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddConfigurationItem(Person person, ConfigurationItem configurationItem)
        {
            return CreateRelation(person, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(Person person, ConfigurationItem configurationItem)
        {
            return DeleteRelation(person, "cis", configurationItem);
        }

        public bool RemoveAllConfigurationItem(Person person)
        {
            return DeleteAllRelations(person, "cis");
        }

        #endregion

        #region contacts 

        public List<Contact> GetContacts(Person person, params string[] fieldNames)
        {
            return GetChildHandler<Contact>(person, "contacts", SortOrder.None).Get(fieldNames);
        }

        public Contact AddContact(Person person, Contact contact)
        {
            return GetChildHandler<Contact>(person, "contacts").Insert(contact);
        }

        public Contact UpdateContact(Person person, Contact contact)
        {
            return GetChildHandler<Contact>(person, "contacts").Update(contact);
        }

        public bool DeleteContact(Person person, Contact contact)
        {
            return GetChildHandler<Contact>(person, "contacts").Delete(contact);
        }

        public bool DeleteAllContacts(Person person)
        {
            return GetChildHandler<Contact>(person, "contacts").DeleteAll();
        }

        #endregion

        #region Permissions

        public List<AccountPermission> GetAccountPermissions(Person person)
        {
            DefaultBaseHandler<AccountPermission> handler = GetChildHandler<AccountPermission>(person, "permissions");
            handler.SortOrder = SortOrder.None;
            handler.AlwaysAsList = true;
            return handler.Get();
        }

        public AccountPermission GetAccountPermissions(Person person, string accountIdentifier)
        {
            return GetAccountPermissions(person, new AccountReference() { ID = accountIdentifier });
        }

        public AccountPermission GetAccountPermissions(Person person, AccountReference account)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            return GetChildHandler<AccountPermission>(person, $"permissions/{account.ID}", SortOrder.None).Get().FirstOrDefault();
        }

        public List<Person> GetPeopleWithRoles(AccessRoles accessRoles, AccountSelection accountSelection, params string[] fieldNames)
        {
            if (accountSelection == AccountSelection.CurrentAccountAndDirectoryAccount)
                return new DefaultBaseHandler<Person>($"{URL}?roles={string.Join(",", accessRoles.Get4meStringCollection())}", AuthenticationTokens, AccountID, ItemsPerRequest, MaximumRecursiveRequests).Get(fieldNames);
            else
                return new DefaultBaseHandler<Person>($"{URL}/all_with_roles?roles={string.Join(",", accessRoles.Get4meStringCollection())}", AuthenticationTokens, AccountID, ItemsPerRequest, MaximumRecursiveRequests).Get(fieldNames);
        }

        public AccountPermission AddAccountPermission(Person person, AccountReference account, AccessRoles accessRoles)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            return AddAccountPermission(person, new AccountPermission() { Account = account, Roles = accessRoles });
        }

        public AccountPermission AddAccountPermission(Person person, AccountPermission permissions)
        {
            if (permissions is null)
                throw new ArgumentNullException(nameof(permissions));

            return GetChildHandler<AccountPermission>(person, $"permissions/{permissions.Account.ID}?roles={string.Join(",", permissions.Roles.Get4meStringCollection())}").Invoke("Post");
        }

        public AccountPermission UpdateAccountPermission(Person person, AccountReference account, AccessRoles accessRoles)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            return UpdateAccountPermission(person, new AccountPermission() { Account = account, Roles = accessRoles });
        }

        public AccountPermission UpdateAccountPermission(Person person, AccountPermission permissions)
        {
            if (permissions is null)
                throw new ArgumentNullException(nameof(permissions));

            return GetChildHandler<AccountPermission>(person, $"permissions/{permissions.Account.ID}?roles={string.Join(",", permissions.Roles.Get4meStringCollection())}").Invoke("Patch");
        }

        public bool RemoveAccountPermission(Person person, AccountReference account)
        {
            return GetChildHandler<AccountPermission>(person, $"permissions/{account.ID}").Invoke("Delete") == null;
        }

        public bool RemoveAllAccountPermissions(Person person)
        {
            return GetChildHandler<AccountPermission>(person, "permissions").Invoke("Delete") == null;
        }

        #endregion

        #region Service coverage

        public List<Service> GetServiceCoverage(Person person, params string[] fieldNames)
        {
            return GetChildHandler<Service>(person, "service_coverages").Get(fieldNames);
        }

        #endregion

        #region Service instance coverage

        public List<ServiceInstance> GetServiceInstanceCoverage(Person person, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(person, "service_instance_coverages").Get(fieldNames);
        }

        #endregion

        #region Service level agreement coverage

        public List<ServiceLevelAgreement> GetServiceLevelAgreementCoverage(Person person, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(person, "sla_coverages").Get(fieldNames);
        }

        #endregion

        #region Teams 

        public List<Team> GetTeams(Person person, params string[] fieldNames)
        {
            return GetChildHandler<Team>(person, "teams").Get(fieldNames);
        }

        public List<Team> GetTeams(PredefinedEnabledDisabledFilter filter, Person person, params string[] fieldNames)
        {
            return GetChildHandler<Team>(person, $"teams/{filter.To4meString()}").Get(fieldNames);
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

        #region Skill pools

        public List<SkillPool> GetSkillPools(Person person, params string[] fieldNames)
        {
            return GetChildHandler<SkillPool>(person, "skill_pools").Get(fieldNames);
        }

        public List<SkillPool> GetSkillPools(PredefinedEnabledDisabledFilter filter, Person person, params string[] fieldNames)
        {
            return GetChildHandler<SkillPool>(person, $"skill_pools/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddSkillPool(Person person, SkillPool skillPool)
        {
            return CreateRelation(person, "skill_pools", skillPool);
        }

        public bool RemoveSkillPool(Person person, SkillPool skillPool)
        {
            return DeleteRelation(person, "skill_pools", skillPool);
        }

        public bool RemoveAllSkillPools(Person person)
        {
            return DeleteAllRelations(person, "skill_pools");
        }

        #endregion

        #region Archive, trash and restore

        public Person Archive(Person person)
        {
            return GetChildHandler<Person>(person, "archive").Invoke("Post");
        }

        public Person Trash(Person person)
        {
            return GetChildHandler<Person>(person, "trash").Invoke("Post");
        }

        public Person Restore(Archive archive)
        {
            return GetChildHandler<Person>(new Person() { ID = archive.Details.ID }, "restore").Invoke("Post");
        }

        public Person Restore(Trash trash)
        {
            return GetChildHandler<Person>(new Person() { ID = trash.Details.ID }, "restore").Invoke("Post");
        }

        #endregion
    }
}
