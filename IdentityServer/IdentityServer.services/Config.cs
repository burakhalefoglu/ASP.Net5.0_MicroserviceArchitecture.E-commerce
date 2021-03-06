// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace IdentityServer.services
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                           new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource(){ Name="roles", DisplayName="Roles", Description="Kullanıcı rolleri", UserClaims=new []{ "role"} }

                   };
        public static IEnumerable<ApiResource> apiResources =>
                new ApiResource[]
                {
                    new ApiResource("resource_product"){Scopes ={ "product_get","product_getall" } },
                    new ApiResource("resource_product_photo_stock"){Scopes ={ "photo_stock_fullpermission" } },                    new ApiResource("photo_stock_catalog"){Scopes ={ "photo_stock_fullpermission" } },
                    new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

                };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("product_get"),
                new ApiScope("product_getall"),
                new ApiScope("photo_stock_fullpermission"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName= "Asp.Net Core MVC",
                    ClientId = "WebMvcClient",
                    ClientSecrets={new Secret("this is my Secret key".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes= { "product_get","product_getall", "photo_stock_fullpermission",
                        IdentityServerConstants.LocalApi.ScopeName }
                },

                 new Client
                {
                    ClientName= "Asp.Net Core MVC",
                    ClientId = "WebMvcClientForUser",
                    ClientSecrets={new Secret("this is my Secret key".Sha256())},
                    AllowOfflineAccess=true,
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    AllowedScopes= { IdentityServerConstants.StandardScopes.Email,
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile,
                     IdentityServerConstants.StandardScopes.OfflineAccess,
                     IdentityServerConstants.LocalApi.ScopeName,"roles"},
                    AccessTokenLifetime = 1*60*60,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int) (DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    RefreshTokenUsage=TokenUsage.ReUse,
                 }
            };
    }
}