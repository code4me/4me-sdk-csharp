using Newtonsoft.Json;

namespace Sdk4me
{
    public class Account : BaseItem
    {
        private string id;
        private string currency;
        private Account directoryAccount;
        private string locale;
        private string name;
        private Organization organization;
        private Person owner;
        private AccountPlanType plan;
        private bool strongPrivacy;
        private bool timeFormat24h;
        private string timeZone;
        private string url;

        #region id

        [JsonProperty("id")]
        public new string ID
        {
            get => id;
            set => id = value;
        }

        #endregion

        #region currency

        [JsonProperty("currency")]
        public string Currency
        {
            get => currency;
            internal set => currency = value;
        }

        #endregion

        #region directory_account

        [JsonProperty("directory_account")]
        public Account DirectoryAccount
        {
            get => directoryAccount;
            internal set => directoryAccount = value;
        }

        #endregion

        #region locale

        [JsonProperty("locale")]
        public string Locale
        {
            get => locale;
            internal set => locale = value;
        }

        #endregion

        #region name

        [JsonProperty("name")]
        public string Name
        {
            get => name;
            internal set => name = value;
        }

        #endregion

        #region organization

        [JsonProperty("organization")]
        public Organization Organization
        {
            get => organization;
            internal set => organization = value;
        }

        #endregion

        #region owner

        [JsonProperty("owner")]
        public Person Owner
        {
            get => owner;
            internal set => owner = value;
        }

        #endregion

        #region plan

        [JsonProperty("plan")]
        public AccountPlanType Plan
        {
            get => plan;
            internal set => plan = value;
        }

        #endregion

        #region strong_privacy

        [JsonProperty("strong_privacy")]
        public bool StrongPrivacy
        {
            get => strongPrivacy;
            internal set => strongPrivacy = value;
        }

        #endregion

        #region time_format_24h

        [JsonProperty("time_format_24h")]
        public bool TimeFormat24h
        {
            get => timeFormat24h;
            internal set => timeFormat24h = value;
        }

        #endregion

        #region time_zone

        [JsonProperty("time_zone")]
        public string TimeZone
        {
            get => timeZone;
            internal set => timeZone = value;
        }

        #endregion

        #region url

        [JsonProperty("url")]
        public string URL
        {
            get => url;
            internal set => url = value;
        }

        #endregion
    }
}
