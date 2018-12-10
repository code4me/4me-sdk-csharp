using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me
{
    public interface IBaseHandler
    {
        int ItemsPerRequest { get; set; }

        int MaximumRecursiveRequests { get; set; }
    }
}
