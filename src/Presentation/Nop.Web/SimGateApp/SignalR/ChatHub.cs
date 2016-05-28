using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Nop.Web.Controllers;

namespace Nop.Web.SimGateApp.SignalR
{
    public class ChatHub : Hub
    {


        private readonly NotificationsController _stockTicker;

        private static IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();


        public ChatHub() : this(NotificationsController.Instance) { }


        public ChatHub(NotificationsController stockTicker)
        {
            _stockTicker = stockTicker;
        }


        public void Hello()
        {
            Clients.All.hello();
        }


        public static void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            context.Clients.All.broadcastMessage(name, message);
        }

    }
}