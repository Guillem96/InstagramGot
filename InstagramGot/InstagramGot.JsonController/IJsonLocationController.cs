using InstagramGot.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace InstagramGot.JsonController
{
    interface IJsonLocationController
    {
        ILocation MapJsonToLocation(string json);
        ILocation MapJsonToLocation(JToken json);
        List<ILocation> MapJsonToLocations(string json);
    }
}