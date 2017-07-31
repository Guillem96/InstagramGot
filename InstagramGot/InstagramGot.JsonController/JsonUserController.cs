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

        /// <summary>
        /// Creates a users with minified data from an existing json token
        /// </summary>
        public IMinifiedUser MapJsonToMinifiedUser(JToken jUser)
        {
            if (!jUser.HasValues) return null;

            IMinifiedUser u = new MinifiedUser()
            {
                Id = long.Parse(jUser["id"].ToString()),
                Username = jUser["username"].ToString(),
                ProfileImageUrl = jUser["profile_picture"].ToString(),
                FullName = jUser.Children<JProperty>().Any(x => x.Name == "full_name") ? jUser["full_name"].ToString() : null,
            };

            if(u.FullName == null)
            {
                u.FullName = jUser.Children<JProperty>().Any(x => x.Name == "first_name") ? jUser["first_name"].ToString() : null;
                u.FullName += jUser.Children<JProperty>().Any(x => x.Name == "last_name") ? " " + jUser["last_name"].ToString() : null;
            }

            return u;
        }

        /// <summary>
        /// Maps a json string to a list of Minified Users
        /// </summary>
        public List<IMinifiedUser> MapJsonToMinifiedUsers(string json)
        { 
            List<IMinifiedUser> users = new List<IMinifiedUser>();
            JObject jObject = JObject.Parse(json);

            var arr = jObject.Children<JProperty>().FirstOrDefault(x => x.Name == "data").Value;
            foreach (var token in arr.Children())
            {
                users.Add(MapJsonToMinifiedUser(token));
            }

            return users;
        }

        /// <summary>
        /// Maps a json string to a list of Users
        /// </summary>
        public List<IUser> MapJsonToUsers(string json)
        {
            List<IUser> users = new List<IUser>();
            JObject jObject = JObject.Parse(json);

            var arr = jObject.Children<JProperty>().FirstOrDefault(x => x.Name == "data").Value;
            foreach (var token in arr.Children())
            {
                users.Add(MapJsonToUser(token));
            }

            return users;
        }

        /// <summary>
        /// Create a new user from an existing json token
        /// </summary>
        public IUser MapJsonToUser(JToken jUser)
        {
            if (!jUser.HasValues) return null;

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
    }
}
