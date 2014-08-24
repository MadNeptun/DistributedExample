using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadNeptun.DistributedExample.SDK;
namespace MadNeptun.DistributedExample.Sample
{
    public class Broadcast : IDistributedProcedure
    {
        public OperationResult Init(string message, IEnumerable<string> connectedNodes)
        {
            throw new NotImplementedException();
        }

        public OperationResult RecieveMessage(string message, string sender, IEnumerable<string> connectedNodes)
        {
            throw new NotImplementedException();
        }
    }
}
