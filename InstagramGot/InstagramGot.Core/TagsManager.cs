using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot
{
    public static class TagsManager
    {
        private static QueryExecutor.ITagsQueryExecutor tagsExecutor = new QueryExecutor.TagsQueryExecutor();

        /// <summary>
        /// Get the name and the media tagged with tag "tagName"
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Instagram api not allowed request.</exception>
        public static Models.ITag GetTagInfo(string tagName)
        {
            try
            {
                return tagsExecutor.GetTagInfo(tagName);
            }
            catch(Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get a list of tagged media
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Instagram api not allowed request.</exception>
        public static List<Models.IMedia> GetTaggedMedia(string tagName, int count = 0)
        {
            try
            {
                return tagsExecutor.GetTaggedMedia(tagName, count);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }
    }
}
