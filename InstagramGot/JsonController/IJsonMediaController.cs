using System.Collections.Generic;
using InstagramGot.Models;
using Newtonsoft.Json.Linq;

namespace InstagramGot.JsonController
{
    internal interface IJsonMediaController
    {
        IMedia MapJsonToMedia(JToken jMedia);
        IMedia MapJsonToMedia(string json);
        List<IMedia> MapJsonToMedias(string json);
    }
}