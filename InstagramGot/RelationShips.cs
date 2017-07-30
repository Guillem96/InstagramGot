using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot
{
    public static class RelationShips
    {
        private static QueryExecutor.IRelationshipQueryExecutor relationshipExecutor = new QueryExecutor.RelationshipQueryExecutor();

        /// <summary>
        /// Returns a list of users that you are following.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public static List<Models.IMinifiedUser> GetFollows()
        {
            try
            {
                return relationshipExecutor.Follows();
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns a list of users who follows you.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public static List<Models.IMinifiedUser> GetFollowedBy()
        {
            try
            {
                return relationshipExecutor.FollowedBy();
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns a list of users who have requested to follow you.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public static List<Models.IMinifiedUser> GetRequestedBy()
        {
            try
            {
                return relationshipExecutor.RequestedBy();
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns the relationship's info wit the specified user.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Application authorization error.</exception>
        public static Models.IRelationship GetRelationshipinfo(long id)
        {
            try
            {
                return relationshipExecutor.RelationshipInfo(id);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }
    }
}
