using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace InstagramGot.Test
{
    [TestClass]
    public class MediaTest
    {
        [TestMethod]
        public void GetMediaFromId()
        {
            try
            {
                // Get media from the current user
                var myMedia = UserManager.GetRecentMedia(5);
                Assert.IsNotNull(myMedia);

                // Get the less recent media
                var lessRecent = myMedia.Last();
                Assert.IsNotNull(lessRecent);

                // Get media info
                var media = MediaManager.GetMediaInfoFromID(lessRecent.Id);

                // Check if media was grabed correctly
                Assert.IsNotNull(media);
                Assert.AreEqual(UserManager.GetAuthenticatedUser().Username, media.CreatedBy.Username);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                Assert.Fail("Instagram API call error." + e.ToString());
            }
        }

        [TestMethod]
        public void GetMediaFromShortCode()
        {
            try
            {
                // Get media from the current user
                var myMedia = UserManager.GetRecentMedia(5);
                Assert.IsNotNull(myMedia);

                // Get the less recent media
                var lessRecent = myMedia.Last();
                Assert.IsNotNull(lessRecent);

                // Get media info
                var media = MediaManager.GetMediaInfoFromID(lessRecent.Id);
                Assert.IsNotNull(lessRecent);

                // Get short code
                var shortCode = media.MediaUrl.Split(new char[] { '/' }).Where(x => !String.IsNullOrEmpty(x)).Last();
                // Get the same media from short code
                var shortMedia = MediaManager.GetMediaInfoFromShortCode(shortCode);

                //// Check if media from id is the same than media from shortcode
                Assert.IsNotNull(shortMedia);
                Assert.IsTrue(shortMedia.Equals(media));

            }
            catch (Exceptions.InstagramAPICallException e)
            {
                Assert.Fail("Instagram API call error." + e.ToString());
            }
        }
    }
}
