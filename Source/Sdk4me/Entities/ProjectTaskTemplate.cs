using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/project_task_templates/">project task template</see> object.
    /// </summary>
    public class ProjectTaskTemplate : BaseItem
    {
        private bool assignToProjectManager;
        private bool assignToRequester;
        private bool assignToRequesterBusinessUnitManager;
        private bool assignToRequesterManager;
        private bool assignToServiceOwner;
        private List<Attachment> attachments;
        private ProjectTaskCategory category;
        private bool copyNotesToProject;
        private bool disabled;
        private EffortClass effortClass;
        private string instructions;
        private List<AttachmentReference> instructionsAttachments;
        private string note;
        private List<AttachmentReference> noteAttachments;
        private TimeSpan? plannedDuration;
        private TimeSpan? plannedEffort;
        private TimeSpan? plannedEffortProjectManager;
        private TimeSpan? plannedEffortRequester;
        private TimeSpan? plannedEffortRequesterBusinessUnitManager;
        private TimeSpan? plannedEffortRequesterManager;
        private TimeSpan? plannedEffortServiceOwner;
        private int? requiredApprovals;
        private SkillPool skillPool;
        private string source;
        private string sourceID;
        private string subject;
        private Organization supplier;
        private Team team;
        private int timesApplied;
        private UIExtension uiExtension;
        private bool workHoursAre24x7;

        #region Assign to project manager

        /// <summary>
        /// The Project manager box is checked if the project manager is to be selected in the Assignees field of a new project task when it is being created based on the template.
        /// </summary>
        [JsonProperty("assign_to_project_manager")]
        public bool AssignToProjectManager
        {
            get => assignToProjectManager;
            set => assignToProjectManager = SetValue("assign_to_project_manager", assignToProjectManager, value);
        }

        #endregion

        #region Assign to requester

        /// <summary>
        /// The Requester box is checked if a new project task that is being created based on the template is to be assigned to the person who is selected in the Requested for field of the request for which the project was registered.
        /// </summary>
        [JsonProperty("assign_to_requester")]
        public bool AssignToRequester
        {
            get => assignToRequester;
            set => assignToRequester = SetValue("assign_to_requester", assignToRequester, value);
        }

        #endregion

        #region Assign to requester business unit manager

        /// <summary>
        /// The Requester’s business unit manager box is checked if a new project task that is being created based on the template is to be assigned to the person who is selected in the Manager field of the business unit to which the organization belongs that is linked to the person who is selected in the Requested for field of the request for which the project was registered.
        /// </summary>
        [JsonProperty("assign_to_requester_business_unit_manager")]
        public bool AssignToRequesterBusinessUnitManager
        {
            get => assignToRequesterBusinessUnitManager;
            set => assignToRequesterBusinessUnitManager = SetValue("assign_to_requester_business_unit_manager", assignToRequesterBusinessUnitManager, value);
        }

        #endregion

        #region Assign to requester manager

        /// <summary>
        /// The Requester’s manager box is checked if a new project task that is being created based on the template is to be assigned to the manager of the project’s requester.
        /// </summary>
        [JsonProperty("assign_to_requester_manager")]
        public bool AssignToRequesterManager
        {
            get => assignToRequesterManager;
            set => assignToRequesterManager = SetValue("assign_to_requester_manager", assignToRequesterManager, value);
        }

        #endregion

        #region Assign to service owner

        /// <summary>
        /// The Service owner box is checked if a new project task that is being created based on the template is to be assigned to the person who is selected in the Service owner field of the service that is linked to the project that the new project task is a part of.
        /// </summary>
        [JsonProperty("assign_to_service_owner")]
        public bool AssignToServiceOwner
        {
            get => assignToServiceOwner;
            set => assignToServiceOwner = SetValue("assign_to_service_owner", assignToServiceOwner, value);
        }

        #endregion

        #region Attachments

        /// <summary>
        /// Readonly aggregated Attachments
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region Category

        /// <summary>
        /// The Category field is used to select the category that needs to be selected in the Category field of a new project task when it is being created based on the template. 
        /// </summary>
        [JsonProperty("category")]
        public ProjectTaskCategory Category
        {
            get => category;
            set => category = SetValue("category", category, value);
        }

        #endregion

        #region Copy notes to project

        /// <summary>
        /// The Copy notes to project checkbox is called “Copy notes to project by default” when the project task template is in Edit mode. This box is checked when the Copy note to project box of project tasks that were created based on the template needs to be checked by default.
        /// </summary>
        [JsonProperty("copy_notes_to_project")]
        public bool CopyNotesToProject
        {
            get => copyNotesToProject;
            set => copyNotesToProject = SetValue("copy_notes_to_project", copyNotesToProject, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the project task template may not be used to help register new project tasks.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Effort class

        /// <summary>
        /// The effort class that is selected by default, when someone registers time on a project task created based on the template.
        /// </summary>
        [JsonProperty("effort_class")]
        public EffortClass EffortClass
        {
            get => effortClass;
            set => effortClass = SetValue("effort_class_id", effortClass, value);
        }

        [JsonProperty("effort_class_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? EffortClassID => effortClass?.ID;

        #endregion

        #region Instructions

        /// <summary>
        /// The Instructions field is used to enter the information that needs to be copied to the Instructions field of a new project task when it is being created based on the template.
        /// </summary>
        [JsonProperty("instructions")]
        public string Instructions
        {
            get => instructions;
            set => instructions = SetValue("instructions", instructions, value);
        }

        #endregion

        #region Instructions attachments

        /// <summary>
        /// Writeonly attachments. Add an inline attachments to be used in the Instructions field.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceInstructionsAttachment(string key, long fileSize)
        {
            if (instructionsAttachments == null)
                instructionsAttachments = new List<AttachmentReference>();

            instructionsAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("instructions_attachments");
        }

        [JsonProperty("instructions_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> InstructionsAttachments
        {
            get => instructionsAttachments;
        }

        #endregion

        #region Note

        /// <summary>
        /// The Note field is used to enter the information that needs to be copied to the Note field of a new project task when it is being created based on the template.
        /// </summary>
        [JsonProperty("note")]
        public string Note
        {
            get => note;
            set => note = SetValue("note", note, value);
        }

        #endregion

        #region Note attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded note attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceNoteAttachment(string key, long fileSize, bool inline = false)
        {
            if (noteAttachments == null)
                noteAttachments = new List<AttachmentReference>();

            noteAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("note_attachments");
        }

        [JsonProperty("note_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> NoteAttachments
        {
            get => noteAttachments;
        }

        #endregion

        #region Planned duration

        /// <summary>
        /// The Planned duration field is used to specify the number of minutes that should be entered in the Planned duration field of a new project task when it is being created based on the template.
        /// </summary>
        public TimeSpan? PlannedDuration
        {
            get => plannedDuration;
            set => plannedDuration = SetValue("planned_duration", plannedDuration, value);
        }

        [JsonProperty("planned_duration")]
        internal int? PlannedDurationInMinutes
        {
            get => plannedDuration != null ? Convert.ToInt32(plannedDuration.Value.TotalMinutes) : (int?)null;
            set => plannedDuration = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Planned effort

        /// <summary>
        /// The Planned effort field is used to specify the number of minutes the member is expected to spend working on the problem.
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

        #region Planned effort project manager

        /// <summary>
        /// The Planned effort field for the project manager is used to specify the number of minutes that the project manager is expected to spend working on a project task that was created based on the template.
        /// </summary>
        public TimeSpan? PlannedEffortProjectManager
        {
            get => plannedEffortProjectManager;
            set => plannedEffortProjectManager = SetValue("planned_effort_project_manager", plannedEffortProjectManager, value);
        }

        [JsonProperty("planned_effort_project_manager")]
        internal int? PlannedEffortProjectManagerInMinutes
        {
            get => plannedEffortProjectManager != null ? Convert.ToInt32(plannedEffortProjectManager.Value.TotalMinutes) : (int?)null;
            set => plannedEffortProjectManager = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Planned effort requester

        /// <summary>
        /// The Planned effort field for the requester of the request for which the project was created is used to specify the number of minutes that the requester is expected to spend working on a project task that was created based on the template.
        /// </summary>
        public TimeSpan? PlannedEffortRequester
        {
            get => plannedEffortRequester;
            set => plannedEffortRequester = SetValue("planned_effort_requester", plannedEffortRequester, value);
        }

        [JsonProperty("planned_effort_requester")]
        internal int? PlannedEffortRequesterInMinutes
        {
            get => plannedEffortRequester != null ? Convert.ToInt32(plannedEffortRequester.Value.TotalMinutes) : (int?)null;
            set => plannedEffortRequester = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Planned effort requester business unit manager

        /// <summary>
        /// The Planned effort field for the business unit manager of the requester of the request for which the project was created is used to specify the number of minutes that the requester’s business unit manager is expected to spend working on a project task that was created based on the template.
        /// </summary>
        public TimeSpan? PlannedEffortRequesterBusinessUnitManager
        {
            get => plannedEffortRequesterBusinessUnitManager;
            set => plannedEffortRequesterBusinessUnitManager = SetValue("planned_effort_requester_business_unit_manager", plannedEffortRequesterBusinessUnitManager, value);
        }

        [JsonProperty("planned_effort_requester_business_unit_manager")]
        internal int? PlannedEffortRequesterBusinessUnitManagerInMinutes
        {
            get => plannedEffortRequesterBusinessUnitManager != null ? Convert.ToInt32(plannedEffortRequesterBusinessUnitManager.Value.TotalMinutes) : (int?)null;
            set => plannedEffortRequesterBusinessUnitManager = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Planned effort requester manager

        /// <summary>
        /// The Planned effort field for the manager of the requester of the request for which the project was created is used to specify the number of minutes that the requester’s manager is expected to spend working on a project task that was created based on the template.
        /// </summary>
        public TimeSpan? PlannedEffortRequesterManager
        {
            get => plannedEffortRequesterManager;
            set => plannedEffortRequesterManager = SetValue("planned_effort_requester_manager", plannedEffortRequesterManager, value);
        }

        [JsonProperty("planned_effort_requester_manager")]
        internal int? PlannedEffortRequesterManagerInMinutes
        {
            get => plannedEffortRequesterManager != null ? Convert.ToInt32(plannedEffortRequesterManager.Value.TotalMinutes) : (int?)null;
            set => plannedEffortRequesterManager = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Planned effort service owner

        /// <summary>
        /// The Planned effort field for the service owner is used to specify the number of minutes that the service owner is expected to spend working on a project task that was created based on the template.
        /// </summary>
        public TimeSpan? PlannedEffortServiceOwner
        {
            get => plannedEffortServiceOwner;
            set => plannedEffortServiceOwner = SetValue("planned_effort_service_owner", plannedEffortServiceOwner, value);
        }

        [JsonProperty("planned_effort_service_owner")]
        internal int? PlannedEffortServiceOwnerInMinutes
        {
            get => plannedEffortServiceOwner != null ? Convert.ToInt32(plannedEffortServiceOwner.Value.TotalMinutes) : (int?)null;
            set => plannedEffortServiceOwner = value != null ? TimeSpan.FromMinutes(value.Value) : (TimeSpan?)null;
        }

        #endregion

        #region Required approvals

        /// <summary>
        /// The Required approvals field is used to enter the number that needs to be specified in the Required approvals field of a new approval project task when it is being created based on the template.
        /// </summary>
        [JsonProperty("required_approvals")]
        public int? RequiredApprovals
        {
            get => requiredApprovals;
            set => requiredApprovals = SetValue("required_approvals", requiredApprovals, value);
        }

        #endregion

        #region Skill pool

        /// <summary>
        /// The Skill Pool field is used to select the skill pool to whom the project task is to be assigned.
        /// </summary>
        [JsonProperty("skill_pool")]
        public SkillPool SkillPool
        {
            get => skillPool;
            set => skillPool = SetValue("skill_pool_id", skillPool, value);
        }

        [JsonProperty("skill_pool_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SkillPoolID => skillPool?.ID;

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

        #region Subject

        /// <summary>
        /// The Subject field is used to enter a short description that needs to be copied to the Subject field of a new project task when it is being created based on the template.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get => subject;
            set => subject = SetValue("subject", subject, value);
        }

        #endregion

        #region Supplier

        /// <summary>
        /// The Supplier field is used to select the supplier organization that should be selected in the Supplier field of a new project task when it is being created based on the template.
        /// </summary>
        [JsonProperty("supplier")]
        public Organization Supplier
        {
            get => supplier;
            set => supplier = SetValue("supplier_id", supplier, value);
        }

        [JsonProperty("supplier_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupplierID => supplier?.ID;

        #endregion

        #region Team

        /// <summary>
        /// The Team field is used to select the Team that should be selected in the Team field of a new project task when it is being created based on the template.
        /// </summary>
        [JsonProperty("team")]
        public Team Team
        {
            get => team;
            set => team = SetValue(":team_id", team, value);
        }

        [JsonProperty("team_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TeamID => team?.ID;

        #endregion

        #region Times applied

        /// <summary>
        /// The number of times the project task template is used to create a project task.
        /// </summary>
        [JsonProperty("times_applied")]
        public int TimesApplied
        {
            get => timesApplied;
            internal set => timesApplied = value;
        }

        #endregion

        #region UI extension

        /// <summary>
        /// The UI extension field is used to select the UI extension that is to be added to a new project task when it is being created based on the template.
        /// </summary>
        [JsonProperty("ui_extension")]
        public UIExtension UIExtension
        {
            get => uiExtension;
            set => uiExtension = SetValue("ui_extension_id", uiExtension, value);
        }

        [JsonProperty("ui_extension_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? UIExtensionID => uiExtension?.ID;

        #endregion

        #region Work hours are 24x7

        /// <summary>
        /// When set to true, the completion target of project tasks created based on the template are calculated using a 24x7 calendar rather than normal business hours.
        /// </summary>
        [JsonProperty("work_hours_are_24x7")]
        public bool WorkHoursAre24x7
        {
            get => workHoursAre24x7;
            set => workHoursAre24x7 = SetValue("work_hours_are_24x7", workHoursAre24x7, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            effortClass?.ResetPropertySerializationCollection();
            supplier?.ResetPropertySerializationCollection();
            skillPool?.ResetPropertySerializationCollection();
            team?.ResetPropertySerializationCollection();
            uiExtension?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
