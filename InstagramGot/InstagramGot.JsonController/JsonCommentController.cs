using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.JsonController
{
    class JsonCommentController : IJsonCommentController
    {
        private IJsonUserController jsonUserController;

        public JsonCommentController()
        {
            jsonUserController = new JsonUserController();
        }

        public List<Models.IComment> MapJsonToComments(string json)
        {
            List<Models.IComment> comments = new List<Models.IComment>();
            JObject jObject = JObject.Parse(json);

            var arr = jObject.Children<JProperty>().FirstOrDefault(x => x.Name == "data").Value;
            foreach (var token in arr.Children())
            {
                comments.Add(MapJsonToComment(token));
            }

            return comments;
        }

        public Models.IComment MapJsonToComment(JToken jComment)
        {
            return new Models.Comment()
            {
                Id = long.Parse(jComment["id"].ToString()),
                Text = jComment["text"].ToString(),
                From = jsonUserController.MapJsonToMinifiedUser(jComment["from"]),
                CreatedTimeUnixMiliseconds = long.Parse(jComment["created_time"].ToString()) * 1000,
            };
        }


    }
}
