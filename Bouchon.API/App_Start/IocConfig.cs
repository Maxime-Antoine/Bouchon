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
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //WebAPI

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()) //Register ***Services
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container); //WebAPI

            app.UseAutofacMiddleware(container); //Register before MVC / WebApi
            app.UseAutofacMvc();
            app.UseAutofacWebApi(config);
        }
    }
}