using MadNeptun.DistributedExample.Logic;
using MadNeptun.DistributedExample.SDK;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MadNeptun.DistributedExample.NetworkNodeService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class NetworkNodeService : System.Web.Services.WebService
    { 
        [WebMethod]
        public void Receive(string message, string sender)
        {
            Messages.Add(message);
            NetworkNode.RecieveMessage(message, sender);
        }

        public NetworkNodeService(IDistributedProcedure implementation, ObservableCollection<string> msgsList)
        {
            Messages = msgsList;
            NetworkNode = new Node(implementation, HttpContext.Current.Request.Url.ToString());
        }

        public void Init(string message)
        {
            Messages.Add(message);
            NetworkNode.PerformInit(message); 
        }

        public void AddConnectedNode(string url)
        {
            NetworkNode.AddConnectedNode(url);
        }

        public void RemoveConnectedNode(string url)
        {
            NetworkNode.RemoveConnectedNode(url);
        }

        private ObservableCollection<string> Messages { get; set; }

        private Node NetworkNode { get; set; }
    }
}
