using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace InstagramGot.Test
{
    /// <summary>
    /// Summary description for UserTests
    /// </summary>
    [TestClass]
    public class UserTests
    {

        /// <summary>
        /// Get the autenticated user with his id and check if the user is grabbed correctly
        /// </summary>
        [TestMethod]
        public void GetUserFromId()
        {
            try
            {
                // Get the authenticaded user as always
                var authUser = UserManager.GetAuthenticatedUser();
                Assert.IsNotNull(authUser);

                // Get Auth user from id
                var authUserFromId = UserManager.GetUser(authUser.Id);
                Assert.IsNotNull(authUserFromId);

                // Check if the users are the same
                Assert.IsTrue(authUser.Equals(authUserFromId));
            }
            catch (Exceptions.InstagramAPICallException)
            {
                Assert.Fail("instagram api call exception.");
            }
        }

        /// <summary>
        /// Get the recent media from authenticated user.
        /// </summary>
        [TestMethod]
        public void GetRecentMediaWithCount()
        {
            try
            {
                // Get recent media with count -> So getting only 5 recent media
                var medias = UserManager.GetRecentMedia(5);
                Assert.IsNotNull(medias);
                Assert.AreEqual(5, medias.Count);
            }
            catch (Exceptions.InstagramAPICallException)
            {
                Assert.Fail("instagram api call exception.");
            }
        }

        /// <summary>
        /// Get media from a follower with parameters.
        /// </summary>
        [TestMethod]
        public void GetRecentMediaWithParameters()
        {
            try
            {
                // Get one user who follows you
                var followingUser = RelationshipsManager.GetFollowedBy().First();
                Assert.IsNotNull(followingUser);

                // Get his media using parameters
                var mediaFromFollower = UserManager.GetRecentMedia(new Parameters.UsersQueryParameters()
                {
                    Count = 5,
                    Id = followingUser.Id
                });

                // Check the media
                Assert.IsNotNull(mediaFromFollower);
                Assert.AreEqual(5, mediaFromFollower.Count);
                Assert.IsTrue(mediaFromFollower.First().CreatedBy.Equals(followingUser));

            }
            catch (Exceptions.InstagramAPICallException)
            {
                Assert.Fail("instagram api call exception.");
            }
        }
    }
}
