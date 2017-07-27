using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Auth
{
    class InstagramCredentials
    {
        private string clientID;
        private string clientSecret;

        /// <param name="clientID">Client ID from api application</param>
        /// <param name="clientSecret">Client Secret Id from api application</param>
        public InstagramCredentials(string clientID, string clientSecret)
        {
            this.clientID = clientID;
            this.clientSecret = clientSecret;
        }
    }
}
