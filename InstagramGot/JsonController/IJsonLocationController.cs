using InstagramGot.Models;
using Newtonsoft.Json.Linq;

namespace InstagramGot.JsonController
{
    interface IJsonLocationController
    {
        ILocation MapJsonToLocation(string json);
        ILocation MapJsonToLocation(JToken json);
    }
}