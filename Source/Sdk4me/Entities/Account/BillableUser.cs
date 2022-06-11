using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/account/billable_users/">billable users</see> object.
    /// </summary>
    public sealed class BillableUser : BaseItem
    {
        private string account;
        private string businessUnit;
        private DateTime? lastVisit;
        private string name;
        private string organization;
        private string primaryEmail;
        private string region;
        private long? signIns;
        private int? updates;

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

        /// <summary>
        /// The Business unit field shows the name of the business unit that the person’s organization belongs to.
        /// </summary>
        [JsonProperty("business_unit")]
        public string BusinessUnit
        {
            get => businessUnit;
            internal set => businessUnit = value;
        }

        #endregion

        #region Last visit

        /// <summary>
        /// The date and time at which the person last accessed the 4me service.
        /// </summary>
        [JsonProperty("last_visit")]
        public DateTime? LastVisit
        {
            get => lastVisit;
            internal set => lastVisit = value;
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the person’s name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            internal set => name = value;
        }

        #endregion

        #region Organization

        /// <summary>
        /// The Organization field shows the name of the organization that the person belongs to.
        /// </summary>
        [JsonProperty("organization")]
        public string Organization
        {
            get => organization;
            internal set => organization = value;
        }

        #endregion

        #region Primary email

        /// <summary>
        /// The Primary email field is used to enter the email address to which email notifications are to be sent.
        /// </summary>
        [JsonProperty("primary_email")]
        public string PrimaryEmail
        {
            get => primaryEmail;
            internal set => primaryEmail = value;
        }

        #endregion

        #region Region

        /// <summary>
        /// The Region field shows the name of the region of the person’s organization.
        /// </summary>
        [JsonProperty("region")]
        public string Region
        {
            get => region;
            internal set => region = value;
        }

        #endregion

        #region Sign ins

        /// <summary>
        /// The total number of times to date that the person has signed into the 4me service.
        /// </summary>
        [JsonProperty("sign_ins")]
        public long? SignIns
        {
            get => signIns;
            internal set => signIns = value;
        }

        #endregion

        #region Updates

        /// <summary>
        /// The number of record updates the person made in the given month through using the UI acting to support.
        /// </summary>
        [JsonProperty("updates")]
        public int? Updates
        {
            get => updates;
            internal set => updates = value;
        }

        #endregion
    }
}
