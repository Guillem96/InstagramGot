using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGot.QueryExecutor;

namespace InstagramGot
{
    public static class MediaManager
    {
        private static IMediaQueryExecutor mediaQueryExecutor = new MediaQueryExecutor();

        /// <summary>
        /// Get the infor of a specific media.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">API Call not allowed.</exception>
        public static Models.IMedia GetMediaInfoFromID(string id)
        {
            try
            {
                return mediaQueryExecutor.MediaInfoFromID(id);
            }
            catch(Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Media info from shortcode. Shortcode can be found on media url
        /// </summary>
        public static Models.IMedia GetMediaInfoFromShortCode(string shortCode)
        {
            try
            {
                return mediaQueryExecutor.MediaInfoFromShortCode(shortCode);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }
    }
}
