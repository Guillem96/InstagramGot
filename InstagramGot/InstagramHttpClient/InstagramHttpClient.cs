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
            Users, Relationships, Media, Comments, Likes
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
            { EndPointsTypes.Media, "media/" },
            { EndPointsTypes.Comments, "media/{0}/comments/" },
            { EndPointsTypes.Likes, "media/{0}/likes/" },
        };
    }
}
