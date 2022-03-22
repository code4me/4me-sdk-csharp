using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/first_line_support_agreements/">first line support agreement</see> object.
    /// </summary>
    public class FirstLineSupportAgreement : BaseItem
    {
        private List<Attachment> attachments;
        private string charges;
        private List<AttachmentReference> chargesAttachments;
        private Organization customer;
        private Person customerRep;
        private DateTime? expiryDate;
        private int? firstCallResolutions;
        private string name;
        private DateTime? noticeDate;
        private Organization provider;
        private string remarks;
        private List<AttachmentReference> remarksAttachments;
        private Team serviceDeskTeam;
        private string source;
        private string sourceID;
        private DateTime? startDate;
        private FirstLineSupportAgreementStatus? status;
        private Calendar supportHours;
        private string targetDetails;
        private List<AttachmentReference> targetDetailsAttachments;
        private string timeZone;

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

        #region Charges

        /// <summary>
        /// The Charges field is used to describe the amounts that the customer will be charged for the first line support agreement. These can be recurring as well as one-off charges.
        /// </summary>
        [JsonProperty("charges")]
        public string Charges
        {
            get => charges;
            set => charges = SetValue("charges", charges, value);
        }

        #endregion

        #region Charges attachments

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the related attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceChargesAttachment(string key, long fileSize)
        {
            if (chargesAttachments == null)
                chargesAttachments = new List<AttachmentReference>();

            chargesAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("charges_attachments");
        }

        [JsonProperty("charges_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> ChargesAttachments
        {
            get => chargesAttachments;
        }

        #endregion

        #region Customer

        /// <summary>
        /// The Customer field is used to select the Organization that pays for the first line support agreement.
        /// </summary>
        [JsonProperty("customer")]
        public Organization Customer
        {
            get => customer;
            set => customer = SetValue("customer_id", customer, value);
        }

        [JsonProperty("customer_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? CustomerID => customer?.ID;

        #endregion

        #region Customer rep

        /// <summary>
        /// Optional reference to Person
        /// </summary>
        [JsonProperty("customer_rep")]
        public Person CustomerRep
        {
            get => customerRep;
            set => customerRep = SetValue("customer_rep_id", customerRep, value);
        }

        [JsonProperty("customer_rep_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? CustomerRepID => customerRep?.ID;

        #endregion

        #region Expiry date

        /// <summary>
        /// The Expiry date field is used to specify the date through which the first line support agreement (FLSA) will be active. The FLSA expires at the end of this day if it is not renewed before then. When the FLSA has expired, its status will automatically be set to “Expired”.
        /// </summary>
        [JsonProperty("expiry_date")]
        public DateTime? ExpiryDate
        {
            get => expiryDate;
            set => expiryDate = SetValue("expiry_date", expiryDate, value);
        }

        #endregion

        #region First call resolutions

        /// <summary>
        /// The First call resolutions field is used to enter the minimum percentage of Requests that are to be completed by the service desk team during their registration.
        /// </summary>
        [JsonProperty("first_call_resolutions")]
        public int? FirstCallResolutions
        {
            get => firstCallResolutions;
            set => firstCallResolutions = SetValue("first_call_resolutions", firstCallResolutions, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the name of the first line support agreement in the following syntax:
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Notice date

        /// <summary>
        /// The Notice date field is used to specify the last day on which the first line support provider organization can still be contacted to terminate the first line support agreement (FLSA) to ensure that it expires on the intended expiry date. The Notice date field is left empty, and the Expiry date field is filled out, when the FLSA is to expire on a specific date and no notice needs to be given to terminate it.
        /// </summary>
        [JsonProperty("notice_date")]
        public DateTime? NoticeDate
        {
            get => noticeDate;
            set => noticeDate = SetValue("notice_date", noticeDate, value);
        }

        #endregion

        #region Provider

        /// <summary>
        /// Required reference to Organization
        /// </summary>
        [JsonProperty("provider")]
        public Organization Provider
        {
            get => provider;
            set => provider = SetValue("provider_id", provider, value);
        }

        [JsonProperty("provider_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ProviderId => provider?.ID;

        #endregion

        #region Remarks

        /// <summary>
        /// The Remarks field is used to add any additional information about the first line support agreement that might prove useful.
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
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the related attachments.
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

        #region Service desk team

        /// <summary>
        /// The Service desk team field is used to select the specific Team within the first line support provider organization that provides first line support for the users covered by the first line support agreement.
        /// </summary>
        [JsonProperty("service_desk_team")]
        public Team ServiceDeskTeam
        {
            get => serviceDeskTeam;
            set => serviceDeskTeam = SetValue("service_desk_team_id", serviceDeskTeam, value);
        }

        [JsonProperty("service_desk_team_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ServiceDeskTeamID => serviceDeskTeam?.ID;

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

        #region Start date

        /// <summary>
        /// The Start date field is used to specify the first day during which the first line support agreement (FLSA) is active.
        /// </summary>
        [JsonProperty("start_date")]
        public DateTime? StartDate
        {
            get => startDate;
            set => startDate = SetValue("start_date", startDate, value);
        }

        #endregion

        #region Status

        /// <summary>
        /// The Status field displays the current status of the first line support agreement (FLSA). 
        /// </summary>
        [JsonProperty("status")]
        public FirstLineSupportAgreementStatus? Status
        {
            get => status;
            set => status = SetValue("status", status, value);
        }

        #endregion

        #region Support hours

        /// <summary>
        /// The Support hours field is used to select a Calendar that defines the support hours during which the service desk team can be contacted for first line support.
        /// </summary>
        [JsonProperty("support_hours")]
        public Calendar SupportHours
        {
            get => supportHours;
            set => supportHours = SetValue("support_hours_id", supportHours, value);
        }

        [JsonProperty("support_hours_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SupportHoursID => supportHours?.ID;

        #endregion

        #region Target details

        /// <summary>
        /// The Target details field is used to provide a description of all the targets of the first line support agreement.
        /// </summary>
        [JsonProperty("target_details")]
        public string TargetDetails
        {
            get => targetDetails;
            set => targetDetails = SetValue("target_details", targetDetails, value);
        }

        #endregion

        #region Target details attachments

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the related attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        public void ReferenceTargetDetailsAttachment(string key, long fileSize)
        {
            if (targetDetailsAttachments == null)
                targetDetailsAttachments = new List<AttachmentReference>();

            targetDetailsAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = true
            });

            base.PropertySerializationCollection.Add("target_details_attachments");
        }

        [JsonProperty("target_details_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> TargetDetailsAttachments
        {
            get => targetDetailsAttachments;
        }

        #endregion

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone that applies to the start, notice and expiry dates, and to the support hours.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set => timeZone = SetValue("time_zone", timeZone, value);
        }

        #endregion
    }
}
