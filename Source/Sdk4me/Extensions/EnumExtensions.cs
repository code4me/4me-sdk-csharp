using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Sdk4me.Extensions
{
    /// <summary>
    /// A class containing multiple <see cref="Enum"/> extension methods.
    /// </summary>
    internal static class EnumExtensions
    {
        /// <summary>
        /// Returns the <see cref="EnumMemberAttribute"/> value of a property.
        /// </summary>
        /// <typeparam name="T">Any type implementing <see cref="Enum"/>.</typeparam>
        /// <param name="value">The <see cref="Enum"/> value.</param>
        /// <returns>The <see cref="EnumMemberAttribute"/> value of a property; or the property name when there is no <see cref="EnumMemberAttribute"/> value set.</returns>
        internal static string GetEnumMemberValue<T>(this T value) where T : Enum
        {
            EnumMemberAttribute attr = value.GetType().GetMember(value.ToString()).FirstOrDefault()?.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
            return attr == null ? value.ToString() : attr.Value;
        }

        /// <summary>
        /// Get the <see cref="AccessRoles"/> as a <see cref="List{string}"/> collection.
        /// </summary>
        /// <param name="accessRoles">The access roles.</param>
        /// <returns>Returns a <see cref="List{string}"/> collection.</returns>
        internal static List<string> Get4meStringCollection(this AccessRoles accessRoles)
        {
            List<string> retval = new List<string>();
            List<AccessRoles> items = Enum.GetValues(accessRoles.GetType()).Cast<Enum>().Where(accessRoles.HasFlag).Cast<AccessRoles>().ToList();
            items.Remove(AccessRoles.None);
            foreach (AccessRoles item in items)
                retval.Add(item.GetEnumMemberValue());
            return retval;
        }
    }
}
