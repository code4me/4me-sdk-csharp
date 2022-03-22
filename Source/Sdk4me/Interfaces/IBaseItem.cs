using System;

namespace Sdk4me
{
    /// <summary>
    /// Allows an object to inherit the basic properties of a 4me data object.
    /// </summary>
    public interface IBaseItem
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        long ID { get; set; }

        /// <summary>
        /// Get the creation date and time.
        /// </summary>
        DateTime? CreatedAt { get; }

        /// <summary>
        /// Get the last updated date and time.
        /// </summary>
        DateTime? UpdatedAt { get; }

        /// <summary>
        /// Gets the 4me account.
        /// </summary>
        AccountReference Account { get; }
    }
}
