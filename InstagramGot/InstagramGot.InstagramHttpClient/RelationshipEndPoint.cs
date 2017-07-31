using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.InstagramHttpClient
{
    class RelationshipEndPoint : InstagramHttpClient
    {
        /// <summary>
        /// Api Call at relationship endpoint.
        /// </summary>
        /// <param name="parameters">Parameters of url</param>
        /// <param name="action">follow | unfollow | approve | ignore, if parameter is set then thr call will be a post in order to modify the relationship</param>
        public static string RealationshipAPICall(string id, string action = "")
        {
            // Format parameters
            HttpResponseMessage response = null;

            // Format final request
            string urlParameters = String.Format(endPoints[EndPointsTypes.Relationships], id) + "?access_token=" + context.AccessToken;

            if (action == "")
            {
                // GET (get info of a relation ship
                response = client.GetAsync(urlParameters).Result;
            }
            else
            {
                // POST (create or modifie a relation ship)
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("action", action)
                });

                response = client.PostAsync(urlParameters, content).Result;
            }

            return ReadRespone(response);
        }

        /// <summary>
        /// Call to get the list of users who you are following.
        /// </summary>
        /// <returns></returns>
        public static string GetFollowsAPICall()
        {
            // Format final request
            string urlParameters = endPoints[EndPointsTypes.Follows] + "?access_token=" + context.AccessToken;

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            return ReadRespone(response);
        }

        /// <summary>
        /// Call to get users who follows you
        /// </summary>
        /// <returns></returns>
        public static string GetFollowedByAPICall()
        {
            // Format final request
            string urlParameters = endPoints[EndPointsTypes.FollowedBy] + "?access_token=" + context.AccessToken;

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }

        /// <summary>
        /// Call to get the users who resquested to follow.
        /// </summary>
        /// <returns></returns>
        public static string GetRequestedByAPICall()
        {
            // Format final request
            string urlParameters = endPoints[EndPointsTypes.RequestedBy] + "?access_token=" + context.AccessToken;

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }

    }
}
