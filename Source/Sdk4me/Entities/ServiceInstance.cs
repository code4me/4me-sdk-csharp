using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/service_instances/">service instance</see> object.
    /// </summary>
    public class ServiceInstance : BaseItem
    {
        private List<Attachment> attachments;
        private Team firstLineTeam;
        private ServiceInstanceImpact? impact;
        private string name;
        private string remarks;
        private List<AttachmentReference> remarksAttachments;
        private Service service;
        private string source;
        private string sourceID;
        private ServiceInstanceStatus? status;
        private Team supportTeam;

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

        #region First line team

        /// <summary>
        /// The First line team field is used to select the team that will automatically be selected in the Team field of requests to which the service instance is linked after they have been submitted using Self Service or when they are generated using the Requests API, Mail API or Events API.
        /// </summary>
        [JsonProperty("first_line_team")]
        public Team FirstLineTeam
        {
            get => firstLineTeam;
            set => firstLineTeam = SetValue("first_line_team_id", firstLineTeam, value);
        }

        [JsonProperty("first_line_team_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? FirstLineTeamID => firstLineTeam?.ID;

        #endregion

        #region Impact

        /// <summary>
        /// The Impact field shows the impact based on the highest impact of the affected SLAs for which the current user has read access. 
        /// </summary>
        [JsonProperty("impact")]
        public ServiceInstanceImpact? Impact
        {
            get => impact;
            internal set => impact = value;
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the service instance.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Remarks

        /// <summary>
        /// Optional text (max 64KB)
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
        /// Write-only. Add a reference to an uploaded information attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceRemarksAttachment(string key, long fileSize, bool inline = false)
        {
            if (remarksAttachments == null)
                remarksAttachments = new List<AttachmentReference>();

            remarksAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("remarks_attachments");
        }

        [JsonProperty("remarks_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> RemarksAttachments
        {
            get => remarksAttachments;
        }

        #endregion

        #region Service

        /// <summary>
        /// The Service field is used to select the Service which service instance(s) the configuration item is, or will be, a part of.
        /// </summary>
        [JsonProperty("service")]
        public Service Service
        {
            get => service;
            set => service = SetValue("service_id", service, value);
        }

        [JsonProperty("service_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceID => service?.ID;

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

        #region Status

        /// <summary>
        /// The Status field is used to select the current status of the service instance. 
        /// </summary>
        [JsonProperty("status")]
        public ServiceInstanceStatus? Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Support team

        /// <summary>
        /// The Support team field is used to select the team that will, by default, be selected in the Team field of a request when the service instance is manually selected in the Service instance field of the request, or when the service instance is applied from the Service Hierarchy Browser.
        /// </summary>
        [JsonProperty("support_team")]
        public Team SupportTeam
        {
            get => supportTeam;
            set => supportTeam = SetValue("support_team_id", supportTeam, value);
        }

        [JsonProperty("support_team_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportTeamID => supportTeam?.ID;

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            firstLineTeam?.ResetPropertySerializationCollection();
            service?.ResetPropertySerializationCollection();
            supportTeam?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
