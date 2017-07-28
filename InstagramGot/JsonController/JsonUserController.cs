using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGot.Models;
using Newtonsoft.Json.Linq;

namespace InstagramGot.JsonController
{ 
    class JsonUserController : IJsonUserController
    {
        public JsonUserController()
        {

        }

        /// <summary>
        /// Creates a User object from json
        /// </summary>
        public IUser MapJsonToUser(string json)
        { 
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["data"];
            IUser u = new User()
            {
                Id = long.Parse(jUser["id"].ToString()),
                Username = jUser["username"].ToString(),
                ProfilePictureUrl = jUser["profile_picture"].ToString(),
                FullName = jUser["full_name"].ToString(),
                Bio = jUser["bio"].ToString(),
                Website = jUser["website"].ToString(),
                Media = int.Parse(jUser["counts"]["media"].ToString()),
                Follows = int.Parse(jUser["counts"]["follows"].ToString()),
                FollowedBy = int.Parse(jUser["counts"]["followed_by"].ToString())
            };
            return u;
        }

        public IUserFrom MapJsonToUser(JToken jUser)
        {
            if (!jUser.HasValues) return null;

            IUserFrom u = new UserFrom()
            {
                Id = long.Parse(jUser["id"].ToString()),
                Username = jUser["username"].ToString(),
                ProfileImageUrl = jUser["profile_picture"].ToString(),
            };
            return u;
        }
    }
}
