using System;

namespace Sdk4me
{
    /// <summary>
    /// <para>Excluded the property from the field selection during the HTTP web request.</para> 
    /// <para>This does not replace the DataMember or the IgnoreDataMember attribute.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class Sdk4meIgnoreInFieldSelectionAttribute : Attribute
    {
    }
}
