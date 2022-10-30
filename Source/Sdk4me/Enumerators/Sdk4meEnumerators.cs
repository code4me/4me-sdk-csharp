using System;
using System.Runtime.Serialization;

namespace Sdk4me
{
    /// <summary>
    /// A 4me environment type.
    /// </summary>
    public enum EnvironmentType
    {
        /// <summary>
        /// The 4me production environment.
        /// </summary>
        Production,
        /// <summary>
        /// The 4me quality environment.
        /// </summary>
        Quality,
        /// <summary>
        /// The 4me demo environment.
        /// <br>The environment region is obsolete for the 4me demo environment.</br>
        /// </summary>
        Demo
    }

    /// <summary>
    /// A 4me environment region.
    /// </summary>
    public enum EnvironmentRegion
    {
        /// <summary>
        /// The European region.
        /// </summary>
        EU,
        /// <summary>
        /// The Australia region.
        /// </summary>
        AU,
        /// <summary>
        /// The United Kingdom region.
        /// </summary>
        UK,
        /// <summary>
        /// The United States region.
        /// </summary>
        US
    }

    /// <summary>
    /// Sort order for the 4me web request.
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// Do not sort the output
        /// </summary>
        None = 0,

        /// <summary>
        /// Order by "id"
        /// </summary>
        [EnumMember(Value = "id")]
        ID = 1,

        /// <summary>
        /// Order by "created_at"
        /// </summary>
        [EnumMember(Value = "created_at")]
        CreatedAt = 2,

        /// <summary>
        /// Order by "updated_at"
        /// </summary>
        [EnumMember(Value = "updated_at")]
        UpdatedAt = 3,

        /// <summary>
        /// Order by "created_at" and then by "id"
        /// </summary>
        [EnumMember(Value = "created_at,id")]
        CreatedAtAndID = 4,

        /// <summary>
        /// Order by "updated_at" and then by "id"
        /// </summary>
        [EnumMember(Value = "updated_at,id")]
        UpdatedAtAndID = 5,
    }

    /// <summary>
    /// Operators for web request filtering.
    /// </summary>
    public enum FilterCondition
    {
        /// <summary>
        /// Same as given value 
        /// </summary>
        Equality,

        /// <summary>
        /// Different from given value 
        /// </summary>
        Negation,

        /// <summary>
        /// Equal to one of the given values (integers and enumerable values only) 
        /// </summary>
        In,

        /// <summary>
        /// Not equal to one of the given values (integers and enumerable values only) 
        /// </summary>
        NotIn,

        /// <summary>
        /// Less than given value (not for enumerable values, strings and booleans) 
        /// </summary>
        LessThan,

        /// <summary>
        /// Less than or equal to given value (not for enumerable values, strings and booleans) 
        /// </summary>
        LessThanOrEqualsTo,

        /// <summary>
        /// Greater than given value (not for enumerable values, strings and booleans) 
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Greater than or equal to given value (not for enumerable values, strings and booleans)
        /// </summary>
        GreaterThanOrEqualsTo,

        /// <summary>
        /// Contains a value (not null)
        /// </summary>
        Present,

        /// <summary>
        /// Has no value 
        /// </summary>
        Empty,

        /// <summary>
        /// Greater than given value and less than the other given value (numeric and date/time types only)
        /// </summary>
        GreaterThanAndLessThan,

        /// <summary>
        /// Greater than or equal to given value and less than or equal to the other given value (numeric and date / time types only)
        /// </summary>
        GreaterThanOrEqualToAndLessThanOrEqualTo
    }

    /// <summary>
    /// The 4me attachment types.
    /// </summary>
    public enum AttachmentType
    {
        /// <summary>
        /// A charges attachment.
        /// </summary>
        Charges,
        /// <summary>
        /// A description attachment.
        /// </summary>
        Description,
        /// <summary>
        /// An information attachment.
        /// </summary>
        Information,
        /// <summary>
        /// An instruction attachment.
        /// </summary>
        Instructions,
        /// <summary>
        /// An internal note attachment.
        /// </summary>
        InternalNote,
        /// <summary>
        /// A note attachment.
        /// </summary>
        Note,
        /// <summary>
        /// A remarks attachment.
        /// </summary>
        Remarks,
        /// <summary>
        /// A summary attachment.
        /// </summary>
        Summary,
        /// <summary>
        /// A target details attachment.
        /// </summary>
        TargetDetails,
        /// <summary>
        /// A work around attachment.
        /// </summary>
        Workaround,
        /// <summary>
        /// A message attachment.
        /// </summary>
        Message
    }
}
