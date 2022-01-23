using System;

namespace Sdk4me
{
    /// <summary>
    /// Make sure the contract resolver serializes all properties of the class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class Sdk4meSerializeAllPropertiesAttribute : Attribute
    {
    }
}
