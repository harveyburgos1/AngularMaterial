using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QRP.Identity
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5CA27F53-3D4D-48D5-90D0-3DD12B0DEDF7",
                    Username = "rsaberon",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Roy"),
                        new Claim("family_name", "Saberon")
                    }
                },
                new TestUser
                {
                    SubjectId = "B3B5CB79-D411-4DF5-9588-D4FF1316B465",
                    Username = "lsaberon",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Linus"),
                        new Claim("family_name", "Saberon")
                    }
                },
                new TestUser
                { 
                    SubjectId = "695DDC99-EA3F-43DE-93D4-D1269D263E5E",
                    Username = "amaity",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Arup"),
                        new Claim("family_name", "Maity")
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("onlinestoreapi", "OnlineStore V1")
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientName = "OnlineStore",
                    ClientId = "onlinestore",
                    AllowedGrantTypes =GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        "onlinestoreapi"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        }
    }
}
