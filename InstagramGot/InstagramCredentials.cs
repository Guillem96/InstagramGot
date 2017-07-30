using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot
{
    public class InstagramCredentials
    {
        private string clientID;

        public string ClientID { get => clientID; set => clientID = value; }

        /// <param name="clientID">Client ID from api application</param>
        public InstagramCredentials(string clientID)
        {
            this.ClientID = clientID;
        }
    }
}
