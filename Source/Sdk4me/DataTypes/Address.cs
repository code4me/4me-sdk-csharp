using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class Address : BaseItem
    {
        private string street;
        private string city;
        private string country;
        private string integration;
        private AddressType? label;
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

        #region address

        [JsonProperty("address")]
        public string Street
        {
            get => street;
            set
            {
                if (street != value)
                    AddIncludedDuringSerialization("address");
                street = value;
            }
        }

        #endregion

        #region city

        [JsonProperty("city")]
        public string City
        {
            get => city;
            set
            {
                if (city != value)
                    AddIncludedDuringSerialization("city");
                city = value;
            }
        }

        #endregion

        #region country

        [JsonProperty("country")]
        public string Country
        {
            get => country;
            set
            {
                if (country != value)
                    AddIncludedDuringSerialization("country");
                country = value;
            }
        }

        #endregion

        #region integration

        [JsonProperty("integration")]
        public string Integration
        {
            get => integration;
            set
            {
                if (integration != value)
                    AddIncludedDuringSerialization("integration");
                integration = value;
            }
        }

        #endregion

        #region label

        [JsonProperty("label")]
        public AddressType? Label
        {
            get => label;
            set
            {
                if (label != value)
                    AddIncludedDuringSerialization("label");
                label = value;
            }
        }

        #endregion

        #region state

        [JsonProperty("state")]
        public string State
        {
            get => state;
            set
            {
                if (state != value)
                    AddIncludedDuringSerialization("state");
                state = value;
            }
        }

        #endregion

        #region zip

        [JsonProperty("zip")]
        public string Zip
        {
            get => zip;
            set
            {
                if (zip != value)
                    AddIncludedDuringSerialization("zip");
                zip = value;
            }
        }

        #endregion
    }
}
