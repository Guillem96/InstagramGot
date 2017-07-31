using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.InstagramHttpClient
{
    class MediaEndPoint : InstagramHttpClient
    {
        /// <summary>
        /// Get information of media with an specific id
        /// </summary>
        public static string APICallId(string id)
        {
            string urlParameters = endPoints[EndPointsTypes.Media] + id + "?access_token=" + context.AccessToken;

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }

        /// <summary>
        /// Get information of media with an specific shortcode
        /// </summary>
        public static string APICallShortCode(string shortCode)
        {
            string urlParameters = endPoints[EndPointsTypes.Media] + "shortcode/"+ shortCode + "?access_token=" + context.AccessToken;

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }

        /// <summary>
        /// Search recent media near the specified location
        /// </summary>
        /// <param name="distance">In meters, max = 5000</param>
        public static string SearchMediaAPICall(double latitude, double longitude, double distance = 0)
        {
            string urlParameters = endPoints[EndPointsTypes.Media] + "search/" +
                                    "?lat=" + latitude.ToString("0.00", new CultureInfo("en-US", false)) + 
                                    "&lng=" + longitude.ToString("0.00", new CultureInfo("en-US", false)) + 
                                    (distance == 0 ? "" : "&distance=" + distance.ToString("0.00", new CultureInfo("en-US", false))) + 
                                    "&access_token=" + context.AccessToken;

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }
    }
}
