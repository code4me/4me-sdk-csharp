using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Site : BaseItem
    {
        private Account account;
        private string address;
        private string city;
        private string country;
        private bool disabled;
        private string name;
        private string pictureUri;
        private string remarks;
        private string source;
        private string sourceID;
        private string state;
        private string timeZone;
        private UIExtension uIExtension;
        private string zip;
        private CustomFieldCollection customFields;

        #region account

        [JsonProperty("account"), Sdk4meIgnoreInFieldSelection()]
        public Account Account
        {
            get => account;
            internal set => account = value;
        }

        #endregion

        #region address

        [JsonProperty("address")]
        public string Address
        {
            get => address;
            internal set => address = value;
        }

        #endregion

        #region city

        [JsonProperty("city")]
        public string City
        {
            get => city;
            internal set => city = value;
        }

        #endregion

        #region country

        [JsonProperty("country")]
        public string Country
        {
            get => country;
            internal set => country = value;
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

        #region state

        [JsonProperty("state")]
        public string State
        {
            get => state;
            internal set => state = value;
        }

        #endregion

        #region time_zone

        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set
            {
                if (timeZone != value)
                    AddIncludedDuringSerialization("time_zone");
                timeZone = value;
            }
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

        #region zip

        [JsonProperty("zip")]
        public string Zip
        {
            get => zip;
            internal set => zip = value;
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
            uIExtension?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
