using System.Web.Mvc;
using Nop.Web.Framework.Security;
using Nop.Core;
using System.Threading.Tasks;
using Telerivet.Client;
using System.Collections.Generic;
using Nop.Web.Framework.Kendoui;
using System.Linq;
using Nop.Web.Models.SimGate;
using Newtonsoft.Json.Linq;
using System;
using Nop.Core.SimGateApp.Domain.Telerivet;
using Nop.Services.SimGateApp.Telerivet;
using Newtonsoft.Json;
using System.Globalization;
using Nop.Services.Common;
using Nop.Core.Domain.Customers;

namespace Nop.Web.Controllers
{
    public partial class SimGateController : BasePublicController
    {
        private readonly IWorkContext _workContext;
        private readonly ITelerivet_Messages_By_DayService _messages_By_Day;

        private readonly TelerivetAPI _telerivetAPI;
        private string apiKey = "cF04TPqu3oFzetwgU03aPKuXeVFSlfbL";
        private string telerivetProjectID = "PJ4143ee057fd74589";

        private Dictionary<string,string> MccMnc = new Dictionary<string, string>();


        string MyDictionaryToJson(Dictionary<int, string> dict)
        {
            var entries = dict.Select(d => string.Format("[{0}, \"{1}\"]", d.Key, d.Value));
            return "[" + string.Join(",", entries) + "]";
        }


        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        public SimGateController(IWorkContext workContext, ITelerivet_Messages_By_DayService Messages_By_Day)
        {
            _workContext = workContext;
            _messages_By_Day = Messages_By_Day;
            _telerivetAPI = new TelerivetAPI(apiKey);
            MccMnc.Add("41904", "Viva");
            MccMnc.Add("41903", "Wataniya");
            MccMnc.Add("41902", "Zain KW");
        }

        [HttpPost]
        public async Task<ActionResult> DashbordData()
        {
            if (!_workContext.CurrentCustomer.IsRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;
            telerivetProjectID = customer.GetAttribute<string>(SystemCustomerAttributeNames.TelerivetProjectID);

            Project project = _telerivetAPI.InitProjectById(telerivetProjectID);


            var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, DateTimeKind.Local);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var unixDateTime = (dateTime.ToUniversalTime() - epoch).TotalSeconds;


            int totalIncomingMessages = await project.QueryMessages(Util.Options("direction", "incoming", "time_created[min]", unixDateTime)).CountAsync();
            int totalOutgoingMessages = await project.QueryMessages(Util.Options("direction", "outgoing", "time_created[min]", unixDateTime)).CountAsync();

            //int totalActiveContactToday = await project.QueryContacts(Util.Options("last_message_time[min]", unixDateTime)).CountAsync();
            //int totalProjectContacts = await project.QueryContacts().CountAsync();

            Telerivet_Messages_By_Day messageByDay = new Telerivet_Messages_By_Day();
            messageByDay.TimeCreated = long.Parse(unixDateTime.ToString());
            messageByDay.ProjectId = project.Id;
            messageByDay.Year = dateTime.Year;
            messageByDay.Month = dateTime.Month;
            messageByDay.Day = dateTime.Day;
            messageByDay.Incoming = totalIncomingMessages;
            messageByDay.Outgoing = totalOutgoingMessages;
            messageByDay.Total = totalIncomingMessages + totalOutgoingMessages;
            _messages_By_Day.InsertOrUpdate(messageByDay);





            IList<Telerivet_Messages_By_Day> messagesStuts = _messages_By_Day.GetCountByProjectId(project.Id, 14).Reverse<Telerivet_Messages_By_Day>().ToList();
            var gridModel = new
            {
                Data = new[] { new { label="Incoming", data = messagesStuts.Select(x=>new int[]{int.Parse(x.TimeCreated.ToString()), x.Incoming })}, new { label="Outgoing", data = messagesStuts.Select(x=>new int[]{ int.Parse(x.TimeCreated.ToString()), x.Outgoing })}},
                ticks = MyDictionaryToJson(messagesStuts.ToDictionary(kvp => int.Parse(kvp.TimeCreated.ToString()), kvp => UnixTimeStampToDateTime((double)kvp.TimeCreated).ToString("m", CultureInfo.InvariantCulture))),
                totalIncomingMessages = await project.QueryMessages(Util.Options("direction", "incoming", "time_created[min]", unixDateTime)).CountAsync(),
                totalOutgoingMessages = await project.QueryMessages(Util.Options("direction", "outgoing", "time_created[min]", unixDateTime)).CountAsync(),
                totalActiveContactToday = await project.QueryContacts(Util.Options("last_message_time[min]", unixDateTime)).CountAsync(),
                totalProjectContacts = await project.QueryContacts().CountAsync()
            };



            return Json(gridModel);
        }

