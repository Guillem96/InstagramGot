using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InstagramGot;
using System.Diagnostics;
using InstagramGot.Models;
using System.Linq;
using System.Collections.Generic;

namespace InstagramGot.Test
{
    [TestClass]
    public class CommentsTest
    {
        [TestMethod]
        public void PostComment()
        {
            try
            {
                // Get the recent media of the auth user
                var AuthUserMedia = UserManager.GetRecentMedia();
                Assert.IsNotNull(AuthUserMedia);

                // Post a comment to the most recent media
                IMedia recentMedia = AuthUserMedia.First();

                // Comments from this media
                List<IComment> prevComments = CommentsManager.GetCommentsFromMedia(recentMedia.Id);

                Assert.IsNotNull(prevComments);

                // Post the new comment
                CommentsManager.PostCommentToMedia(recentMedia.Id, "Making some tests.");

                // Get the comements again
                List<IComment> currentComments = CommentsManager.GetCommentsFromMedia(recentMedia.Id);

                // Check that 1 comment has been added
                Assert.AreEqual(prevComments.Count() + 1, currentComments.Count());

                // Check if new comment has been added correctly
                Assert.IsTrue(currentComments.Any(c => c.Text.Contains("Making some tests.")));
            }
            catch (Exceptions.CommentFormatException e)
            {
                Assert.Fail("Incorrect comment error." + e.ToString());
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                Assert.Fail("Instagram API call error." + e.ToString());
            }
        }

        [TestMethod]
        public void DeleteComment()
        {
            try
            {
                // Get the recent media of the auth user
                var AuthUserMedia = UserManager.GetRecentMedia();
                Assert.IsNotNull(AuthUserMedia);

                // Post a comment to the most recent media
                IMedia recentMedia = AuthUserMedia.First();

                // Comments from this media
                List<IComment> prevComments = CommentsManager.GetCommentsFromMedia(recentMedia.Id);

                Assert.IsNotNull(prevComments);

                // Delete the comment made in the previous test
                CommentsManager.DeleteComment(recentMedia.Id, prevComments.Single(c => c.Text.Contains("Making some tests.")).Id);

                // Get the comements again
                List<IComment> currentComments = CommentsManager.GetCommentsFromMedia(recentMedia.Id);

                // Check that 1 comment has been deleted
                Assert.AreEqual(prevComments.Count() - 1, currentComments.Count());

                // Check if new comment doesn't exist now
                Assert.IsFalse(currentComments.Any(c => c.Text.Contains("Making some tests.")));
            }
            catch (Exceptions.CommentFormatException e)
            {
                Assert.Fail("Incorrect comment error." + e.ToString());
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                Assert.Fail("Instagram API call error." + e.ToString());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.CommentFormatException))]
        public void IncorrectCommentFormatURI()
        {
            // Get the recent media of the auth user
            var AuthUserMedia = UserManager.GetRecentMedia();
            Assert.IsNotNull(AuthUserMedia);

            // Post a comment to the most recent media
            IMedia recentMedia = AuthUserMedia.First();

            // Post an incorrect Comment
            CommentsManager.PostCommentToMedia(recentMedia.Id, "http://www.google.es http://www.github.com");

            // Then CommentFormatException is rised with a message saying that you cannot
            // add more than one URI to de comment
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.CommentFormatException))]
        public void IncorrectCommentFormatHashtag()
        {
            // Get the recent media of the auth user
            var AuthUserMedia = UserManager.GetRecentMedia();
            Assert.IsNotNull(AuthUserMedia);

            // Post a comment to the most recent media
            IMedia recentMedia = AuthUserMedia.First();

            // Post an incorrect Comment
            CommentsManager.PostCommentToMedia(recentMedia.Id, "#love #sex #american #express #morehashtag");

            // Then CommentFormatException is rised with a message saying that you cannot
            // add more than four hashtags to de comment
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.CommentFormatException))]
        public void IncorrectCommentFormatCapitalLetters()
        {
            // Get the recent media of the auth user
            var AuthUserMedia = UserManager.GetRecentMedia();
            Assert.IsNotNull(AuthUserMedia);

            // Post a comment to the most recent media
            IMedia recentMedia = AuthUserMedia.First();

            // Post an incorrect Comment
            CommentsManager.PostCommentToMedia(recentMedia.Id, "THIS COMMENT IS NOT WELL FORMATED.");

            // Then CommentFormatException is rised with a message saying  
            // that all letters can't be capital case
        }
    }
}
