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
                            SigningCertificate = LoadCertificate(),
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
            var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            foreach (var cert in store.Certificates)
                if (cert.FriendlyName == "Development Certificate")
                    return cert;

            throw new Exception("Dev SSL certificate not found !");
        }
    }
}