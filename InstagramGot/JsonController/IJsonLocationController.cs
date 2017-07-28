using InstagramGot.Models;
using Newtonsoft.Json.Linq;

namespace InstagramGot.JsonController
{
    internal interface IJsonLocationController
    {
        ILocation MapJsonToLocation(string json);
        ILocation MapJsonToLocation(JToken json);
    }
}