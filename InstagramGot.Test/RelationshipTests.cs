using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using InstagramGot.Models;

namespace InstagramGot.Test
{
    /// <summary>
    /// Summary description for RelationshipTests
    /// </summary>
    [TestClass]
    public class RelationshipTests
    {
        /// <summary>
        /// Get the follows and check that the outgoing relationship status is correct
        /// </summary>
        [TestMethod]
        public void GetFollowsAndRelationshipInfo()
        {
            try
            {
                // Get follows
                var follows = RelationshipsManager.GetFollows();
                Assert.IsNotNull(follows);

                // Get relationship info with the first user (for example)
                var relInfo = RelationshipsManager.GetRelationshipinfo(follows.First().Id);

                // Check if relationship info is correct
                Assert.IsNotNull(relInfo);
                Assert.AreEqual(OutgoingRelationshipStatus.Follows, relInfo.OutgoingRelation);
            }
            catch(Exceptions.InstagramAPICallException)
            {
                Assert.Fail("Instagram Api error.");
            }   
        }

        /// <summary>
        /// Get the followers and check that the incoming relationship status is correct
        /// </summary>
        [TestMethod]
        public void GetFollowersAndRelationshipInfo()
        {
            try
            {
                // Get followers
                var followers = RelationshipsManager.GetFollowedBy();
                Assert.IsNotNull(followers);

                // Get relationship info with the first user (for example)
                var relInfo = RelationshipsManager.GetRelationshipinfo(followers.First().Id);

                // Check if relationship info is correct
                // If the user is a follower the ingoing status must by followed_by
                Assert.IsNotNull(relInfo);
                Assert.AreEqual(IngoingRelationshipStatus.FollowedBy, relInfo.IngoingRelation);
            }
            catch (Exceptions.InstagramAPICallException)
            {
                Assert.Fail("Instagram Api error.");
            }
        }

        /// <summary>
        /// Unfollow one user and then follow him again
        /// </summary>
        [TestMethod]
        public void UnfollowAndFollowAgain()
        {
            try
            {
                // Get follows
                var prevFollows = RelationshipsManager.GetFollows();
                Assert.IsNotNull(prevFollows);

                // unfollow the first user
                RelationshipsManager.DestroyRelationship(prevFollows.First().Id);

                // Check if the user is not a follow
                var currentFollows = RelationshipsManager.GetFollows();
                Assert.IsNotNull(currentFollows);
                Assert.AreEqual(prevFollows.Count - 1, currentFollows.Count);

                // Follow again
                RelationshipsManager.CreateRelationship(prevFollows.First().Id);

                // Update current follows and check again
                currentFollows = RelationshipsManager.GetFollows();
                Assert.IsNotNull(currentFollows);
                Assert.AreEqual(prevFollows.Count, currentFollows.Count);
            }
            catch (Exceptions.InstagramAPICallException)
            {
                Assert.Fail("Instagram Api error.");
            }
        }

        /// <summary>
        /// Try to approve or ignore a requests that doesn't exist
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exceptions.InstagramAPICallException))]
        public void TryToApproveAnAlreadyFollowedUser()
        {
            // Get follows
            var follows = RelationshipsManager.GetFollows();
            Assert.IsNotNull(follows);

            // unfollow the first user
            RelationshipsManager.ApproveRelationship(follows.First().Id);
        }

    }
}
