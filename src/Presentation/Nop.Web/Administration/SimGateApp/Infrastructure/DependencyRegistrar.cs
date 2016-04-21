using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Services.SimGateApp.Telerivet;

namespace Nop.Admin.SimGateApp.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order
        {
            get { return 2; }

        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<Telerivet_RouteService>().As<ITelerivet_RouteService>().InstancePerLifetimeScope();
            builder.RegisterType<Telerivet_MessageService>().As<ITelerivet_MessageService>().InstancePerLifetimeScope();
            builder.RegisterType<Telerivet_ProjectService>().As<ITelerivet_ProjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Telerivet_PhoneService>().As<ITelerivet_PhoneService>().InstancePerLifetimeScope();
            builder.RegisterType<Telerivet_GroupService>().As<ITelerivet_GroupService>().InstancePerLifetimeScope();
            builder.RegisterType<Telerivet_ContactService>().As<ITelerivet_ContactService>().InstancePerLifetimeScope();
        }
    }
}