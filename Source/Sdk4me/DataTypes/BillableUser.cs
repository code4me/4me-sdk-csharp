using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class BillableUser : BaseItem
    {
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

        #region business_unit

        [JsonProperty("business_unit")]
        public string BusinessUnit
        {
            get => businessUnit;
            internal set => businessUnit = value;
        }

        #endregion

        #region last_visit

        [JsonProperty("last_visit")]
        public DateTime? LastVisit
        {
            get => lastVisit;
            internal set => lastVisit = value;
        }

        #endregion

        #region name

        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                    AddIncludedDuringSerialization("name");
                name = value;
            }
        }

        #endregion

        #region organization

        [JsonProperty("organization")]
        public string Organization
        {
            get => organization;
            set
            {
                if (organization != value)
                    AddIncludedDuringSerialization("organization");
                organization = value;
            }
        }

        #endregion

        #region primary_email

        [JsonProperty("primary_email")]
        public string PrimaryEmail
        {
            get => primaryEmail;
            internal set => primaryEmail = value;
        }

        #endregion

        #region sign_ins

        [JsonProperty("sign_ins")]
        public long? SignIns
        {
            get => signIns;
            internal set => signIns = value;
        }

        #endregion
    }
}
