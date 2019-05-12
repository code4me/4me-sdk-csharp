using Newtonsoft.Json;

namespace Sdk4me
{
    public class TimesheetSetting : BaseItem
    {
        private bool allocationTimeTracking;
        private bool allowWorkdayOvertime;
        private bool allowWorkweekOvertime;
        private bool disabled;
        private string name;
        private float? percentageIncrement;
        private EffortClass problemEffortClass;
        private EffortClass projectTaskEffortClass;
        private EffortClass requestEffortClass;
        private string source;
        private string sourceID;
        private EffortClass taskEffortClass;
        private EffortClass timeAllocationEffortClass;
        private long? timeIncrement;
        private TimesheetSettingsUnitType unit;
        private int workday;
        private int workweek;

        #region allocation_time_tracking

        [JsonProperty("allocation_time_tracking")]
        public bool AllocationTimeTracking
        {
            get => allocationTimeTracking;
            set
            {
                if (allocationTimeTracking != value)
                    AddIncludedDuringSerialization("allocation_time_tracking");
                allocationTimeTracking = value;
            }
        }

        #endregion

        #region allow_workday_overtime

        [JsonProperty("allow_workday_overtime")]
        public bool AllowWorkdayOvertime
        {
            get => allowWorkdayOvertime;
            set
            {
                if (allowWorkdayOvertime != value)
                    AddIncludedDuringSerialization("allow_workday_overtime");
                allowWorkdayOvertime = value;
            }
        }

        #endregion

        #region allow_workweek_overtime

        [JsonProperty("allow_workweek_overtime")]
        public bool AllowWorkweekOvertime
        {
            get => allowWorkweekOvertime;
            set
            {
                if (allowWorkweekOvertime != value)
                    AddIncludedDuringSerialization("allow_workweek_overtime");
                allowWorkweekOvertime = value;
            }
        }

        #endregion

        #region disabled

        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set
            {
                if (disabled != value)
                    AddIncludedDuringSerialization("disabled");
                disabled = value;
            }
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

        #region percentage_increment

        [JsonProperty("percentage_increment")]
        public float? PercentageIncrement
        {
            get => percentageIncrement;
            set
            {
                if (percentageIncrement != value)
                    AddIncludedDuringSerialization("percentage_increment");
                percentageIncrement = value;
            }
        }

        #endregion

        #region problem_effort_class

        [JsonProperty("problem_effort_class")]
        public EffortClass ProblemEffortClass
        {
            get => problemEffortClass;
            set
            {
                if (problemEffortClass?.ID != value?.ID)
                    AddIncludedDuringSerialization("problem_effort_class_id");
                problemEffortClass = value;
            }
        }

        [JsonProperty(PropertyName = "problem_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ProblemEffortClassID
        {
            get => (problemEffortClass != null ? problemEffortClass.ID : (long?)null);
        }

        #endregion

        #region project_task_effort_class

        [JsonProperty("project_task_effort_class")]
        public EffortClass ProjectTaskEffortClass
        {
            get => projectTaskEffortClass;
            set
            {
                if (projectTaskEffortClass?.ID != value?.ID)
                    AddIncludedDuringSerialization("project_task_effort_class_id");
                projectTaskEffortClass = value;
            }
        }

        [JsonProperty(PropertyName = "project_task_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ProjectTaskEffortClassID
        {
            get => (projectTaskEffortClass != null ? projectTaskEffortClass.ID : (long?)null);
        }

        #endregion

        #region request_effort_class

        [JsonProperty("request_effort_class")]
        public EffortClass RequestEffortClass
        {
            get => requestEffortClass;
            set
            {
                if (requestEffortClass?.ID != value?.ID)
                    AddIncludedDuringSerialization("request_effort_class_id");
                requestEffortClass = value;
            }
        }

        [JsonProperty(PropertyName = "request_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        private long? RequestEffortClassID
        {
            get => (requestEffortClass != null ? requestEffortClass.ID : (long?)null);
        }

        #endregion

        #region source

        [JsonProperty("source")]
        public string Source
        {
            get => source;
            set
            {
                if (source != value)
                    AddIncludedDuringSerialization("source");
                source = value;
            }
        }

        #endregion

        #region sourceID

        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set
            {
                if (sourceID != value)
                    AddIncludedDuringSerialization("sourceID");
                sourceID = value;
            }
        }

        #endregion

        #region task_effort_class

        [JsonProperty("task_effort_class")]
        public EffortClass TaskEffortClass
        {
            get => taskEffortClass;
            set
            {
                if (taskEffortClass?.ID != value?.ID)
                    AddIncludedDuringSerialization("task_effort_class_id");
                taskEffortClass = value;
            }
        }

        [JsonProperty(PropertyName = "task_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        private long? TaskEffortClassID
        {
            get => (taskEffortClass != null ? taskEffortClass.ID : (long?)null);
        }

        #endregion

        #region time_allocation_effort_class

        [JsonProperty("time_allocation_effort_class")]
        public EffortClass TimeAllocationEffortClass
        {
            get => timeAllocationEffortClass;
            set
            {
                if (timeAllocationEffortClass?.ID != value?.ID)
                    AddIncludedDuringSerialization("time_allocation_effort_class_id");
                timeAllocationEffortClass = value;
            }
        }

        [JsonProperty(PropertyName = "time_allocation_effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        private long? TimeAllocationEffortClassID
        {
            get => (timeAllocationEffortClass != null ? timeAllocationEffortClass.ID : (long?)null);
        }

        #endregion

        #region time_increment

        [JsonProperty("time_increment")]
        public long? TimeIncrement
        {
            get => timeIncrement;
            set
            {
                if (timeIncrement != value)
                    AddIncludedDuringSerialization("time_increment");
                timeIncrement = value;
            }
        }

        #endregion

        #region unit

        [JsonProperty("unit")]
        public TimesheetSettingsUnitType Unit
        {
            get => unit;
            set
            {
                if (unit != value)
                    AddIncludedDuringSerialization("unit");
                unit = value;
            }
        }

        #endregion

        #region workday

        [JsonProperty("workday")]
        public int Workday
        {
            get => workday;
            set
            {
                if (workday != value)
                    AddIncludedDuringSerialization("workday");
                workday = value;
            }
        }

        #endregion

        #region workweek

        [JsonProperty("workweek")]
        public int Workweek
        {
            get => workweek;
            set
            {
                if (workweek != value)
                    AddIncludedDuringSerialization("workweek");
                workweek = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            problemEffortClass?.ResetIncludedDuringSerialization();
            projectTaskEffortClass?.ResetIncludedDuringSerialization();
            requestEffortClass?.ResetIncludedDuringSerialization();
            taskEffortClass?.ResetIncludedDuringSerialization();
            timeAllocationEffortClass?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
