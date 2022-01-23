using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace Sdk4me
{
    /// <summary>
    /// Custom Json.Net contract resolver, only serialize properties that are marked for serialization.
    /// </summary>
    internal sealed class Sdk4meContractResolver : DefaultContractResolver
    {
        private HashSet<string> includedProperties = null;

        public HashSet<string> IncludedProperties
        {
            get => includedProperties;
            set => includedProperties = value ?? new HashSet<string>();
        }

        /// <summary>
        /// Initialize a new instance of the Sdk4meContractResolver.
        /// </summary>
        public Sdk4meContractResolver()
        {
            this.includedProperties = new HashSet<string>();
        }

        /// <summary>
        /// Initialize a new instance of the Sdk4meContractResolver.
        /// </summary>
        /// <param name="includedProperties">A list of attributes that should be serialized.</param>
        public Sdk4meContractResolver(HashSet<string> includedProperties)
        {
            if (includedProperties == null)
                this.includedProperties = new HashSet<string>();
            else
                this.includedProperties = includedProperties;
        }

        /// <summary>
        /// Creates a json property for the given member.
        /// </summary>
        /// <param name="member">The member to create a JsonProperty for.</param>
        /// <param name="memberSerialization">The member's parent MemberSerialization.</param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = instance =>
            {
                if (property.DeclaringType.GetCustomAttribute(typeof(Sdk4meSerializeAllPropertiesAttribute)) is Sdk4meSerializeAllPropertiesAttribute)
                    return true;

                return includedProperties.Contains(property.PropertyName);
            };
            return property;
        }
    }
}
