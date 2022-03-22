using System;

namespace Sdk4me
{
    /// <summary>
    /// Excluded the property from the 4me field selection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class Sdk4meIgnoreInFieldSelectionAttribute : Attribute
    {
    }
}
