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

using Moq;
using SimpleIdentityServer.Uma.Core.Api.ScopeController.Actions;
using SimpleIdentityServer.Uma.Core.Errors;
using SimpleIdentityServer.Uma.Core.Exceptions;
using SimpleIdentityServer.Uma.Core.Models;
using SimpleIdentityServer.Uma.Core.Parameters;
using SimpleIdentityServer.Uma.Core.Repositories;
using SimpleIdentityServer.Uma.Core.Validators;
using System;
using Xunit;

namespace SimpleIdentityServer.Uma.Core.UnitTests.Api.ScopeController.Actions
{
    public class UpdateScopeActionFixture
    {
        private Mock<IScopeRepository> _scopeRepositoryStub;

        private Mock<IScopeParameterValidator> _scopeParameterValidator;

        private IUpdateScopeAction _updateScopeAction;

        #region Exceptions

        [Fact]
        public void When_Passing_Null_Parameter_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();

            // ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() => _updateScopeAction.Execute(null));
        }

        [Fact]
        public void When_An_Error_Occured_While_Retrieving_Scope_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();
            var updateScopeParameter = new UpdateScopeParameter();
            _scopeRepositoryStub.Setup(s => s.GetScope(It.IsAny<string>()))
                .Callback(() =>
                {
                    throw new Exception();
                });

            // ACT & ASSERTS
            var exception = Assert.Throws<BaseUmaException>(() => _updateScopeAction.Execute(updateScopeParameter));
            Assert.NotNull(exception);
            Assert.True(exception.Code == ErrorCodes.InternalError);
            Assert.True(exception.Message == ErrorDescriptions.TheScopeCannotBeRetrieved);
        }

        [Fact]
        public void When_An_Error_Occured_While_Inserted_Scope_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();
            var updateScopeParameter = new UpdateScopeParameter();
            _scopeRepositoryStub.Setup(s => s.GetScope(It.IsAny<string>()))
                .Returns(new Scope());
            _scopeRepositoryStub.Setup(s => s.UpdateScope(It.IsAny<Scope>()))
                .Callback(() =>
                {
                    throw new Exception();
                });

            // ACT & ASSERTS
            var exception = Assert.Throws<BaseUmaException>(() => _updateScopeAction.Execute(updateScopeParameter));
            Assert.NotNull(exception);
            Assert.True(exception.Code == ErrorCodes.InternalError);
            Assert.True(exception.Message == ErrorDescriptions.TheScopeCannotBeUpdated);
        }

        #endregion

        #region Happy paths

        [Fact]
        public void When_A_Scope_Is_Updated_Then_True_Is_Returned()
        {
            // ARRANGE
            InitializeFakeObjects();
            var updateScopeParameter = new UpdateScopeParameter();
            _scopeRepositoryStub.Setup(s => s.GetScope(It.IsAny<string>()))
                .Returns(new Scope());
            _scopeRepositoryStub.Setup(s => s.InsertScope(It.IsAny<Scope>()))
                .Returns(new Scope());

            // ACT
            var result = _updateScopeAction.Execute(updateScopeParameter);

            // ASSERT
            Assert.True(result);
        }

        [Fact]
        public void When_Trying_To_Update_A_Not_Existed_Scope_Then_False_Is_Returned()
        {
            // ARRANGE
            InitializeFakeObjects();
            var updateScopeParameter = new UpdateScopeParameter();
            _scopeRepositoryStub.Setup(s => s.GetScope(It.IsAny<string>()))
                .Returns(() => null);

            // ACT
            var result = _updateScopeAction.Execute(updateScopeParameter);

            // ASSERT
            Assert.False(result);
        }

        #endregion

        private void InitializeFakeObjects()
        {
            _scopeRepositoryStub = new Mock<IScopeRepository>();
            _scopeParameterValidator = new Mock<IScopeParameterValidator>();
            _updateScopeAction = new UpdateScopeAction(_scopeRepositoryStub.Object,
                _scopeParameterValidator.Object);
        }
    }
}
