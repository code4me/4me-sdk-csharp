using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/project_task_templates/assignments/">project task template assignment</see> object.
    /// </summary>
    public class ProjectTaskTemplateAssignment : BaseItem
    {
        private Person assignee;
        private TimeSpan? plannedEffort;

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

        #region Assignee

        /// <summary>
        /// The ID of the person who is selected as the assignee for the project task template assignment.
        /// </summary>
        [JsonProperty("assignee")]
        public Person Assignee
        {
            get => assignee;
            set => assignee = SetValue("assignee_id", assignee, value);
        }

        [JsonProperty("assignee_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? AssigneeID => assignee?.ID;

        #endregion

        #region Planned effort

        /// <summary>
        /// The Planned effort field is used to enter the number of minutes the assignee is expected to spend working on a project task that was created based on the project task template to which the assignment belongs.
        /// </summary>
        public TimeSpan? PlannedEffort
        {
            get => plannedEffort;
            set => plannedEffort = SetValue("planned_effort", plannedEffort, value);
        }

        [JsonProperty("planned_effort")]
        internal int? PlannedEffortInMinutes
        {
            get => plannedEffort != null ? Convert.ToInt32(plannedEffort.Value.TotalMinutes) : (int?)null;
            set => plannedEffort = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            assignee?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
