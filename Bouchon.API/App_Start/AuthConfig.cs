using Bouchon.API.Authentication;
using Bouchon.API.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Bouchon.API
{
    public class AuthConfig
    {
        public static void Config(IAppBuilder app)
        {
            //create auth classes in owin context
            app.CreatePerOwinContext(AppDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            //JWT token generation
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true, //to change in prod
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJWTFormatProvider(ConfigurationManager.AppSettings["appRootUrl"])
            };
            app.UseOAuthAuthorizationServer(oAuthServerOptions);

            //JWT token comsuption
            var issuer = ConfigurationManager.AppSettings["appRootUrl"];
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            //Api controllers with [Authorize] filter will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }
    }
}