using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sdk4me
{
    /// <summary>
    /// A 4me <see href="https://developer.4me.com/v1/people/permissions/">account permission</see> object.
    /// </summary>
    [DebuggerDisplay("{ID}")]
    public class AccountPermission : BaseItem
    {
        private List<AccessRoles> roles = new List<AccessRoles>();

        /// <summary>
        /// The account identifier.
        /// </summary>
        [Sdk4meIgnoreInFieldSelection()]
        public new string ID
        {
            get => Account?.ID;
        }

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

        #region Roles

        /// <summary>
        /// The roles the person has within the account
        /// </summary>
        [JsonProperty("roles")]
        internal List<AccessRoles> RoleList
        {
            get => roles;
            set => roles = value;
        }

        public AccessRoles Roles
        {
            get
            {
                AccessRoles retval = AccessRoles.None;
                foreach (AccessRoles filter in roles)
                    retval |= filter;
                return retval;
            }
            set
            {
                List<AccessRoles> items = Enum.GetValues(value.GetType()).Cast<Enum>().Where(value.HasFlag).Cast<AccessRoles>().ToList();
                items.Remove(AccessRoles.None);
                if (!Enumerable.SequenceEqual(roles, items))
                {
                    roles = items;
                    AddPropertySerializationItem("roles");
                }
            }
        }

        #endregion
    }
}
