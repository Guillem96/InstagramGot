using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InstagramGot.Models;
using System.Linq;

namespace InstagramGot.Test
{
    /// <summary>
    /// Summary description for LikesTests
    /// </summary>
    [TestClass]
    public class LikesTests
    {

        /// <summary>
        /// Delete the like and then like again
        /// </summary>
        [TestMethod]
        public void UnlikeAndLikeMedia()
        {
            try
            {
                // Get any liked media
                var likedMedia = UserManager.GetLikedMedia(5);
                Assert.IsNotNull(likedMedia);
                Assert.AreEqual(5, likedMedia.Count);

                // Delete the like of the media
                var likedImage = likedMedia.First();
                Assert.IsTrue(LikesManager.DeleteLike(likedImage.Id));

                // Chek the like is not there
                var likesFromMedia = LikesManager.GetLikesFromMedia(likedImage.Id);
                Assert.IsFalse(likesFromMedia.Any(i => i.Id == UserManager.GetAuthenticatedUser().Id));

                // Like the image again
                Assert.IsTrue(LikesManager.PostLikeToMedia(likedImage.Id));

                // Check that the like is there
                likesFromMedia = LikesManager.GetLikesFromMedia(likedImage.Id);
                Assert.IsTrue(likesFromMedia.Any(i => i.Id == UserManager.GetAuthenticatedUser().Id));
            }
            catch(Exceptions.InstagramAPICallException)
            {
                Assert.Fail("Instagram api error.");
            }
        }


        [TestMethod]
        public void LikeAnAlreadyLikedMedia()
        {
            try
            {
                // Get any liked media
                var likedMedia = UserManager.GetLikedMedia(5);
                Assert.IsNotNull(likedMedia);
                Assert.AreEqual(5, likedMedia.Count);

                // Like an already liked media
                var likedImage = likedMedia.First();
                Assert.IsFalse(LikesManager.PostLikeToMedia(likedImage.Id));
            }
            catch (Exceptions.InstagramAPICallException)
            {
                Assert.Fail("Instagram api error.");
            }
        }

        [TestMethod]
        public void DeleteNonExistentLike()
        {
            try
            {
                // Get any liked media
                var likedMedia = UserManager.GetLikedMedia(5);
                Assert.IsNotNull(likedMedia);
                Assert.AreEqual(5, likedMedia.Count);

                // Delete the like
                var likedImage = likedMedia.First();
                Assert.IsTrue(LikesManager.DeleteLike(likedImage.Id));

                // Delete the like again
                Assert.IsFalse(LikesManager.DeleteLike(likedImage.Id));

                // like the media again
                Assert.IsTrue(LikesManager.PostLikeToMedia(likedImage.Id));

            }
            catch (Exceptions.InstagramAPICallException)
            {
                Assert.Fail("Instagram api error.");
            }
        }
    }
}
