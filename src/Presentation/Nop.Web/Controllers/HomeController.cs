using System.Web.Mvc;
using Nop.Web.Framework.Security;
using Nop.Core.Domain.Customers;




namespace Nop.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        [NopHttpsRequirement(SslRequirement.No)]
        public ActionResult Index()
        {
            if (!_workContext.CurrentCustomer.IsRegistered())
                return new HttpUnauthorizedResult();

            return View();
        }
    }
}
