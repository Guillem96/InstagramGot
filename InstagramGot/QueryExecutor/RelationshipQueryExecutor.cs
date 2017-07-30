using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGot.Models;

namespace InstagramGot.QueryExecutor
{
    class RelationshipQueryExecutor : IRelationshipQueryExecutor
    {
        private JsonController.IJsonRelationshipController relationJsonController;
        private JsonController.IJsonUserController userJsonController;

        public RelationshipQueryExecutor()
        {
            relationJsonController = new JsonController.JsonRelationshipController();
            userJsonController = new JsonController.JsonUserController();
        }

        /// <summary>
        /// Return a relationship object containing the relation info.
        /// </summary>
        public IRelationship RelationshipInfo(long id)
        {
            try
            {
                return relationJsonController.MapjsonToRelationship(
                    InstagramHttpClient.RelationshipEndPoint.RealationshipAPICall(id.ToString()));
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

        public IRelationship CreateRelationshìp(long id, string action)
        {
            try
            {
                return relationJsonController.MapjsonToRelationship(
                    InstagramHttpClient.RelationshipEndPoint.RealationshipAPICall(id.ToString(), action));
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
        /// Return a list of follows.
        /// </summary>
        public List<IMinifiedUser> Follows()
        {
            try
            {
                return userJsonController.MapJsonToMinifiedUsers(
                    InstagramHttpClient.RelationshipEndPoint.GetFollowsAPICall());
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
        /// Get a list of users who you are following.
        /// </summary>
        public List<IMinifiedUser> FollowedBy()
        {
            try
            {
                return userJsonController.MapJsonToMinifiedUsers(
                    InstagramHttpClient.RelationshipEndPoint.GetFollowedByAPICall());
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
        /// Get a list of requested users
        /// </summary>
        /// <returns></returns>
        public List<IMinifiedUser> RequestedBy()
        {
            try
            {
                return userJsonController.MapJsonToMinifiedUsers(
                    InstagramHttpClient.RelationshipEndPoint.GetRequestedByAPICall());
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
