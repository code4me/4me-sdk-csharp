using System;

namespace Sdk4me
{
    public interface IBaseType
    {
        long ID { get; set; }

        DateTime? CreatedAt { get; }

        DateTime? UpdatedAt { get; }
    }
}
