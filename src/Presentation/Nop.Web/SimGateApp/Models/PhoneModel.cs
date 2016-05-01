using Nop.Web.Framework.Mvc;
using System;

namespace Nop.Web.Models.SimGate
{
    public partial class PhoneModel : BaseNopModel
    {
        public string TelerivetID { get; set; }
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
        public string Country { get; set; }
        public long TimeCreated { get; set; }
        public long? LastActiveTime { get; set; }
        public int? Battery { get; set; }
        public bool? Charging { get; set; }
        public string AppVersion { get; set; }
        public int? AndroidSdk { get; set; }
        public string Mccmnc { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int? SendLimit { get; set; }
        public bool? SendPaused { get; set; }
        public string InternetType { get; set; }

    }
}