using InstagramGot.Models;

namespace InstagramGot.QueryExecutor
{
    interface IMediaQueryExecutor
    {
        IMedia MediaInfoFromID(string id);
        IMedia MediaInfoFromShortCode(string shortCode);
    }
}