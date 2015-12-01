﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using SimpleIdentityServer.Core.Extensions;
using SimpleIdentityServer.Core.Helpers;
using SimpleIdentityServer.Core.Jwt;
using SimpleIdentityServer.Core.Models;
using SimpleIdentityServer.Core.Parameters;
using SimpleIdentityServer.Core.Repositories;
using SimpleIdentityServer.Core.Results;
using SimpleIdentityServer.Core.JwtToken;

namespace SimpleIdentityServer.Core.Common
{
    public interface IGenerateAuthorizationResponse
    {
        void Execute(
            ActionResult actionResult,
            AuthorizationParameter authorizationParameter,
            ClaimsPrincipal claimsPrincipal);
    }

    public class GenerateAuthorizationResponse : IGenerateAuthorizationResponse
    {
        private readonly IAuthorizationCodeRepository _authorizationCodeRepository;

        private readonly IParameterParserHelper _parameterParserHelper;

        private readonly IJwtGenerator _jwtGenerator;

        private readonly ITokenHelper _tokenHelper;

        private readonly IGrantedTokenRepository _grantedTokenRepository;

        private readonly IConsentRepository _consentRepository;

        public GenerateAuthorizationResponse(
            IAuthorizationCodeRepository authorizationCodeRepository,
            IParameterParserHelper parameterParserHelper,
            IJwtGenerator jwtGenerator,
            ITokenHelper tokenHelper,
            IGrantedTokenRepository grantedTokenRepository,
            IConsentRepository consentRepository)
        {
            _authorizationCodeRepository = authorizationCodeRepository;
            _parameterParserHelper = parameterParserHelper;
            _jwtGenerator = jwtGenerator;
            _tokenHelper = tokenHelper;
            _grantedTokenRepository = grantedTokenRepository;
            _consentRepository = consentRepository;
        }

        public void Execute(
            ActionResult actionResult, 
            AuthorizationParameter authorizationParameter,
            ClaimsPrincipal claimsPrincipal)
        {
            var responses = _parameterParserHelper.ParseResponseType(authorizationParameter.ResponseType);
            var idToken = GenerateIdToken(claimsPrincipal, authorizationParameter);
            var userInformationPayload = GenerateUserInformationPayload(claimsPrincipal, authorizationParameter);

            if (responses.Contains(ResponseType.id_token))
            {
                actionResult.RedirectInstruction.AddParameter(Constants.StandardAuthorizationResponseNames.IdTokenName, idToken);
            }

            if (responses.Contains(ResponseType.token))
            {
                var allowedTokenScopes = string.Empty;
                if (!string.IsNullOrWhiteSpace(authorizationParameter.Scope))
                {
                    allowedTokenScopes = string.Join(" ", _parameterParserHelper.ParseScopeParameters(authorizationParameter.Scope));
                }

                var generatedToken = _tokenHelper.GenerateToken(
                    allowedTokenScopes, 
                    idToken);
                generatedToken.UserInfoPayLoad = userInformationPayload;
                _grantedTokenRepository.Insert(generatedToken);
                actionResult.RedirectInstruction.AddParameter(Constants.StandardAuthorizationResponseNames.AccessTokenName, generatedToken.AccessToken);
            }

            if (responses.Contains(ResponseType.code))
            {
                var assignedConsent = GetResourceOwnerConsent(claimsPrincipal, authorizationParameter);
                if (assignedConsent != null)
                {
                    // Insert a temporary authorization code 
                    // It will be used later to retrieve tha id_token or an access token.
                    var authorizationCode = new AuthorizationCode
                    {
                        Code = Guid.NewGuid().ToString(),
                        RedirectUri = authorizationParameter.RedirectUrl,
                        CreateDateTime = DateTime.UtcNow,
                        ClientId = authorizationParameter.ClientId,
                        Scopes = authorizationParameter.Scope,
                        IdToken = idToken,
                    };

                    _authorizationCodeRepository.AddAuthorizationCode(authorizationCode);
                    actionResult.RedirectInstruction.AddParameter(Constants.StandardAuthorizationResponseNames.AuthorizationCodeName, authorizationCode.Code);
                }
            }

            if (!string.IsNullOrWhiteSpace(authorizationParameter.State))
            {
                actionResult.RedirectInstruction.AddParameter(Constants.StandardAuthorizationResponseNames.StateName, authorizationParameter.State);
            }

            if (authorizationParameter.ResponseMode == ResponseMode.form_post)
            {
                actionResult.Type = TypeActionResult.RedirectToAction;
                actionResult.RedirectInstruction.Action = IdentityServerEndPoints.FormIndex;
                actionResult.RedirectInstruction.AddParameter("redirect_uri", authorizationParameter.RedirectUrl);
            }
        }
        
