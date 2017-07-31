using InstagramGot.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace InstagramGot.JsonController
{
    interface IJsonTagsController
    {
        ITag MapJsonToTag(string json);
        ITag MapJsonToTag(JToken json);
        List<ITag> MapJsonToTags(string json);
    }
}