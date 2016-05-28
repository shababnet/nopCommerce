using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Nop.Web.SimGateApp.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Web.Controllers
{
    public class NotificationsController : Controller
    {
        public NotificationsController()
        {

        }

        // Singleton instance
        private readonly static Lazy<NotificationsController> _instance = new Lazy<NotificationsController>(() => new NotificationsController(GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients));


        private NotificationsController(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;

            //_stocks.Clear();
            //var stocks = new List<Stock>
            //{
            //    new Stock { Symbol = "MSFT", Price = 30.31m },
            //    new Stock { Symbol = "APPL", Price = 578.18m },
            //    new Stock { Symbol = "GOOG", Price = 570.30m }
            //};
            //stocks.ForEach(stock => _stocks.TryAdd(stock.Symbol, stock));

            //_timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);

        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }




        public static NotificationsController Instance
        {
            get
            {
                return _instance.Value;
            }
        }




        // GET: Notifications
        public ActionResult Index()
        {
            //String statusSecret = "YOUR_STATUS_SECRET_HERE";

            //if (Request["secret"] != statusSecret)
            //{
            //    Response.StatusCode = 403;
            //    return Content("Invalid status secret");
            //}

            Dictionary<string, object> result = new Dictionary<string, object>();



            if (Request["event"] == "incoming_message")
            {
                String content = Request["content"];
                String fromNumber = Request["from_number"];
                String phoneId = Request["phone_id"];

                // do something with the message, e.g. send an autoreply           
                Dictionary<string, object> reply = new Dictionary<string, object>();
                reply["content"] = "Thanks for your message!";
                result["messages"] = new Object[] { reply };

                ChatHub.Send(Request["event"], content);
            }
            else if (Request["event"] == "send_status")
            {

                ChatHub.Send(Request["event"], Request["update_type"]);

            } else if (Request["event"] == "contact_update")
            {
                ChatHub.Send(Request["event"], Request["update_type"]);

            } else if (Request["event"] == "message_metadata") {

                ChatHub.Send(Request["event"], Request["update_type"]);
            }
            else
            {
                Response.StatusCode = 400;
                // return Content("Unknown event");
            }

            return Json(result);
        }



    }
}