        public async Task<ActionResult> Index()
        {
            if (!_workContext.CurrentCustomer.IsRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;
            telerivetProjectID = customer.GetAttribute<string>(SystemCustomerAttributeNames.TelerivetProjectID);

            //var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, DateTimeKind.Local);
            //var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //var unixDateTime = (dateTime.ToUniversalTime() - epoch).TotalSeconds;
            //Project project = _telerivetAPI.InitProjectById(telerivetProjectID);


            //var startDay = new DateTime(2016, 5, 7, 0, 0, 0, DateTimeKind.Local);
            //for (int i = 0; i < 4; i++)
            //{
            //    var currentDate = startDay.AddDays(i);
            //    var nextDate = currentDate.AddDays(1);
            //    var currentUnixDateTime = (currentDate.ToUniversalTime() - epoch).TotalSeconds;
            //    var nextUnixDateTime = (nextDate.ToUniversalTime() - epoch).TotalSeconds;
            //    int IncomingMessages = await project.QueryMessages(Util.Options("direction", "incoming", "time_created[min]", currentUnixDateTime, "time_created[max]", nextUnixDateTime)).CountAsync();
            //    int OutgoingMessages = await project.QueryMessages(Util.Options("direction", "outgoing", "time_created[min]", currentUnixDateTime, "time_created[max]", nextUnixDateTime)).CountAsync();
            //    Telerivet_Messages_By_Day messageByDay = new Telerivet_Messages_By_Day();
            //    messageByDay.TimeCreated = long.Parse(currentUnixDateTime.ToString());
            //    messageByDay.ProjectId = project.Id;
            //    messageByDay.Year = currentDate.Year;
            //    messageByDay.Month = currentDate.Month;
            //    messageByDay.Day = currentDate.Day;
            //    messageByDay.Incoming = IncomingMessages;
            //    messageByDay.Outgoing = OutgoingMessages;
            //    messageByDay.Total = IncomingMessages + OutgoingMessages;
            //    _messages_By_Day.InsertOrUpdate(messageByDay);
            //}



            //int totalIncomingMessages = await project.QueryMessages(Util.Options("direction", "incoming", "time_created[min]", unixDateTime)).CountAsync();
            //int totalOutgoingMessages = await project.QueryMessages(Util.Options("direction", "outgoing", "time_created[min]", unixDateTime)).CountAsync();

            //int totalActiveContactToday = await project.QueryContacts(Util.Options("last_message_time[min]", unixDateTime)).CountAsync();
            //int totalProjectContacts = await project.QueryContacts().CountAsync();


            //IList<Telerivet_Messages_By_Day> messagesStuts = _messages_By_Day.GetCountByProjectId(project.Id, 14);
            //messagesStuts.Reverse();

            // List<Message> fmessage = await project.QueryMessages(Util.Options("sort_dir", "asc")).AllAsync();

            //int offset = (1 - 1) * 30;



            //time_created[min]
            //UNIX timestamp, optional
            //Filter messages created on or after a particular time
            //time_created[max]
            //UNIX timestamp, optional
            //Filter messages created before a particular time


            //var dateTime = new DateTime(2015, 05, 24, 10, 2, 0, DateTimeKind.Local);
            //var dateTimeOffset = new DateTimeOffset(dateTime);
            //var unixDateTime = dateTimeOffset.ToUnixTimeSeconds();




            //JObject Options = new JObject();
            //Options.Add("page_size", 30);
            //Options.Add("offset", offset);
            //Options.Add("sort_dir", "desc");
            //Options.Add("time_created[min]", unixDateTime);
            //Options.Add("direction", "incoming");
            ////Options.Add("direction", "outgoing");
            //APICursor<Message> cursor = project.QueryMessages(Options);
            //int total = await cursor.CountAsync();
            //List<Message> messages = await cursor.Limit(30).AllAsync();
            //var gridModel = new DataSourceResult
            //{
            //    Data = messages.Select(message =>
            //    {
            //        var m = new MessageModel
            //        {
            //            TelerivetID = message.Id,
            //            ProjectId = message.ProjectId,
            //            ContactId = message.ContactId,
            //            Content = message.Content,
            //            Direction = message.Direction,
            //            ErrorMessage = message.ErrorMessage,
            //            ExternalId = message.ExternalId,
            //            FromNumber = message.FromNumber,
            //            MessageType = message.MessageType,
            //            PhoneId = message.PhoneId,
            //            Price = message.Price,
            //            Simulated = message.Simulated,
            //            Source = message.Source,
            //            Starred = message.Starred,
            //            Status = message.Status,
            //            TimeCreated = message.TimeCreated,
            //            TimeSent = message.TimeSent,
            //            ToNumber = message.ToNumber,
            //            LabelIds = message.LabelIds,
            //            MmsParts = message.MmsParts,
            //            PriceCurrency = message.PriceCurrency,
            //            Vars = message.Vars,
            //            RingTime = message.RingTime
            //        };
            //        return m;
            //    }),
            //    Total = total,
            //};
            //return View(gridModel);

            return View();
        }

        // GET: SimGate/Messages
        public async Task<ActionResult> Messages()
        {
            if (!_workContext.CurrentCustomer.IsRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;
            telerivetProjectID = customer.GetAttribute<string>(SystemCustomerAttributeNames.TelerivetProjectID);

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
            return View(gridModel);
        }

        public async Task<ActionResult> Phones()
        {
            if (!_workContext.CurrentCustomer.IsRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;
            telerivetProjectID = customer.GetAttribute<string>(SystemCustomerAttributeNames.TelerivetProjectID);


            var unixDateTime = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;



            int offset = (1 - 1) * 30;
            Project project = _telerivetAPI.InitProjectById(telerivetProjectID);
            APICursor<Phone> cursor = project.QueryPhones(Util.Options("page_size", 30, "offset", offset, "sort_dir", "desc"));

            int total = await cursor.CountAsync();
            List<Phone> phones = await cursor.Limit(30).AllAsync();

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
                        Mccmnc = MccMnc[phone.Mccmnc],
                        Manufacturer = phone.Manufacturer,
                        Model = phone.Model,
                        SendLimit = phone.SendLimit,
                        SendPaused = phone.SendPaused,
                        InternetType = phone.InternetType,
                        LastActiveDateTime = UnixTimeStampToDateTime((double)phone.LastActiveTime),
                        LastActiveSince = ((unixDateTime - phone.LastActiveTime) / 60),

                    };
                    return m;
                }),
                Total = total,
            };
            return View(gridModel);
        }

