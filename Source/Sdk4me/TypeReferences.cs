using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A collection of type references.
    /// </summary>
    internal static class TypeReferences
    {
        /// <summary>
        /// A <see cref="JsonPropertyAttribute"/> type object.
        /// </summary>
        public static readonly Type JsonPropertyAttributeType = typeof(JsonPropertyAttribute);
        /// <summary>
        /// A <see cref="Sdk4meIgnoreInFieldSelectionAttribute"/> type object.
        /// </summary>
        public static readonly Type Sdk4meIgnoreInFieldSelectionAttributeType = typeof(Sdk4meIgnoreInFieldSelectionAttribute);
        /// <summary>
        /// A <see cref="PredefinedDefaultFilter"/> type object.
        /// </summary>
        public static readonly Type PredefinedDefaultFilterType = typeof(PredefinedDefaultFilter);
        /// <summary>
        /// A <see cref="CustomField"/> type object.
        /// </summary>
        public static readonly Type CustomFieldType = typeof(CustomField);
        /// <summary>
        /// A <see cref="BaseItem"/> type object.
        /// </summary>
        public static readonly Type BaseItemType = typeof(BaseItem);
        /// <summary>
        /// A <see cref="StorageFacility"/> type object.
        /// </summary>
        public static readonly Type StorageFacilityType = typeof(StorageFacility);
        /// <summary>
        /// A <see cref="AttachmentReference"/> type object.
        /// </summary>
        public static readonly Type AttachmentReferenceType = typeof(AttachmentReference);
        /// <summary>
        /// A <see cref="AccountReference"/> type object.
        /// </summary>
        public static readonly Type AccountReferenceType = typeof(AccountReference);
        /// <summary>
        /// A <see cref="AccountPermission"/> type object.
        /// </summary>
        public static readonly Type AccountPermissionType = typeof(AccountPermission);
    }
}
