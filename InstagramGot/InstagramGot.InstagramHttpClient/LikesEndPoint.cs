using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.InstagramHttpClient
{
    class LikesEndPoint : InstagramHttpClient
    {
        /// <summary>
        /// Get the users who liked the specified media.
        /// </summary>
        public static string GetLikesAPICall(string mediaId)
        {
            string urlParameters = String.Format(endPoints[EndPointsTypes.Likes], mediaId) + "?access_token=" + context.AccessToken;

            var response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }

        /// <summary>
        /// Post a like.
        /// </summary
        public static bool PostLikeAPICall(string mediaId)
        {
            // Format url parameters
            string urlParameters = String.Format(endPoints[EndPointsTypes.Likes], mediaId) + "?access_token=" + context.AccessToken;

            // Post request
            var response = client.PostAsync(urlParameters, null).Result;

            ReadRespone(response);

            // If status code is not 200 ReadRespones already throws an exception
            return true;
        }

        /// <summary>
        /// Delete an specific like.
        /// </summary>
        public static bool DeleteLikeAPICall(string mediaId)
        {
            string urlParameters = String.Format(endPoints[EndPointsTypes.Likes], mediaId) + "?access_token=" + context.AccessToken;

            var response = client.DeleteAsync(urlParameters).Result;

            ReadRespone(response);

            // If status code is not 200 ReadRespones already throws an exception
            return true;
        }
    }
}
