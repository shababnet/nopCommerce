using System.Web.Mvc;
using Nop.Web.Framework.Security;
using Nop.Core;


namespace Nop.Web.Controllers
{
    public partial class SimGateController : BasePublicController
    {
        private readonly IWorkContext _workContext;



        public SimGateController(IWorkContext workContext)
        {
            this._workContext = workContext;
        }

    }
}
