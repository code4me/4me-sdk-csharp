namespace Sdk4me
{
    public interface IBaseHandler
    {
        int ItemsPerRequest { get; set; }

        int MaximumRecursiveRequests { get; set; }
    }
}
