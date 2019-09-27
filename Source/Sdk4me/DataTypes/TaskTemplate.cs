using Newtonsoft.Json;

namespace Sdk4me
{
    public class TaskTemplate : BaseItem
    {
        private bool assignToChangeManager;
        private bool assignToRequester;
        private bool assignToRequesterBusinessUnitManager;
        private bool assignToRequesterManager;
        private bool assignToServiceOwner;
        private TaskCategoryType? category;
        private bool copyNotesToChange;
        private bool disabled;
        private TaskImpactType? impact;
        private string instructions;
        private Person member;
        private string note;
        private int? plannedDurationInMinutes;
        private int? plannedEffortInMinutes;
        private int? plannedEffortChangeManagerInMinutes;
        private int? plannedEffortRequesterInMinutes;
        private int? plannedEffortRequesterBusinessUnitManagerInMinutes;
        private int? plannedEffortRequesterManagerInMinutes;
        private int? plannedEffortServiceOwnerInMinutes;
        private int? requiredApprovals;
        private string source;
        private string sourceID;
        private string subject;
        private Organization supplier;
        private Team team;
        private UIExtension uIExtension;
        private bool urgent;

        #region assign_to_change_manager

        [JsonProperty("assign_to_change_manager")]
        public bool AssignToChangeManager
        {
            get => assignToChangeManager;
            set
            {
                if (assignToChangeManager != value)
                    AddIncludedDuringSerialization("assign_to_change_manager");
                assignToChangeManager = value;
            }
        }

        #endregion

        #region assign_to_requester

        [JsonProperty("assign_to_requester")]
        public bool AssignToRequester
        {
            get => assignToRequester;
            set
            {
                if (assignToRequester != value)
                    AddIncludedDuringSerialization("assign_to_requester");
                assignToRequester = value;
            }
        }

        #endregion

        #region assign_to_requester_business_unit_manager

        [JsonProperty("assign_to_requester_business_unit_manager")]
        public bool AssignToRequesterBusinessUnitManager
        {
            get => assignToRequesterBusinessUnitManager;
            set
            {
                if (assignToRequesterBusinessUnitManager != value)
                    AddIncludedDuringSerialization("assign_to_requester_business_unit_manager");
                assignToRequesterBusinessUnitManager = value;
            }
        }

        #endregion

        #region assign_to_requester_manager

        [JsonProperty("assign_to_requester_manager")]
        public bool AssignToRequesterManager
        {
            get => assignToRequesterManager;
            set
            {
                if (assignToRequesterManager != value)
                    AddIncludedDuringSerialization("assign_to_requester_manager");
                assignToRequesterManager = value;
            }
        }

        #endregion

        #region assign_to_service_owner

        [JsonProperty("assign_to_service_owner")]
        public bool AssignToServiceOwner
        {
            get => assignToServiceOwner;
            set
            {
                if (assignToServiceOwner != value)
                    AddIncludedDuringSerialization("assign_to_service_owner");
                assignToServiceOwner = value;
            }
        }

        #endregion

        #region category

        [JsonProperty("category")]
        public TaskCategoryType? Category
        {
            get => category;
            set
            {
                if (category != value)
                    AddIncludedDuringSerialization("category");
                category = value;
            }
        }

        #endregion

        #region copy_notes_to_change

