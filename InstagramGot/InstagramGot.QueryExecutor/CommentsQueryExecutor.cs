using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.QueryExecutor
{
    class CommentsQueryExecutor : ICommentsQueryExecutor
    {
        private JsonController.IJsonCommentController commentsController;

        public CommentsQueryExecutor()
        {
            commentsController = new JsonController.JsonCommentController();
        }

        /// <summary>
        /// List of comments from media id
        /// </summary>
        public List<Models.IComment> GetCommentsFromMedia(string id)
        {
            try
            {
                return commentsController.MapJsonToComments(InstagramHttpClient.
                                                                CommentsEndPoint.
                                                                GetCommentsAPICall(id));
            }
            catch(Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
            catch(Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Post a comment to media.
        /// </summary>
        public bool PostCommentToMedia(string mediaId, string text)
        {
            try
            {
                return InstagramHttpClient.CommentsEndPoint.PostCommentAPICall(mediaId, text);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
            catch (Exceptions.CommentFormatException e)
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
        public bool DeleteComment(string mediaId, long commentId)
        {
            try
            {
                return InstagramHttpClient.CommentsEndPoint.DeleteCommentAPICall(mediaId, commentId.ToString());
            }
            catch(Exceptions.InstagramAPICallException e)
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
