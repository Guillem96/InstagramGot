using System;
using System.Collections.Generic;
using InstagramGot.InstagramHttpClient;
using InstagramGot.Models;
using InstagramGot.Parameters;

namespace InstagramGot.QueryExecutor
{
    internal class SearchQueryExecutor : ISearchQueryExecutor
    {
        private JsonController.IJsonUserController userJsonController;

        public SearchQueryExecutor()
        {
            userJsonController = new JsonController.JsonUserController();
        }

        /// <summary>
        /// Return a list of users who match with the specified query. (MinifiedUser)
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Authorization error related to application.</exception>
        public List<IMinifiedUser> SearchUsers(ISearchUserParameters _params)
        {
            try
            {
                // If no parameters or not query -> Invalid request
                if (_params == null) return null;
                if (_params.Query == null) return null;

                // No count
                if (_params.Count == null)
                    return userJsonController.MapJsonToMinifiedUsers(UserEndPoint.
                                                                        ApiCallSearch(_params.Query));
                // With count
                else
                    return userJsonController.MapJsonToMinifiedUsers(UserEndPoint.
                                                                        ApiCallSearch(_params.Query, _params.Count.Value));
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
            catch (Exception)
            {
                return null;
            }
        }  
    }
}
