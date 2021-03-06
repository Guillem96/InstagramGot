﻿using InstagramGot.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.JsonController
{
    internal class JsonMediaController : IJsonMediaController
    {
        private IJsonUserController userJson = new JsonUserController();

        /// <summary>
        /// Return a media list pared from json string
        /// </summary>
        public List<IMedia> MapJsonToMedias(string json)
        {
            List<IMedia> medias = new List<IMedia>();
            JObject jObject = JObject.Parse(json);

            var arr = jObject.Children<JProperty>().FirstOrDefault(x => x.Name == "data").Value;
            foreach(var token in arr.Children())
            {
                medias.Add(MapJsonToMedia(token));
            }

            return medias;
        }

        /// <summary>
        /// One media from json
        /// </summary>
        public IMedia MapJsonToMedia(string json)
        {
            IMedia m = new Models.Media();
            JObject jObject = JObject.Parse(json);
            JToken jMedia = jObject["data"];

            m.CreatedBy = userJson.MapJsonToMinifiedUser(jMedia["user"]);
            m.ImageThumbnailUrl = jMedia["images"]["thumbnail"]["url"].ToString();
            m.ImageLowResolutionUrl = jMedia["images"]["low_resolution"]["url"].ToString();
            m.ImageStandardResolutionUrl = jMedia["images"]["standard_resolution"]["url"].ToString();
            m.Id = jMedia["id"].ToString();
            m.Text = jMedia["caption"]["text"].ToString();
            m.CreatedTimeUnixMiliseconds = long.Parse(jMedia["caption"]["created_time"].ToString()) * 1000;
            m.LikesCount = int.Parse(jMedia["likes"]["count"].ToString());

            m.Tags = new List<string>();
            foreach (var token in jMedia["tags"])
            {
                m.Tags.Add(token.ToString());
            }
            m.CommentsCount = int.Parse(jMedia["comments"]["count"].ToString());
            m.MediaUrl = jMedia["link"].ToString();
            m.Location = new JsonLocationController().MapJsonToLocation(jMedia["location"]);

            m.UsersInPhoto = new List<IMinifiedUser>();
            foreach(var token in jMedia["users_in_photo"].Children())
            {
                m.UsersInPhoto.Add(userJson.MapJsonToMinifiedUser(token["user"]));
            }
            return m;
        }

        /// <summary>
        ///  Returns a media from a JToken
        /// </summary>
        public IMedia MapJsonToMedia(JToken jMedia)
        {
            if (!jMedia.HasValues) return null;

            IMedia m = new Models.Media()
            {
                CreatedBy = userJson.MapJsonToMinifiedUser(jMedia["user"]),
                ImageThumbnailUrl = jMedia["images"]["thumbnail"]["url"].ToString(),
                ImageLowResolutionUrl = jMedia["images"]["low_resolution"]["url"].ToString(),
                ImageStandardResolutionUrl = jMedia["images"]["standard_resolution"]["url"].ToString(),
                Id = jMedia["id"].ToString(),
                Text = jMedia["caption"]["text"].ToString(),
                CreatedTimeUnixMiliseconds = long.Parse(jMedia["caption"]["created_time"].ToString()) * 1000,
                LikesCount = int.Parse(jMedia["likes"]["count"].ToString()),
                CommentsCount = int.Parse(jMedia["comments"]["count"].ToString()),
                MediaUrl = jMedia["link"].ToString(),
                Location = new JsonLocationController().MapJsonToLocation(jMedia["location"]),

                UsersInPhoto = new List<IMinifiedUser>()
            };
            // Add tags
            m.Tags = new List<string>();
            foreach (var token in jMedia["tags"].Children())
            {
                m.Tags.Add(token.ToString());
            }
            // Add users in photo
            m.UsersInPhoto = new List<IMinifiedUser>();
            foreach (var token in jMedia["users_in_photo"].Children())
            {
                m.UsersInPhoto.Add(userJson.MapJsonToMinifiedUser(token["user"]));
            }
            return m;
        }
    }
}
