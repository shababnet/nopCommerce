using System.Web.Mvc;
using Nop.Web.Framework.Security;
using Nop.Core;


namespace Nop.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        private readonly IWorkContext _workContext;



        public HomeController(IWorkContext workContext)
        {
            this._workContext = workContext;
        }

    }
}
