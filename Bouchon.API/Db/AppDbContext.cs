using Bouchon.API.Authentication;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bouchon.API.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("AppDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Migrations.Configuration>());
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}