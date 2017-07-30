using System.Collections.Generic;
using InstagramGot.Models;

namespace InstagramGot.QueryExecutor
{
    interface IRelationshipQueryExecutor
    {
        IRelationship CreateRelationshìp(long id, string action);
        List<IMinifiedUser> FollowedBy();
        List<IMinifiedUser> Follows();
        IRelationship RelationshipInfo(long id);
        List<IMinifiedUser> RequestedBy();
    }
}