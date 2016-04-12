using Nop.Core.Plugins;
using Nop.Services.Localization;
using Nop.Web.Framework.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Nop.Plugin.SimGate
{
    public class SimGatePlugin : BasePlugin, IAdminMenuPlugin
    {
        public void ManageSiteMap(Nop.Web.Framework.Menu.SiteMapNode rootNode)
        {
            var menuItem = new Nop.Web.Framework.Menu.SiteMapNode()
            {
                SystemName = "SimGatePluging",
                Title = "SimGate",
                ControllerName = null,
                ActionName = null,
                Visible = true,
                RouteValues = new RouteValueDictionary() { { "area", "Admin" } },
            };

            menuItem.ChildNodes.Add(new Web.Framework.Menu.SiteMapNode() { SystemName = "SimGatePlugingProjects", Title = "Projects", ControllerName = "SimGate", ActionName = "Projects", Visible = true, RouteValues = new RouteValueDictionary() { { "area", "Admin" } }, });
            menuItem.ChildNodes.Add(new Web.Framework.Menu.SiteMapNode() { SystemName = "SimGatePlugingPhones", Title = "Phones", ControllerName = "SimGate", ActionName = "Phones", Visible = true, RouteValues = new RouteValueDictionary() { { "area", "Admin" } }, });
            menuItem.ChildNodes.Add(new Web.Framework.Menu.SiteMapNode() { SystemName = "SimGatePlugingRoutes", Title = "Routes", ControllerName = "SimGate", ActionName = "Routes", Visible = true, RouteValues = new RouteValueDictionary() { { "area", "Admin" } }, });
            menuItem.ChildNodes.Add(new Web.Framework.Menu.SiteMapNode() { SystemName = "SimGatePlugingMessages", Title = "Messages", ControllerName = "SimGate", ActionName = "Messages", Visible = true, RouteValues = new RouteValueDictionary() { { "area", "Admin" } }, });
            menuItem.ChildNodes.Add(new Web.Framework.Menu.SiteMapNode() { SystemName = "SimGatePlugingGroups", Title = "Groups", ControllerName = "SimGate", ActionName = "Groups", Visible = true, RouteValues = new RouteValueDictionary() { { "area", "Admin" } }, });
            menuItem.ChildNodes.Add(new Web.Framework.Menu.SiteMapNode() { SystemName = "SimGatePlugingContacts", Title = "Contacts", ControllerName = "SimGate", ActionName = "Contacts", Visible = true, RouteValues = new RouteValueDictionary() { { "area", "Admin" } }, });
            menuItem.ChildNodes.Add(new Web.Framework.Menu.SiteMapNode() { SystemName = "SimGatePlugingServices", Title = "Services", ControllerName = "SimGate", ActionName = "Services", Visible = true, RouteValues = new RouteValueDictionary() { { "area", "Admin" } }, });

            var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Third party plugins");
            if (pluginNode != null)
                pluginNode.ChildNodes.Add(menuItem);
            else
                rootNode.ChildNodes.Add(menuItem);
        }










        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            ////database objects
            //_objectContext.Install();

            ////locales
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Store", "Store");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Store.Hint", "If an asterisk is selected, then this shipping rate will apply to all stores.");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Country", "Country");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Country.Hint", "The country.");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.StateProvince", "State / province");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.StateProvince.Hint", "If an asterisk is selected, then this tax rate will apply to all customers from the given country, regardless of the state.");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Zip", "Zip");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Zip.Hint", "Zip / postal code. If zip is empty, then this tax rate will apply to all customers from the given country or state, regardless of the zip code.");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.TaxCategory", "Tax category");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.TaxCategory.Hint", "The tax category.");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Percentage", "Percentage");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Percentage.Hint", "The tax rate.");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.AddRecord", "Add tax rate");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Tax.CountryStateZip.AddRecord.Hint", "Adding a new tax rate");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            ////database objects
            //_objectContext.Uninstall();

            ////locales
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Store");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Store.Hint");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Country");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Country.Hint");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.StateProvince");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.StateProvince.Hint");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Zip");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Zip.Hint");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.TaxCategory");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.TaxCategory.Hint");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Percentage");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.Fields.Percentage.Hint");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.AddRecord");
            //this.DeletePluginLocaleResource("Plugins.Tax.CountryStateZip.AddRecord.Hint");

            base.Uninstall();
        }




    }
}