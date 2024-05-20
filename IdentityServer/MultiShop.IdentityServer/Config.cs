﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        // her  bir mikroservis için o mikro servise erişim sağlanıcak bir key belirlenir
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog") { Scopes = {"CatalogFullPermission","CatalogReadPermission"} },
            new ApiResource("ResourceDiscount") { Scopes = {"DiscountFullPermission","DiscountReadPermission"} },
            new ApiResource("ResourceOrder") { Scopes = {"OrderFullPermission","OrderReadPermission"} },
        };
        // o token içinde hangi bilgilere erişim sağlanıcak
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),

            new ApiScope("DiscountFullPermission","Reading authority for discount operations"),
            new ApiScope("DiscountReadPermission","Reading authority for discount operations"),

            new ApiScope("OrderFullPermission","Reading authority for order operations"),
            new ApiScope("OrderReadPermission","Reading authority for order operations"),
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "Multi Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials, //kimlik işlemleri için kullanılan bir prop
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission" }
            },
            //Manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "Multi Shop Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials, //kimlik işlemleri için kullanılan bir prop
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission" }
            },
            //Admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "Multi Shop Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials, //kimlik işlemleri için kullanılan bir prop
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission", IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                AccessTokenLifetime = 600
            },
        };

    }
}
