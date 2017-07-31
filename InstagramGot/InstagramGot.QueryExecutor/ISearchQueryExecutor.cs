using System.Collections.Generic;
using InstagramGot.Models;
using InstagramGot.Parameters;

namespace InstagramGot.QueryExecutor
{
    internal interface ISearchQueryExecutor
    {
        List<IMinifiedUser> SearchUsers(ISearchUserParameters _params);
        List<IMedia> SearchMediaNearLocation(double latitude, double longitude, double distance);
        List<ITag> SearchTags(string tagName);
        List<ILocation> SearchLocations(double latitude, double longitude, double distance = 0);


    }
}