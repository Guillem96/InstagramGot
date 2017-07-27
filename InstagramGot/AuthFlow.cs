using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGot.Auth;

namespace InstagramGot
{
    /// <summary>
    /// Auth manager
    /// </summary>
    public static class AuthFlow
    {
        private static AuthContext authContext;

        /// <summary>
        /// Creates an authorization url for the authcontext.
        /// </summary>
        /// <param name="appCredentials">InstagramCredential object</param>
        /// <param name="callbackUrl">Application's callback url</param>
        public static AuthContext InitAuth(InstagramCredentials appCredentials, string callbackUrl)
        {
            authContext =  new AuthContext()
            {
                AuthorizationURL = GetAuthUrl(appCredentials, callbackUrl)
            };

            return authContext;
        }

        /// <summary>
        /// Set acces token at auth context
        /// </summary>
        /// <param name="accesToken">Parameter acces_token from the redirected url</param>
        public static void CreateCredentialsFromAccesToken(string accesToken)
        {
            // Set the acces token
            authContext.AccesToken = accesToken;

            // Set to httpclient the acces token
            InstagramHttpClient.InstagramHttpClient.context = authContext;
        }

        public static Models.User SetUserCredentials()
        {
            string json = InstagramHttpClient.InstagramHttpClient.APICallUsersEndpoint("self");
            Users.UserManager.AuthenticatedUser = new Models.User(json);
            return Users.UserManager.AuthenticatedUser;
        }

        /// <summary>
        /// Get the authorization url.
        /// </summary>
        private static string GetAuthUrl(InstagramCredentials appCredentials, string callbackUrl)
        {
            return String.Format("https://api.instagram.com/oauth/authorize/" +
                                    "?client_id={0}" +
                                    "&redirect_uri={1}" +
                                    "&response_type=token", appCredentials.ClientID, callbackUrl);
        }


    }
}
