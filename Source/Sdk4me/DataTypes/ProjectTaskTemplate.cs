using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectTaskTemplate : BaseItem
    {
        private bool assignToProjectManager;
        private bool assignToRequester;
        private bool assignToRequesterBusinessUnitManager;
        private bool assignToRequesterManager;
        private bool assignToServiceOwner;
        private List<Attachment> attachments;
        private ProjectCategoryType? category;
        private bool copyNotesToProject;
        private bool disabled;
        private EffortClass effortClass;
        private string instructions;
        private string note;
        private int? plannedDuration;
        private int? plannedEffortProjectManager;
        private int? plannedEffortRequester;
        private int? plannedEffortRequesterBusinessUnitManager;
        private int? plannedEffortRequesterManager;
        private int? plannedEffortServiceOwner;
        private int? requiredApprovals;
        private string source;
        private string sourceID;
        private string subject;
        private Organization supplier;
        private UIExtension uIExtension;
        private bool workHoursAre24x7;

        #region assign_to_project_manager

        [JsonProperty("assign_to_project_manager")]
        public bool AssignToProjectManager
        {
            get => assignToProjectManager;
            set
            {
                if (assignToProjectManager != value)
                    AddIncludedDuringSerialization("assign_to_project_manager");
                assignToProjectManager = value;
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

        #region attachments

        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region category

        [JsonProperty("category")]
        public ProjectCategoryType? Category
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

        #region copy_notes_to_project

        [JsonProperty("copy_notes_to_project")]
        public bool CopyNotesToProject
        {
            get => copyNotesToProject;
            set
            {
                if (copyNotesToProject != value)
                    AddIncludedDuringSerialization("copy_notes_to_project");
                copyNotesToProject = value;
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

        #region effort_class

        [JsonProperty("effort_class")]
        public EffortClass EffortClass
        {
            get => effortClass;
            set
            {
                if (effortClass?.ID != value?.ID)
                    AddIncludedDuringSerialization("effort_class_id");
                effortClass = value;
            }
        }

        [JsonProperty(PropertyName = "effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        private long? EffortClassID
        {
            get => (effortClass != null ? effortClass.ID : (long?)null);
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

        #region planned_duration

        [JsonProperty("planned_duration")]
        public int? PlannedDuration
        {
            get => plannedDuration;
            set
            {
                if (plannedDuration != value)
                    AddIncludedDuringSerialization("planned_duration");
                plannedDuration = value;
            }
        }

        #endregion

        #region planned_effort_project_manager

        [JsonProperty("planned_effort_project_manager")]
        public int? PlannedEffortProjectManager
        {
            get => plannedEffortProjectManager;
            set
            {
                if (plannedEffortProjectManager != value)
                    AddIncludedDuringSerialization("planned_effort_project_manager");
                plannedEffortProjectManager = value;
            }
        }

        #endregion

        #region planned_effort_requester

        [JsonProperty("planned_effort_requester")]
        public int? PlannedEffortRequester
        {
            get => plannedEffortRequester;
            set
            {
                if (plannedEffortRequester != value)
                    AddIncludedDuringSerialization("planned_effort_requester");
                plannedEffortRequester = value;
            }
        }

        #endregion

        #region planned_effort_requester_business_unit_manager

        [JsonProperty("planned_effort_requester_business_unit_manager")]
        public int? PlannedEffortRequesterBusinessUnitManager
        {
            get => plannedEffortRequesterBusinessUnitManager;
            set
            {
                if (plannedEffortRequesterBusinessUnitManager != value)
                    AddIncludedDuringSerialization("planned_effort_requester_business_unit_manager");
                plannedEffortRequesterBusinessUnitManager = value;
            }
        }

        #endregion

        #region planned_effort_requester_manager

        [JsonProperty("planned_effort_requester_manager")]
        public int? PlannedEffortRequesterManager
        {
            get => plannedEffortRequesterManager;
            set
            {
                if (plannedEffortRequesterManager != value)
                    AddIncludedDuringSerialization("planned_effort_requester_manager");
                plannedEffortRequesterManager = value;
            }
        }

        #endregion

        #region planned_effort_service_owner

        [JsonProperty("planned_effort_service_owner")]
        public int? PlannedEffortServiceOwner
        {
            get => plannedEffortServiceOwner;
            set
            {
                if (plannedEffortServiceOwner != value)
                    AddIncludedDuringSerialization("planned_effort_service_owner");
                plannedEffortServiceOwner = value;
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

        #region work_hours_are_24x7

        [JsonProperty("work_hours_are_24x7")]
        public bool WorkHoursAre24x7
        {
            get => workHoursAre24x7;
            set
            {
                if (workHoursAre24x7 != value)
                    AddIncludedDuringSerialization("work_hours_are_24x7");
                workHoursAre24x7 = value;
            }
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            if (attachments != null)
                for (int i = 0; i < attachments.Count; i++)
                    attachments[i]?.ResetIncludedDuringSerialization();

            effortClass?.ResetIncludedDuringSerialization();
            supplier?.ResetIncludedDuringSerialization();
            uIExtension?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
