using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class ProjectTaskAssignment : BaseItem
    {
        private Person assignee;
        private Attachment attachment;
        private int? plannedEffort;
        private AssignmentStatusType? status;
        private DateTime? waitingUntil;

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

        #region assignee

        [JsonProperty("assignee")]
        public Person Assignee
        {
            get => assignee;
            set
            {
                if (assignee?.ID != value?.ID)
                    AddIncludedDuringSerialization("assignee_id");
                assignee = value;
            }
        }

        [JsonProperty(PropertyName = "assignee_id"), Sdk4meIgnoreInFieldSelection()]
        private long? AssigneeID
        {
            get => (assignee != null ? assignee.ID : (long?)null);
        }

        #endregion

        #region attachment

        [JsonProperty("attachment")]
        public Attachment Attachment
        {
            get => attachment;
            internal set => attachment = value;
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

        #region status

        [JsonProperty("status")]
        public AssignmentStatusType? Status
        {
            get => status;
            internal set => status = value;
        }

        #endregion

        #region waiting_until

        [JsonProperty("waiting_until")]
        public DateTime? WaitingUntil
        {
            get => waitingUntil;
            set
            {
                if (waitingUntil != value)
                    AddIncludedDuringSerialization("waiting_until");
                waitingUntil = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            assignee?.ResetIncludedDuringSerialization();
            attachment?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
