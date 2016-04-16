using System;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;
using Nop.Admin.Infrastructure.Cache;
using Nop.Admin.Models.Home;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Common;
using Nop.Services.Configuration;
using Nop.Web.Framework.Kendoui;
using Telerivet.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Admin.Models.Orders;
using Nop.Services.Orders;
using System.Linq;
using Nop.Services.Catalog;
using Nop.Admin.Models.SimGate;
using Nop.Admin.Models.Catalog;

namespace Nop.Admin.Controllers
{
    public partial class SimGateController : BaseAdminController
    {
        #region Fields
        private readonly IStoreContext _storeContext;
        private readonly CommonSettings _commonSettings;
        private readonly ISettingService _settingService;
        private readonly IWorkContext _workContext;
        private readonly ICacheManager _cacheManager;

        private readonly IOrderReportService _orderReportService;
        private readonly IProductService _productService;
        private readonly IPriceFormatter _priceFormatter;


        private readonly TelerivetAPI _telerivetAPI;


        private String apiKey = "cF04TPqu3oFzetwgU03aPKuXeVFSlfbL";


        #endregion

        #region Ctor

        public SimGateController(IStoreContext storeContext,

            IOrderReportService orderReportService,
            IProductService productService,
            IPriceFormatter priceFormatter,


            CommonSettings commonSettings, 
            ISettingService settingService,
            IWorkContext workContext,
            ICacheManager cacheManager)
        {
            this._storeContext = storeContext;
            this._commonSettings = commonSettings;
            this._settingService = settingService;
            this._workContext = workContext;
            this._cacheManager= new MemoryCacheManager();

            this._orderReportService = orderReportService;
            this._productService = productService;
            this._priceFormatter = priceFormatter;

            this._telerivetAPI = new TelerivetAPI(apiKey);



        }

        #endregion

        #region PrivedMethods
        public void SetCurrentProject(ProjectListModel model)
        {

            if (_cacheManager.IsSet("currentProjectID"))
                _cacheManager.Remove("currentProjectID");

            if (_cacheManager.IsSet("currentProjectName"))
                _cacheManager.Remove("currentProjectName");

            _cacheManager.Set("currentProjectID", model.SearchProjectId, int.MaxValue);
            _cacheManager.Set("currentProjectName", model.CurrentProjectName, int.MaxValue);

        }

        public async Task<ProjectListModel> PrepaerProjectListModel()
        {

            APICursor<Project> cursor = _telerivetAPI.QueryProjects();
            List<Project> projects = await cursor.AllAsync();

            var model = new ProjectListModel();

            var currentProjectID = (_cacheManager.IsSet("currentProjectID")) ? _cacheManager.Get<string>("currentProjectID") : projects.First<Project>().Id;
            var currentProjectName = (_cacheManager.IsSet("currentProjectName")) ? _cacheManager.Get<string>("currentProjectName") : projects.First<Project>().Name;


            foreach (var s in projects)
                model.AvailableProjects.Add(new SelectListItem { Text = s.Name, Value = s.Id.ToString(), Selected = (s.Id == currentProjectID) ? true : false });

            model.SearchProjectId = currentProjectID;
            model.CurrentProjectName = currentProjectName;

            return model;
        }

        
        #endregion

        #region Methods
        // GET: SimGateAdmin
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Projects()
        {
            return View(await PrepaerProjectListModel());
        }
        public async Task<ActionResult> Phones()
        {
            return View(await PrepaerProjectListModel());
        }
        public async Task<ActionResult> Routes()
        {
            return View(await PrepaerProjectListModel());
        }
        public async Task<ActionResult> Messages()
        {
            return View(await PrepaerProjectListModel());
        }
        public async Task<ActionResult> Groups()
        {
            return View(await PrepaerProjectListModel());
        }
        public async Task<ActionResult> Contacts()
        {
            return View(await PrepaerProjectListModel());
        }
        public async Task<ActionResult> Services()
        {
            return View(await PrepaerProjectListModel());
        }

