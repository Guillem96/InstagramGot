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
            JToken jLocation = jObject["data"];
            l.Id = long.Parse(jLocation["id"].ToString());
            l.Latitude = double.Parse(jLocation["latitude"].ToString());
            l.Longitude = double.Parse(jLocation["longitude"].ToString());
            l.Name = jLocation["name"].ToString();
            return l;
        }

        /// <summary>
        /// Creates a location from an existing json token
        /// </summary>
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

        /// <summary>
        /// Creates a list of locations from a json string
        /// </summary>
        public List<ILocation> MapJsonToLocations(string json)
        {
            List<ILocation> locations = new List<ILocation>();
            JObject jObject = JObject.Parse(json);

            var arr = jObject.Children<JProperty>().FirstOrDefault(x => x.Name == "data").Value;
            foreach (var token in arr.Children())
            {
                locations.Add(MapJsonToLocation(token));
            }

            return locations;
        }
    }
}
