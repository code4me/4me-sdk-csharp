using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/task_templates/approvals/">task template approval</see> object.
    /// </summary>
    public class TaskTemplateApproval : BaseItem
    {
        private Person approver;
        private TimeSpan? plannedEffort;

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

        #region Approver

        /// <summary>
        /// The ID of the person who is selected as the approver for the task template approval.
        /// </summary>
        [JsonProperty("approver")]
        public Person Approver
        {
            get => approver;
            set => approver = SetValue("approver_id", approver, value);
        }

        [JsonProperty("approver_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ApproverID => approver?.ID;

        #endregion

        #region Planned effort

        /// <summary>
        /// The Planned effort field is used to enter the number of minutes the approver is expected to spend working on a task that was created based on the task template to which the approval belongs.
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
            approver?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
