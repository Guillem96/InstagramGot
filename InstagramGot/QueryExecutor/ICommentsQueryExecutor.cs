using System.Collections.Generic;
using InstagramGot.Models;

namespace InstagramGot.QueryExecutor
{
    interface ICommentsQueryExecutor
    {
        bool DeleteComment(string mediaId, long commentId);
        List<IComment> GetCommentsFromMedia(string id);
        bool PostCommentToMedia(string mediaId, string text);
    }
}