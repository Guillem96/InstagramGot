using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGot.InstagramHttpClient;
using InstagramGot.Models;
using InstagramGot.Parameters;

namespace InstagramGot.QueryExecutor
{
    /// <summary>
    /// Execute api calls related to user
    /// </summary>
    class UserQueryExecutor : IUserQueryExecutor
    {
        private JsonController.IJsonUserController userJsonController;
        private JsonController.IJsonMediaController mediaJsonController;

        public UserQueryExecutor()
        {
            userJsonController = new JsonController.JsonUserController();
            mediaJsonController = new JsonController.JsonMediaController();
        }

        /// <summary>
        /// Make the api call to get authenticated user.
        /// If api call is incorrect returns null.
        /// </summary>
        /// <returns>Authenticated User</returns>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public Models.IUser GetAuthenticatedUser()
        {
            try
            {
                return userJsonController
                            .MapJsonToUser(UserEndPoint.APICall("self"));
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw new Exceptions.InstagramAPICallException(e.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the profile of the user with id "id".
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public Models.IUser GetUserProfile(long id)
        {
            try
            {
                return userJsonController
                            .MapJsonToUser(UserEndPoint.APICall(id.ToString()));
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw new Exceptions.InstagramAPICallException(e.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a list with recent media of specified user.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public List<Models.IMedia> GetUserRecentMedia(IUsersQueryParameters parameter = null)
        {
            try
            {
                // Some parameters specified
                if(parameter != null)
                {
                    // With only count 
                    if(parameter.Count != null)
                        return mediaJsonController
                                .MapJsonToMedias(UserEndPoint.APICall(parameter.Id.ToString()+ "/media/recent", 
                                                new Dictionary<string, string>() { { "count", parameter.Count.ToString() } }));
                    // With count and id
                    else
                        return mediaJsonController
                               .MapJsonToMedias(UserEndPoint.APICall(parameter.Id.ToString() + "/media/recent"));
                }
                // No parameters
                return mediaJsonController
                            .MapJsonToMedias(UserEndPoint.APICall("self/media/recent"));
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw new Exceptions.InstagramAPICallException(e.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns authenticated user's recent media.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public List<IMedia> GetUserRecentMedia(int count = 0)
        {
            try
            {
                if (count != 0)
                    return mediaJsonController
                            .MapJsonToMedias(UserEndPoint.APICall("self/media/recent",
                            new Dictionary<string, string>() { { "count", count.ToString() } }));
                else
                    return mediaJsonController
                            .MapJsonToMedias(UserEndPoint.APICall("self/media/recent"));
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw new Exceptions.InstagramAPICallException(e.ToString());
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// Returns authenticated user's liked media.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public List<IMedia> GetUserLikedMedia(int count = 0)
        {
            try
            {
                if (count != 0)
                    return mediaJsonController
                            .MapJsonToMedias(UserEndPoint.APICall("self/media/liked",
                            new Dictionary<string, string>() { { "count", count.ToString() } }));
                else
                    return mediaJsonController
                            .MapJsonToMedias(UserEndPoint.APICall("self/media/liked"));
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw new Exceptions.InstagramAPICallException(e.ToString());
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
