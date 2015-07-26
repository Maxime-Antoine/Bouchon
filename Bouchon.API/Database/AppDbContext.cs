using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bouchon.API.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
            : base("AppDb")
        {

        }

        public static AuthDbContext Create()
        {
            return new AuthDbContext();
        }
    }
}