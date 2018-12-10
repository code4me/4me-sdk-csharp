using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    public class Contact : BaseItem
    {
        private string email;
        private bool integration;
        private ContactType label;
        private string telephone;
        private string website;
        private string chat;

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

        #region email

        [JsonProperty("email"), Sdk4meIgnoreInFieldSelection()]
        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                    AddIncludedDuringSerialization("email");
                email = value;
            }
        }

        #endregion

        #region integration

        [JsonProperty("integration")]
        public bool Integration
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
        public ContactType Label
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

        #region telephone

        [JsonProperty("telephone"), Sdk4meIgnoreInFieldSelection()]
        public string Telephone
        {
            get => telephone;
            set
            {
                if (telephone != value)
                    AddIncludedDuringSerialization("telephone");
                telephone = value;
            }
        }

        #endregion

        #region website

        [JsonProperty("website"), Sdk4meIgnoreInFieldSelection()]
        public string Website
        {
            get => website;
            set
            {
                if (website != value)
                    AddIncludedDuringSerialization("website");
                website = value;
            }
        }

        #endregion

        #region chat

        [JsonProperty("chat"), Sdk4meIgnoreInFieldSelection()]
        public string Chat
        {
            get => chat;
            set
            {
                if (chat != value)
                    AddIncludedDuringSerialization("chat");
                chat = value;
            }
        }

        #endregion
    }
}
