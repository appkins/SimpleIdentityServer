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

using Microsoft.Extensions.DependencyInjection;
using SimpleIdentityServer.Uma.Core.Api.ResourceSetController;
using SimpleIdentityServer.Uma.Core.Api.ResourceSetController.Actions;
using SimpleIdentityServer.Uma.Core.Api.ScopeController;
using SimpleIdentityServer.Uma.Core.Api.ScopeController.Actions;
using SimpleIdentityServer.Uma.Core.Validators;

namespace SimpleIdentityServer.Uma.Core
{
    public static class SimpleIdServerUmaCoreExtensions
    {
        #region Public static methods

        public static IServiceCollection AddSimpleIdServerUmaCore(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IResourceSetActions, ResourceSetActions>();
            serviceCollection.AddTransient<IAddResourceSetAction, AddResourceSetAction>();
            serviceCollection.AddTransient<IGetResourceSetAction, GetResourceSetAction>();
            serviceCollection.AddTransient<IUpdateResourceSetAction, UpdateResourceSetAction>();
            serviceCollection.AddTransient<IDeleteResourceSetAction, DeleteResourceSetAction>();
            serviceCollection.AddTransient<IGetAllResourceSetAction, GetAllResourceSetAction>();
            serviceCollection.AddTransient<IResourceSetParameterValidator, ResourceSetParameterValidator>();
            serviceCollection.AddTransient<IGetScopeAction, GetScopeAction>();
            serviceCollection.AddTransient<IScopeActions, ScopeActions>();
            serviceCollection.AddTransient<IScopeParameterValidator, ScopeParameterValidator>();
            serviceCollection.AddTransient<IInsertScopeAction, InsertScopeAction>();
            serviceCollection.AddTransient<IScopeActions, ScopeActions>();
            serviceCollection.AddTransient<IUpdateScopeAction, UpdateScopeAction>();
            serviceCollection.AddTransient<IDeleteScopeAction, DeleteScopeAction>();
            return serviceCollection;
        }

        #endregion
    }
}
