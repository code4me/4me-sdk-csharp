using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/teams/">team</see> object.
    /// </summary>
    public class Team : CustomFieldsBaseItem
    {
        private AgileBoard agileBoard;
        private bool autoAssign;
        private List<Attachment> attachments;
        private Person configurationManager;
        private Person coordinator;
        private bool disabled;
        private string inboundEmailLocalPart;
        private Person manager;
        private string name;
        private string pictureUri;
        private string remarks;
        private List<AttachmentReference> remarksAttachments;
        private ScrumWorkspace scrumWorkspace;
        private string source;
        private string sourceID;
        private string timeZone;
        private Calendar workHours;

        #region Agile board

        /// <summary>
        /// The Agile Board field is used to automatically link records to the agile board when they are assigned to the team.
        /// </summary>
        [JsonProperty("agile_board")]
        public AgileBoard AgileBoard
        {
            get => agileBoard;
            set => agileBoard = SetValue("agile_board_id", agileBoard, value);
        }

        [JsonProperty("agile_board_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? AgileBoardID => agileBoard?.ID;

        #endregion

        #region Auto assign

        /// <summary>
        /// The Auto assign field is used to indicate whether requests are auto-assigned to a team member.
        /// </summary>
        [JsonProperty("auto_assign")]
        public bool AutoAssign
        {
            get => autoAssign;
            set => autoAssign = SetValue("auto_assign", autoAssign, value);
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

        #region Configuration manager

        /// <summary>
        /// The Configuration manager field is used to select the person who maintains the information about the Configuration Items that the team supports.
        /// </summary>
        [JsonProperty("configuration_manager")]
        public Person ConfigurationManager
        {
            get => configurationManager;
            set => configurationManager = SetValue("configuration_manager_id", configurationManager, value);
        }

        [JsonProperty("configuration_manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ConfigurationManagerID => configurationManager?.ID;

        #endregion

        #region Coordinator

        /// <summary>
        /// The Coordinator field is used to select the current team coordinator for the team. Only members of the team can be selected in this field.
        /// </summary>
        [JsonProperty("coordinator")]
        public Person Coordinator
        {
            get => coordinator;
            set => coordinator = SetValue("coordinator_id", coordinator, value);
        }

        [JsonProperty("coordinator_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? CoordinatorID => coordinator?.ID;

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the team may no longer be related to other records.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Inbound email local part

        /// <summary>
        /// The Inbound email address field is used to specify an email address for the team. When an email is sent to this email address, a new request gets generated and assigned to the team.
        /// </summary>
        [JsonProperty("inbound_email_local_part")]
        public string InboundEmailLocalPart
        {
            get => inboundEmailLocalPart;
            set => inboundEmailLocalPart = SetValue("inbound_email_local_part", inboundEmailLocalPart, value);
        }

        #endregion

        #region Manager

        /// <summary>
        /// The Manager field is used to select the manager or supervisor of the team. This person is able to maintain the information about the team. The manager of a team does not need to be a member of the team.
        /// </summary>
        [JsonProperty("manager")]
        public Person Manager
        {
            get => manager;
            set => manager = SetValue("manager_id", manager, value);
        }

        [JsonProperty("manager_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ManagerID => manager?.ID;

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the team.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Picture uri

        /// <summary>
        /// The hyperlink to the image file for the team.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Remarks

        /// <summary>
        /// The Remarks field is used to add any additional information about the team that might prove useful.
        /// </summary>
        [JsonProperty("remarks")]
        public string Remarks
        {
            get => remarks;
            set => remarks = SetValue("remarks", remarks, value);
        }

        #endregion

        #region Remarks attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceRemarksAttachment(string key, long fileSize)
        {
            if (remarksAttachments == null)
                remarksAttachments = new List<AttachmentReference>();

            remarksAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("remarks_attachments");
        }

        [JsonProperty("remarks_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> RemarksAttachments
        {
            get => remarksAttachments;
        }

        #endregion

        #region Scrum workspace

        /// <summary>
        /// The Scrum Workspace used by this team to plan their work.
        /// </summary>
        [JsonProperty("scrum_workspace")]
        public ScrumWorkspace ScrumWorkspace
        {
            get => scrumWorkspace;
            internal set => scrumWorkspace = value;
        }

        [JsonProperty("scrum_workspace_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ScrumWorkspaceID => scrumWorkspace?.ID;

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

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone that applies to the selected work hours.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set => timeZone = SetValue("time_zone", timeZone, value);
        }

        #endregion

        #region Work hours

        /// <summary>
        /// The Work hours field is used to select a Calendar that defines the work hours during which the team is available for work on all types of assignments.
        /// </summary>
        [JsonProperty("work_hours")]
        public Calendar WorkHours
        {
            get => workHours;
            set => workHours = SetValue("work_hours_id", workHours, value);
        }

        [JsonProperty("work_hours_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? WorkHoursID => workHours?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            configurationManager?.ResetPropertySerializationCollection();
            coordinator?.ResetPropertySerializationCollection();
            manager?.ResetPropertySerializationCollection();
            scrumWorkspace?.ResetPropertySerializationCollection();
            workHours?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
