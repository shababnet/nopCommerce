using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Telerivet.Client;

namespace Nop.Web.Models.SimGate
{
    public partial class BaseTelerivetModel : BaseNopModel
    {
        public string TelerivetID { get; set; }
        public string ProjectId { get; set; }
        public string Name { get; set; }
    }

    public partial class RouteModel : BaseNopModel
    {
        public string TelerivetID { get; set; }
        public string ProjectId { get; set; }
        public string Name { get; set; }
    }


    public partial class MessageModel : BaseNopModel
    {
        public string TelerivetID { get; set; }
        public string ProjectId { get; set; }
        public object ContactId { get; set; }
        public string Content { get; set; }
        public string Direction { get; set; }
        public string ErrorMessage { get; set; }
        public string ExternalId { get; set; }
        public string FromNumber { get; set; }
        public string MessageType { get; set; }
        public string PhoneId { get; set; }
        public decimal? Price { get; set; }
        public bool Simulated { get; set; }
        public string Source { get; set; }
        public bool Starred { get; set; }
        public string Status { get; set; }
        public long? TimeCreated { get; set; }
        public long? TimeSent { get; set; }
        public string ToNumber { get; set; }
        public JArray LabelIds { get; set; }
        public CustomVars Vars { get; set; }
        public string PriceCurrency { get; set; }
        public JArray MmsParts { get; set; }
        public Nullable<long> RingTime { get; set; }

        // ring_time

    }


    public partial class GroupModel : BaseNopModel
    {
        public string TelerivetID { get; set; }
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public long? TimeCreated { get; set; }
        public bool Dynamic { get; set; }
        public int NumMembers { get; set; }
        public CustomVars Vars { get; set; }
    }


    public partial class ContactModel : BaseNopModel
    {
        public string TelerivetID { get; set; }
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public long? TimeCreated { get; set; }
        public CustomVars Vars { get; set; }
        public string PhoneNumber { get; set; }
        public long? LastMessageTime { get; set; }
        public string LastMessageId { get; set; }
        public string DefaultRouteId { get; set; }
        public JArray GroupIds { get; set; }
        public int MessageCount { get; set; }
        public long? LastIncomingMessageTime { get; set; }
        public long? LastOutgoingMessageTime { get; set; }
        public int IncomingMessageCount { get; set; }
        public int OutgoingMessageCount { get; set; }
        public bool SendBlocked { get; set; }
    }

    

}