        public async Task<ActionResult> Routes()
        {
            if (!_workContext.CurrentCustomer.IsRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;
            telerivetProjectID = customer.GetAttribute<string>(SystemCustomerAttributeNames.TelerivetProjectID);


            int offset = (1 - 1) * 30;
            Project project = _telerivetAPI.InitProjectById(telerivetProjectID);
            APICursor<Route> cursor = project.QueryRoutes(Util.Options("page_size", 30, "offset", offset, "sort_dir", "desc"));

            int total = await cursor.CountAsync();
            List<Route> routes = await cursor.Limit(30).AllAsync();

            var gridModel = new DataSourceResult
            {
                Data = routes.Select(route =>
                {
                    var m = new RouteModel
                    {
                        TelerivetID = route.Id,
                        Name = route.Name,
                        ProjectId = route.ProjectId,
                    };
                    return m;
                }),
                Total = total,
            };
            return View(gridModel);
        }


        #region Contacts
        public async Task<ActionResult> Contacts()
        {
            if (!_workContext.CurrentCustomer.IsRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;
            telerivetProjectID = customer.GetAttribute<string>(SystemCustomerAttributeNames.TelerivetProjectID);

            Project project = _telerivetAPI.InitProjectById(telerivetProjectID);
            APICursor<Group> groupCursor = project.QueryGroups();
            List<Group> groups = await groupCursor.AllAsync();




            int offset = (1 - 1) * 30;
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
                ExtraData = groups.Select(group =>
                {
                    var g = new GroupModel
                    {
                        TelerivetID = group.Id,
                        ProjectId = group.ProjectId,
                        Name = group.Name,
                        TimeCreated = group.TimeCreated,
                        Dynamic = group.Dynamic,
                        NumMembers = group.NumMembers,
                        Vars = group.Vars,

                    };
                    return g;
                }).ToList<GroupModel>(),
            };
            return View(gridModel);
        }



        [HttpPost]
        public async Task<ActionResult> Contacts(DataSourceRequest command, ContactsListModel model)
        {

            if (!_workContext.CurrentCustomer.IsRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;
            telerivetProjectID = customer.GetAttribute<string>(SystemCustomerAttributeNames.TelerivetProjectID);


            APICursor<Contact> cursor;

            int offset = (command.Page - 1) * command.PageSize;

            Project project = _telerivetAPI.InitProjectById(telerivetProjectID);

            JObject Options = new JObject();
            Options.Add("page_size", command.PageSize);
            Options.Add("offset", offset);
            Options.Add("sort_dir", "asc");
            Options.Add("sort", "phone_number");

            if (!string.IsNullOrEmpty(model.GroupID))
            {
                Group group = project.InitGroupById(model.GroupID);
                cursor = group.QueryContacts(Options);

            }
            else
            {

                cursor = project.QueryContacts(Options);

            }



            ////From Windows application
            //MessageQueue messageQueue = new MessageQueue(@".\Private$\SomeTestName");
            //System.Messaging.Message[] messages = messageQueue.GetAllMessages();
            //foreach (System.Messaging.Message message in messages)
            //{
            //    //Do something with the message.
            //}
            //// after all processing, delete all the messages
            //messageQueue.Purge();



            // APICursor<Contact> cursor = project.QueryContacts(Options);

            int total = await cursor.CountAsync();
            List<Contact> contacts = await cursor.Limit(command.PageSize).AllAsync();

            var gridModel = new DataSourceResult
            {
                Data = contacts.Select(contact =>
                {
                    var m = new ContactModel
                    {
                        Id = 1,
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



        public async Task<ActionResult> AddNewGroup(string GroupName) {

            if (!_workContext.CurrentCustomer.IsRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;
            telerivetProjectID = customer.GetAttribute<string>(SystemCustomerAttributeNames.TelerivetProjectID);

            Project project = _telerivetAPI.InitProjectById(telerivetProjectID);
            Group telerivetGroup = await project.GetOrCreateGroupAsync(GroupName);



            var gridModel = new
            {
                TelerivetID = telerivetGroup.Id,
                Name = telerivetGroup.Name,
                NumMembers = telerivetGroup.NumMembers,
                TimeCreated = telerivetGroup.TimeCreated,
                Dynamic = telerivetGroup.Dynamic,
            };
            return Json(gridModel);
        }

        #endregion Contacts



        [HttpPost]
        public async Task<ActionResult> Phones(DataSourceRequest command, ProjectListModel model)
        {
            if (!_workContext.CurrentCustomer.IsRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;
            telerivetProjectID = customer.GetAttribute<string>(SystemCustomerAttributeNames.TelerivetProjectID);


            Project project = _telerivetAPI.InitProjectById(telerivetProjectID);
            APICursor<Phone> cursor = project.QueryPhones();
            List<Phone> phones = await cursor.AllAsync();

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







    }
}
