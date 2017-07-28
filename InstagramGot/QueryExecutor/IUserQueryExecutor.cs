using InstagramGot.Models;
using System.Collections.Generic;

namespace InstagramGot.QueryExecutor
{
    internal interface IUserQueryExecutor
    {
        IUser GetAuthenticatedUser();
        IUser GetUserProfile(long id);
        List<IMedia> GetUserRecentMedia(IUsersQueryParameters parameter = null);
    }
}