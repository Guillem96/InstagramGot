using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGot.Auth;
using InstagramGot.QueryExecutor;

namespace InstagramGot
{
    public class UserManager
    {
        private static IUserQueryExecutor userQueryExecutor = new UserQueryExecutor();
        private static Auth.IAuthContext authContext;

        /// <summary>
        /// Current Authorization Context
        /// </summary>
        public static IAuthContext AuthContext { get => authContext; set => authContext = value; }

        /// <summary>
        /// Authenticated user
        /// </summary>
        public static Models.IUser GetAuthenticatedUser()
        {
            if (AuthContext != null)
                return userQueryExecutor.GetAuthenticatedUser();
            else
                throw new Exceptions.AuthorizationException("Not authorized");
        }

        /// <summary>
        /// Gets the user with an specific id.
        /// </summary>
        public static Models.IUser GetUser(long id)
        {
            if (AuthContext != null)
                return userQueryExecutor.GetUserProfile(id);
            else
                throw new Exceptions.AuthorizationException("Not authorized");
        }

        public static List<Models.IMedia> GetRecentMedia()
        {
            if (AuthContext != null)
                return userQueryExecutor.GetUserRecentMedia();
            else
                throw new Exceptions.AuthorizationException("Not authorized");
        }
    }
}
