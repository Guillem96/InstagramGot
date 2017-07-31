using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.QueryExecutor
{
    class TagsQueryExecutor : ITagsQueryExecutor
    {
        JsonController.IJsonTagsController tagsController;
        JsonController.IJsonMediaController mediaController;

        public TagsQueryExecutor()
        {
            tagsController = new JsonController.JsonTagsController();
            mediaController = new JsonController.JsonMediaController();
        }

        /// <summary>
        /// Get number of medias tagged with tag "tagName"
        /// </summary>
        public Models.ITag GetTagInfo(string tagName)
        {
            try
            {
                return tagsController.MapJsonToTag(
                                        InstagramHttpClient
                                                .TagsEndPoint
                                                .GetTagsInfoAPICall(tagName));
            }
            catch(Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get a list of medias tagged with tag "tagName".
        /// </summary>
        public List<Models.IMedia> GetTaggedMedia(string tagName, int count = 0)
        {
            try
            {
                return mediaController.MapJsonToMedias(
                                        InstagramHttpClient
                                                .TagsEndPoint
                                                .GetRecentMediasWithTagAPICall(tagName, count));
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
    }
}
