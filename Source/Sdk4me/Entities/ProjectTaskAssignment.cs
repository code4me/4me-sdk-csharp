using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/project_tasks/assignments/">project task assignment</see> object.
    /// </summary>
    public class ProjectTaskAssignment : BaseItem
    {
        private Person assignee;
        private string attachment;
        private TimeSpan? plannedEffort;
        private ProjectTaskStatus status;
        private DateTime? canceled;
        private DateTime? waitingUntil;

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

        #region Assignee

        /// <summary>
        /// The ID of the person who is selected as the assignee for the assignment.
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

        #region Attachment

        /// <summary>
        /// The hyperlink to the Project Summary PDF file that was generated for the assignee when the assignment was last set to the status assigned (for project tasks of the category approval only).
        /// </summary>
        [JsonProperty("attachment")]
        public string Attachment
        {
            get => attachment;
            internal set => attachment = value;
        }

        #endregion

        #region Planned effort

        /// <summary>
        /// The Planned effort field is used to enter the number of minutes the assignee is expected to spend working on the project task to which the assignment belongs.
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

        #region Status

        /// <summary>
        /// The status of the assignment. 
        /// </summary>
        [JsonProperty("status")]
        public ProjectTaskStatus Status
        {
            get => status;
            internal set => status = value;
        }

        #endregion

        #region Canceled

        /// <summary>
        /// The date and time of the last update of the assignment. If the assignment has had no updates it contains the created_at value.
        /// </summary>
        [JsonProperty("canceled")]
        public DateTime? Canceled
        {
            get => canceled;
            internal set => canceled = value;
        }

        #endregion

        #region Waiting until

        /// <summary>
        /// The Waiting until field is used to specify the date and time at which the status of the assignment is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [JsonProperty("waiting_until")]
        public DateTime? WaitingUntil
        {
            get => waitingUntil;
            set => waitingUntil = SetValue("waiting_until", waitingUntil, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            assignee?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
