using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class TaskApproval : BaseItem
    {
        private Person approver;
        private int? plannedEffort;
        private TaskApprovalStatus? status;

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

        #region task approval

        [JsonProperty("status")]
        public TaskApprovalStatus? Status
        {
            get => status;
            set
            {
                if (status != value)
                    AddIncludedDuringSerialization("status");
                status = value;
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
