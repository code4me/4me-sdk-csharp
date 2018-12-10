using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me
{
    /// <summary>
    /// Make sure the contract resolver serializes all properties of the class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class Sdk4meSerializeAllPropertiesAttribute : Attribute
    {
    }
}
