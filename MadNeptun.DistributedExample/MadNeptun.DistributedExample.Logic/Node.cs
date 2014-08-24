using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadNeptun.DistributedExample.SDK;
namespace MadNeptun.DistributedExample.Logic
{
    public class Node
    {
        private List<string> Nodes { get; set; }

        private NetworkWebService.NetworkNodeService Service { get; set; }

        private IDistributedProcedure Implementation { get; set; }

        public string ThisNode { get; private set; }

        public Node(IDistributedProcedure implementation, string url)
        {
            Implementation = implementation;
            Service = new NetworkWebService.NetworkNodeService();
            ThisNode = url;
            Nodes = new List<string>();
        }

        public void PerformInit(string message)
        {
            var result = Implementation.Init(message, Nodes);
            foreach(var node in result.Recievers)
            {
                Service.Url = node;
                Service.Receive(result.Message, ThisNode);
            }
        }

        public void RecieveMessage(string message, string sender)
        {
            var result = Implementation.RecieveMessage(message, sender, Nodes);
            foreach(var node in result.Recievers)
            {
                Service.Url = node;
                Service.Receive(result.Message, ThisNode);
            }
        }

        public void AddConnectedNode(string url)
        {
            Nodes.Add(url);
        }

        public void RemoveConnectedNode(string url)
        {
            Nodes.Remove(url);
        }
    }
}
