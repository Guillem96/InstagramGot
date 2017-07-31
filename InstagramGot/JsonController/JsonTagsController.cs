using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGot.Models;

namespace InstagramGot.JsonController
{
    class JsonTagsController : IJsonTagsController
    {
        public Models.ITag MapJsonToTag(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jTag = jObject["data"];

            return new Models.Tag()
            {
                MediaCount = int.Parse(jTag["media_count"].ToString()),
                Name = jTag["name"].ToString()
            };
        }

        public ITag MapJsonToTag(JToken jTag)
        {
            return new Models.Tag()
            {
                MediaCount = int.Parse(jTag["media_count"].ToString()),
                Name = jTag["name"].ToString()
            };
        }

        public List<ITag> MapJsonToTags(string json)
        {
            List<ITag> tags = new List<ITag>();

            JObject jObject = JObject.Parse(json);

            var arr = jObject.Children<JProperty>().FirstOrDefault(x => x.Name == "data").Value;
            foreach (var token in arr.Children())
            {
                tags.Add(MapJsonToTag(token));
            }

            return tags;
        }
    }
}
