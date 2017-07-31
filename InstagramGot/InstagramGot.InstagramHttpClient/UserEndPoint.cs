using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.InstagramHttpClient
{
    class UserEndPoint : InstagramHttpClient
    {
        /// <summary>
        /// Api Call at users endpoint.
        /// </summary>
        /// <param name="parameters">Parameters of url</param>
        /// <returns></returns>
        public static string APICall(string id, Dictionary<string, string> parametersDic = null)
        {
            // Format parameters
            string parameters = "";

            // If dictionary parameters has values
            if (parametersDic != null)
            {
                // Concat parameters to string parameter
                foreach (var parameter in parametersDic)
                    parameters += "&" + parameter.Key + "=" + parameter.Value;
            }
            
            // Format final request
            string urlParameters = endPoints[EndPointsTypes.Users] + id + "/?access_token=" + context.AccessToken + parameters;

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }

        public static string ApiCallSearch(string query, int count = 0)
        {

            string urlParameters = endPoints[EndPointsTypes.Users] + "search?q=" + query + 
                                    (count != 0 ? "&count=" + count.ToString() : "") + 
                                    "&access_token=" + context.AccessToken;

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            var s = ReadRespone(response);
            return s;

        }
    }
}
