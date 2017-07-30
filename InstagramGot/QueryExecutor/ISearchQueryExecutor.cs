using System.Collections.Generic;
using InstagramGot.Models;
using InstagramGot.Parameters;

namespace InstagramGot.QueryExecutor
{
    internal interface ISearchQueryExecutor
    {
        List<IMinifiedUser> SearchUsers(ISearchUserParameters _params);
    }
}