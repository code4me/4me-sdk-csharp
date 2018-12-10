using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me
{
    public interface IBaseType
    {
        long ID { get; set; }

        DateTime? CreatedAt { get; }

        DateTime? UpdatedAt { get; }
    }
}
