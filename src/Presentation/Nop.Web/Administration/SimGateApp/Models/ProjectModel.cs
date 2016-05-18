using Nop.Web.Framework.Mvc;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Nop.Admin.Models.SimGate
{
    public partial class ProjectModel : BaseNopModel
    {

        public ProjectModel()
        {
            this.AvailableCustomers = new List<SelectListItem>();

        }
        public bool Active { get; set; }
        public int Contacts { get; set; }
        public int Messages { get; set; }
        public string Name { get; set; }
        public int Phones { get; set; }
        public int Receipts { get; set; }
        public int Routes { get; set; }
        public string TimeZone { get; set; }
        public int UserID { get; set; }
        public int Id { get; set; }
        public string TelerivetID { get; set; }


        public IList<SelectListItem> AvailableCustomers { get; set; }

    }
}