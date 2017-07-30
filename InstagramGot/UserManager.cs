using System.Collections.Generic;
using InstagramGot.Auth;
using InstagramGot.QueryExecutor;
using InstagramGot.Parameters;

namespace InstagramGot
{
    public class UserManager
    {
        private static IUserQueryExecutor userQueryExecutor = new UserQueryExecutor();
        private static Auth.IAuthContext authContext;
        private static Models.IUser authUser;

        /// <summary>
        /// Current Authorization Context
        /// </summary>
        public static IAuthContext AuthContext { get => authContext; set => authContext = value; }

        /// <summary>
        /// Authenticated user
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public static Models.IUser GetAuthenticatedUser()
        {
            try
            {
                if (AuthContext != null)
                {
                    if (authUser == null)
                        authUser = userQueryExecutor.GetAuthenticatedUser();

                    return authUser;
                }
                else
                    throw new Exceptions.AuthorizationException("Not authorized");
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the user with an specific id.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public static Models.IUser GetUser(long id)
        {
            try
            {
                if (AuthContext != null)
                    return userQueryExecutor.GetUserProfile(id);
                else
                    throw new Exceptions.AuthorizationException("Not authorized");
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get recent media from authenticated user.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public static List<Models.IMedia> GetRecentMedia(int count = 0)
        {
            try
            {
                if (AuthContext != null)
                {
                    if (count != 0)
                        return userQueryExecutor.GetUserRecentMedia(count);
                    else
                        return userQueryExecutor.GetUserRecentMedia();

                }
                else
                    throw new Exceptions.AuthorizationException("Not authorized");
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Get recent media of the user specified at parmeters.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public static List<Models.IMedia> GetRecentMedia(IUsersQueryParameters _params)
        {
            try
            {
                if (AuthContext != null)
                {
                    return userQueryExecutor.GetUserRecentMedia(_params);
                }
                else
                    throw new Exceptions.AuthorizationException("Not authorized");
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get liked media of the user specified at parmeters.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public static List<Models.IMedia> GetLikedMedia(int count = 0)
        {
            try
            {
                if (AuthContext != null)
                {
                    return userQueryExecutor.GetUserLikedMedia(count);
                }
                else
                    throw new Exceptions.AuthorizationException("Not authorized");
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }
    }
}
