namespace Sdk4me
{
    /// <summary>
    /// Allows a handler to inherit the basic properties of a 4me handler object.
    /// </summary>
    public interface IBaseHandler
    {
        /// <summary>
        /// The number of items per request.
        /// </summary>
        int ItemsPerRequest { get; set; }

        /// <summary>
        /// The number of recursive requests.
        /// </summary>
        int MaximumRecursiveRequests { get; set; }
    }
}
