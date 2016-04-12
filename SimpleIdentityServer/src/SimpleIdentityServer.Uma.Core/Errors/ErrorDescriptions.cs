#region copyright
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

namespace SimpleIdentityServer.Uma.Core.Errors
{
    public static class ErrorDescriptions
    {
        public const string TheParameterNeedsToBeSpecified = "the parameter {0} needs to be specified";   
        
        public const string TheUrlIsNotWellFormed = "the url {0} is not well formed";

        public const string TheResourceSetCannotBeInserted = "an error occured while trying to insert the resource set";

        public const string TheResourceSetDoesntExist = "resource set {0} doesn't exist";

        public const string TheResourceSetCannotBeUpdated = "resource set {0} cannot be udpated";

        public const string TheResourceSetCannotBeRemoved = "resource set {0} cannot be removed";

        public const string TheResourceSetsCannotBeRetrieved = "resource sets cannot be retrieved";

        public const string TheScopeCannotBeRetrieved = "scope cannot be retrieved";

        public const string TheScopeCannotBeInserted = "scope cannot be inserted";

        public const string TheScopeCannotBeUpdated = "scope cannot be updated";

        public const string TheScopeCannotBeRemoved = "scope cannot be removed";

        public const string TheScopesCannotBeRetrieved = "scopes cannot be retrieved";

        public const string TheScopeAlreadyExists = "scope {0} already exists";
    }
}