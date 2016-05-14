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
using Nop.Services.SimGateApp.Telerivet;
using Nop.Core.SimGateApp.Domain.Telerivet;

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

        private readonly ITelerivet_ProjectService _projectService;

        #endregion

        #region Ctor

        public SimGateController(IStoreContext storeContext,
            IOrderReportService orderReportService,
            IProductService productService,
            IPriceFormatter priceFormatter,

            ITelerivet_ProjectService ProjectService,


        CommonSettings commonSettings, 
            ISettingService settingService,
            IWorkContext workContext,
            ICacheManager cacheManager)
        {
            _storeContext = storeContext;
            _commonSettings = commonSettings;
            _settingService = settingService;
            _workContext = workContext;
            _cacheManager = new MemoryCacheManager();

            _orderReportService = orderReportService;
            _productService = productService;
            _priceFormatter = priceFormatter;

            _projectService = ProjectService;

            _telerivetAPI = new TelerivetAPI(apiKey);



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

        #region Projects
        public async Task<ActionResult> Projects()
        {
            return View(await PrepaerProjectListModel());
        }

        [HttpPost]
        public ActionResult Projects(DataSourceRequest command, ProjectListModel model)
        {
            SetCurrentProject(model);
            var localProjects = _projectService.GetAll();
            var gridModel = new DataSourceResult
            {
                Data = localProjects.Select(x =>
                {
                    var m = new ProjectModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        TimeZone = x.TimezoneId,
                        Contacts = x.Contacts,
                        Phones = x.Phones,
                        Messages = x.Messages,
                        Routes = x.Routes,
                        Receipts = x.Receipts,
                        Active = x.Active,
                        UserID = 0,
                        
                    };
                    return m;
                }),
                Total = localProjects.TotalCount
            };
            return Json(gridModel);
        }



        [HttpPost]
        public async Task<ActionResult> UpdateProjects(DataSourceRequest command, ProjectListModel model)
        {
            TelerivetAPI tr = new TelerivetAPI(apiKey);
            APICursor<Project> cursor = tr.QueryProjects();
            List<Project> projects = await cursor.AllAsync();
            foreach (Project project in projects)
            {
                Telerivet_Project remoteProject = new Telerivet_Project()
                {
                    TimezoneId = project.TimezoneId,
                    Name = project.Name,
                    TelerivetID = project.Id,
                    Active = true,
                    UserID = null,

                    Contacts = await project.QueryContacts().CountAsync(),
                    DataTables = await project.QueryDataTables().CountAsync(),
                    Groups = await project.QueryGroups().CountAsync(),
                    Labels = await project.QueryLabels().CountAsync(),
                    Messages = await project.QueryMessages().CountAsync(),
                    Phones = await project.QueryPhones().CountAsync(),
                    Receipts = await project.QueryReceipts().CountAsync(),
                    Routes = await project.QueryRoutes().CountAsync(),
                    ScheduledMessages = await project.QueryScheduledMessages().CountAsync(),
                    Services = await project.QueryServices().CountAsync(),

                };
                _projectService.InsertOrUpdate(remoteProject);

            }

            var gridModel = new
            {
                status = true,
            };
            return Json(gridModel);
        }




        public ActionResult Edit_Project(int id)
        {

            var item = _projectService.GetById(id);
            if (item == null)
                return RedirectToAction("List");

            var model = new ProjectModel();
            PrepareCustomerModel(model, item, false);

            return View(model);
        }


        [NonAction]
        //protected virtual void PrepareCustomerModel(ProjectModel model, Telerivet_Project customer, bool excludeProperties)
        //{
        //    var allStores = _storeService.GetAllStores();
        //    if (customer != null)
        //    {
        //        model.Id = customer.Id;
        //        if (!excludeProperties)
        //        {
        //            model.Email = customer.Email;
        //            model.Username = customer.Username;
        //            model.VendorId = customer.VendorId;
        //            model.AdminComment = customer.AdminComment;
        //            model.IsTaxExempt = customer.IsTaxExempt;
        //            model.Active = customer.Active;

        //            var affiliate = _affiliateService.GetAffiliateById(customer.AffiliateId);
        //            if (affiliate != null)
        //            {
        //                model.AffiliateId = affiliate.Id;
        //                model.AffiliateName = affiliate.GetFullName();
        //            }

        //            model.TimeZoneId = customer.GetAttribute<string>(SystemCustomerAttributeNames.TimeZoneId);
        //            model.VatNumber = customer.GetAttribute<string>(SystemCustomerAttributeNames.VatNumber);
        //            model.VatNumberStatusNote = ((VatNumberStatus)customer.GetAttribute<int>(SystemCustomerAttributeNames.VatNumberStatusId))
        //                .GetLocalizedEnum(_localizationService, _workContext);
        //            model.CreatedOn = _dateTimeHelper.ConvertToUserTime(customer.CreatedOnUtc, DateTimeKind.Utc);
        //            model.LastActivityDate = _dateTimeHelper.ConvertToUserTime(customer.LastActivityDateUtc, DateTimeKind.Utc);
        //            model.LastIpAddress = customer.LastIpAddress;
        //            model.LastVisitedPage = customer.GetAttribute<string>(SystemCustomerAttributeNames.LastVisitedPage);

        //            model.SelectedCustomerRoleIds = customer.CustomerRoles.Select(cr => cr.Id).ToArray();



        //            //form fields
        //            model.FirstName = customer.GetAttribute<string>(SystemCustomerAttributeNames.FirstName);
        //            model.LastName = customer.GetAttribute<string>(SystemCustomerAttributeNames.LastName);
        //            model.Gender = customer.GetAttribute<string>(SystemCustomerAttributeNames.Gender);
        //            model.DateOfBirth = customer.GetAttribute<DateTime?>(SystemCustomerAttributeNames.DateOfBirth);
        //            model.Company = customer.GetAttribute<string>(SystemCustomerAttributeNames.Company);
        //            model.StreetAddress = customer.GetAttribute<string>(SystemCustomerAttributeNames.StreetAddress);
        //            model.StreetAddress2 = customer.GetAttribute<string>(SystemCustomerAttributeNames.StreetAddress2);
        //            model.ZipPostalCode = customer.GetAttribute<string>(SystemCustomerAttributeNames.ZipPostalCode);
        //            model.City = customer.GetAttribute<string>(SystemCustomerAttributeNames.City);
        //            model.CountryId = customer.GetAttribute<int>(SystemCustomerAttributeNames.CountryId);
        //            model.StateProvinceId = customer.GetAttribute<int>(SystemCustomerAttributeNames.StateProvinceId);
        //            model.Phone = customer.GetAttribute<string>(SystemCustomerAttributeNames.Phone);
        //            model.Fax = customer.GetAttribute<string>(SystemCustomerAttributeNames.Fax);
        //        }
        //    }

        //    model.UsernamesEnabled = _customerSettings.UsernamesEnabled;
        //    model.AllowUsersToChangeUsernames = _customerSettings.AllowUsersToChangeUsernames;
        //    model.AllowCustomersToSetTimeZone = _dateTimeSettings.AllowCustomersToSetTimeZone;
        //    foreach (var tzi in _dateTimeHelper.GetSystemTimeZones())
        //        model.AvailableTimeZones.Add(new SelectListItem { Text = tzi.DisplayName, Value = tzi.Id, Selected = (tzi.Id == model.TimeZoneId) });
        //    if (customer != null)
        //    {
        //        model.DisplayVatNumber = _taxSettings.EuVatEnabled;
        //    }
        //    else
        //    {
        //        model.DisplayVatNumber = false;
        //    }

        //    //vendors
        //    PrepareVendorsModel(model);
        //    //customer attributes
        //    PrepareCustomerAttributeModel(model, customer);

        //    model.GenderEnabled = _customerSettings.GenderEnabled;
        //    model.DateOfBirthEnabled = _customerSettings.DateOfBirthEnabled;
        //    model.CompanyEnabled = _customerSettings.CompanyEnabled;
        //    model.StreetAddressEnabled = _customerSettings.StreetAddressEnabled;
        //    model.StreetAddress2Enabled = _customerSettings.StreetAddress2Enabled;
        //    model.ZipPostalCodeEnabled = _customerSettings.ZipPostalCodeEnabled;
        //    model.CityEnabled = _customerSettings.CityEnabled;
        //    model.CountryEnabled = _customerSettings.CountryEnabled;
        //    model.StateProvinceEnabled = _customerSettings.StateProvinceEnabled;
        //    model.PhoneEnabled = _customerSettings.PhoneEnabled;
        //    model.FaxEnabled = _customerSettings.FaxEnabled;


        //}



        #endregion











    }
}
