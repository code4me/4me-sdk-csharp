using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public sealed class BillableUser : BaseItem
    {
        private string account;
        private string businessUnit;
        private DateTime? lastVisit;
        private string name;
        private string organization;
        private string primaryEmail;
        private long? signIns;

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

        #region Account

        /// <summary>
        /// The account of the person.
        /// </summary>
        [JsonProperty("account"), Sdk4meIgnoreInFieldSelection()]
        public new string Account
        {
            get => account;
            internal set => account = value;
        }

        #endregion

        #region Business unit

        [JsonProperty("business_unit")]
        public string BusinessUnit
        {
            get => businessUnit;
            internal set => businessUnit = value;
        }

        #endregion

        #region Last visit

        [JsonProperty("last_visit")]
        public DateTime? LastVisit
        {
            get => lastVisit;
            internal set => lastVisit = value;
        }

        #endregion

        #region Name

        [JsonProperty("name")]
        public string Name
        {
            get => name;
            internal set => name = value;
        }

        #endregion

        #region Organization

        [JsonProperty("organization")]
        public string Organization
        {
            get => organization;
            internal set => organization = value;
        }

        #endregion

        #region Primary email

        [JsonProperty("primary_email")]
        public string PrimaryEmail
        {
            get => primaryEmail;
            internal set => primaryEmail = value;
        }

        #endregion

        #region Sign ins

        [JsonProperty("sign_ins")]
        public long? SignIns
        {
            get => signIns;
            internal set => signIns = value;
        }

        #endregion
    }
}
