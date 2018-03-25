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

using SimpleBus.Core;
using SimpleIdentityServer.Core.Api.Introspection.Actions;
using SimpleIdentityServer.Core.Exceptions;
using SimpleIdentityServer.Core.Parameters;
using SimpleIdentityServer.Core.Results;
using SimpleIdentityServer.Handler.Events;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SimpleIdentityServer.Core.Api.Introspection
{
    public interface IIntrospectionActions
    {
        Task<IntrospectionResult> PostIntrospection(
            IntrospectionParameter introspectionParameter,
            AuthenticationHeaderValue authenticationHeaderValue);
    }

    public class IntrospectionActions : IIntrospectionActions
    {
        private readonly IPostIntrospectionAction _postIntrospectionAction;
        private readonly IEventPublisher _eventPublisher;
        private readonly IPayloadSerializer _payloadSerializer;

        public IntrospectionActions(IPostIntrospectionAction postIntrospectionAction, IEventPublisher eventPublisher, IPayloadSerializer payloadSerializer)
        {
            _postIntrospectionAction = postIntrospectionAction;
            _eventPublisher = eventPublisher;
            _payloadSerializer = payloadSerializer;
        }

        public async Task<IntrospectionResult> PostIntrospection(IntrospectionParameter introspectionParameter, AuthenticationHeaderValue authenticationHeaderValue)
        {
            if (introspectionParameter == null)
            {
                throw new ArgumentNullException(nameof(introspectionParameter));
            }

            var processId = Guid.NewGuid().ToString();
            try
            {
                _eventPublisher.Publish(new IntrospectionRequestReceived(Guid.NewGuid().ToString(), processId, _payloadSerializer.GetPayload(introspectionParameter, authenticationHeaderValue), authenticationHeaderValue, 0));
                var result = await _postIntrospectionAction.Execute(introspectionParameter, authenticationHeaderValue);
                _eventPublisher.Publish(new IntrospectionResultReturned(Guid.NewGuid().ToString(), processId, _payloadSerializer.GetPayload(result), 1));
                return result;
            }
            catch (IdentityServerException ex)
            {
                _eventPublisher.Publish(new OpenIdErrorReceived(Guid.NewGuid().ToString(), processId, ex.Code, ex.Message, 1));
                throw;
            }
        }
    }
}
