using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdk4me
{
    public class Person : BaseItem
    {
        private Account account;
        private List<Address> addresses;
        private List<Contact> contacts;
        private float? costPerHour;
        private bool disabled;
        private string information;
        private string jobTitle;
        private string locale;
        private string location;
        private Person manager;
        private string name;
        private Organization organization;
        private string pictureUri;
        private string primaryEmail;
        private PeopleNotificationPreferenceType sendEmailNotifications;
        private PeopleNotificationPreferenceType showNotificationPopup;
        private Site site;
        private string source;
        private string sourceID;
        private string supportID;
        private bool timeFormat24h;
        private string timeZone;
        private UIExtension uIExtension;
        private bool vip;
        private Calendar workHours;
        private CustomFieldCollection customFields;

        #region account

        [JsonProperty("account"), Sdk4meIgnoreInFieldSelection()]
        public Account Account
        {
            get => account;
            internal set => account = value;
        }

        #endregion

        #region addresses

        [JsonProperty("addresses")]
        public List<Address> Addresses
        {
            get => addresses;
            internal set => addresses = value;
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

        #region cost_per_hour

        [JsonProperty("cost_per_hour")]
        public float? CostPerHour
        {
            get => costPerHour;
            set
            {
                if (costPerHour != value)
                    AddIncludedDuringSerialization("cost_per_hour");
                costPerHour = value;
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

        #region information

        [JsonProperty("information")]
        public string Information
        {
            get => information;
            set
            {
                if (information != value)
                    AddIncludedDuringSerialization("information");
                information = value;
            }
        }

        #endregion

        #region job_title

        [JsonProperty("job_title")]
        public string JobTitle
        {
            get => jobTitle;
            set
            {
                if (jobTitle != value)
                    AddIncludedDuringSerialization("job_title");
                jobTitle = value;
            }
        }

        #endregion

        #region locale

        [JsonProperty("locale")]
        public string Locale
        {
            get => locale;
            set
            {
                if (locale != value)
                    AddIncludedDuringSerialization("locale");
                locale = value;
            }
        }

        #endregion

        #region location

        [JsonProperty("location")]
        public string Location
        {
            get => location;
            set
            {
                if (location != value)
                    AddIncludedDuringSerialization("location");
                location = value;
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

        #region organization

        [JsonProperty("organization")]
        public Organization Organization
        {
            get => organization;
            set
            {
                if (organization?.ID != value?.ID)
                    AddIncludedDuringSerialization("organization_id");
                organization = value;
            }
        }

        [JsonProperty(PropertyName = "organization_id"), Sdk4meIgnoreInFieldSelection()]
        private long? OrganizationID
        {
            get => (organization != null ? organization.ID : (long?)null);
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

        #region primary_email

        [JsonProperty("primary_email")]
        public string PrimaryEmail
        {
            get => primaryEmail;
            set
            {
                if (primaryEmail != value)
                    AddIncludedDuringSerialization("primary_email");
                primaryEmail = value;
            }
        }

        #endregion

        #region send_email_notifications

        [JsonProperty("send_email_notifications")]
        public PeopleNotificationPreferenceType SendEmailNotifications
        {
            get => sendEmailNotifications;
            set
            {
                if (sendEmailNotifications != value)
                    AddIncludedDuringSerialization("send_email_notifications");
                sendEmailNotifications = value;
            }
        }

        #endregion

        #region show_notification_popup

        [JsonProperty("show_notification_popup")]
        public PeopleNotificationPreferenceType ShowNotificationPopup
        {
            get => showNotificationPopup;
            set
            {
                if (showNotificationPopup != value)
                    AddIncludedDuringSerialization("show_notification_popup");
                showNotificationPopup = value;
            }
        }

        #endregion

        #region site

        [JsonProperty("site")]
        public Site Site
        {
            get => site;
            set
            {
                if (site?.ID != value?.ID)
                    AddIncludedDuringSerialization("site_id");
                site = value;
            }
        }

        [JsonProperty(PropertyName = "site_id"), Sdk4meIgnoreInFieldSelection()]
        private long? SiteID
        {
            get => (site != null ? site.ID : (long?)null);
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

        #region supportID

        [JsonProperty("supportID")]
        public string SupportID
        {
            get => supportID;
            set
            {
                if (supportID != value)
                    AddIncludedDuringSerialization("supportID");
                supportID = value;
            }
        }

        #endregion

        #region time_format_24h

        [JsonProperty("time_format_24h")]
        public bool TimeFormat24h
        {
            get => timeFormat24h;
            set
            {
                if (timeFormat24h != value)
                    AddIncludedDuringSerialization("time_format_24h");
                timeFormat24h = value;
            }
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

        #region vip

        [JsonProperty("vip")]
        public bool Vip
        {
            get => vip;
            set
            {
                if (vip != value)
                    AddIncludedDuringSerialization("vip");
                vip = value;
            }
        }

        #endregion

        #region work_hours

        [JsonProperty("work_hours")]
        public Calendar WorkHours
        {
            get => workHours;
            set
            {
                if (workHours?.ID != value?.ID)
                    AddIncludedDuringSerialization("work_hours_id");
                workHours = value;
            }
        }

        [JsonProperty(PropertyName = "work_hours_id"), Sdk4meIgnoreInFieldSelection()]
        private long? WorkHoursID
        {
            get => (workHours != null ? workHours.ID : (long?)null);
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

            account?.ResetIncludedDuringSerialization();
            manager?.ResetIncludedDuringSerialization();
            organization?.ResetIncludedDuringSerialization();
            site?.ResetIncludedDuringSerialization();
            uIExtension?.ResetIncludedDuringSerialization();
            workHours?.ResetIncludedDuringSerialization();
            base.ResetIncludedDuringSerialization();
        }
    }
}
