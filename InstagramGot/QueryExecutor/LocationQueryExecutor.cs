using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.QueryExecutor
{
    class LocationQueryExecutor : ILocationQueryExecutor
    {
        private JsonController.IJsonLocationController locationController;
        private JsonController.IJsonMediaController mediaController;

        public LocationQueryExecutor()
        {
            locationController = new JsonController.JsonLocationController();
            mediaController = new JsonController.JsonMediaController();
        }

        /// <summary>
        /// Get location info.
        /// </summary>
        public Models.ILocation GetLocationInfo(long id)
        {
            try
            {
                return locationController.MapJsonToLocation(InstagramHttpClient
                                                            .LocationEndPoint
                                                            .GetLocationInfoAPICall(id));
            }
            catch(Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get a lsit of medias from given location.
        /// </summary>
        public List<Models.IMedia> GetLocationMedias(long id, int count = 0)
        {
            try
            {
                return mediaController.MapJsonToMedias(InstagramHttpClient
                                                            .LocationEndPoint
                                                            .GetRecentMediasWithLocationAPICall(id, count));
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
