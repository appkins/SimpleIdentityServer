﻿#region copyright
// Copyright 2015 Habart Thierry
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using SimpleIdentityServer.Core.Jwt.Serializer;
using SimpleIdentityServer.Core.Jwt.Signature;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SimpleIdentityServer.Client.Test
{
    class Program
    {
        private const string _baseUrl = "https://rp.certification.openid.net:8080/simpleIdServer";
        private const string RedirectUriCode = "https://localhost:5106/Authenticate/Callback";
        private static IJwsParser _jwsParser;

        public static void Main(string[] args)
        {
            _jwsParser = new JwsParser(null);
            // 1. Execute tests for basic profile
            RpResponseTypeCode().Wait();
            RpScopeUserInfoClaims().Wait();
            RpNonceInvalid().Wait();
            RpTokenEndpointClientSecretBasic().Wait();
            // identityServerClientFactory.CreateAuthSelector()
            Console.ReadLine();
        }

        private static async Task RpResponseTypeCode()
        {
            using (var writer = File.AppendText(@"C:\Users\thabart\Desktop\Logs\rp-response_type-code.log"))
            {
                var identityServerClientFactory = new IdentityServerClientFactory();
                var state = Guid.NewGuid().ToString();
                var nonce = Guid.NewGuid().ToString();
                Log("Call OpenIdConfiguration", writer);
                var discovery = await identityServerClientFactory.CreateDiscoveryClient()
                    .GetDiscoveryInformationAsync(_baseUrl + "/rp-response_type-code/.well-known/openid-configuration");
                // rp-response_type-code : Make an authentication request using the "Authorization code Flow"
                Log("Register client", writer);
                var client = await identityServerClientFactory.CreateRegistrationClient()
                    .ExecuteAsync(new Core.Common.DTOs.Client
                    {
                        RedirectUris = new List<string>
                        {
                        RedirectUriCode
                        },
                        ApplicationType = "web",
                        GrantTypes = new List<string>
                        {
                        "authorization_code"
                        },
                        ResponseTypes = new List<string>
                        {
                        "code"
                        }
                    }, discovery.RegistrationEndPoint);
                Log("Get authorization", writer);
                var result = await identityServerClientFactory.CreateAuthorizationClient()
                    .ExecuteAsync(discovery.AuthorizationEndPoint,
                        new Core.Common.DTOs.AuthorizationRequest
                        {
                            ClientId = client.ClientId,
                            State = state,
                            RedirectUri = RedirectUriCode,
                            ResponseType = "code",
                            Scope = "openid",
                            Nonce = nonce
                        });
                Log($"Authorization code has been returned {result.Content.Value<string>("code")}", writer);
            }
        }

        private static async Task RpScopeUserInfoClaims()
        {
            using (var writer = File.AppendText(@"C:\Users\thabart\Desktop\Logs\rp-scope-userinfo-claims.log"))
            {
                var state = Guid.NewGuid().ToString();
                var nonce = Guid.NewGuid().ToString();
                var identityServerClientFactory = new IdentityServerClientFactory();
                Log("Call OpenIdConfiguration", writer);
                var discovery = await identityServerClientFactory.CreateDiscoveryClient()
                    .GetDiscoveryInformationAsync(_baseUrl + "/rp-scope-userinfo-claims/.well-known/openid-configuration");
                // rp-scope-userinfo-claims : Request claims using scope values.
                Log("Register the client", writer);
                var client = await identityServerClientFactory.CreateRegistrationClient()
                    .ExecuteAsync(new Core.Common.DTOs.Client
                    {
                        RedirectUris = new List<string>
                        {
                        RedirectUriCode
                        },
                        ApplicationType = "web",
                        GrantTypes = new List<string>
                        {
                        "authorization_code"
                        },
                        ResponseTypes = new List<string>
                        {
                        "code"
                        }
                    }, discovery.RegistrationEndPoint);
                Log("Get authorization", writer);
                var auth = await identityServerClientFactory.CreateAuthorizationClient()
                    .ExecuteAsync(discovery.AuthorizationEndPoint,
                        new Core.Common.DTOs.AuthorizationRequest
                        {
                            ClientId = client.ClientId,
                            State = state,
                            RedirectUri = RedirectUriCode,
                            ResponseType = "code",
                            Scope = "openid email profile",
                            Nonce = nonce
                        });
                var code = auth.Content.Value<string>("code");
                Log("Get access token", writer);
                var token = await identityServerClientFactory.CreateAuthSelector()
                    .UseClientSecretBasicAuth(client.ClientId, client.ClientSecret)
                    .UseAuthorizationCode(code, RedirectUriCode)
                    .ExecuteAsync(discovery.TokenEndPoint);
                Log("Get user information", writer);
                var userInfo = await identityServerClientFactory.CreateUserInfoClient()
                    .GetUserInfoAsync(discovery.UserInfoEndPoint, token.AccessToken);
                Log($"claims has been returned, the subject is : {userInfo.Value<string>("sub")}", writer);
            }
        }

        private static async Task RpNonceInvalid()
        {
            using (var writer = File.AppendText(@"C:\Users\thabart\Desktop\Logs\rp-nonce-invalid.log"))
            {
                var state = Guid.NewGuid().ToString();
                var nonce = Guid.NewGuid().ToString();
                var identityServerClientFactory = new IdentityServerClientFactory();
                Log("Call OpenIdConfiguration", writer);
                var discovery = await identityServerClientFactory.CreateDiscoveryClient()
                    .GetDiscoveryInformationAsync(_baseUrl + "/rp-nonce-invalid/.well-known/openid-configuration");
                // rp-scope-userinfo-claims : Request claims using scope values.
                var client = await identityServerClientFactory.CreateRegistrationClient()
                    .ExecuteAsync(new Core.Common.DTOs.Client
                    {
                        RedirectUris = new List<string>
                        {
                        RedirectUriCode
                        },
                        ApplicationType = "web",
                        GrantTypes = new List<string>
                        {
                        "authorization_code"
                        },
                        ResponseTypes = new List<string>
                        {
                        "code"
                        }
                    }, discovery.RegistrationEndPoint);
                Log("Get an authorization code", writer);
                var auth = await identityServerClientFactory.CreateAuthorizationClient()
                    .ExecuteAsync(discovery.AuthorizationEndPoint,
                        new Core.Common.DTOs.AuthorizationRequest
                        {
                            ClientId = client.ClientId,
                            State = state,
                            RedirectUri = RedirectUriCode,
                            ResponseType = "code",
                            Scope = "openid email profile",
                            Nonce = nonce
                        });
                var code = auth.Content.Value<string>("code");
                Log("Get an identity token", writer);
                var token = await identityServerClientFactory.CreateAuthSelector()
                    .UseClientSecretBasicAuth(client.ClientId, client.ClientSecret)
                    .UseAuthorizationCode(code, RedirectUriCode)
                    .ExecuteAsync(discovery.TokenEndPoint);
                var payload = _jwsParser.GetPayload(token.IdToken);
                if (payload.Nonce == nonce)
                {
                    Log("The nonce in identity token is correct", writer);
                }
                else
                {
                    Log("The nonce in identity token is not correct", writer);
                }
            }
        }

        private static async Task RpTokenEndpointClientSecretBasic()
        {
            using (var writer = File.AppendText(@"C:\Users\thabart\Desktop\Logs\rp-token_endpoint-client_secret_basic.log"))
            {
                var state = Guid.NewGuid().ToString();
                var nonce = Guid.NewGuid().ToString();
                var identityServerClientFactory = new IdentityServerClientFactory();
                Log("Call OpenIdConfiguration", writer);
                var discovery = await identityServerClientFactory.CreateDiscoveryClient()
                    .GetDiscoveryInformationAsync(_baseUrl + "/rp-token_endpoint-client_secret_basic/.well-known/openid-configuration");
                Log("Register the client", writer);
                var client = await identityServerClientFactory.CreateRegistrationClient()
                    .ExecuteAsync(new Core.Common.DTOs.Client
                    {
                        RedirectUris = new List<string>
                        {
                            RedirectUriCode
                        },
                        ApplicationType = "web",
                        GrantTypes = new List<string>
                        {
                            "authorization_code"
                        },
                        ResponseTypes = new List<string>
                        {
                            "code"
                        },
                        TokenEndpointAuthMethod = "client_secret_basic"
                    }, discovery.RegistrationEndPoint);
                Log("Get an authorization code", writer);
                var auth = await identityServerClientFactory.CreateAuthorizationClient()
                    .ExecuteAsync(discovery.AuthorizationEndPoint,
                        new Core.Common.DTOs.AuthorizationRequest
                        {
                            ClientId = client.ClientId,
                            State = state,
                            RedirectUri = RedirectUriCode,
                            ResponseType = "code",
                            Scope = "openid email profile",
                            Nonce = nonce
                        });
                var code = auth.Content.Value<string>("code");
                Log("Get the identity token with client_secret_basic authentication method", writer);
                var token = await identityServerClientFactory.CreateAuthSelector()
                    .UseClientSecretBasicAuth(client.ClientId, client.ClientSecret)
                    .UseAuthorizationCode(code, RedirectUriCode)
                    .ExecuteAsync(discovery.TokenEndPoint);
                Log($"Identity token returns {token.IdToken}", writer);
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.WriteLine($"Log Entry : {DateTime.UtcNow} : {logMessage}");
        }
    }
}
