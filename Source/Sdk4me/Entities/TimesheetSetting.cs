using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/timesheet_settings/">time sheet setting</see> object.
    /// </summary>
    public class TimesheetSetting : BaseItem
    {
        private bool allocationTimeTracking;
        private bool allowWorkdayOvertime;
        private bool allowWorkweekOvertime;
        private bool assignmentTimeTracking;
        private bool disabled;
        private string name;
        private bool notifyOnIncomplete;
        private TimesheetPercentageIncrement? percentageIncrement;
        private EffortClass problemEffortClass;
        private EffortClass projectTaskEffortClass;
        private EffortClass requestEffortClass;
        private bool requireNote;
        private string source;
        private string sourceID;
        private EffortClass taskEffortClass;
        private EffortClass timeAllocationEffortClass;
        private int? timeIncrement;
        private TimesheetUnit unit;
        private TimeSpan? workday;
        private TimeSpan? workweek;

        #region Allocation time tracking

        /// <summary>
        /// The Allocation time tracking box is checked when people of the related organizations need to be able to register time entries for the time allocations that are linked to their organizations.
        /// </summary>
        [JsonProperty("allocation_time_tracking")]
        public bool AllocationTimeTracking
        {
            get => allocationTimeTracking;
            set => allocationTimeTracking = SetValue("allocation_time_tracking", allocationTimeTracking, value);
        }

        #endregion

        #region Allow workday overtime

        /// <summary>
        /// The Allow workday overtime box is checked when the people of the organizations to which the timesheet settings are linked are allowed to register more time for a single day than the amount of time specified in the Workday field.
        /// </summary>
        [JsonProperty("allow_workday_overtime")]
        public bool AllowWorkdayOvertime
        {
            get => allowWorkdayOvertime;
            set => allowWorkdayOvertime = SetValue("allow_workday_overtime", allowWorkdayOvertime, value);
        }

        #endregion

        #region Allow workweek overtime

        /// <summary>
        /// The Allow workweek overtime box is checked when the people of the organizations to which the timesheet settings are linked are allowed to register more time for a single week than the amount of time specified in the Workweek field.
        /// </summary>
        [JsonProperty("allow_workweek_overtime")]
        public bool AllowWorkweekOvertime
        {
            get => allowWorkweekOvertime;
            set => allowWorkweekOvertime = SetValue("allow_workweek_overtime", allowWorkweekOvertime, value);
        }

        #endregion

        #region Assignment time tracking

        /// <summary>
        /// The Assignment time tracking box is checked when the Time spent field needs to be available in requests, problems and tasks for specialists of the related organizations to specify how long they have worked on their assignments.
        /// </summary>
        [JsonProperty("assignment_time_tracking")]
        public bool AssignmentTimeTracking
        {
            get => assignmentTimeTracking;
            set => assignmentTimeTracking = SetValue("assignment_time_tracking", assignmentTimeTracking, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the timesheet settings may no longer be related to any more organizations.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the timesheet settings.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Notify on incomplete

        /// <summary>
        /// The ‘Notify people when their timesheet is incomplete’ checkbox prevents 4me from sending notifications to people whose timesheet is incomplete.
        /// </summary>
        [JsonProperty("notify_on_incomplete")]
        public bool NotifyOnIncomplete
        {
            get => notifyOnIncomplete;
            set => notifyOnIncomplete = SetValue("notify_on_incomplete", notifyOnIncomplete, value);
        }

        #endregion

        #region Percentage increment

        /// <summary>
        /// The Percentage Increment field is used to select the minimum amount percentage of a workday that the people of the organizations to which the timesheet settings are linked can select when they register a time entry. This percentage of a workday is also the increment by which they can increase this minimum percentage of a workday. 
        /// </summary>
        [JsonProperty("percentage_increment")]
        public TimesheetPercentageIncrement? PercentageIncrement
        {
            get => percentageIncrement;
            set => percentageIncrement = SetValue("percentage_increment", percentageIncrement, value);
        }

        #endregion

        #region Problem effort class

        /// <summary>
        /// The effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a problem.
        /// </summary>
        [JsonProperty("problem_effort_class")]
        public EffortClass ProblemEffortClass
        {
            get => problemEffortClass;
            set => problemEffortClass = SetValue("problem_effort_class_id", problemEffortClass, value);
        }

        [JsonProperty("problem_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProblemEffortClassID => problemEffortClass?.ID;

        #endregion

        #region Project task effort class

        /// <summary>
        /// The effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a project task.
        /// </summary>
        [JsonProperty("project_task_effort_class")]
        public EffortClass ProjectTaskEffortClass
        {
            get => projectTaskEffortClass;
            set => projectTaskEffortClass = SetValue("project_task_effort_class_id", projectTaskEffortClass, value);
        }

        [JsonProperty("project_task_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProjectTaskEffortClassID => projectTaskEffortClass?.ID;

        #endregion

        #region Request effort class

        /// <summary>
        /// The effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a request.
        /// </summary>
        [JsonProperty("request_effort_class")]
        public EffortClass RequestEffortClass
        {
            get => requestEffortClass;
            set => requestEffortClass = SetValue("request_effort_class_id", requestEffortClass, value);
        }

        [JsonProperty("request_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? RequestEffortClassID => requestEffortClass?.ID;

        #endregion

        #region Require note

        /// <summary>
        /// The Require note box is checked when the Note field needs to become required, when someone in an organization linked to the timesheet settings registers time on a request, problem or task.
        /// </summary>
        [JsonProperty("require_note")]
        public bool RequireNote
        {
            get => requireNote;
            set => requireNote = SetValue("require_note", requireNote, value);
        }

        #endregion

        #region Source

        /// <summary>
        /// See source
        /// </summary>
        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set => source = SetValue("source", source, value);
        }

        #endregion

        #region SourceID

        /// <summary>
        /// See source
        /// </summary>
        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set => sourceID = SetValue("sourceID", sourceID, value);
        }

        #endregion

        #region Task effort class

        /// <summary>
        /// The effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a workflow task.
        /// </summary>
        [JsonProperty("task_effort_class")]
        public EffortClass TaskEffortClass
        {
            get => taskEffortClass;
            set => taskEffortClass = SetValue("task_effort_class_id", taskEffortClass, value);
        }

        [JsonProperty("task_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TaskEffortClassID => taskEffortClass?.ID;

        #endregion

        #region Time allocation effort class

        /// <summary>
        /// The effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a time allocation.
        /// </summary>
        [JsonProperty("time_allocation_effort_class")]
        public EffortClass TimeAllocationEffortClass
        {
            get => timeAllocationEffortClass;
            set => timeAllocationEffortClass = SetValue("time_allocation_effort_class_id", timeAllocationEffortClass, value);
        }

        [JsonProperty("time_allocation_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TimeAllocationEffortClassID => timeAllocationEffortClass?.ID;

        #endregion

        #region Time increment

        /// <summary>
        /// The Time Increment field is used to select the minimum amount of time that the people of the organizations to which the timesheet settings are linked can select when they register a time entry. This amount of time is also the increment by which they can increase this minimum amount of time.
        /// </summary>
        [JsonProperty("time_increment")]
        public int? TimeIncrement
        {
            get => timeIncrement;
            set => timeIncrement = SetValue("time_increment", timeIncrement, value);
        }

        #endregion

        #region Unit

        /// <summary>
        /// The Unit field is used to specify whether the people of the organizations to which the timesheet settings are linked need to register their time in hours and minutes, or as a percentage of a workday. 
        /// </summary>
        [JsonProperty("unit")]
        public TimesheetUnit Unit
        {
            get => unit;
            set => unit = SetValue("unit", unit, value);
        }

        #endregion

        #region Workday

        /// <summary>
        /// The Workday field is used to specify the duration of a workday.
        /// </summary>
        public TimeSpan? Workday
        {
            get => workday;
            set => workday = SetValue("workday", workday, value);
        }

        /// <summary>
        /// The Workday field is used to specify the duration of a workday.
        /// </summary>
        [JsonProperty("workday")]
        public int? WorkdayInMinutes
        {
            get => workday != null ? Convert.ToInt32(workday.Value.TotalMinutes) : (int?)null;
            set => workday = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Workweek

        /// <summary>
        /// The Workweek field is used to specify the duration of a workweek.
        /// </summary>
        public TimeSpan? Workweek
        {
            get => workweek;
            set => workweek = SetValue("workweek", workweek, value);
        }

        /// <summary>
        /// The Workweek field is used to specify the duration of a workweek.
        /// </summary>
        [JsonProperty("workweek")]
        public int? WorkweekInMinutes
        {
            get => workweek != null ? Convert.ToInt32(workweek.Value.TotalMinutes) : (int?)null;
            set => workweek = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            problemEffortClass?.ResetPropertySerializationCollection();
            projectTaskEffortClass?.ResetPropertySerializationCollection();
            requestEffortClass?.ResetPropertySerializationCollection();
            taskEffortClass?.ResetPropertySerializationCollection();
            timeAllocationEffortClass?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
