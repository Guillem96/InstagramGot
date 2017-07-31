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
        private JsonController.IJsonMediaController mediaJsonController;
        private JsonController.IJsonTagsController tagsJsonController;
        private JsonController.IJsonLocationController locationJsonController;

        public SearchQueryExecutor()
        {
            userJsonController = new JsonController.JsonUserController();
            mediaJsonController = new JsonController.JsonMediaController();
            tagsJsonController = new JsonController.JsonTagsController();
            locationJsonController = new JsonController.JsonLocationController();
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

        /// <summary>
        /// Returns a list of recent medias near to the specified location.
        /// </summary>
        /// <param name="distance">Distance in meters, max = 5000</param>
        public List<IMedia> SearchMediaNearLocation(double latitude, double longitude, double distance = 0)
        {
            try
            {

                return mediaJsonController.MapJsonToMedias (MediaEndPoint
                                                                .SearchMediaAPICall(latitude, 
                                                                                    longitude, 
                                                                                    distance));
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


        public List<ITag> SearchTags(string tagName)
        {
            try
            {

                return tagsJsonController.MapJsonToTags(TagsEndPoint
                                                                .SearchTagAPICall(tagName));
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


        /// <summary>
        /// Returns a list of locations near to the given one.
        /// </summary>
        /// <param name="distance">Distance in meters, max = 5000</param>
        public List<ILocation> SearchLocations(double latitude, double longitude, double distance = 0)
        {
            try
            {

                return locationJsonController.MapJsonToLocations(
                                                        LocationEndPoint
                                                            .SearchLocationAPICall(latitude,
                                                                                    longitude,
                                                                                    distance));
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
