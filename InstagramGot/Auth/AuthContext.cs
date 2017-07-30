using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Auth
{
    internal class AuthContext : IAuthContext
    {
        public string AuthorizationURL { get; set; }
        public string AccesToken { get; set; }

        public static IAuthContext AuthContextFromCredentials(InstagramCredentials credentials, string callbackUrl)
        {
            return new AuthContext()
            {
                AuthorizationURL = GetAuthUrl(credentials, callbackUrl)
            };
        }

        /// <summary>
        /// Get the authorization url.
        /// </summary>
        private static string GetAuthUrl(InstagramCredentials appCredentials, string callbackUrl)
        {
            return String.Format("https://api.instagram.com/oauth/authorize/" +
                                    "?client_id={0}" +
                                    "&redirect_uri={1}" +
                                    "&response_type=token", appCredentials.ClientID, callbackUrl) +
                                    "&scope=public_content+follower_list+relationships";
        }


    }
}
