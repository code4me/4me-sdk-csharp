using Newtonsoft.Json;
using System.Diagnostics;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/account/">account</see> object.
    /// </summary>
    [DebuggerDisplay("{ID}")]
    public class Account : BaseItem
    {
        private string id;
        private string currency;
        private Account directoryAccount;
        private string locale;
        private string name;
        private Organization organization;
        private Person owner;
        private AccountPlan plan;
        private bool strongPrivacy;
        private bool timeFormat24h;
        private string timeZone;
        private string url;

        public static implicit operator AccountReference(Account account) => new AccountReference() { ID = account.ID, Name = account.Name };

        #region ID

        /// <summary>
        /// The unique identifier.
        /// </summary>
        [JsonProperty("id")]
        public new string ID
        {
            get => id;
            set => id = value;
        }

        #endregion

        #region Currency

        /// <summary>
        /// The Currency field is used to select the currency that is applied to all financial values stored in the account.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency
        {
            get => currency;
            internal set => currency = value;
        }

        #endregion

        #region Directory account

        /// <summary>
        /// The Directory account field contains a value only for support domain accounts.
        /// </summary>
        [JsonProperty("directory_account")]
        public Account DirectoryAccount
        {
            get => directoryAccount;
            internal set => directoryAccount = value;
        }

        #endregion

        #region Locale

        /// <summary>
        /// The Language field is used to select the language in which the records of the account are stored. It is also the default language that is applied to new Person records.
        /// </summary>
        [JsonProperty("locale")]
        public string Locale
        {
            get => locale;
            internal set => locale = SetValue("locale", locale, value);
        }

        #endregion

        #region Name

        /// <summary>
        /// The Name field is used to enter the full name of the account.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            internal set => name = value;
        }

        #endregion

        #region Organization

        /// <summary>
        /// The Organization field is set to the organization for which the account was prepared.
        /// </summary>
        [JsonProperty("organization")]
        public Organization Organization
        {
            get => organization;
            internal set => organization = value;
        }

        #endregion

        #region Owner

        /// <summary>
        /// The Owner field is used to select the account administrator who is allowed to update the billing information and settings of the account.
        /// </summary>
        [JsonProperty("owner")]
        public Person Owner
        {
            get => owner;
            internal set => owner = value;
        }

        #endregion

        #region Plan

        /// <summary>
        /// The Plan field is used to select the Plan for the account.
        /// </summary>
        [JsonProperty("plan")]
        public AccountPlan Plan
        {
            get => plan;
            internal set => plan = value;
        }

        #endregion

        #region Strong privacy

        /// <summary>
        /// The Strong privacy box is checked when access to requests, problems and tasks needs to be restricted to members of the teams to which they are assigned.
        /// </summary>
        [JsonProperty("strong_privacy")]
        public bool StrongPrivacy
        {
            get => strongPrivacy;
            internal set => strongPrivacy = value;
        }

        #endregion

        #region Time format 24h

        /// <summary>
        /// The Time format field is the default format for displaying time values that is applied to new Person records. When true, times are displayed within the 4me service in the 24-hour format, otherwise the 12-hour format is applied.
        /// </summary>
        [JsonProperty("time_format_24h")]
        public bool TimeFormat24h
        {
            get => timeFormat24h;
            internal set => timeFormat24h = value;
        }

        #endregion

        #region Time zone

        /// <summary>
        /// The Time zone field is used to select the time zone that applies to the account’s analytics and report data. It is also the default time zone that is applied to new Person records.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            internal set => timeZone = value;
        }

        #endregion

        #region Url

        /// <summary>
        /// The Account URL field contains the web address that is used to access the account.
        /// </summary>
        [JsonProperty("url")]
        public string Url
        {
            get => url;
            internal set => url = value;
        }

        #endregion

        internal override void ResetPropertySerializationCollection()
        {
            directoryAccount?.ResetPropertySerializationCollection();
            organization?.ResetPropertySerializationCollection();
            owner?.ResetPropertySerializationCollection();
            base.ResetPropertySerializationCollection();
        }
    }
}
