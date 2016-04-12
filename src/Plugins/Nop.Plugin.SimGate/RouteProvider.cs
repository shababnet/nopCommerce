using Nop.Web.Framework.Mvc.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nop.Plugin.SimGate
{
    //public partial class RouteProvider : IRouteProvider
    //{

    //    public void RegisterRoutes(RouteCollection routes)
    //    {
    //        List<Route> Routes = new List<Route>();
    //        //Index
    //        Routes.Add(
    //            routes.MapRoute("Plugin.SimGate.Admin.Index",
    //             "Admin/SimGate/Index",
    //             new { controller = "SimGateAdmin", action = "Index" },
    //             new[] { "Nop.Plugin.SimGate.Controllers" }
    //        ));


    //        //Projects
    //        Routes.Add(
    //        routes.MapRoute("Plugin.SimGate.Admin.Projects",
    //             "Admin/SimGate/Projects",
    //             new { controller = "SimGateAdmin", action = "Projects" },
    //             new[] { "Nop.Plugin.SimGate.Controllers" }
    //        ));


    //        //Phones
    //        Routes.Add(
    //            routes.MapRoute("Plugin.SimGate.Admin.Phones",
    //             "Admin/SimGate/Phones",
    //             new { controller = "SimGateAdmin", action = "Phones", area = "Admin" },
    //             new[] { "Nop.Plugin.SimGate.Controllers" }
    //        ));



    //        //Routes
    //        Routes.Add(
    //        routes.MapRoute("Plugin.SimGate.Admin.Routes",
    //             "Admin/SimGate/Routes",
    //             new { controller = "SimGateAdmin", action = "Routes" },
    //             new[] { "Nop.Plugin.SimGate.Controllers" }
    //        ));
    //        //Messages
    //        Routes.Add(
    //        routes.MapRoute("Plugin.SimGate.Admin.Messages",
    //             "Admin/SimGate/Messages",
    //             new { controller = "SimGateAdmin", action = "Messages" },
    //             new[] { "Nop.Plugin.SimGate.Controllers" }
    //        ));
    //        //Groups
    //        Routes.Add(
    //        routes.MapRoute("Plugin.SimGate.Admin.Groups",
    //             "Admin/SimGate/Groups",
    //             new { controller = "SimGateAdmin", action = "Groups" },
    //             new[] { "Nop.Plugin.SimGate.Controllers" }
    //        ));
    //        //Contacts
    //        Routes.Add(
    //        routes.MapRoute("Plugin.SimGate.Admin.Contacts",
    //             "Admin/SimGate/Contacts",
    //             new { controller = "SimGateAdmin", action = "Contacts" },
    //             new[] { "Nop.Plugin.SimGate.Controllers" }
    //        ));
    //        //Services
    //        Routes.Add(
    //        routes.MapRoute("Plugin.SimGate.Admin.Services",
    //             "Admin/SimGate/Services",
    //             new { controller = "SimGateAdmin", action = "Services" },
    //             new[] { "Nop.Plugin.SimGate.Controllers" }
    //        ));

    //        foreach (var  routeItem in Routes)
    //        {
    //            routeItem.DataTokens.Add("area", "admin");
    //            routes.Remove(routeItem);
    //            routes.Insert(0, routeItem);
    //        }
    //    }

    //    public int Priority
    //    {
    //        get
    //        {
    //            return 1;
    //        }
    //    }




    //}
}