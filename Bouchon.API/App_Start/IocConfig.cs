using Autofac;
using Autofac.Integration.WebApi;
using Bouchon.API.Db;
using Owin;
using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Bouchon.API
{
    public class IocConfig
    {
        public static void Config(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            //register controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()) //Register ***Services
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            //Register generics
            builder.RegisterGeneric(typeof(Repository<>)).AsImplementedInterfaces();

            // Register dependecy of MailerApiController from Postal dll
            builder.RegisterType<EmailService>().As<IEmailService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container); //WebAPI

            app.UseAutofacMiddleware(container); //Register before MVC / WebApi
            app.UseAutofacWebApi(config);
        }
    }
}