        private Consent GetResourceOwnerConsent(
            ClaimsPrincipal claimsPrincipal,
            AuthorizationParameter authorizationParameter)
        {
            var subject = claimsPrincipal.GetSubject();
            var consents = _consentRepository.GetConsentsForGivenUser(subject);
            Consent confirmedConsent = null;
            if (consents != null && consents.Any())
            {
                var claimsParameter = authorizationParameter.Claims;
                if (claimsParameter == null ||
                    (claimsParameter.IdToken == null ||
                     !claimsParameter.IdToken.Any()) &&
                    (claimsParameter.UserInfo == null ||
                     !claimsParameter.UserInfo.Any()))
                {
                    var expectedClaims = GetClaims(claimsParameter);
                    confirmedConsent = consents.FirstOrDefault(
                        c =>
                            c.Client.ClientId == authorizationParameter.ClientId &&
                            c.GrantedScopes != null && c.GrantedScopes.Any() &&
                            c.Claims.All(cl => expectedClaims.Contains(cl)));
                }
                else
                {
                    var scopeNames =
                        _parameterParserHelper.ParseScopeParameters(authorizationParameter.Scope);
                    confirmedConsent = consents.FirstOrDefault(
                        c =>
                            c.Client.ClientId == authorizationParameter.ClientId &&
                            c.GrantedScopes != null && c.GrantedScopes.Any() &&
                            c.GrantedScopes.All(s => scopeNames.Contains(s.Name)));
                }
            }

            return confirmedConsent;
        }

        private string GenerateIdToken(
            ClaimsPrincipal claimsPrincipal,
            AuthorizationParameter authorizationParameter)
        {
            JwsPayload jwsPayload;
            if (authorizationParameter.Claims != null &&
                authorizationParameter.Claims.IdToken != null &&
                authorizationParameter.Claims.IdToken.Any())
            {
                jwsPayload = _jwtGenerator.GenerateFilteredJwsPayload(
                    claimsPrincipal,
                    authorizationParameter,
                    authorizationParameter.Claims.IdToken);
            }
            else
            {
                jwsPayload = _jwtGenerator.GenerateJwsPayloadForScopes(claimsPrincipal, authorizationParameter);
            }

            var idToken = _jwtGenerator.Sign(jwsPayload, authorizationParameter);
            return _jwtGenerator.Encrypt(idToken, authorizationParameter);
        }

        private JwsPayload GenerateUserInformationPayload(
            ClaimsPrincipal claimsPrincipal,
            AuthorizationParameter authorizationParameter)
        {
            JwsPayload jwsPayload;
            if (authorizationParameter.Claims != null &&
                authorizationParameter.Claims.UserInfo != null &&
                authorizationParameter.Claims.UserInfo.Any())
            {
                jwsPayload = _jwtGenerator.GenerateFilteredJwsPayload(
                    claimsPrincipal,
                    authorizationParameter,
                    authorizationParameter.Claims.UserInfo);
            }
            else
            {
                jwsPayload = _jwtGenerator.GenerateJwsPayloadForScopes(claimsPrincipal, authorizationParameter);
            }

            return jwsPayload;
        }
        
        /// <summary>
        /// Returns a list of claims.
        /// </summary>
        /// <param name="claimsParameter"></param>
        /// <returns></returns>
        private List<string> GetClaims(ClaimsParameter claimsParameter)
        {
            var result = new List<string>();
            if (claimsParameter.IdToken != null &&
                !claimsParameter.IdToken.Any())
            {
                result.AddRange(claimsParameter.IdToken.Select(s => s.Name));
            }

            if (claimsParameter.UserInfo != null &&
                !claimsParameter.UserInfo.Any())
            {
                result.AddRange(claimsParameter.UserInfo.Select(s => s.Name));
            }

            return result;
        } 
    }
}
