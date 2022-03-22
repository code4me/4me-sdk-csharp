using Sdk4me.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    public sealed class AccountHandler : IBaseHandler
    {
        private readonly AuthenticationTokenCollection authenticationTokens = null;
        private readonly string accountID = null;
        private readonly string url = null;
        private readonly string peopleUrl = null;
        private int itemsPerRequest = 25;
        private int maximumRecursiveRequests = 10;

        /// <summary>
        /// <para>Gets or sets the number of items returned in one request.</para>
        /// <para>The value must be at least 1 and maximum 100.</para>
        /// </summary>
        public int ItemsPerRequest
        {
            get => itemsPerRequest;
            set => itemsPerRequest = (value < 1 || value > 100) ? 25 : value;
        }

        /// <summary>
        /// <para>Gets or sets the number of recursive requests.</para>
        /// <para>The value must be at least 1 and maximum 1000.</para>
        /// </summary>
        public int MaximumRecursiveRequests
        {
            get => maximumRecursiveRequests;
            set => maximumRecursiveRequests = (value < 1 || value > 1000) ? 10 : value;
        }

        public AccountHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : this(new AuthenticationTokenCollection(authenticationToken), accountID, environmentType, environmentRegion, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public AccountHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
        {
            //validate string argument values
            if (string.IsNullOrWhiteSpace(accountID))
                throw new ArgumentException($"'{nameof(accountID)}' cannot be null or whitespace.", nameof(accountID));

            //validate authentication tokens
            if (authenticationTokens is null)
                throw new ArgumentNullException(nameof(authenticationTokens));

            if (!authenticationTokens.Any())
                throw new ArgumentException($"'{nameof(authenticationTokens)}' cannot be empty.", nameof(authenticationTokens));

            //set global variables
            url = $"{EnvironmentURL.Get(environmentType, environmentRegion)}/account";
            peopleUrl = $"{EnvironmentURL.Get(environmentType, environmentRegion)}/people";
            this.authenticationTokens = authenticationTokens;
            this.accountID = accountID;
            this.itemsPerRequest = (itemsPerRequest < 1 || itemsPerRequest > 100) ? 25 : itemsPerRequest;
            this.maximumRecursiveRequests = (maximumRecursiveRequests < 1 || maximumRecursiveRequests > 1000) ? 10 : maximumRecursiveRequests;
        }

        /// <summary>
        /// Get the current account information.
        /// </summary>
        /// <returns>The account information for the currently used <see cref="AuthenticationToken"/>.</returns>
        public Account Get()
        {
            return new DefaultBaseHandler<Account>(url, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests) { SortOrder = SortOrder.None }.Get().FirstOrDefault();
        }

        #region Permissions

        /// <summary>
        /// Returns all people that are registered in this account and its directory account, provided that these people have at least one of the specified roles.
        /// </summary>
        /// <param name="accessRoles">The access roles.</param>
        /// <returns>A person collection.</returns>
        public List<Person> GetPeopleWithRoles(AccessRoles accessRoles, AccountSelection accountSelection, params string[] fieldNames)
        {
            if (accountSelection == AccountSelection.CurrentAccountAndDirectoryAccount)
                return new DefaultBaseHandler<Person>($"{peopleUrl}?roles={string.Join(",", accessRoles.Get4meStringCollection())}", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests).Get(fieldNames);
            else
                return new DefaultBaseHandler<Person>($"{peopleUrl}/all_with_roles?roles={string.Join(",", accessRoles.Get4meStringCollection())}", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests).Get(fieldNames);
        }

        #endregion

        #region billable users

        /// <summary>
        /// Get all billable users for the current account.
        /// </summary>
        /// <returns>A list of billable users.</returns>
        public List<BillableUser> GetBillableUsers()
        {
            return new DefaultBaseHandler<BillableUser>($"{url}/billable_users", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests) { SortOrder = SortOrder.None }.Get();
        }

        /// <summary>
        /// Get all billable users for the current account.
        /// </summary>
        /// <param name="year">The year for which to get the billable users.</param>
        /// <param name="month">The month for which to get the billable users.</param>
        /// <returns>A list of billable users for a specific month.</returns>
        public List<BillableUser> GetBillableUsers(int year, int month)
        {
            return new DefaultBaseHandler<BillableUser>($"{url}/billable_users?year={year}&month={month}", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests) { SortOrder = SortOrder.None }.Get();
        }

        /// <summary>
        /// Get all billable users for the current account.
        /// </summary>
        /// <param name="date">The date for which to get the billable users; only the year and month value are taken into account.</param>
        /// <returns>A list of billable users for a specific month.</returns>
        public List<BillableUser> GetBillableUsers(DateTime date)
        {
            return GetBillableUsers(date.Year, date.Month);
        }

        #endregion

        #region usage statements

        /// <summary>
        /// Get all usage statements for the current account.
        /// </summary>
        /// <returns>A list of usage statements.</returns>
        public List<UsageStatement> GetUsageStatements()
        {
            return new DefaultBaseHandler<UsageStatement>($"{url}/usage_statements", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests) { SortOrder = SortOrder.None }.Get();
        }

        /// <summary>
        /// Get all billable users for the current account.
        /// </summary>
        /// <param name="year">The year for which to get the billable users.</param>
        /// <param name="month">The month for which to get the billable users.</param>
        /// <returns>A list of billable users for a specific month.</returns>
        public List<UsageStatement> GetUsageStatements(int year, int month)
        {
            return new DefaultBaseHandler<UsageStatement>($"{url}/usage_statements?year={year}&month={month}", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests) { SortOrder = SortOrder.None }.Get();
        }

        /// <summary>
        /// Get all billable users for the current account.
        /// </summary>
        /// <param name="date">The date for which to get the billable users; only the year and month value are taken into account.</param>
        /// <returns>A list of billable users for a specific month.</returns>
        public List<UsageStatement> GetUsageStatements(DateTime date)
        {
            return GetUsageStatements(date.Year, date.Month);
        }

        #endregion
    }
}
