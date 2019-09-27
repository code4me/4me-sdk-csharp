using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class ProjectTaskTemplateAssignment : BaseItem
    {
        private Person assignee;
        private int? plannedEffortInMinutes;

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

        #region planned_effort

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

        internal override void ResetIncludedDuringSerialization()
        {
            assignee?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
