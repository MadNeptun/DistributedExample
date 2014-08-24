using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadNeptun.DistributedExample.SDK
{
    public class OperationResult
    {
        public string Message { get; set; }

        public List<string> Recievers { get; set; }
    }
}
