using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Admin.Models.Catalog
{
    public partial class ProjectListModel : BaseNopModel
    {
        public ProjectListModel()
        {
            AvailableProjects = new List<SelectListItem>();
        }


        [NopResourceDisplayName("ProjectId")]
        public string SearchProjectId { get; set; }
        public IList<SelectListItem> AvailableProjects { get; set; }
        public string CurrentProjectName { get; set; }
    }
}