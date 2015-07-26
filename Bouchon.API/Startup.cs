using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(Annufal.Startup))]

namespace Bouchon.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            AuthConfig.Config(app);

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll); //Allow CORS for API

            IocConfig.Config(app, config);

            app.UseWebApi(config);
        }
    }
}