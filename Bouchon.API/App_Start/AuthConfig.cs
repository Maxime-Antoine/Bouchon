using Bouchon.API.Authentication;
using Owin;
using System;
using System.Security.Cryptography.X509Certificates;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Core.Models;

namespace Bouchon.API
{
    public class AuthConfig
    {
        public static void Config(IAppBuilder app)
        {
            app.Map("/identity", idsrvApp =>
                {
                    idsrvApp.UseIdentityServer(new IdentityServerOptions
                        {
                            SiteName = "Embedded IdentityServer",
                            //SigningCertificate = LoadCertificate(),
                            Factory = InMemoryFactory.Create(
                                users: Users.Get(),
                                clients: Clients.Get(),
                                scopes: Scopes.Get()
                            )

                        });
                });
        }

        private static X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2();
        }
    }
}