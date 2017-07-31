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
    internal class InstagramHttpClient
    {
        /// <summary>
        /// Enumeration of supported endpoints
        /// </summary>
        protected enum EndPointsTypes
        {
            Users,
            Relationships,
                // Endpoints inside relationship endpoint
                Follows,
                FollowedBy,
                RequestedBy,
            Media,
            Comments,
            Likes,
            Tags,
            Locations,
        };

        protected static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://api.instagram.com/v1/")
        };

        public static Auth.IAuthContext context;

        protected static readonly Dictionary<EndPointsTypes, string> endPoints = new Dictionary<EndPointsTypes, string>
        {
            { EndPointsTypes.Users, "users/" },
            { EndPointsTypes.Relationships, "users/{0}/relationship/" },
            { EndPointsTypes.Follows, "users/self/follows/" },
            { EndPointsTypes.FollowedBy, "users/self/followed-by/" },
            { EndPointsTypes.RequestedBy, "users/self/requested-by/" },
            { EndPointsTypes.Media, "media/" },
            { EndPointsTypes.Comments, "media/{0}/comments/" },
            { EndPointsTypes.Likes, "media/{0}/likes/" },
            { EndPointsTypes.Tags, "tags/" },
            {EndPointsTypes.Locations, "locations/" }

        };

        /// <summary>
        /// Read the respones and returns a json string
        /// </summary>
        protected static string ReadRespone(HttpResponseMessage response)
        {
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
