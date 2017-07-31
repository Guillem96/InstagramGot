using InstagramGot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.QueryExecutor
{
    class MediaQueryExecutor : IMediaQueryExecutor
    {
        private JsonController.IJsonMediaController jsonMediaController;

        public MediaQueryExecutor()
        {
            jsonMediaController = new JsonController.JsonMediaController();
        }

        /// <summary>
        /// Get the info of specific media.
        /// </summary>
        public IMedia MediaInfoFromID(string id)
        {
            try
            {
                return jsonMediaController.MapJsonToMedia(
                    InstagramHttpClient.MediaEndPoint.APICallId(id));
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

        public IMedia MediaInfoFromShortCode(string shortCode)
        {
            try
            {
                return jsonMediaController.MapJsonToMedia(
                    InstagramHttpClient.MediaEndPoint.APICallShortCode(shortCode));
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
