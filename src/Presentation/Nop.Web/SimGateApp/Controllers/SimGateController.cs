using System.Web.Mvc;
using Nop.Web.Framework.Security;
using Nop.Core;
using System.Threading.Tasks;
using Telerivet.Client;
using System.Collections.Generic;
using Nop.Web.Framework.Kendoui;
using System.Linq;
using Nop.Web.Models.SimGate;

namespace Nop.Web.Controllers
{
    public partial class SimGateController : BasePublicController
    {
        private readonly IWorkContext _workContext;

        private readonly TelerivetAPI _telerivetAPI;
        private string apiKey = "cF04TPqu3oFzetwgU03aPKuXeVFSlfbL";
        private string telerivetProjectID = "PJ9574c5ee610de89b";







        public SimGateController(IWorkContext workContext)
        {
            this._workContext = workContext;
            this._telerivetAPI = new TelerivetAPI(apiKey);

        }




        // GET: SimGate/Messages
        public async Task<ActionResult> Messages()
        {
            if (!_workContext.CurrentCustomer.IsRegistered())
                return new HttpUnauthorizedResult();





            // SetCurrentProject(model);

            int offset = (1 - 1) * 30;

            Project project = _telerivetAPI.InitProjectById(telerivetProjectID);
            APICursor<Message> cursor = project.QueryMessages(Util.Options("page_size", 30, "offset", offset, "sort_dir", "desc"));

            int total = await cursor.CountAsync();
            List<Message> messages = await cursor.Limit(30).AllAsync();

            var gridModel = new DataSourceResult
            {
                Data = messages.Select(message =>
                {
                    var m = new MessageModel
                    {
                        TelerivetID = message.Id,
                        ProjectId = message.ProjectId,
                        ContactId = message.ContactId,
                        Content = message.Content,
                        Direction = message.Direction,
                        ErrorMessage = message.ErrorMessage,
                        ExternalId = message.ExternalId,
                        FromNumber = message.FromNumber,
                        MessageType = message.MessageType,
                        PhoneId = message.PhoneId,
                        Price = message.Price,
                        Simulated = message.Simulated,
                        Source = message.Source,
                        Starred = message.Starred,
                        Status = message.Status,
                        TimeCreated = message.TimeCreated,
                        TimeSent = message.TimeSent,
                        ToNumber = message.ToNumber,
                        LabelIds = message.LabelIds,
                        MmsParts = message.MmsParts,
                        PriceCurrency = message.PriceCurrency,
                        Vars = message.Vars,
                        RingTime = message.RingTime
                    };
                    return m;
                }),
                Total = total,
            };

           // return Json(gridModel);




            return View(gridModel);
        }


    }
}
