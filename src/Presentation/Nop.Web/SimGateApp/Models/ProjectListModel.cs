﻿using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Web.Models.SimGate
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


    public partial class ContactsListModel : BaseNopModel
    {
        public string GroupID { get; set; }
        public string SearchProjectId { get; set; }
        public IList<SelectListItem> AvailableProjects { get; set; }
        public string CurrentProjectName { get; set; }
    }
}