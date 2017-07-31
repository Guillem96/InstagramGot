using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.QueryExecutor
{
    class LikesQueryExecutor : ILikesQueryExecutor
    {
        private JsonController.IJsonUserController userController;

        public LikesQueryExecutor()
        {
            userController = new JsonController.JsonUserController();
        }

        /// <summary>
        /// List of users who liked a media.
        /// </summary>
        public List<Models.IMinifiedUser> GetLikesFromMedia(string id)
        {
            try
            {
                return userController.MapJsonToMinifiedUsers(InstagramHttpClient.
                                                                LikesEndPoint.
                                                                GetLikesAPICall(id));
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Post a like to media.
        /// </summary>
        public bool PostLikeToMedia(string mediaId)
        {
            try
            {
                return InstagramHttpClient.LikesEndPoint.PostLikeAPICall(mediaId);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete a comment.
        /// </summary>
        public bool DeleteLike(string mediaId)
        {
            try
            {
                return InstagramHttpClient.LikesEndPoint.DeleteLikeAPICall(mediaId);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
