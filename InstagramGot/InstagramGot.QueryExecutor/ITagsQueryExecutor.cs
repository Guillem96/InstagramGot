using System.Collections.Generic;
using InstagramGot.Models;

namespace InstagramGot.QueryExecutor
{
    interface ITagsQueryExecutor
    {
        List<IMedia> GetTaggedMedia(string tagName, int count);
        ITag GetTagInfo(string tagName);
    }
}