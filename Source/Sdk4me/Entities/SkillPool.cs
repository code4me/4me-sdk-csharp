using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/skill_pools/">skill pool</see> object.
    /// </summary>
    public class SkillPool : BaseItem
    {
        private List<Attachment> attachments;
        private bool disabled;
        private Person manager;
        private string name;
        private string pictureUri;
        private string remarks;
        private List<AttachmentReference> remarksAttachments;
        private string source;
        private string sourceID;
        private float? costPerHour;
        private string costPerHourCurrency;

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

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the skill pool may no longer be related to other records.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Manager

        /// <summary>
        /// The Manager field is used to select the manager or supervisor of the skill pool. This person is able to maintain the information about the skill pool. The manager of a skill pool does not need to be a member of the skill pool.
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
        /// The Name field is used to enter the name of the skill pool.
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
        /// The hyperlink to the image file for the skill pool.
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
        /// The Remarks field is used to add any additional information about the skill pool that might prove useful.
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

        #region Cost per hour

        /// <summary>
        /// The Cost per hour field is used to enter the skill pool’s estimated total cost per work hour for the service provider organization.
        /// </summary>
        [JsonProperty("cost_per_hour")]
        public float? CostPerHour
        {
            get => costPerHour;
            set => costPerHour = SetValue("cost_per_hour", costPerHour, value);
        }

        #endregion

        #region Cost per hour currency

        /// <summary>
        /// The currency of the Cost per hour field value of the skill pool. For valid values, see the list of currencies in the Currency field of the Account API.
        /// </summary>
        [JsonProperty("cost_per_hour_currency")]
        public string CostPerHourCurrency
        {
            get => costPerHourCurrency;
            set => costPerHourCurrency = SetValue("cost_per_hour_currency", costPerHourCurrency, value);
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            manager?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
