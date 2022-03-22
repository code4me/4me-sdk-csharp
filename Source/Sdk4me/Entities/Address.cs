using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/people/addresses/">people address</see> object.
    /// </summary>
    public class Address : BaseItem
    {
        private string address;
        private string city;
        private string country;
        private bool integration;
        private AddressType label;
        private string state;
        private string zip;

        #region created_at (override)

        [JsonProperty("created_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? CreatedAt
        {
            get => base.CreatedAt;
            internal set => base.CreatedAt = null;
        }

        #endregion

        #region updated_at (override)

        [JsonProperty("updated_at"), Sdk4meIgnoreInFieldSelection()]
        public override DateTime? UpdatedAt
        {
            get => base.UpdatedAt;
            internal set => base.UpdatedAt = null;
        }

        #endregion

        #region Street

        /// <summary>
        /// The address line.
        /// </summary>
        [JsonProperty("address")]
        public string Street
        {
            get => address;
            set => address = SetValue("address", address, value);
        }

        #endregion

        #region City

        /// <summary>
        /// The city name.
        /// </summary>
        [JsonProperty("city")]
        public string City
        {
            get => city;
            set => city = SetValue("city", city, value);
        }

        #endregion

        #region Country

        /// <summary>
        /// The 2-letter country code.
        /// </summary>
        [JsonProperty("country")]
        public string Country
        {
            get => country;
            set => country = SetValue("country", country, value);
        }

        #endregion

        #region Integration

        /// <summary>
        /// The Integration field.
        /// </summary>
        [JsonProperty("integration")]
        public bool Integration
        {
            get => integration;
            set => integration = SetValue("integration", integration, value);
        }

        #endregion

        #region Label

        /// <summary>
        /// The Label of the address details.
        /// </summary>
        [JsonProperty("label")]
        public AddressType Label
        {
            get => label;
            set => label = SetValue("label", label, value);
        }

        #endregion

        #region State

        /// <summary>
        /// The state name.
        /// </summary>
        [JsonProperty("state")]
        public string State
        {
            get => state;
            set => state = SetValue("state", state, value);
        }

        #endregion

        #region Zip

        /// <summary>
        /// The zip code.
        /// </summary>
        [JsonProperty("zip")]
        public string Zip
        {
            get => zip;
            set => zip = SetValue("zip", zip, value);
        }

        #endregion
    }
}
