using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace InstagramGot.InstagramHttpClient
{
    /// <summary>
    /// Static class for making api calls
    /// </summary>
    static class InstagramHttpClient
    {
        /// <summary>
        /// Enumeration of supported endpoints
        /// </summary>
        private enum EndPointsTypes
        {
            Users, Relationships, Media, Comments, Likes
        };

        private static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://api.instagram.com/v1/")
        };
        public static Auth.AuthContext context;

        private static readonly Dictionary<EndPointsTypes, string> endPoints = new Dictionary<EndPointsTypes, string>
        {
            { EndPointsTypes.Users, "users/" },
            { EndPointsTypes.Relationships, "users/{0}/relationship/" },
            { EndPointsTypes.Media, "media/" },
            { EndPointsTypes.Comments, "media/{0}/comments/" },
            { EndPointsTypes.Likes, "media/{0}/likes/" },
        };

        /// <summary>
        /// Api Call at users endpoint.
        /// </summary>
        /// <param name="parameters">Parameters of url</param>
        /// <returns></returns>
        public static string APICallUsersEndpoint(string parameters)
        {
            string urlParameters = endPoints[EndPointsTypes.Users] + parameters + "/?access_token=" + context.AccesToken;

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                throw new Exceptions.InstagramAPICallException("Invalid API Call:" + response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