        [JsonProperty("copy_notes_to_change")]
        public bool CopyNotesToChange
        {
            get => copyNotesToChange;
            set
            {
                if (copyNotesToChange != value)
                    AddIncludedDuringSerialization("copy_notes_to_change");
                copyNotesToChange = value;
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

        #region impact

        [JsonProperty("impact")]
        public TaskImpactType? Impact
        {
            get => impact;
            set
            {
                if (impact != value)
                    AddIncludedDuringSerialization("impact");
                impact = value;
            }
        }

        #endregion

        #region instructions

        [JsonProperty("instructions")]
        public string Instructions
        {
            get => instructions;
            set
            {
                if (instructions != value)
                    AddIncludedDuringSerialization("instructions");
                instructions = value;
            }
        }

        #endregion

        #region member

        [JsonProperty("member")]
        public Person Member
        {
            get => member;
            set
            {
                if (member?.ID != value?.ID)
                    AddIncludedDuringSerialization("member_id");
                member = value;
            }
        }

        [JsonProperty(PropertyName = "member_id"), Sdk4meIgnoreInFieldSelection()]
        private long? MemberID
        {
            get => (member != null ? member.ID : (long?)null);
        }

        #endregion

        #region note

        [JsonProperty("note")]
        public string Note
        {
            get => note;
            set
            {
                if (note != value)
                    AddIncludedDuringSerialization("note");
                note = value;
            }
        }

        #endregion

        #region planned_duration_in_minutes

        [JsonProperty("planned_duration_in_minutes")]
        public int? PlannedDurationInMinutes
        {
            get => plannedDurationInMinutes;
            set
            {
                if (plannedDurationInMinutes != value)
                    AddIncludedDuringSerialization("planned_duration_in_minutes");
                plannedDurationInMinutes = value;
            }
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

        #region planned_effort_change_manager_in_minutes

        [JsonProperty("planned_effort_change_manager_in_minutes")]
        public int? PlannedEffortChangeManagerInMinutes
        {
            get => plannedEffortChangeManagerInMinutes;
            set
            {
                if (plannedEffortChangeManagerInMinutes != value)
                    AddIncludedDuringSerialization("planned_effort_change_manager_in_minutes");
                plannedEffortChangeManagerInMinutes = value;
            }
        }

        #endregion

        #region planned_effort_requester_in_minutes

        [JsonProperty("planned_effort_requester_in_minutes")]
        public int? PlannedEffortRequesterInMinutes
        {
            get => plannedEffortRequesterInMinutes;
            set
            {
                if (plannedEffortRequesterInMinutes != value)
                    AddIncludedDuringSerialization("planned_effort_requester_in_minutes");
                plannedEffortRequesterInMinutes = value;
            }
        }

        #endregion

        #region planned_effort_requester_business_unit_manager_in_minutes

        [JsonProperty("planned_effort_requester_business_unit_manager_in_minutes")]
        public int? PlannedEffortRequesterBusinessUnitManagerInMinutes
        {
            get => plannedEffortRequesterBusinessUnitManagerInMinutes;
            set
            {
                if (plannedEffortRequesterBusinessUnitManagerInMinutes != value)
                    AddIncludedDuringSerialization("planned_effort_requester_business_unit_manager_in_minutes");
                plannedEffortRequesterBusinessUnitManagerInMinutes = value;
            }
        }

        #endregion

        #region planned_effort_requester_manager_in_minutes

        [JsonProperty("planned_effort_requester_manager_in_minutes")]
        public int? PlannedEffortRequesterManagerInMinutes
        {
            get => plannedEffortRequesterManagerInMinutes;
            set
            {
                if (plannedEffortRequesterManagerInMinutes != value)
                    AddIncludedDuringSerialization("planned_effort_requester_manager_in_minutes");
                plannedEffortRequesterManagerInMinutes = value;
            }
        }

        #endregion

        #region planned_effort_service_owner

        [JsonProperty("planned_effort_service_owner_in_minutes")]
        public int? PlannedEffortServiceOwnerInMinutes
        {
            get => plannedEffortServiceOwnerInMinutes;
            set
            {
                if (plannedEffortServiceOwnerInMinutes != value)
                    AddIncludedDuringSerialization("planned_effort_service_owner_in_minutes");
                plannedEffortServiceOwnerInMinutes = value;
            }
        }

        #endregion

        #region required_approvals

        [JsonProperty("required_approvals")]
        public int? RequiredApprovals
        {
            get => requiredApprovals;
            set
            {
                if (requiredApprovals != value)
                    AddIncludedDuringSerialization("required_approvals");
                requiredApprovals = value;
            }
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

        #region subject

        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set
            {
                if (subject != value)
                    AddIncludedDuringSerialization("subject");
                subject = value;
            }
        }

        #endregion

        #region supplier

        [JsonProperty("supplier")]
        public Organization Supplier
        {
            get => supplier;
            set
            {
                if (supplier?.ID != value?.ID)
                    AddIncludedDuringSerialization("supplier_id");
                supplier = value;
            }
        }

        [JsonProperty(PropertyName = "supplier_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SupplierID
        {
            get => (supplier != null ? supplier.ID : (long?)null);
        }

        #endregion

        #region team

        [JsonProperty("team")]
        public Team Team
        {
            get => team;
            set
            {
                if (team?.ID != value?.ID)
                    AddIncludedDuringSerialization("team_id");
                team = value;
            }
        }

        [JsonProperty(PropertyName = "team_id"), Sdk4meIgnoreInFieldSelection()]
        private long? TeamID
        {
            get => (team != null ? team.ID : (long?)null);
        }

        #endregion

        #region ui_extension

        [JsonProperty("ui_extension")]
        public UIExtension UIExtension
        {
            get => uIExtension;
            set
            {
                if (uIExtension?.ID != value?.ID)
                    AddIncludedDuringSerialization("ui_extension_id");
                uIExtension = value;
            }
        }

        [JsonProperty(PropertyName = "ui_extension_id"), Sdk4meIgnoreInFieldSelection()]
        private long? UIExtensionID
        {
            get => (uIExtension != null ? uIExtension.ID : (long?)null);
        }

        #endregion

        #region urgent

        [JsonProperty("urgent")]
        public bool Urgent
        {
            get => urgent;
            set
            {
                if (urgent != value)
                    AddIncludedDuringSerialization("urgent");
                urgent = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            member?.ResetIncludedDuringSerialization();
            supplier?.ResetIncludedDuringSerialization();
            uIExtension?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
