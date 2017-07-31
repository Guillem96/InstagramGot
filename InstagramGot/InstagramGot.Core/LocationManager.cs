using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot
{
    public static class LocationManager
    {
        private static QueryExecutor.ILocationQueryExecutor locationExecutor = new QueryExecutor.LocationQueryExecutor();

        /// <summary>
        /// Get the info of location given
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Instagram api not allowed request.</exception>
        public static Models.ILocation GetLocationInfo(long id)
        {
            try
            {
                return locationExecutor.GetLocationInfo(id);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get a list of media near to the given location
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Instagram api not allowed request.</exception>
        public static List<Models.IMedia> GetMediaNearLocation(long id, int count = 0)
        {
            try
            {
                return locationExecutor.GetLocationMedias(id, count);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }
    }
}
