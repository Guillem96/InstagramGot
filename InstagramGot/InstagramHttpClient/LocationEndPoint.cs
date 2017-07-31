using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.InstagramHttpClient
{
    class LocationEndPoint : InstagramHttpClient
    {
        /// <summary>
        /// Get the number of medias with specified tag.
        /// </summary>
        public static string GetLocationInfoAPICall(long id)
        {
            string urlParameters = endPoints[EndPointsTypes.Locations] + id.ToString() + "/?access_token=" + context.AccessToken;

            var response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }

        /// <summary>
        /// Get a list of recent media at location
        /// </summary>
        public static string GetRecentMediasWithLocationAPICall(long locationId, int count = 0)
        {
            string urlParameters = endPoints[EndPointsTypes.Locations] + locationId.ToString() + "/media/recent" + "/?access_token=" + context.AccessToken;

            if (count != 0)
                urlParameters += "&count=" + count.ToString();

            var response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }

        /// <summary>
        /// Get a list of locations.
        /// </summary>
        public static string SearchLocationAPICall(double lat, double lng, double distance = 0)
        {
            string urlParameters = endPoints[EndPointsTypes.Locations] + "search/" +
                                    "?lat=" + lat.ToString("0.00", new CultureInfo("en-US", false)) +
                                    "&lng=" + lng.ToString("0.00", new CultureInfo("en-US", false)) +
                                    (distance == 0 ? "" : "&distance=" + distance.ToString("0.00", new CultureInfo("en-US", false))) +
                                    "&access_token=" + context.AccessToken;

            var response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }
    }
}
