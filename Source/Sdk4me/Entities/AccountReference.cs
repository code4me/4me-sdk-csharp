﻿using Newtonsoft.Json;

namespace Sdk4me
{
    /// <summary>
    /// An account reference.
    /// </summary>
    public class AccountReference
    {
        private string id;
        private string name;

        /// <summary>
        /// Convert an <see cref="AccountReference"/> object to an <see cref="Account"/> object.
        /// </summary>
        /// <param name="accountReference">The account reference object.</param>
        public static explicit operator Account(AccountReference accountReference) => new Account() { ID = accountReference.id, Name = accountReference.Name };

        #region ID

        /// <summary>
        /// The account identifier.
        /// </summary>
        [JsonProperty("id")]
        public string ID
        {
            get => id;
            set => id = value;
        }

        #endregion

        #region Name

        /// <summary>
        /// The full name of the account.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            internal set => name = value;
        }

        #endregion
    }
}