        [HttpPost]
        public async Task<ActionResult> Phones(DataSourceRequest command, ProjectListModel model)
        {
            SetCurrentProject(model);

            Project project = _telerivetAPI.InitProjectById(model.SearchProjectId);
            APICursor<Phone> cursor = project.QueryPhones();
            List<Phone> phones = await cursor.AllAsync();
            //var gridModel = GetBestsellersBriefReportModel(command.Page - 1,command.PageSize, 1);
            var gridModel = new DataSourceResult
            {
                Data = phones.Select(phone =>
                {
                    var m = new PhoneModel
                    {
                        TelerivetID = phone.Id,
                        Name = phone.Name,
                        PhoneNumber = phone.PhoneNumber,
                        PhoneType = phone.PhoneType,
                        Country = phone.Country,
                        TimeCreated = phone.TimeCreated,
                        LastActiveTime = phone.LastActiveTime,
                        ProjectId = phone.ProjectId,
                        Battery = phone.Battery,
                        Charging = phone.Charging,
                        AppVersion = phone.AppVersion,
                        AndroidSdk = phone.AndroidSdk,
                        Mccmnc = phone.Mccmnc,
                        Manufacturer = phone.Manufacturer,
                        Model = phone.Model,
                        SendLimit = phone.SendLimit,
                        SendPaused = phone.SendPaused,
                        InternetType = phone.InternetType
                    };
                    return m;
                }),
                Total = phones.Count
            };

            return Json(gridModel);
        }


        [HttpPost]
        public async Task<ActionResult> Projects(DataSourceRequest command, ProjectListModel model)
        {
            SetCurrentProject(model);

            TelerivetAPI tr = new TelerivetAPI(apiKey);
            APICursor<Project> cursor = tr.QueryProjects();
            List<Project> projects = await cursor.AllAsync();

            List<ProjectModel> projectsData = new List<ProjectModel>();

            int QueryPhones = 0;
            int QueryContacts = 0;

            int QueryMessages = 0;
            int QueryReceipts = 0;
            int QueryRoutes = 0;

            //int QueryScheduledMessages = 0;
            //int QueryServices = 0;
            //int QueryDataTables = 0;
            //int QueryGroups = 0;
            //int QueryLabels = 0;

            foreach (Project project in projects)
            {
                // int QueryPhones = await project.QueryPhones().CountAsync();
                // int QueryContacts = await project.QueryContacts().CountAsync();
                // int QueryDataTables = await project.QueryDataTables().CountAsync();
                // int QueryGroups = await project.QueryGroups().CountAsync();
                // int QueryLabels = await project.QueryLabels().CountAsync();
                // int QueryMessages = await project.QueryMessages().CountAsync();
                // int QueryReceipts = await project.QueryReceipts().CountAsync();
                // int QueryRoutes = await project.QueryRoutes().CountAsync();
                // int QueryScheduledMessages = await project.QueryScheduledMessages().CountAsync();
                // int QueryServices = await project.QueryServices().CountAsync();

                projectsData.Add(new ProjectModel
                {
                    Name = project.Name,
                    TimeZone = project.TimezoneId,
                    Contacts = QueryContacts,
                    Phones = QueryPhones,
                    Messages = QueryMessages,
                    Routes = QueryRoutes,
                    Receipts = QueryReceipts,
                    Active = true,
                    UserID = 1
                });

            }

            //var gridModel = GetBestsellersBriefReportModel(command.Page - 1,command.PageSize, 1);
            var gridModel = new DataSourceResult
            {
                Data = projectsData.Select(x =>
               {
                   var m = new ProjectModel
                   {
                       Name = x.Name,
                       TimeZone = x.TimeZone,
                       Contacts = x.Contacts,
                       Phones = x.Phones,
                       Messages = x.Messages,
                       Routes = x.Routes,
                       Receipts = x.Receipts,
                       Active = true,
                       UserID = 1
                   };
                   return m;
               }),
                Total = projects.Count
            };

            return Json(gridModel);
        }

