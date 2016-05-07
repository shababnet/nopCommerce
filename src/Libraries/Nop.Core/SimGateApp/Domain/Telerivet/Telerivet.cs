using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.SimGateApp.Domain.Telerivet
{
    public partial class Telerivet : BaseEntity
    {
    }
    public partial class Telerivet_Route : BaseEntity
    {
        public Telerivet_Route()
        {
        }
        public string TelerivetID { get; set; }

        public string Name { get; set; }

        public string ProjectId { get; set; }
    }

    public partial class Telerivet_Message : BaseEntity
    {
        public Telerivet_Message()
        {
        }

        public string TelerivetID { get; set; }

        public string Direction { get; set; }

        public string Status { get; set; }

        public string MessageType { get; set; }

        public string Source { get; set; }

        public System.Nullable<long> TimeCreated { get; set; }

        public System.Nullable<long> TimeSent { get; set; }

        public string FromNumber { get; set; }

        public string ToNumber { get; set; }

        public string Content { get; set; }

        public System.Nullable<bool> Starred { get; set; }

        public bool Simulated { get; set; }

        public string ErrorMessage { get; set; }

        public string ExternalId { get; set; }

        public System.Nullable<decimal> Price { get; set; }

        public string PriceCurrency { get; set; }

        public string PhoneId { get; set; }

        public string ContactId { get; set; }

        public string ProjectId { get; set; }

    }

    public partial class Telerivet_Project : BaseEntity
    {
        public Telerivet_Project()
        {
        }
        public string TelerivetID { get; set; }

        public string Name { get; set; }

        public string TimezoneId { get; set; }

        public bool Active { get; set; }

        public System.Nullable<System.Guid> UserID { get; set; }

        public int Phones { get; set; }

        public int Contacts { get; set; }

        public int DataTables { get; set; }

        public int Groups { get; set; }

        public int Labels { get; set; }

        public int Messages { get; set; }

        public int Receipts { get; set; }

        public int Routes { get; set; }

        public int ScheduledMessages { get; set; }

        public int Services { get; set; }
    }

    public partial class Telerivet_Phone : BaseEntity
    {
        public Telerivet_Phone()
        {
        }

        public string TelerivetID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneType { get; set; }

        public string Country { get; set; }

        public System.Nullable<long> TimeCreated { get; set; }

        public System.Nullable<long> LastActiveTime { get; set; }

        public string ProjectId { get; set; }

        public System.Nullable<int> Battery { get; set; }

        public System.Nullable<bool> Charging { get; set; }

        public string AppVersion { get; set; }

        public System.Nullable<int> AndroidSdk { get; set; }

        public string Mccmnc { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public System.Nullable<int> SendLimit { get; set; }

        public int Messages { get; set; }
    }

    public partial class Telerivet_Group : BaseEntity
    {
        public Telerivet_Group()
        {
        }

        public string TelerivetID { get; set; }

        public string Name { get; set; }

        public int NumMembers { get; set; }

        public string ProjectId { get; set; }

        public long TimeCreated { get; set; }

        public int Contacts { get; set; }

        public int ScheduledMessages { get; set; }

    }

     public partial class Telerivet_Contact : BaseEntity
    {
        public Telerivet_Contact()
        {
        }

        public string TelerivetID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public long TimeCreated { get; set; }

        public System.Nullable<long> LastMessageTime { get; set; }

        public string LastMessageId { get; set; }

        public string DefaultRouteId { get; set; }

        public string GroupIds { get; set; }

        public string ProjectId { get; set; }
        public int Messages { get; set; }

        public int Groups { get; set; }

        public int ScheduledMessages { get; set; }

        public int DataRows { get; set; }

        public int ServiceStates { get; set; }
    }




    public partial class Telerivet_Messages_By_Day : BaseEntity
    {
        public Telerivet_Messages_By_Day()
        {
        }
        public string ProjectId { get; set; }

        public System.Nullable<long> TimeCreated { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }


        public int Incoming { get; set; }
        public int Outgoing { get; set; }
        public int Total { get; set; }

    }

}
