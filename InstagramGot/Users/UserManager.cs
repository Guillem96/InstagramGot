using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Users
{
    public static class UserManager
    {
        /// <summary>
        /// Authenticated user
        /// </summary>
        public static Models.User AuthenticatedUser { get; set; }
    }
}
