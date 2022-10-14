using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/scrum_workspaces/">scrum workspace</see> object.
    /// </summary>
    public class ScrumWorkspace : BaseItem
    {
        private List<Attachment> attachments;
        private AgileBoard agileBoard;
        private string description;
        private List<AttachmentReference> descriptionAttachments;
        private bool disabled;
        private string name;
        private string pictureUri;
        private ProductBacklog productBacklog;
        private string source;
        private string sourceID;
        private int sprintLength;
        private Team team;

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

        #region Agile board

        /// <summary>
        /// Agile board used to track the progress of this workspace’s active sprint.
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

        #region Description

        /// <summary>
        /// Additional information about the scrum workspace.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set => description = SetValue("description", description, value);
        }

        #endregion

        #region Description attachments

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceDescriptionAttachment(string key, long fileSize)
        {
            if (descriptionAttachments == null)
                descriptionAttachments = new List<AttachmentReference>();

            descriptionAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("description_attachments");
        }

        [JsonProperty("description_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> DescriptionAttachments
        {
            get => descriptionAttachments;
        }

        #endregion

        #region Disabled

        /// <summary>
        /// Whether the scrum workspace is in use.
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
        /// Name of the scrum workspace.
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
        /// The hyperlink to the image file for the scrum workspace.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Product backlog

        /// <summary>
        /// Product backlog used when planning sprints.
        /// </summary>
        [JsonProperty("product_backlog")]
        public ProductBacklog ProductBacklog
        {
            get => productBacklog;
            set => productBacklog = SetValue("product_backlog_id", productBacklog, value);
        }

        [JsonProperty("product_backlog_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProductBacklogID => productBacklog?.ID;

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

        #region Sprint length

        /// <summary>
        /// Standard length in weeks of new sprints planned in this scrum workspace.
        /// </summary>
        [JsonProperty("sprint_length")]
        public int SprintLength
        {
            get => sprintLength;
            set => sprintLength = SetValue("sprint_length", sprintLength, value);
        }

        #endregion

        #region Team

        /// <summary>
        /// Team planning their work using this scrum workspace.
        /// </summary>
        [JsonProperty("team")]
        public Team Team
        {
            get => team;
            set => team = SetValue("team_id", team, value);
        }

        [JsonProperty("team_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? TeamID => team?.ID;

        #endregion
    }
}
