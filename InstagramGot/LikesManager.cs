using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot
{
    public static class LikesManager
    {
        private static QueryExecutor.ILikesQueryExecutor likesExecutor = new QueryExecutor.LikesQueryExecutor();

        /// <summary>
        /// Get all likes from a media.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">API Call not allowed</exception>
        public static List<Models.IMinifiedUser> GetLikesFromMedia(string mediaId)
        {
            try
            {
                return likesExecutor.GetLikesFromMedia(mediaId);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Post a like to a media.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">API Call not allowed</exception>
        public static bool PostCommentToMedia(string mediaId)
        {
            try
            {
                return likesExecutor.PostLikeToMedia(mediaId);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Delete a like.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">API Call not allowed</exception>
        public static bool DeleteLike(string mediaId, long commentId)
        {
            try
            {
                return likesExecutor.DeleteLike(mediaId);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }
    }
}
