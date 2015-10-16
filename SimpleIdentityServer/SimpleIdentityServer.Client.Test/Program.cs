﻿using System;
using SimpleIdentityServerClient;
using SimpleIdentityServerClient.Parameters;

namespace SimpleIdentityServer.Client.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new IdentityServerClientFactory();
            var client = factory.CreateClient("http://localhost:50470/swagger/docs/v1", "http://localhost:50470");
            var request = new GetAccessToken
            {
                ClientId = "WebSite",
                Username = "administrator",
                Password = "administrator",
                Scope = "firstScope"
            };
            var result = client.GetAccessTokenViaResourceOwnerGrantTypeAsync(request).Result;

            Console.WriteLine(result.AccessToken);

            Console.ReadLine();
        }
    }
}
