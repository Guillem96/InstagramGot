using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using InstagramGot.Auth;
using OpenQA.Selenium.PhantomJS;
using System.Text.RegularExpressions;

namespace InstagramGot.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestBackground
    {
        public TestContext TestContext { get; set; }

        [AssemblyInitialize()]
        public static void Initialize(TestContext tcontext)
        {
            // Set credentials from client-ID
            InstagramCredentials instaCre = new InstagramCredentials("6a5985a97e0842d3a97c80d29a761f83");
            IAuthContext context = AuthFlow.InitAuth(instaCre, "http://www.google.es");

            var token = GetTokenFromUrl(context.AuthorizationURL, "guillem_orellana", "go123456789");
            // Set the credentials
            AuthFlow.CreateCredentialsFromAccesToken(token);

            AuthFlow.SetUserCredentials();

            Assert.IsNotNull(UserManager.GetAuthenticatedUser());
        }

        [AssemblyCleanup()]
        public static void Cleanup()
        {
            
        }

        private static string GetTokenFromUrl(string url, string username, string password)
        {
            var driverService = PhantomJSDriverService.CreateDefaultService();

            driverService.HideCommandPromptWindow = true;

            driverService.LoadImages = false;
            driverService.SslProtocol = "tlsv1";
            driverService.IgnoreSslErrors = true;
            driverService.ProxyType = "https";
            driverService.Proxy = "";

            using (var phantom = new PhantomJSDriver(driverService))
            {
                phantom.Manage().Cookies.DeleteAllCookies();
                phantom.Navigate().GoToUrl(url);

                var userField = phantom.FindElementById("id_username");
                var passField = phantom.FindElementById("id_password");
                var loginButton = phantom.FindElementByClassName("button-green");

                userField.SendKeys(username);
                passField.SendKeys(password);
                loginButton.Click();

                //https://www.google.es/?gws_rd=ssl#access_token=1092362346.6a5985a.584f9dfd6b88426a8e155ef68b443b2c
                Regex regex = new Regex(@"access_token=\S+$");
                var match = regex.Match(phantom.Url);

                if (match.Success)
                {
                    return match.Value.Substring("access_token=".Length);
                }

                Assert.Fail("No token found on " + phantom.Url);

                return "";
            }
        }
    }
}
