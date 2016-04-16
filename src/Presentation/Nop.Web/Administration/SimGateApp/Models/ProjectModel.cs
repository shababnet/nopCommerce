using Nop.Web.Framework.Mvc;

namespace Nop.Admin.Models.SimGate
{
    public partial class ProjectModel : BaseNopModel
    {
        public bool Active { get; set; }
        public int Contacts { get; set; }
        public int Messages { get; set; }
        public string Name { get; set; }
        public int Phones { get; set; }
        public int Receipts { get; set; }
        public int Routes { get; set; }
        public string TimeZone { get; set; }
        public int UserID { get; set; }
    }
}