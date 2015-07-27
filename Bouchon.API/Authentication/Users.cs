using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Thinktecture.IdentityServer.Core;
using Thinktecture.IdentityServer.Core.Services.InMemory;

namespace Bouchon.API.Authentication
{
    public static class Users
    {
       public static List<InMemoryUser> Get()
       {
           return new List<InMemoryUser>
           {
               new InMemoryUser
               {
                   Username = "Max",
                   Password = "password",
                   Subject = "1",
                   Claims = new[]
                   {
                       new Claim(Constants.ClaimTypes.GivenName, "Maxime"),
                       new Claim(Constants.ClaimTypes.FamilyName, "Antoine"),
                       new Claim(Constants.ClaimTypes.Role, "Geek"),
                       new Claim(Constants.ClaimTypes.Role, "Foo")
                   }
               }
           };
       }
    }
}