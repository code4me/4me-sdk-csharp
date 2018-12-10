using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Organization : BaseItem
    {
        private List<Address> addresses;
        private string businessUnit;
        private Organization businessUnitOrganization;
        private List<Contact> contacts;
        private bool disabled;
        private Person manager;
        private string name;
        private Organization parent;
        private string pictureUri;
        private string region;
        private string remarks;
        private string source;
        private string sourceID;
        private Person substitute;
        private UIExtension uIExtension;
        private CustomFieldCollection customFields;

        #region addresses

        [JsonProperty("addresses")]
        public List<Address> Addresses
        {
            get => addresses;
            internal set => addresses = value;
        }

        #endregion

        #region business_unit

        [JsonProperty("business_unit")]
        public string BusinessUnit
        {
            get => businessUnit;
            set
            {
                if (businessUnit != value)
                    AddIncludedDuringSerialization("business_unit");
                businessUnit = value;
            }
        }

        #endregion

        #region business_unit_organization

        [JsonProperty("business_unit_organization")]
        public Organization BusinessUnitOrganization
        {
            get => businessUnitOrganization;
            internal set => businessUnitOrganization = value;
        }

        #endregion

        #region contacts

        [JsonProperty("contacts")]
        public List<Contact> Contacts
        {
            get => contacts;
            internal set => contacts = value;
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

        #region manager

        [JsonProperty("manager")]
        public Person Manager
        {
            get => manager;
            set
            {
                if (manager?.ID != value?.ID)
                    AddIncludedDuringSerialization("manager_id");
                manager = value;
            }
        }

        [JsonProperty(PropertyName = "manager_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ManagerID
        {
            get => (manager != null ? manager.ID : (long?)null);
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

        #region parent

        [JsonProperty("parent")]
        public Organization Parent
        {
            get => parent;
            set
            {
                if (parent?.ID != value?.ID)
                    AddIncludedDuringSerialization("parent_id");
                parent = value;
            }
        }

        [JsonProperty(PropertyName = "parent_id"), Sdk4meIgnoreInFieldSelection()]
        private long? ParentID
        {
            get => (parent != null ? parent.ID : (long?)null);
        }

        #endregion

        #region picture_uri

        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set
            {
                if (pictureUri != value)
                    AddIncludedDuringSerialization("picture_uri");
                pictureUri = value;
            }
        }

        #endregion

        #region region

        [JsonProperty("region")]
        public string Region
        {
            get => region;
            set
            {
                if (region != value)
                    AddIncludedDuringSerialization("region");
                region = value;
            }
        }

        #endregion

        #region remarks

        [JsonProperty("remarks")]
        public string Remarks
        {
            get => remarks;
            set
            {
                if (remarks != value)
                    AddIncludedDuringSerialization("remarks");
                remarks = value;
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

        #region substitute

        [JsonProperty("substitute")]
        public Person Substitute
        {
            get => substitute;
            set
            {
                if (substitute?.ID != value?.ID)
                    AddIncludedDuringSerialization("substitute_id");
                substitute = value;
            }
        }

        [JsonProperty(PropertyName = "substitute_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SubstituteID
        {
            get => (substitute != null ? substitute.ID : (long?)null);
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

        #region custom_fields

        [JsonProperty("custom_fields")]
        private List<CustomField> CustomFieldsPrivate
        {
            get => customFields?.GetCustomFields();
            set
            {
                customFields = new CustomFieldCollection(value);
                customFields.Changed += CustomFields_Changed;
            }
        }

        [JsonIgnore(), Sdk4meIgnoreInFieldSelection()]
        public CustomFieldCollection CustomFields
        {
            get => customFields;
        }

        private void CustomFields_Changed(object sender, EventArgs e)
        {
            AddIncludedDuringSerialization("custom_fields");
        }

        #endregion

        internal override void ResetIncludedDuringSerialization()
        {
            if (addresses != null)
                for (int i = 0; i < addresses.Count; i++)
                    addresses[i]?.ResetIncludedDuringSerialization();

            if (contacts != null)
                for (int i = 0; i < contacts.Count; i++)
                    contacts[i]?.ResetIncludedDuringSerialization();

            businessUnitOrganization?.ResetIncludedDuringSerialization();
            manager?.ResetIncludedDuringSerialization();
            parent?.ResetIncludedDuringSerialization();
            substitute?.ResetIncludedDuringSerialization();
            uIExtension?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
