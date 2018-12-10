using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class UsageStatement : BaseItem
    {
        private List<long> billableUserIdentifiers;
        private string plan;
        private int year;
        private int month;
        private DateTime startDate;
        private DateTime endDate;
        private int userMonths;

        #region created_at (override)

        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = null;
        }

        #endregion

        #region updated_at (override)

        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region billable_user_ids

        [JsonProperty("billable_user_ids")]
        public List<long> BillableUserIdentifiers
        {
            get => billableUserIdentifiers;
            internal set => billableUserIdentifiers = value;
        }

        #endregion

        #region plan

        [JsonProperty("plan")]
        public string Plan
        {
            get => plan;
            internal set => plan = value;
        }

        #endregion

        #region year

        [JsonProperty("year")]
        public int Year
        {
            get => year;
            internal set => year = value;
        }

        #endregion

        #region month

        [JsonProperty("month")]
        public int Month
        {
            get => month;
            internal set => month = value;
        }

        #endregion

        #region start_date

        [JsonProperty("start_date")]
        public DateTime StartDate
        {
            get => startDate;
            internal set => startDate = value;
        }

        #endregion

        #region end_date

        [JsonProperty("end_date")]
        public DateTime EndDate
        {
            get => endDate;
            internal set => endDate = value;
        }

        #endregion

        #region user_months

        [JsonProperty("user_months")]
        public int UserMonths
        {
            get => userMonths;
            internal set => userMonths = value;
        }

        #endregion
    }
}
