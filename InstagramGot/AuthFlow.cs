using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGot.Auth;
using InstagramGot.QueryExecutor;

namespace InstagramGot
{
    /// <summary>
    /// Auth manager
    /// </summary>
    public static class AuthFlow
    {
        private static IAuthContext authContext;
        private static IUserQueryExecutor userQueryExecutor = new UserQueryExecutor();

        /// <summary>
        /// Creates an authorization url for the authcontext.
        /// </summary>
        /// <param name="appCredentials">InstagramCredential object</param>
        /// <param name="callbackUrl">Application's callback url</param>
        public static IAuthContext InitAuth(InstagramCredentials appCredentials, string callbackUrl)
        {
            authContext = AuthContext.AuthContextFromCredentials(appCredentials, callbackUrl);

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

        public static Models.IUser SetUserCredentials()
        {
            UserManager.AuthContext = authContext;
            return UserManager.GetAuthenticatedUser();
        }

    }
}
