using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Web.Infrastructure
{
    public partial class SimGateRouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            //home page
            routes.MapLocalizedRoute("SimGate",
                            "SimGate",
                            new { controller = "SimGate", action = "Index" },
                            new[] { "Nop.Web.Controllers" });
        }

        public int Priority
        {
            get
            {
                return 1;
            }
        }
    }
}
