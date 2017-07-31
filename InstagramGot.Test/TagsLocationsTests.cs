using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace InstagramGot.Test
{
    /// <summary>
    /// Summary description for TagsLocationsTests
    /// </summary>
    [TestClass]
    public class TagsLocationsTests
    {
        [TestMethod]
        public void GetTagInfo()
        {
            try
            {
                // Get snow tag
                var snowTag = TagsManager.GetTagInfo("snow");
                Assert.IsNotNull(snowTag);
            }
            catch (Exceptions.InstagramAPICallException)
            {
                Assert.Fail("Instagram Api error.");
            }   
        }

        [TestMethod]
        public void GetTaggedMedia()
        {
            try
            {
                // Get snow tagged media
                var snowTagMedia = TagsManager.GetTaggedMedia("snow", 5);
                Assert.IsNotNull(snowTagMedia);
            }
            catch (Exceptions.InstagramAPICallException)
            {
                Assert.Fail("Instagram Api error.");
            }
        }

        [TestMethod]
        public void GetLocationInfo()
        {
            try
            {
                // Search a location
                var locations = SearchManager.GetLocations(41.6109, 0.6419, 5000);
                Assert.IsNotNull(locations);

                // Get location info
                var locationInfo = LocationManager.GetLocationInfo(locations.First().Id);
                Assert.IsNotNull(locationInfo);
            }
            catch (Exceptions.InstagramAPICallException)
            {
                Assert.Fail("Instagram Api error.");
            }
        }

        [TestMethod]
        public void GetLocatedMedia()
        {
            try
            {
                // Search a location
                var locations = SearchManager.GetLocations(41.6109, 0.6419, 5000);
                Assert.IsNotNull(locations);

                // Get location info
                var locationMedia = LocationManager.GetMediaNearLocation(locations.First().Id);
                Assert.IsNotNull(locationMedia);
            }
            catch (Exceptions.InstagramAPICallException)
            {
                Assert.Fail("Instagram Api error.");
            }
        }
    }
}
