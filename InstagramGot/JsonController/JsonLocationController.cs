using InstagramGot.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.JsonController
{
    internal class JsonLocationController : IJsonLocationController
    {
        public JsonLocationController()
        {

        }

        /// <summary>
        /// Creates a Location object from json text.
        /// </summary>
        public ILocation MapJsonToLocation(string json)
        {
            ILocation l = new Location();
            JObject jObject = JObject.Parse(json);
            JToken jLocation = jObject["location"];
            l.Id = long.Parse(jLocation["id"].ToString());
            l.Latitude = long.Parse(jLocation["latitude"].ToString());
            l.Longitude = long.Parse(jLocation["longitude"].ToString());
            l.Name = jLocation["name"].ToString();
            return l;
        }

        public ILocation MapJsonToLocation(JToken jLocation)
        {
            if (!jLocation.HasValues) return null;

            ILocation l = new Location()
            {
                Id = long.Parse(jLocation["id"].ToString()),
                Latitude = double.Parse(jLocation["latitude"].ToString()),
                Longitude = double.Parse(jLocation["longitude"].ToString()),
                Name = jLocation["name"].ToString()
            };

            return l;
        }
    }
}
