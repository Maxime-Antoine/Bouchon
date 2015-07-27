﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thinktecture.IdentityServer.Core.Models;

namespace Bouchon.API.Authentication
{
    public static class Scopes
    {
        public static List<Scope> Get()
        {
            var scopes = new List<Scope>
            {
                new Scope
                {
                    Enabled = true,
                    Name = "api",
                    Type = ScopeType.Resource,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role")

                    }
                }
            };

            scopes.AddRange(StandardScopes.All);

            return scopes;
        }
    }
}