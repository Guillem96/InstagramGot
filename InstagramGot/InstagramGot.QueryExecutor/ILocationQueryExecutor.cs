using System.Collections.Generic;
using InstagramGot.Models;

namespace InstagramGot.QueryExecutor
{
    interface ILocationQueryExecutor
    {
        ILocation GetLocationInfo(long id);
        List<IMedia> GetLocationMedias(long id, int count = 0);
    }
}