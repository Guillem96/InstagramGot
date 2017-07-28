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

            if (parametersDic != null)
            {
                foreach (var parameter in parametersDic)
                {
                    parameters += "&" + parameter.Key + "=" + parameter.Value;
                }
            }
            
            string urlParameters = endPoints[EndPointsTypes.Users] + id + "/?access_token=" + context.AccesToken;

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
