using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.InstagramHttpClient
{
    class TagsEndPoint :InstagramHttpClient
    {
        /// <summary>
        /// Get the number of medias with specified tag.
        /// </summary>
        public static string GetTagsInfoAPICall(string tagName)
        {
            string urlParameters = endPoints[EndPointsTypes.Tags] + tagName + "/?access_token=" + context.AccessToken;

            var response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }

        /// <summary>
        /// Get a list of tagget recent media
        /// </summary>
        public static string GetRecentMediasWithTagAPICall(string tagName, int count = 0)
        {
            string urlParameters = endPoints[EndPointsTypes.Tags] + tagName + "/media/recent" + "/?access_token=" + context.AccessToken;

            if (count != 0)
                urlParameters += "&count=" + count.ToString();

            var response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }

        /// <summary>
        /// Get a list of matching tags.
        /// </summary>
        public static string SearchTagAPICall(string tagName)
        {
            string urlParameters = endPoints[EndPointsTypes.Tags] + "?q=" + tagName + "&access_token=" + context.AccessToken;

            var response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }
    }
}
