using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class AccountHandler : IBaseHandler
    {
        private readonly AuthenticationTokenCollection authenticationTokens = null;
        private readonly string accountID = null;
        private readonly string qualityUrl = "https://api.4me.qa/v1/account";
        private readonly string productionUrl = "https://api.4me.com/v1/account";
        private readonly string url = null;
        private int itemsPerRequest = 100;
        private int maximumRecursiveRequests = 50;

        /// <summary>
        /// <para>Gets or sets the amount of items returned in one request.</para>
        /// <para>The value must be at least 1 and maximum 100.</para>
        /// </summary>
        public int ItemsPerRequest
        {
            get => itemsPerRequest;
            set => itemsPerRequest = (value < 1 || value > 100) ? 100 : value;
        }

        /// <summary>
        /// <para>Gets or sets the amount of recursive requests.</para>
        /// </summary>
        public int MaximumRecursiveRequests
        {
            get => maximumRecursiveRequests;
            set => maximumRecursiveRequests = (value < 1 || value > 1000) ? 50 : value;
        }

        /// <summary>
        /// Creates a new instance of the AccountHandler.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication object.</param>
        /// <param name="accountID">The 4me account identifier.</param>
        /// <param name="environmentType">The 4me environment.</param>
        public AccountHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
        {
            this.authenticationTokens = new AuthenticationTokenCollection(authenticationToken);
            this.accountID = accountID;
            this.url = environmentType == EnvironmentType.Production ? productionUrl : qualityUrl;
            this.itemsPerRequest = itemsPerRequest;
            this.maximumRecursiveRequests = maximumRecursiveRequests;
        }

        /// <summary>
        /// Creates a new instance of the AccountHandler.
        /// </summary>
        /// <param name="authenticationTokens">A collection of 4me authorization objects.</param>
        /// <param name="accountID">The 4me account identifier.</param>
        /// <param name="environmentType">The 4me environment.</param>
        public AccountHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
        {
            this.authenticationTokens = authenticationTokens;
            this.accountID = accountID;
            this.url = environmentType == EnvironmentType.Production ? productionUrl : qualityUrl;
            this.itemsPerRequest = itemsPerRequest;
            this.maximumRecursiveRequests = maximumRecursiveRequests;
        }

        /// <summary>
        /// Get the current account information.
        /// </summary>
        /// <returns>The current Account object.</returns>
        public Account Get()
        {
            BaseHandler<Account> handler = new BaseHandler<Account>($"{url}", authenticationTokens, accountID, 100, 1000);
            handler.SortOrder = SortOrder.None;
            return handler.Get()[0];
        }

        #region billable users

        /// <summary>
        /// Get all billable users for the current account.
        /// </summary>
        /// <returns>A list of billable users.</returns>
        public List<BillableUser> GetBillableUsers()
        {
            BaseHandler<BillableUser> handler = new BaseHandler<BillableUser>($"{url}/billable_users", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests);
            handler.SortOrder = SortOrder.None;
            return handler.Get("*");
        }

        /// <summary>
        /// Get all billable users for the current account.
        /// </summary>
        /// <param name="year">The year for which to get the billable users.</param>
        /// <param name="month">The month for which to get the billable users.</param>
        /// <returns>A list of billable users for a specific month.</returns>
        public List<BillableUser> GetBillableUsers(int year, int month)
        {
            BaseHandler<BillableUser> handler = new BaseHandler<BillableUser>($"{url}/billable_users?year={year}&month={month}", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests);
            handler.SortOrder = SortOrder.None;
            return handler.Get("*");
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
            BaseHandler<UsageStatement> handler = new BaseHandler<UsageStatement>($"{url}/usage_statements", authenticationTokens, accountID, 100, 1000);
            handler.SortOrder = SortOrder.None;
            return handler.Get("*");
        }

        /// <summary>
        /// Get all billable users for the current account.
        /// </summary>
        /// <param name="year">The year for which to get the billable users.</param>
        /// <param name="month">The month for which to get the billable users.</param>
        /// <returns>A list of billable users for a specific month.</returns>
        public List<UsageStatement> GetUsageStatements(int year, int month)
        {
            BaseHandler<UsageStatement> handler = new BaseHandler<UsageStatement>($"{url}/usage_statements?year={year}&month={month}", authenticationTokens, accountID, 100, 1000);
            handler.SortOrder = SortOrder.None;
            return handler.Get("*");
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