        [HttpPost]
        public async Task<ActionResult> Routes(DataSourceRequest command, ProjectListModel model)
        {
            SetCurrentProject(model);
            Project project = _telerivetAPI.InitProjectById(model.SearchProjectId);
            APICursor<Route> cursor = project.QueryRoutes();
            List<Route> routes = await cursor.AllAsync();

            var gridModel = new DataSourceResult
            {
                Data = routes.Select(phone =>
                {
                    var m = new RouteModel
                    {
                        TelerivetID = phone.Id,
                        Name = phone.Name,
                        ProjectId = phone.ProjectId
                    };
                    return m;
                }),
                Total = routes.Count
            };

            return Json(gridModel);
        }



        [HttpPost]
        public async Task<ActionResult> Messages(DataSourceRequest command, ProjectListModel model)
        {
            SetCurrentProject(model);
            int offset = (command.Page - 1) * command.PageSize;

            Project project = _telerivetAPI.InitProjectById(model.SearchProjectId);
            APICursor<Message> cursor = project.QueryMessages(Util.Options(
    "page_size", command.PageSize,
    "offset", offset,
    "sort_dir", "desc"
));

            int total = await cursor.CountAsync();
            List<Message> messages = await cursor.Limit(command.PageSize).AllAsync();

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
                    };
                    return m;
                }),
                Total = total,
            };

            return Json(gridModel);
        }


        [HttpPost]
        public async Task<ActionResult> Groups(DataSourceRequest command, ProjectListModel model)
        {
            SetCurrentProject(model);
            int offset = (command.Page - 1) * command.PageSize;

            Project project = _telerivetAPI.InitProjectById(model.SearchProjectId);
            APICursor<Group> cursor = project.QueryGroups(Util.Options("page_size", command.PageSize, "offset", offset, "sort_dir", "desc"));

            int total = await cursor.CountAsync();
            List<Group> groups = await cursor.Limit(command.PageSize).AllAsync();

            var gridModel = new DataSourceResult
            {
                Data = groups.Select(group =>
                {
                    var m = new GroupModel
                    {
                        TelerivetID = group.Id,
                        ProjectId = group.ProjectId,
                        Name = group.Name,
                        Dynamic = group.Dynamic,
                        NumMembers = group.NumMembers,
                        TimeCreated = group.TimeCreated,
                        Vars = group.Vars,
                    };
                    return m;
                }),
                Total = total,
            };
            return Json(gridModel);
        }

        [HttpPost]
        public async Task<ActionResult> Contacts(DataSourceRequest command, ProjectListModel model)
        {
            SetCurrentProject(model);
            int offset = (command.Page - 1) * command.PageSize;

            Project project = _telerivetAPI.InitProjectById(model.SearchProjectId);
            APICursor<Contact> cursor = project.QueryContacts(Util.Options("page_size", command.PageSize, "offset", offset, "sort_dir", "asc", "sort", "phone_number"));

            int total = await cursor.CountAsync();
            List<Contact> contacts = await cursor.Limit(command.PageSize).AllAsync();

            var gridModel = new DataSourceResult
            {
                Data = contacts.Select(contact =>
                {
                    var m = new ContactModel
                    {
                        TelerivetID = contact.Id,
                        ProjectId = contact.ProjectId,
                        Name = contact.Name,
                        Vars = contact.Vars,
                        PhoneNumber = contact.PhoneNumber,
                        LastMessageTime = contact.LastMessageTime,
                        LastMessageId = contact.LastMessageId,
                        DefaultRouteId = contact.DefaultRouteId,
                        GroupIds = contact.GroupIds,
                        TimeCreated = contact.TimeCreated,
                        MessageCount = contact.MessageCount,
                        LastIncomingMessageTime = contact.LastIncomingMessageTime,
                        LastOutgoingMessageTime = contact.LastOutgoingMessageTime,
                        IncomingMessageCount = contact.IncomingMessageCount,
                        OutgoingMessageCount = contact.OutgoingMessageCount,
                        SendBlocked = contact.SendBlocked,
                    };
                    return m;
                }),
                Total = total,
            };
            return Json(gridModel);
        }
        #endregion
    }
}
