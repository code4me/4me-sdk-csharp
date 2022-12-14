using Newtonsoft.Json;
using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/organizations/">organization</see> object.
    /// </summary>
    public class Organization : CustomFieldsBaseItem
    {
        private List<Address> addresses;
        private List<Attachment> attachments;
        private bool businessUnit;
        private Organization businessUnitOrganization;
        private List<Contact> contacts;
        private bool disabled;
        private string financialID;
        private Person manager;
        private string name;
        private RequestTemplate orderTemplate;
        private Organization parent;
        private string pictureUri;
        private string region;
        private string remarks;
        private List<AttachmentReference> remarksAttachments;
        private string source;
        private string sourceID;
        private Person substitute;
        private UIExtension uiExtension;

        #region Addresses

        /// <summary>
        /// The Address fields are used to enter the street, mailing and billing addresses of the organization.
        /// </summary>
        [JsonProperty("addresses")]
        public List<Address> Addresses
        {
            get => addresses;
            internal set => addresses = value;
        }

        #endregion

        #region Attachments

        /// <summary>
        /// Readonly aggregated Attachments.
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments
        {
            get => attachments;
            internal set => attachments = value;
        }

        #endregion

        #region Business unit

        /// <summary>
        /// The Business unit box is checked when the organization needs to be treated as a separate entity from a reporting perspective. This checkbox is only available for internal organizations.
        /// </summary>
        [JsonProperty("business_unit")]
        public bool BusinessUnit
        {
            get => businessUnit;
            set => businessUnit = SetValue("business_unit", businessUnit, value);
        }

        #endregion

        #region Business unit organization

        /// <summary>
        /// Refers to itself if the organization is a business unit, or refers to the business unit that the organization belongs to.
        /// </summary>
        [JsonProperty("business_unit_organization")]
        public Organization BusinessUnitOrganization
        {
            get => businessUnitOrganization;
            set => businessUnitOrganization = SetValue("business_unit_organization_id", businessUnitOrganization, value);
        }

        [JsonProperty("business_unit_organization_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? BusinessUnitOrganizationID => businessUnitOrganization?.ID;

        #endregion

        #region Contacts

        /// <summary>
        /// The Contact fields are used to enter the general/service desk email addresses, general/fax/etc. of the organization.
        /// </summary>
        [JsonProperty("contacts")]
        public List<Contact> Contacts
        {
            get => contacts;
            internal set => contacts = value;
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the organization may no longer be related to other records.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region FinancialID

        /// <summary>
        /// The Financial ID field is used to enter the unique identifier by which the organization is known in the financial system.
        /// </summary>
        [JsonProperty("financialID")]
        public string FinancialID
        {
            get => financialID;
            set => financialID = SetValue("financialID", financialID, value);
        }

        #endregion

        #region Manager

        /// <summary>
        /// The Manager field is used to select the manager of the organization.
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
        /// The Name field is used to enter the full name of the organization.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region Order template

        /// <summary>
        /// Refers to the order template that is used for purchases of people defined in this organization or its descendants.
        /// </summary>
        [JsonProperty("order_template")]
        public RequestTemplate OrderTemplate
        {
            get => orderTemplate;
            set => orderTemplate = SetValue("order_template_id", orderTemplate, value);
        }

        [JsonProperty("order_template_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? OrderTemplateID => orderTemplate?.ID;

        #endregion

        #region Parent

        /// <summary>
        /// The Parent organization field is used to select the organization’s parent organization.
        /// </summary>
        [JsonProperty("parent")]
        public Organization Parent
        {
            get => parent;
            set => parent = SetValue("parent_id", parent, value);
        }

        [JsonProperty("parent_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? ParentID => parent?.ID;

        #endregion

        #region Picture uri

        /// <summary>
        /// The hyperlink to the image file for the organization.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Region

        /// <summary>
        /// The Region field is used to specify which region the organization belongs to. It is possible to select a previously entered region name or to enter a new one. This field is only available when the organization is a business unit (i.e. when the Business unit box is checked). Although not visible, the Region field of a business unit’s child organizations is automatically set to the same value as the Region field of the business unit. Examples of commonly used region names are:
        /// </summary>
        [JsonProperty("region")]
        public string Region
        {
            get => region;
            set => region = SetValue("region", region, value);
        }

        #endregion

        #region Remarks

        /// <summary>
        /// The Remarks field is used to add any additional information about the organization that might prove useful.
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

        #region Substitute

        /// <summary>
        /// The Substitute field is used to select the person who acts as the substitute of the organization’s manager.
        /// </summary>
        [JsonProperty("substitute")]
        public Person Substitute
        {
            get => substitute;
            set => substitute = SetValue("substitute_id", substitute, value);
        }

        [JsonProperty("substitute_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SubstituteID => substitute?.ID;

        #endregion

        #region UI Extension

        /// <summary>
        /// The UI extension field indicates the UI extension that is applied to the person.
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

        internal override void ResetPropertySerializationCollection()
        {
            addresses?.ResetPropertySerializationCollection();
            businessUnitOrganization?.ResetPropertySerializationCollection();
            manager?.ResetPropertySerializationCollection();
            parent?.ResetPropertySerializationCollection();
            substitute?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
