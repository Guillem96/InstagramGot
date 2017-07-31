using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot
{
    public static class CommentsManager
    {
        private static QueryExecutor.ICommentsQueryExecutor commentExecutor = new QueryExecutor.CommentsQueryExecutor();

        /// <summary>
        /// Get all comments from a media.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">API Call not allowed</exception>
        public static List<Models.IComment> GetCommentsFromMedia(string mediaId)
        {
            try
            {
                return commentExecutor.GetCommentsFromMedia(mediaId);
            }
            catch(Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Post a comment to a media.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">API Call not allowed</exception>
        /// <exception cref="Exceptions.CommentFormatException">Comment text incorrect.</exception>
        public static bool PostCommentToMedia(string mediaId, string text)
        {
            try
            {
                return commentExecutor.PostCommentToMedia(mediaId, text);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
            catch (Exceptions.CommentFormatException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Delete a comment.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">API Call not allowed</exception>
        public static bool DeleteComment(string mediaId, long commentId)
        {
            try
            {
                return commentExecutor.DeleteComment(mediaId, commentId);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }
    }
}
