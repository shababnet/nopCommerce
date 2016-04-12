using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Plugin.SimGate.Controllers
{
    public class SimGateAdminController : Controller
    {
        // GET: SimGateAdmin
        public ActionResult Index()
        {
            return View("~/Plugins/SimGate/Views/SimGateAdmin/Index.cshtml");
        }
        public ActionResult Projects()
        {
            return View("~/Plugins/SimGate/Views/SimGateAdmin/Projects.cshtml");
        }
        public ActionResult Phones()
        {
            return View("~/Plugins/SimGate/Views/SimGateAdmin/Phones.cshtml");
        }
        public ActionResult Routes()
        {
            return View("~/Plugins/SimGate/Views/SimGateAdmin/Routes.cshtml");
        }
        public ActionResult Messages()
        {
            return View("~/Plugins/SimGate/Views/SimGateAdmin/Messages.cshtml");
        }
        public ActionResult Groups()
        {
            return View("~/Plugins/SimGate/Views/SimGateAdmin/Groups.cshtml");
        }
        public ActionResult Contacts()
        {
            return View("~/Plugins/SimGate/Views/SimGateAdmin/Contacts.cshtml");
        }
        public ActionResult Services()
        {
            return View("~/Plugins/SimGate/Views/SimGateAdmin/Services.cshtml");
        }







    }
}