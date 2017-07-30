using System;
using System.Collections.Generic;
using System.Linq;
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
            string parameters = "";

            if(action == "")
            {
                // GET (get info of a relation ship
                parameters = "";
            }
            else
            {
                // POST (create or modifie a relation ship)
                parameters = "&action=" + action;
            }

            // Format final request
            string urlParameters = String.Format(endPoints[EndPointsTypes.Relationships],id) + "?access_token=" + context.AccesToken + parameters;

            return ReadRespone(client, urlParameters);
        }

        /// <summary>
        /// Call to get the list of users who you are following.
        /// </summary>
        /// <returns></returns>
        public static string GetFollowsAPICall()
        {
            // Format final request
            string urlParameters = endPoints[EndPointsTypes.Follows] + "?access_token=" + context.AccesToken;

            return ReadRespone(client, urlParameters);
        }

        /// <summary>
        /// Call to get users who follows you
        /// </summary>
        /// <returns></returns>
        public static string GetFollowedByAPICall()
        {
            // Format final request
            string urlParameters = endPoints[EndPointsTypes.FollowedBy] + "?access_token=" + context.AccesToken;

            return ReadRespone(client, urlParameters);
        }

        /// <summary>
        /// Call to get the users who resquested to follow.
        /// </summary>
        /// <returns></returns>
        public static string GetRequestedByAPICall()
        {
            // Format final request
            string urlParameters = endPoints[EndPointsTypes.RequestedBy] + "?access_token=" + context.AccesToken;

            return ReadRespone(client, urlParameters);
        }

    }
}
