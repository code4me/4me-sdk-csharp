using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace Sdk4me
{
    /// <summary>
    /// Custom Newtonsoft.Json contract resolver.
    /// </summary>
    internal sealed class ContractResolver : DefaultContractResolver
    {
        private readonly HashSet<string> includedProperties = null;

        /// <summary>
        /// Create a new instance of the <see cref="ContractResolver"/>.
        /// </summary>
        /// <param name="includedProperties">A collection of properties that should be serialized.</param>
        /// <param name="includeIdentifier">True to included the <see cref="IBaseItem.ID"/> during serialization; otherwise false.</param>
        public ContractResolver(HashSet<string> includedProperties, bool includeIdentifier)
        {
            this.includedProperties = includedProperties ?? new HashSet<string>();
            if (includeIdentifier)
                includedProperties.Add("id");
            else
                includedProperties.Remove("id");
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = instance =>
            {
                if (includedProperties.Contains(property.PropertyName))
                    return !property.PropertyType.IsEnum || ((int)instance.GetType().GetProperty(property.UnderlyingName).GetValue(instance)) > 0;
                else
                    return property.DeclaringType != TypeReferences.AccountReferenceType && (property.DeclaringType == TypeReferences.CustomFieldType || property.DeclaringType == TypeReferences.AttachmentReferenceType || property.DeclaringType == TypeReferences.AccountPermissionType);
            };
            return property;
        }
    }
}
