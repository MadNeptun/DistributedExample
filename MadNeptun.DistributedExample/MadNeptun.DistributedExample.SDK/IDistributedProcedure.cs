using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadNeptun.DistributedExample.SDK
{
    public interface IDistributedProcedure
    {
        /// <summary>
        /// Perform distributed algorithm init.
        /// </summary>
        OperationResult Init(string message, IEnumerable<string> connectedNodes);

        /// <summary>
        /// Perform recieve on node.
        /// </summary>
        OperationResult RecieveMessage(string message, string sender, IEnumerable<string> connectedNodes);
    }
}
