using Newtonsoft.Json;
using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/people/">person</see> object.
    /// </summary>
    public class Person : CustomFieldsBaseItem
    {
        private List<Address> addresses;
        private List<Attachment> attachments;
        private string authenticationID;
        private bool autoTranslation;
        private List<Contact> contacts;
        private float? costPerHour;
        private string costPerHourCurrency;
        private bool disabled;
        private string doNotTranslateLanguages;
        private string employeeID;
        private bool excludeTeamNotifications;
        private string information;
        private List<AttachmentReference> informationAttachments;
        private string jobTitle;
        private string locale;
        private string location;
        private Person manager;
        private string name;
        private bool oauthPersonEnablement;
        private Organization organization;
        private string pictureUri;
        private string primaryEmail;
        private PeopleEmailNotificationPreference sendEmailNotifications;
        private PeoplePopupNotificationPreference showNotificationPopup;
        private Site site;
        private string source;
        private string sourceID;
        private string supportID;
        private bool timeFormat24h;
        private string timeZone;
        private UIExtension uiExtension;
        private bool vip;
        private Calendar workHours;

        #region Addresses

        /// <summary>
        /// The address fields are used to enter the home and mailing addresses of the person.
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

        #region AuthenticationID

        /// <summary>
        /// The authenticationID field may be used by the Single Sign-On feature to uniquely identify a user.
        /// </summary>
        [JsonProperty("authenticationID")]
        public string Authenticationid
        {
            get => authenticationID;
            set => authenticationID = SetValue("authenticationID", authenticationID, value);
        }

        #endregion

        #region Auto translation

        /// <summary>
        /// The Auto translation box is checked when the person should be offered translations
        /// </summary>
        [JsonProperty("auto_translation")]
        public bool AutoTranslation
        {
            get => autoTranslation;
            set => autoTranslation = SetValue("auto_translation", autoTranslation, value);
        }

        #endregion

        #region Contacts

        /// <summary>
        /// The Contact fields
        /// </summary>
        [JsonProperty("contacts")]
        public List<Contact> Contacts
        {
            get => contacts;
            internal set => contacts = value;
        }

        #endregion

        #region Cost per hour

        /// <summary>
        /// The Cost per hour field.
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
        /// The currency of the Cost per hour field value of the person.
        /// </summary>
        [JsonProperty("cost_per_hour_currency")]
        public string CostPerHourCurrency
        {
            get => costPerHourCurrency;
            set => costPerHourCurrency = SetValue("cost_per_hour_currency", costPerHourCurrency, value);
        }

        #endregion

        #region Disabled

        /// <summary>
        /// The Disabled box is checked when the person may no longer be related to other records.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get => disabled;
            set => disabled = SetValue("disabled", disabled, value);
        }

        #endregion

        #region Do not translate languages

        /// <summary>
        /// The Do not translate field is used to select the languages that should not be translated automatically for the person.
        /// </summary>
        [JsonProperty("do_not_translate_languages")]
        public string DoNotTranslateLanguages
        {
            get => doNotTranslateLanguages;
            set => doNotTranslateLanguages = SetValue("do_not_translate_languages", doNotTranslateLanguages, value);
        }

        #endregion

        #region EmployeeID

        /// <summary>
        /// The Employee ID field is the unique identifier for a person typically based on order of hire or association with an organization.
        /// </summary>
        [JsonProperty("employeeID")]
        public string EmployeeID
        {
            get => employeeID;
            set => employeeID = SetValue("employeeID", employeeID, value);
        }

        #endregion

        #region Exclude team notifications

        /// <summary>
        /// Indicates whether the person wants to receive team notifications.
        /// </summary>
        [JsonProperty("exclude_team_notifications")]
        public bool ExcludeTeamNotifications
        {
            get => excludeTeamNotifications;
            set => excludeTeamNotifications = SetValue("exclude_team_notifications", excludeTeamNotifications, value);
        }

        #endregion

        #region Information

        /// <summary>
        /// The Information field is used to add any additional information.
        /// </summary>
        [JsonProperty("information")]
        public string Information
        {
            get => information;
            set => information = SetValue("information", information, value);
        }

        #endregion

        #region Information attachment

        /// <summary>
        /// Write-only. Add a reference to an uploaded attachment. Use <see cref="Attachments"/> to get the existing attachments.
        /// </summary>
        /// <param name="key">The attachment key.</param>
        /// <param name="fileSize">The attachment file size.</param>
        /// <param name="inline">True if this an in-line attachment; otherwise false.</param>
        public void ReferenceInformationAttachment(string key, long fileSize, bool inline = false)
        {
            if (informationAttachments == null)
                informationAttachments = new List<AttachmentReference>();

            informationAttachments.Add(new AttachmentReference()
            {
                Key = key,
                FileSize = fileSize,
                Inline = inline
            });

            base.PropertySerializationCollection.Add("information_attachments");
        }

        [JsonProperty("information_attachments"), Sdk4meIgnoreInFieldSelection()]
        internal List<AttachmentReference> InformationAttachments
        {
            get => informationAttachments;
        }

        #endregion

        #region Job title

        /// <summary>
        /// The Job title field is used to enter the person’s job title.
        /// </summary>
        [JsonProperty("job_title")]
        public string JobTitle
        {
            get => jobTitle;
            set => jobTitle = SetValue("job_title", jobTitle, value);
        }

        #endregion

        #region Locale

        /// <summary>
        /// The locale field has the label “Language” in the user interface. It is used to select the language preference of the person.
        /// </summary>
        [JsonProperty("locale")]
        public string Locale
        {
            get => locale;
            set => locale = SetValue("locale", locale, value);
        }

        #endregion

        #region Location

        /// <summary>
        /// The Location field is used to enter the name or number of the room.
        /// </summary>
        [JsonProperty("location")]
        public string Location
        {
            get => location;
            set => location = SetValue("location", location, value);
        }

        #endregion

        #region Manager

        /// <summary>
        /// The Manager field is used to select the manager or supervisor to whom the person reports.
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
        /// The Name field is used to enter the person’s name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set => name = SetValue("name", name, value);
        }

        #endregion

        #region OAuth person enablement

        /// <summary>
        /// An enabled OAuth person is mentionable and visible in suggest fields, just like a real person.
        /// </summary>
        [JsonProperty("oauth_person_enablement")]
        public bool OauthPersonEnablement
        {
            get => oauthPersonEnablement;
            set => oauthPersonEnablement = SetValue("oauth_person_enablement", oauthPersonEnablement, value);
        }

        #endregion

        #region Organization

        /// <summary>
        /// The Organization field is used to select the Organization for which the person works.
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization
        {
            get => organization;
            set => organization = SetValue("organization_id", organization, value);
        }

        [JsonProperty("organization_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? OrganizationID => organization?.ID;

        #endregion

        #region Picture URI

        /// <summary>
        /// The hyperlink to the image file for the person.
        /// </summary>
        [JsonProperty("picture_uri")]
        public string PictureUri
        {
            get => pictureUri;
            set => pictureUri = SetValue("picture_uri", pictureUri, value);
        }

        #endregion

        #region Primary email

        /// <summary>
        /// The Primary email field is used to enter the email address to which email notifications are to be sent. This email address acts as the unique identifier for the person within the 4me account.
        /// </summary>
        [JsonProperty("primary_email")]
        public string PrimaryEmail
        {
            get => primaryEmail;
            set => primaryEmail = SetValue("primary_email", primaryEmail, value);
        }

        #endregion

        #region Send email notifications

        /// <summary>
        /// Indicates when to send email notifications to the person.
        /// </summary>
        [JsonProperty("send_email_notifications")]
        public PeopleEmailNotificationPreference SendEmailNotifications
        {
            get => sendEmailNotifications;
            set => sendEmailNotifications = SetValue("send_email_notifications", sendEmailNotifications, value);
        }

        #endregion

        #region Show notification popup

        /// <summary>
        /// Indicates when to show a notification popup to the person.
        /// </summary>
        [JsonProperty("show_notification_popup")]
        public PeoplePopupNotificationPreference ShowNotificationPopup
        {
            get => showNotificationPopup;
            set => showNotificationPopup = SetValue("show_notification_popup", showNotificationPopup, value);
        }

        #endregion

        #region Site

        /// <summary>
        /// The Site where the person is stationed.
        /// </summary>
        [JsonProperty("site")]
        public Site Site
        {
            get => site;
            set => site = SetValue("site_id", site, value);
        }

        [JsonProperty("site_id"), Sdk4meIgnoreInFieldSelection()]
        internal long? SiteID => site?.ID;

        #endregion

        #region Source

        /// <summary>
        /// See source.
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
        /// See source identifier.
        /// </summary>
        [JsonProperty("sourceID")]
        public string SourceID
        {
            get => sourceID;
            set => sourceID = SetValue("sourceID", sourceID, value);
        }

        #endregion

        #region SupportID

        /// <summary>
        /// The Support ID field is used to enter a number or code that a service desk analyst can ask the person for when the person contacts the service desk for support.
        /// </summary>
        [JsonProperty("supportID")]
        public string SupportID
        {
            get => supportID;
            set => supportID = SetValue("supportID", supportID, value);
        }

        #endregion

        #region Time format 24h

        /// <summary>
        /// The Time format field is used to indicate whether the person prefers to see times displayed within the 4me service in the 24-hour format or not (in which case the 12-hour format is applied).
        /// </summary>
        [JsonProperty("time_format_24h")]
        public bool TimeFormat24h
        {
            get => timeFormat24h;
            set => timeFormat24h = SetValue("time_format_24h", timeFormat24h, value);
        }

        #endregion

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone in which the person normally resides.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            set => timeZone = SetValue("time_zone", timeZone, value);
        }

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

        #region VIP

        /// <summary>
        /// The VIP box is checked to indicate that the person is a very important person.
        /// </summary>
        [JsonProperty("vip")]
        public bool Vip
        {
            get => vip;
            set => vip = SetValue("vip", vip, value);
        }

        #endregion

        #region Work hours

        /// <summary>
        /// The Work hours field is used to select a Calendar that represents the work hours of the person.
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
            addresses?.ResetPropertySerializationCollection();
            contacts?.ResetPropertySerializationCollection();
            WorkHours?.ResetPropertySerializationCollection();
            manager?.ResetPropertySerializationCollection();
            organization?.ResetPropertySerializationCollection();
            site?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
