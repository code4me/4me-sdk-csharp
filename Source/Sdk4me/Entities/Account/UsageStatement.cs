using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/account/usage_statements/">usage statement</see> object.
    /// </summary>
    public sealed class UsageStatement : BaseItem
    {
        private List<long> billableUserIds;
        private DateTime endDate;
        private int month;
        private AccountPlan plan;
        private DateTime startDate;
        private int userMonths;
        private int year;

        #region Created at (override)

        /// <summary>
        /// The creation date and time; which is obsolete for this object.
        /// </summary>
        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = null;
        }

        #endregion

        #region Updated at (override)

        /// <summary>
        /// The updated date and time; which is obsolete for this object.
        /// </summary>
        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region Billable user identifiers

        /// <summary>
        /// The IDs of the Person records that are registered in the account and which were enabled and had a role (other than End User or Key Contact) at any time between the start date and the end date.
        /// </summary>
        [JsonProperty("billable_user_ids")]
        public List<long> BillableUserIds
        {
            get => billableUserIds;
            internal set => billableUserIds = value;
        }

        #endregion

        #region End date

        /// <summary>
        /// The date on which the billing period ended.
        /// </summary>
        [JsonProperty("end_date")]
        public DateTime EndDate
        {
            get => endDate;
            internal set => endDate = value;
        }

        #endregion

        #region Month

        /// <summary>
        /// The month for which the usage statement was generated.
        /// </summary>
        [JsonProperty("month")]
        public int Month
        {
            get => month;
            internal set => month = value;
        }

        #endregion

        #region Plan

        /// <summary>
        /// The Plan field is used to select the Plan for the account. 
        /// </summary>
        [JsonProperty("plan")]
        public AccountPlan Plan
        {
            get => plan;
            internal set => plan = value;
        }

        #endregion

        #region Start date

        /// <summary>
        /// The date on which the billing period started.
        /// </summary>
        [JsonProperty("start_date")]
        public DateTime StartDate
        {
            get => startDate;
            internal set => startDate = value;
        }

        #endregion

        #region User months

        /// <summary>
        /// The number of Person records that are registered in the account and which were enabled and had a role (other than End User or Key Contact) at any time between the start date and the end date.
        /// </summary>
        [JsonProperty("user_months")]
        public int UserMonths
        {
            get => userMonths;
            internal set => userMonths = value;
        }

        #endregion

        #region Year

        /// <summary>
        /// The year for which the usage statement was generated.
        /// </summary>
        [JsonProperty("year")]
        public int Year
        {
            get => year;
            internal set => year = value;
        }

        #endregion
    }
}
