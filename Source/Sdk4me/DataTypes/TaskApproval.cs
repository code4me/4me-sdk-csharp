using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class TaskApproval : BaseItem
    {
        private Person approver;
        private int? plannedEffortInMinutes;
        private TaskApprovalStatus? status;

        //#region created_at (override)

        //[JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        //public override DateTime? CreatedAt
        //{
        //    get => base.CreatedAt;
        //    internal set => base.CreatedAt = value;
        //}

        //#endregion

        //#region updated_at (override)

        //[JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        //public override DateTime? UpdatedAt
        //{
        //    get => base.UpdatedAt;
        //    internal set => base.UpdatedAt = value;
        //}

        //#endregion

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

        #region planned_effort_in_minutes

        [JsonProperty("planned_effort_in_minutes")]
        public int? PlannedEffortInMinutes
        {
            get => plannedEffortInMinutes;
            set
            {
                if (plannedEffortInMinutes != value)
                    AddIncludedDuringSerialization("planned_effort_in_minutes");
                plannedEffortInMinutes = value;
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
