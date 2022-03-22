using System.Runtime.Serialization;

namespace Sdk4me
{
    /// <summary>
    /// A 4me environment type.
    /// </summary>
    public enum EnvironmentType
    {
        Production,
        Quality,
        Demo
    }

    /// <summary>
    /// A 4me environment region.
    /// </summary>
    public enum EnvironmentRegion
    {
        Global,
        Australia
    }

    /// <summary>
    /// The 4me authentication type.
    /// </summary>
    public enum AuthenticationType
    {
        /// <summary>
        /// API Token using Basic Authentication
        /// </summary>
        BasicAuthentication,

        /// <summary>
        /// Personal Access Token using Bearer Authentication.
        /// </summary>
        BearerAuthentication
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
        Charges,
        Description,
        Information,
        Instructions,
        InternalNote,
        Note,
        Remarks,
        Summary,
        TargetDetails,
        Workaround,
        ProductGoal,
        Message
    }
}
