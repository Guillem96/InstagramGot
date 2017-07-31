using System.Collections.Generic;
using InstagramGot.Models;
using Newtonsoft.Json.Linq;

namespace InstagramGot.JsonController
{
    interface IJsonCommentController
    {
        IComment MapJsonToComment(JToken jComment);
        List<IComment> MapJsonToComments(string json);
    }
}