using System.Collections.Generic;
using InstagramGot.Models;

namespace InstagramGot.QueryExecutor
{
    interface ILikesQueryExecutor
    {
        bool DeleteLike(string mediaId);
        List<IMinifiedUser> GetLikesFromMedia(string id);
        bool PostLikeToMedia(string mediaId);
    }
}