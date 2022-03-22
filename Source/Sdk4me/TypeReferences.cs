using Newtonsoft.Json;
using System;

namespace Sdk4me
{
    /// <summary>
    /// A collection of type references.
    /// </summary>
    internal static class TypeReferences
    {
        public static readonly Type JsonPropertyAttributeType = typeof(JsonPropertyAttribute);
        public static readonly Type Sdk4meIgnoreInFieldSelectionAttributeType = typeof(Sdk4meIgnoreInFieldSelectionAttribute);
        public static readonly Type PredefinedDefaultFilterType = typeof(PredefinedDefaultFilter);
        public static readonly Type CustomFieldType = typeof(CustomField);
        public static readonly Type BaseItemType = typeof(BaseItem);
        public static readonly Type StorageFacilityType = typeof(StorageFacility);
        public static readonly Type AttachmentReferenceType = typeof(AttachmentReference);
        public static readonly Type AccountReferenceType = typeof(AccountReference);
        public static readonly Type AccountPermissionType = typeof(AccountPermission);
    }
}
