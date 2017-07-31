using InstagramGot.QueryExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGot.Parameters;

namespace InstagramGot
{
    public static class SearchManager
    {
        private static ISearchQueryExecutor searchQueryExecutor = new SearchQueryExecutor();

        /// <summary>
        /// Get list of users(with minified data) who match with specified query.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Instagram api exception.</exception>
        public static List<Models.IMinifiedUser> GetUsers(ISearchUserParameters _params)
        {
            try
            {
                return searchQueryExecutor.SearchUsers(_params);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get a list of medias near the location
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lng">Longitude</param>
        /// <param name="distance">Distance in meters, max = 5000</param>
        /// <exception cref="Exceptions.InstagramAPICallException">Instagram api exception.</exception>
        public static List<Models.IMedia> GetMediasNearLocation(double lat, double lng, double distance = 0)
        {
            try
            {
                return searchQueryExecutor.SearchMediaNearLocation(lat, lng, distance);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get a list of tags
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Instagram api exception.</exception>
        public static List<Models.ITag> GetTags(string name)
        {
            try
            {
                return searchQueryExecutor.SearchTags(name);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get a list of locations
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lng">Longitude</param>
        /// <param name="distance">Distance in meters, max = 5000</param>
        /// <exception cref="Exceptions.InstagramAPICallException">Instagram api exception.</exception>
        public static List<Models.ILocation> GetLocations(double lat, double lng, double distance = 0)
        {
            try
            {
                return searchQueryExecutor.SearchLocations(lat, lng, distance);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }
    }
}
