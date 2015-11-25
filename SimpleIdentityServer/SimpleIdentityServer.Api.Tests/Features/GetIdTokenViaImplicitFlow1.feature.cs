﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SimpleIdentityServer.Api.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("GetIdTokenViaImplicitWorkflow")]
    public partial class GetIdTokenViaImplicitWorkflowFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetIdTokenViaImplicitFlow.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetIdTokenViaImplicitWorkflow", "As a known client\r\nI want to use the implicit workflow to retrieve the id token o" +
                    "r access token", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get the id token")]
        public virtual void GetTheIdToken()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get the id token", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("the redirection uri http://localhost is assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal"});
            table1.AddRow(new string[] {
                        "openid",
                        "true"});
            table1.AddRow(new string[] {
                        "PlanningApi",
                        "false"});
#line 9
 testRunner.And("the scopes are defined", ((string)(null)), table1, "And ");
#line 14
 testRunner.And("the id_token signature algorithm is set to none for the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("the scopes openid,PlanningApi are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("the grant-type implicit is supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("the response-types id_token are supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name"});
            table2.AddRow(new string[] {
                        "habarthierry@loki.be",
                        "thabart"});
#line 18
 testRunner.And("create a resource owner", ((string)(null)), table2, "And ");
#line 21
 testRunner.And("authenticate the resource owner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("the consent has been given by the resource owner habarthierry@loki.be for the cli" +
                    "ent MyHolidays and scopes openid,PlanningApi", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "scope",
                        "response_type",
                        "client_id",
                        "redirect_uri",
                        "prompt",
                        "state",
                        "nonce"});
            table3.AddRow(new string[] {
                        "openid PlanningApi",
                        "id_token",
                        "MyHolidays",
                        "http://localhost",
                        "none",
                        "state1",
                        "parameterNonce"});
#line 24
 testRunner.When("requesting an authorization", ((string)(null)), table3, "When ");
#line 28
 testRunner.Then("the http status code is 301", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.And("decrypt the id_token parameter from the query string", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alg"});
            table4.AddRow(new string[] {
                        "none"});
#line 30
 testRunner.And("the protected JWS header is returned", ((string)(null)), table4, "And ");
#line 33
 testRunner.And("the audience parameter with value MyHolidays is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("the parameter nonce with value parameterNonce is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("the claim sub with value habarthierry@loki.be is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get the id token and access token via implicit workflow")]
        public virtual void GetTheIdTokenAndAccessTokenViaImplicitWorkflow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get the id token and access token via implicit workflow", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.And("the redirection uri http://localhost is assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal"});
            table5.AddRow(new string[] {
                        "openid",
                        "true"});
            table5.AddRow(new string[] {
                        "PlanningApi",
                        "false"});
#line 40
 testRunner.And("the scopes are defined", ((string)(null)), table5, "And ");
#line 44
 testRunner.And("the id_token signature algorithm is set to none for the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("the scopes openid,PlanningApi are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("the grant-type implicit is supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("the response-types id_token,token are supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name"});
            table6.AddRow(new string[] {
                        "habarthierry@loki.be",
                        "thabart"});
#line 48
 testRunner.And("create a resource owner", ((string)(null)), table6, "And ");
#line 51
 testRunner.And("authenticate the resource owner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("the consent has been given by the resource owner habarthierry@loki.be for the cli" +
                    "ent MyHolidays and scopes openid,PlanningApi", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "scope",
                        "response_type",
                        "client_id",
                        "redirect_uri",
                        "prompt",
                        "state",
                        "nonce"});
            table7.AddRow(new string[] {
                        "openid PlanningApi",
                        "id_token token",
                        "MyHolidays",
                        "http://localhost",
                        "none",
                        "state1",
                        "parameterNonce"});
#line 54
 testRunner.When("requesting an authorization", ((string)(null)), table7, "When ");
#line 59
 testRunner.Then("the http status code is 301", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
 testRunner.And("decrypt the id_token parameter from the query string", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alg"});
            table8.AddRow(new string[] {
                        "none"});
#line 61
 testRunner.And("the protected JWS header is returned", ((string)(null)), table8, "And ");
#line 64
 testRunner.And("the audience parameter with value MyHolidays is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("the parameter nonce with value parameterNonce is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("the claim sub with value habarthierry@loki.be is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("the callback contains the following query name access_token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get an id token and check if the claims returned in the token are correct")]
        public virtual void GetAnIdTokenAndCheckIfTheClaimsReturnedInTheTokenAreCorrect()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get an id token and check if the claims returned in the token are correct", ((string[])(null)));
#line 70
this.ScenarioSetup(scenarioInfo);
#line 71
 testRunner.Given("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.And("the redirection uri http://localhost is assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal",
                        "Claims"});
            table9.AddRow(new string[] {
                        "openid",
                        "true",
                        ""});
            table9.AddRow(new string[] {
                        "profile",
                        "true",
                        "name"});
#line 73
 testRunner.And("the scopes are defined", ((string)(null)), table9, "And ");
#line 78
 testRunner.And("the id_token signature algorithm is set to none for the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("the scopes openid,profile are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("the grant-type implicit is supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("the response-types id_token are supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name"});
            table10.AddRow(new string[] {
                        "habarthierry@loki.be",
                        "thabart"});
#line 82
 testRunner.And("create a resource owner", ((string)(null)), table10, "And ");
#line 85
 testRunner.And("authenticate the resource owner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("the consent has been given by the resource owner habarthierry@loki.be for the cli" +
                    "ent MyHolidays and scopes openid,profile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "scope",
                        "response_type",
                        "client_id",
                        "redirect_uri",
                        "prompt",
                        "state",
                        "nonce"});
            table11.AddRow(new string[] {
                        "openid profile",
                        "id_token",
                        "MyHolidays",
                        "http://localhost",
                        "none",
                        "state1",
                        "parameterNonce"});
#line 88
 testRunner.When("requesting an authorization", ((string)(null)), table11, "When ");
#line 92
 testRunner.Then("the http status code is 301", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
 testRunner.And("decrypt the id_token parameter from the query string", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alg"});
            table12.AddRow(new string[] {
                        "none"});
#line 94
 testRunner.And("the protected JWS header is returned", ((string)(null)), table12, "And ");
#line 97
 testRunner.And("the audience parameter with value MyHolidays is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("the parameter nonce with value parameterNonce is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("the claim sub with value habarthierry@loki.be is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("the claim name with value thabart is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get a signed id_token")]
        public virtual void GetASignedId_Token()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get a signed id_token", ((string[])(null)));
#line 103
this.ScenarioSetup(scenarioInfo);
#line 104
 testRunner.Given("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 105
 testRunner.And("the redirection uri http://localhost is assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Kid",
                        "Alg",
                        "Operation",
                        "Kty",
                        "Use"});
            table13.AddRow(new string[] {
                        "1",
                        "RS256",
                        "Sign",
                        "RSA",
                        "Sig"});
#line 106
 testRunner.And("add json web keys", ((string)(null)), table13, "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal"});
            table14.AddRow(new string[] {
                        "openid",
                        "true"});
            table14.AddRow(new string[] {
                        "PlanningApi",
                        "false"});
#line 110
 testRunner.And("the scopes are defined", ((string)(null)), table14, "And ");
#line 115
 testRunner.And("the id_token signature algorithm is set to RS256 for the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.And("the scopes openid,PlanningApi are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.And("the grant-type implicit is supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And("the response-types id_token are supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name"});
            table15.AddRow(new string[] {
                        "habarthierry@loki.be",
                        "thabart"});
#line 119
 testRunner.And("create a resource owner", ((string)(null)), table15, "And ");
#line 122
 testRunner.And("authenticate the resource owner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.And("the consent has been given by the resource owner habarthierry@loki.be for the cli" +
                    "ent MyHolidays and scopes openid,PlanningApi", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "scope",
                        "response_type",
                        "client_id",
                        "redirect_uri",
                        "prompt",
                        "state",
                        "nonce"});
            table16.AddRow(new string[] {
                        "openid PlanningApi",
                        "id_token",
                        "MyHolidays",
                        "http://localhost",
                        "none",
                        "state1",
                        "parameterNonce"});
#line 125
 testRunner.When("requesting an authorization", ((string)(null)), table16, "When ");
#line 129
 testRunner.Then("the http status code is 301", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.And("decrypt the id_token parameter from the query string", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.And("check the signature is correct with the kid 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alg"});
            table17.AddRow(new string[] {
                        "RS256"});
#line 132
 testRunner.And("the protected JWS header is returned", ((string)(null)), table17, "And ");
#line 135
 testRunner.And("the audience parameter with value MyHolidays is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
 testRunner.And("the parameter nonce with value parameterNonce is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.And("the claim sub with value habarthierry@loki.be is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 138
 testRunner.And("the signature of the JWS payload is valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get an encrypted id token and check if the claims returned in the token are corre" +
            "ct")]
        public virtual void GetAnEncryptedIdTokenAndCheckIfTheClaimsReturnedInTheTokenAreCorrect()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get an encrypted id token and check if the claims returned in the token are corre" +
                    "ct", ((string[])(null)));
#line 140
this.ScenarioSetup(scenarioInfo);
#line 141
 testRunner.Given("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 142
 testRunner.And("the redirection uri http://localhost is assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Kid",
                        "Alg",
                        "Operation",
                        "Kty",
                        "Use"});
            table18.AddRow(new string[] {
                        "1",
                        "RSA1_5",
                        "Encrypt",
                        "RSA",
                        "Enc"});
#line 143
 testRunner.And("add json web keys", ((string)(null)), table18, "And ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal",
                        "Claims"});
            table19.AddRow(new string[] {
                        "openid",
                        "true",
                        ""});
            table19.AddRow(new string[] {
                        "profile",
                        "true",
                        "name"});
#line 147
 testRunner.And("the scopes are defined", ((string)(null)), table19, "And ");
#line 152
 testRunner.And("the id_token signature algorithm is set to none for the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.And("the id_token encrypted response alg is set to RSA1_5 for the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 154
 testRunner.And("the id_token encrypted response enc is set to A128CBC-HS256 for the client MyHoli" +
                    "days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
 testRunner.And("the scopes openid,profile are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
 testRunner.And("the grant-type implicit is supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 157
 testRunner.And("the response-types id_token are supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name"});
            table20.AddRow(new string[] {
                        "habarthierry@loki.be",
                        "thabart"});
#line 158
 testRunner.And("create a resource owner", ((string)(null)), table20, "And ");
#line 161
 testRunner.And("authenticate the resource owner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
 testRunner.And("the consent has been given by the resource owner habarthierry@loki.be for the cli" +
                    "ent MyHolidays and scopes openid,profile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "scope",
                        "response_type",
                        "client_id",
                        "redirect_uri",
                        "prompt",
                        "state",
                        "nonce"});
            table21.AddRow(new string[] {
                        "openid profile",
                        "id_token",
                        "MyHolidays",
                        "http://localhost",
                        "none",
                        "state1",
                        "parameterNonce"});
#line 164
 testRunner.When("requesting an authorization", ((string)(null)), table21, "When ");
#line 168
 testRunner.Then("the http status code is 301", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 169
 testRunner.And("decrypt the jwe parameter from the query string with the following kid 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alg"});
            table22.AddRow(new string[] {
                        "none"});
#line 170
 testRunner.And("the protected JWS header is returned", ((string)(null)), table22, "And ");
#line 173
 testRunner.And("the audience parameter with value MyHolidays is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 174
 testRunner.And("the parameter nonce with value parameterNonce is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 175
 testRunner.And("the claim sub with value habarthierry@loki.be is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
 testRunner.And("the claim name with value thabart is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get a signed and encrypted id token and check if the claims returned in the token" +
            " are correct")]
        public virtual void GetASignedAndEncryptedIdTokenAndCheckIfTheClaimsReturnedInTheTokenAreCorrect()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get a signed and encrypted id token and check if the claims returned in the token" +
                    " are correct", ((string[])(null)));
#line 178
this.ScenarioSetup(scenarioInfo);
#line 179
 testRunner.Given("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 180
 testRunner.And("the redirection uri http://localhost is assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "Kid",
                        "Alg",
                        "Operation",
                        "Kty",
                        "Use"});
            table23.AddRow(new string[] {
                        "1",
                        "RSA1_5",
                        "Encrypt",
                        "RSA",
                        "Enc"});
            table23.AddRow(new string[] {
                        "2",
                        "RS256",
                        "Sign",
                        "RSA",
                        "Sig"});
#line 181
 testRunner.And("add json web keys", ((string)(null)), table23, "And ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal",
                        "Claims"});
            table24.AddRow(new string[] {
                        "openid",
                        "true",
                        ""});
            table24.AddRow(new string[] {
                        "profile",
                        "true",
                        "name"});
#line 186
 testRunner.And("the scopes are defined", ((string)(null)), table24, "And ");
#line 191
 testRunner.And("the id_token signature algorithm is set to RS256 for the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
 testRunner.And("the id_token encrypted response alg is set to RSA1_5 for the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
 testRunner.And("the id_token encrypted response enc is set to A128CBC-HS256 for the client MyHoli" +
                    "days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
 testRunner.And("the scopes openid,profile are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 195
 testRunner.And("the grant-type implicit is supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 196
 testRunner.And("the response-types id_token are supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name"});
            table25.AddRow(new string[] {
                        "habarthierry@loki.be",
                        "thabart"});
#line 197
 testRunner.And("create a resource owner", ((string)(null)), table25, "And ");
#line 200
 testRunner.And("authenticate the resource owner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 201
 testRunner.And("the consent has been given by the resource owner habarthierry@loki.be for the cli" +
                    "ent MyHolidays and scopes openid,profile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "scope",
                        "response_type",
                        "client_id",
                        "redirect_uri",
                        "prompt",
                        "state",
                        "nonce"});
            table26.AddRow(new string[] {
                        "openid profile",
                        "id_token",
                        "MyHolidays",
                        "http://localhost",
                        "none",
                        "state1",
                        "parameterNonce"});
#line 203
 testRunner.When("requesting an authorization", ((string)(null)), table26, "When ");
#line 207
 testRunner.Then("the http status code is 301", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 208
 testRunner.And("decrypt the jwe parameter from the query string with the following kid 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 209
 testRunner.And("check the signature is correct with the kid 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alg"});
            table27.AddRow(new string[] {
                        "RS256"});
#line 210
 testRunner.And("the protected JWS header is returned", ((string)(null)), table27, "And ");
#line 213
 testRunner.And("the audience parameter with value MyHolidays is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 214
 testRunner.And("the parameter nonce with value parameterNonce is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 215
 testRunner.And("the claim sub with value habarthierry@loki.be is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 216
 testRunner.And("the claim name with value thabart is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
