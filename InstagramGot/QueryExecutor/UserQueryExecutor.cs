using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGot.InstagramHttpClient;

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
        public Models.IUser GetAuthenticatedUser()
        {
            try
            {
                return userJsonController
                            .MapJsonToUser(UserEndPoint.APICall("self"));
            }
            catch (Exceptions.InstagramAPICallException )
            {
                return null;
            }
            catch (Exception )
            {
                return null;
            }
        }

        public Models.IUser GetUserProfile(long id)
        {
            try
            {
                return userJsonController
                            .MapJsonToUser(UserEndPoint.APICall(id.ToString()));
            }
            catch (Exceptions.InstagramAPICallException )
            {
                return null;
            }
            catch (Exception )
            {
                return null;
            }
        }

        public List<Models.IMedia> GetUserRecentMedia(IUsersQueryParameters parameter = null)
        {
            try
            {
                if(parameter != null)
                {
                    return mediaJsonController
                            .MapJsonToMedias(UserEndPoint.APICall(parameter.Id.ToString()+ "/media/recent", 
                                            new Dictionary<string, string>() { { "count", parameter.Count.ToString() } }));
                }
                return mediaJsonController
                            .MapJsonToMedias(UserEndPoint.APICall("self/media/recent"));
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
