using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class TaskTemplateApproval : BaseItem
    {
        private Person approver;
        private int? plannedEffort;

        #region created_at (override)

        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = value;
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

        #region approver

        [JsonProperty("approver")]
        public Person Approver
        {
            get => approver;
            set
            {
                if (approver?.ID != value?.ID)
                    AddIncludedDuringSerialization("approver_id");
                approver = value;
            }
        }

        [JsonProperty(PropertyName = "approver_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ApproverID
        {
            get => (approver != null ? approver.ID : (long?)null);
        }

        #endregion

        #region planned_effort

        [JsonProperty("planned_effort")]
        public int? PlannedEffort
        {
            get => plannedEffort;
            set
            {
                if (plannedEffort != value)
                    AddIncludedDuringSerialization("planned_effort");
                plannedEffort = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            approver?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
