using InstagramGot.Models;
using System.Collections.Generic;
using InstagramGot.Parameters;

namespace InstagramGot.QueryExecutor
{
    internal interface IUserQueryExecutor
    {
        IUser GetAuthenticatedUser();
        IUser GetUserProfile(long id);
        List<IMedia> GetUserRecentMedia(IUsersQueryParameters parameter = null);
        List<IMedia> GetUserRecentMedia(int count);
        List<IMedia> GetUserLikedMedia(int count);
    }
}