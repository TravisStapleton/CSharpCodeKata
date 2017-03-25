using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console;
using ProviderQuality.Logic;

namespace ProviderQuality.Tests
{
    [TestClass]
    public class UpdateQualityAwardsTests
    {
        private const int LegacyCompareTestCyclesToRun = 10000;
        private const int ErrorThreshold = 300;

        [TestMethod]
        public void TestImmutabilityOfBlueDistinctionPlus()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Distinction Plus", SellIn = 0, Quality = 80}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Distinction Plus");
            Assert.IsTrue(app.Awards[0].Quality == 80);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 80);
        }

        // +++To Do - 1/10/2013: Discuss with team about adding more tests.  Seems like a lot of work for something
        //                       that probably won't change.  I watched it all in the debugger and know everything works
        //                       plus QA has already signed off and no one has complained.

        [TestMethod]
        public void TestAcmePartnerFacilityLegacyVsNew()
        {
            var legacyApp = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "ACME Partner Facility", SellIn = 2, Quality = 20},
                    new Award {Name = "ACME Partner Facility", SellIn = 20, Quality = 30},
                    new Award {Name = "ACME Partner Facility", SellIn = 10, Quality = 25},
                    new Award {Name = "ACME Partner Facility", SellIn = 6, Quality = 9},
                    new Award {Name = "ACME Partner Facility", SellIn = 8, Quality = 48},
                    new Award {Name = "ACME Partner Facility", SellIn = 19, Quality = 35},
                    new Award {Name = "ACME Partner Facility", SellIn = 18, Quality = 40},
                    new Award {Name = "ACME Partner Facility", SellIn = 12, Quality = 6},
                    new Award {Name = "ACME Partner Facility", SellIn = 5, Quality = 2},
                    new Award {Name = "ACME Partner Facility", SellIn = 9, Quality = 0},
                    new Award {Name = "ACME Partner Facility", SellIn = 0, Quality = 50},
                    new Award {Name = "ACME Partner Facility", SellIn = 11, Quality = 1},
                    new Award {Name = "ACME Partner Facility", SellIn = 17, Quality = 10},
                    new Award {Name = "ACME Partner Facility", SellIn = 24, Quality = 22},
                    new Award {Name = "ACME Partner Facility", SellIn = 20, Quality = 33},
                    new Award {Name = "ACME Partner Facility", SellIn = 10, Quality = 43},
                    new Award {Name = "ACME Partner Facility", SellIn = 6, Quality = 43},
                    new Award {Name = "ACME Partner Facility", SellIn = 8, Quality = 38},
                    new Award {Name = "ACME Partner Facility", SellIn = 19, Quality = 15},
                    new Award {Name = "ACME Partner Facility", SellIn = 18, Quality = 48},
                    new Award {Name = "ACME Partner Facility", SellIn = 16, Quality = 32},
                    new Award {Name = "ACME Partner Facility", SellIn = 54, Quality = 22},
                    new Award {Name = "ACME Partner Facility", SellIn = 45, Quality = 1},
                    new Award {Name = "ACME Partner Facility", SellIn = 32, Quality = 50},
                    new Award {Name = "ACME Partner Facility", SellIn = 141, Quality = 21},
                    new Award {Name = "ACME Partner Facility", SellIn = 14, Quality = 10},
                    new Award {Name = "ACME Partner Facility", SellIn = 9, Quality = 20},
                    new Award {Name = "ACME Partner Facility", SellIn = 20, Quality = 30},
                    new Award {Name = "ACME Partner Facility", SellIn = 10, Quality = 25},
                    new Award {Name = "ACME Partner Facility", SellIn = 6, Quality = 9},
                    new Award {Name = "ACME Partner Facility", SellIn = 15, Quality = 42},
                    new Award {Name = "ACME Partner Facility", SellIn = 19, Quality = 37},
                    new Award {Name = "ACME Partner Facility", SellIn = 18, Quality = 20},
                    new Award {Name = "ACME Partner Facility", SellIn = 17, Quality = 4},
                    new Award {Name = "ACME Partner Facility", SellIn = 12, Quality = 34},
                    new Award {Name = "ACME Partner Facility", SellIn = 5, Quality = 40},
                    new Award {Name = "ACME Partner Facility", SellIn = 4, Quality = 29},
                    new Award {Name = "ACME Partner Facility", SellIn = 12, Quality = 11},
                    new Award {Name = "ACME Partner Facility", SellIn = 17, Quality = 30},
                    #endregion TestData
                }
            };

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "ACME Partner Facility", SellIn = 2, Quality = 20},
                    new Award {Name = "ACME Partner Facility", SellIn = 20, Quality = 30},
                    new Award {Name = "ACME Partner Facility", SellIn = 10, Quality = 25},
                    new Award {Name = "ACME Partner Facility", SellIn = 6, Quality = 9},
                    new Award {Name = "ACME Partner Facility", SellIn = 8, Quality = 48},
                    new Award {Name = "ACME Partner Facility", SellIn = 19, Quality = 35},
                    new Award {Name = "ACME Partner Facility", SellIn = 18, Quality = 40},
                    new Award {Name = "ACME Partner Facility", SellIn = 12, Quality = 6},
                    new Award {Name = "ACME Partner Facility", SellIn = 5, Quality = 2},
                    new Award {Name = "ACME Partner Facility", SellIn = 9, Quality = 0},
                    new Award {Name = "ACME Partner Facility", SellIn = 0, Quality = 50},
                    new Award {Name = "ACME Partner Facility", SellIn = 11, Quality = 1},
                    new Award {Name = "ACME Partner Facility", SellIn = 17, Quality = 10},
                    new Award {Name = "ACME Partner Facility", SellIn = 24, Quality = 22},
                    new Award {Name = "ACME Partner Facility", SellIn = 20, Quality = 33},
                    new Award {Name = "ACME Partner Facility", SellIn = 10, Quality = 43},
                    new Award {Name = "ACME Partner Facility", SellIn = 6, Quality = 43},
                    new Award {Name = "ACME Partner Facility", SellIn = 8, Quality = 38},
                    new Award {Name = "ACME Partner Facility", SellIn = 19, Quality = 15},
                    new Award {Name = "ACME Partner Facility", SellIn = 18, Quality = 48},
                    new Award {Name = "ACME Partner Facility", SellIn = 16, Quality = 32},
                    new Award {Name = "ACME Partner Facility", SellIn = 54, Quality = 22},
                    new Award {Name = "ACME Partner Facility", SellIn = 45, Quality = 1},
                    new Award {Name = "ACME Partner Facility", SellIn = 32, Quality = 50},
                    new Award {Name = "ACME Partner Facility", SellIn = 141, Quality = 21},
                    new Award {Name = "ACME Partner Facility", SellIn = 14, Quality = 10},
                    new Award {Name = "ACME Partner Facility", SellIn = 9, Quality = 20},
                    new Award {Name = "ACME Partner Facility", SellIn = 20, Quality = 30},
                    new Award {Name = "ACME Partner Facility", SellIn = 10, Quality = 25},
                    new Award {Name = "ACME Partner Facility", SellIn = 6, Quality = 9},
                    new Award {Name = "ACME Partner Facility", SellIn = 15, Quality = 42},
                    new Award {Name = "ACME Partner Facility", SellIn = 19, Quality = 37},
                    new Award {Name = "ACME Partner Facility", SellIn = 18, Quality = 20},
                    new Award {Name = "ACME Partner Facility", SellIn = 17, Quality = 4},
                    new Award {Name = "ACME Partner Facility", SellIn = 12, Quality = 34},
                    new Award {Name = "ACME Partner Facility", SellIn = 5, Quality = 40},
                    new Award {Name = "ACME Partner Facility", SellIn = 4, Quality = 29},
                    new Award {Name = "ACME Partner Facility", SellIn = 12, Quality = 11},
                    new Award {Name = "ACME Partner Facility", SellIn = 17, Quality = 30},
                    #endregion TestData
                }
            };

            var numberOfMismatchs = 0;

            for (var x = 0; x < LegacyCompareTestCyclesToRun; x++)
            {
                legacyApp.UpdateQualityLegacy();
                app.UpdateQuality();
                for (var i = 0; i < legacyApp.Awards.Count; i++)
                {
                    var legacyAward = legacyApp.Awards[i];
                    var award = app.Awards[i];

                    if (legacyAward.Quality != award.Quality)
                        numberOfMismatchs++;

                    if (numberOfMismatchs > ErrorThreshold)
                        break;
                }
            }

            Assert.IsTrue(numberOfMismatchs == 0);
        }

        [TestMethod]
        public void TestBlueCompareLegacyVsNew()
        {
            var legacyApp = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "Blue Compare", SellIn = 2, Quality = 20},
                    new Award {Name = "Blue Compare", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue Compare", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue Compare", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue Compare", SellIn = 8, Quality = 48},
                    new Award {Name = "Blue Compare", SellIn = 19, Quality = 35},
                    new Award {Name = "Blue Compare", SellIn = 18, Quality = 40},
                    new Award {Name = "Blue Compare", SellIn = 12, Quality = 6},
                    new Award {Name = "Blue Compare", SellIn = 5, Quality = 2},
                    new Award {Name = "Blue Compare", SellIn = 9, Quality = 0},
                    new Award {Name = "Blue Compare", SellIn = 0, Quality = 50},
                    new Award {Name = "Blue Compare", SellIn = 11, Quality = 1},
                    new Award {Name = "Blue Compare", SellIn = 17, Quality = 10},
                    new Award {Name = "Blue Compare", SellIn = 24, Quality = 22},
                    new Award {Name = "Blue Compare", SellIn = 20, Quality = 33},
                    new Award {Name = "Blue Compare", SellIn = 10, Quality = 43},
                    new Award {Name = "Blue Compare", SellIn = 6, Quality = 43},
                    new Award {Name = "Blue Compare", SellIn = 8, Quality = 38},
                    new Award {Name = "Blue Compare", SellIn = 19, Quality = 15},
                    new Award {Name = "Blue Compare", SellIn = 18, Quality = 48},
                    new Award {Name = "Blue Compare", SellIn = 16, Quality = 32},
                    new Award {Name = "Blue Compare", SellIn = 54, Quality = 22},
                    new Award {Name = "Blue Compare", SellIn = 45, Quality = 1},
                    new Award {Name = "Blue Compare", SellIn = 32, Quality = 50},
                    new Award {Name = "Blue Compare", SellIn = 141, Quality = 21},
                    new Award {Name = "Blue Compare", SellIn = 14, Quality = 10},
                    new Award {Name = "Blue Compare", SellIn = 9, Quality = 20},
                    new Award {Name = "Blue Compare", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue Compare", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue Compare", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue Compare", SellIn = 15, Quality = 42},
                    new Award {Name = "Blue Compare", SellIn = 19, Quality = 37},
                    new Award {Name = "Blue Compare", SellIn = 18, Quality = 20},
                    new Award {Name = "Blue Compare", SellIn = 17, Quality = 4},
                    new Award {Name = "Blue Compare", SellIn = 12, Quality = 34},
                    new Award {Name = "Blue Compare", SellIn = 5, Quality = 40},
                    new Award {Name = "Blue Compare", SellIn = 4, Quality = 29},
                    new Award {Name = "Blue Compare", SellIn = 12, Quality = 11},
                    new Award {Name = "Blue Compare", SellIn = 17, Quality = 30},
                    #endregion TestData
                }
            };

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "Blue Compare", SellIn = 2, Quality = 20},
                    new Award {Name = "Blue Compare", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue Compare", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue Compare", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue Compare", SellIn = 8, Quality = 48},
                    new Award {Name = "Blue Compare", SellIn = 19, Quality = 35},
                    new Award {Name = "Blue Compare", SellIn = 18, Quality = 40},
                    new Award {Name = "Blue Compare", SellIn = 12, Quality = 6},
                    new Award {Name = "Blue Compare", SellIn = 5, Quality = 2},
                    new Award {Name = "Blue Compare", SellIn = 9, Quality = 0},
                    new Award {Name = "Blue Compare", SellIn = 0, Quality = 50},
                    new Award {Name = "Blue Compare", SellIn = 11, Quality = 1},
                    new Award {Name = "Blue Compare", SellIn = 17, Quality = 10},
                    new Award {Name = "Blue Compare", SellIn = 24, Quality = 22},
                    new Award {Name = "Blue Compare", SellIn = 20, Quality = 33},
                    new Award {Name = "Blue Compare", SellIn = 10, Quality = 43},
                    new Award {Name = "Blue Compare", SellIn = 6, Quality = 43},
                    new Award {Name = "Blue Compare", SellIn = 8, Quality = 38},
                    new Award {Name = "Blue Compare", SellIn = 19, Quality = 15},
                    new Award {Name = "Blue Compare", SellIn = 18, Quality = 48},
                    new Award {Name = "Blue Compare", SellIn = 16, Quality = 32},
                    new Award {Name = "Blue Compare", SellIn = 54, Quality = 22},
                    new Award {Name = "Blue Compare", SellIn = 45, Quality = 1},
                    new Award {Name = "Blue Compare", SellIn = 32, Quality = 50},
                    new Award {Name = "Blue Compare", SellIn = 141, Quality = 21},
                    new Award {Name = "Blue Compare", SellIn = 14, Quality = 10},
                    new Award {Name = "Blue Compare", SellIn = 9, Quality = 20},
                    new Award {Name = "Blue Compare", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue Compare", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue Compare", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue Compare", SellIn = 15, Quality = 42},
                    new Award {Name = "Blue Compare", SellIn = 19, Quality = 37},
                    new Award {Name = "Blue Compare", SellIn = 18, Quality = 20},
                    new Award {Name = "Blue Compare", SellIn = 17, Quality = 4},
                    new Award {Name = "Blue Compare", SellIn = 12, Quality = 34},
                    new Award {Name = "Blue Compare", SellIn = 5, Quality = 40},
                    new Award {Name = "Blue Compare", SellIn = 4, Quality = 29},
                    new Award {Name = "Blue Compare", SellIn = 12, Quality = 11},
                    new Award {Name = "Blue Compare", SellIn = 17, Quality = 30},
                    #endregion TestData
                }
            };

            var numberOfMismatchs = 0;

            for (var x = 0; x < LegacyCompareTestCyclesToRun; x++)
            {
                legacyApp.UpdateQualityLegacy();
                app.UpdateQuality();
                for (var i = 0; i < legacyApp.Awards.Count; i++)
                {
                    var legacyAward = legacyApp.Awards[i];
                    var award = app.Awards[i];

                    if (legacyAward.Quality != award.Quality)
                        numberOfMismatchs++;

                    if (numberOfMismatchs > ErrorThreshold)
                        break;
                }
            }

            Assert.IsTrue(numberOfMismatchs == 0);
        }

        [TestMethod]
        public void TestBlueCompareNotOverFifty()
        {
            var cycleCount = 15;
            var startQuality = 49;
            var startSellIn = 15;

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = Constants.BlueCompareName, SellIn = startSellIn, Quality = startQuality}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == Constants.BlueCompareName);
            Assert.IsTrue(app.Awards[0].Quality == startQuality);
            Assert.IsTrue(app.Awards[0].SellIn == startSellIn);

            for (var x = 0; x < cycleCount; x++)
            {
                app.UpdateQuality();
            }

            Assert.IsTrue(app.Awards[0].Quality == 50);
        }

        [TestMethod]
        public void TestGovQualityNotUnderZero()
        {
            var cycleCount = 15;
            var startQuality = 1;
            var startSellIn = 15;

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = Constants.GovQualityPlusName, SellIn = startSellIn, Quality = startQuality}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == Constants.GovQualityPlusName);
            Assert.IsTrue(app.Awards[0].Quality == startQuality);
            Assert.IsTrue(app.Awards[0].SellIn == startSellIn);

            for (var x = 0; x < cycleCount; x++)
            {
                app.UpdateQuality();
            }

            Assert.IsTrue(app.Awards[0].Quality == 0);
        }

        [TestMethod]
        public void TestBlueFirstLegacyVsNew()
        {
            var legacyApp = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "Blue First", SellIn = 2, Quality = 20},
                    new Award {Name = "Blue First", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue First", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue First", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue First", SellIn = 8, Quality = 48},
                    new Award {Name = "Blue First", SellIn = 19, Quality = 35},
                    new Award {Name = "Blue First", SellIn = 18, Quality = 40},
                    new Award {Name = "Blue First", SellIn = 12, Quality = 6},
                    new Award {Name = "Blue First", SellIn = 5, Quality = 2},
                    new Award {Name = "Blue First", SellIn = 9, Quality = 0},
                    new Award {Name = "Blue First", SellIn = 0, Quality = 50},
                    new Award {Name = "Blue First", SellIn = 11, Quality = 1},
                    new Award {Name = "Blue First", SellIn = 17, Quality = 10},
                    new Award {Name = "Blue First", SellIn = 24, Quality = 22},
                    new Award {Name = "Blue First", SellIn = 20, Quality = 33},
                    new Award {Name = "Blue First", SellIn = 10, Quality = 43},
                    new Award {Name = "Blue First", SellIn = 6, Quality = 43},
                    new Award {Name = "Blue First", SellIn = 8, Quality = 38},
                    new Award {Name = "Blue First", SellIn = 19, Quality = 15},
                    new Award {Name = "Blue First", SellIn = 18, Quality = 48},
                    new Award {Name = "Blue First", SellIn = 16, Quality = 32},
                    new Award {Name = "Blue First", SellIn = 54, Quality = 22},
                    new Award {Name = "Blue First", SellIn = 45, Quality = 1},
                    new Award {Name = "Blue First", SellIn = 32, Quality = 50},
                    new Award {Name = "Blue First", SellIn = 141, Quality = 21},
                    new Award {Name = "Blue First", SellIn = 14, Quality = 10},
                    new Award {Name = "Blue First", SellIn = 9, Quality = 20},
                    new Award {Name = "Blue First", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue First", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue First", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue First", SellIn = 15, Quality = 42},
                    new Award {Name = "Blue First", SellIn = 19, Quality = 37},
                    new Award {Name = "Blue First", SellIn = 18, Quality = 20},
                    new Award {Name = "Blue First", SellIn = 17, Quality = 4},
                    new Award {Name = "Blue First", SellIn = 12, Quality = 34},
                    new Award {Name = "Blue First", SellIn = 5, Quality = 40},
                    new Award {Name = "Blue First", SellIn = 4, Quality = 29},
                    new Award {Name = "Blue First", SellIn = 12, Quality = 11},
                    new Award {Name = "Blue First", SellIn = 17, Quality = 30},
                    #endregion TestData
                }
            };

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "Blue First", SellIn = 2, Quality = 20},
                    new Award {Name = "Blue First", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue First", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue First", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue First", SellIn = 8, Quality = 48},
                    new Award {Name = "Blue First", SellIn = 19, Quality = 35},
                    new Award {Name = "Blue First", SellIn = 18, Quality = 40},
                    new Award {Name = "Blue First", SellIn = 12, Quality = 6},
                    new Award {Name = "Blue First", SellIn = 5, Quality = 2},
                    new Award {Name = "Blue First", SellIn = 9, Quality = 0},
                    new Award {Name = "Blue First", SellIn = 0, Quality = 50},
                    new Award {Name = "Blue First", SellIn = 11, Quality = 1},
                    new Award {Name = "Blue First", SellIn = 17, Quality = 10},
                    new Award {Name = "Blue First", SellIn = 24, Quality = 22},
                    new Award {Name = "Blue First", SellIn = 20, Quality = 33},
                    new Award {Name = "Blue First", SellIn = 10, Quality = 43},
                    new Award {Name = "Blue First", SellIn = 6, Quality = 43},
                    new Award {Name = "Blue First", SellIn = 8, Quality = 38},
                    new Award {Name = "Blue First", SellIn = 19, Quality = 15},
                    new Award {Name = "Blue First", SellIn = 18, Quality = 48},
                    new Award {Name = "Blue First", SellIn = 16, Quality = 32},
                    new Award {Name = "Blue First", SellIn = 54, Quality = 22},
                    new Award {Name = "Blue First", SellIn = 45, Quality = 1},
                    new Award {Name = "Blue First", SellIn = 32, Quality = 50},
                    new Award {Name = "Blue First", SellIn = 141, Quality = 21},
                    new Award {Name = "Blue First", SellIn = 14, Quality = 10},
                    new Award {Name = "Blue First", SellIn = 9, Quality = 20},
                    new Award {Name = "Blue First", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue First", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue First", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue First", SellIn = 15, Quality = 42},
                    new Award {Name = "Blue First", SellIn = 19, Quality = 37},
                    new Award {Name = "Blue First", SellIn = 18, Quality = 20},
                    new Award {Name = "Blue First", SellIn = 17, Quality = 4},
                    new Award {Name = "Blue First", SellIn = 12, Quality = 34},
                    new Award {Name = "Blue First", SellIn = 5, Quality = 40},
                    new Award {Name = "Blue First", SellIn = 4, Quality = 29},
                    new Award {Name = "Blue First", SellIn = 12, Quality = 11},
                    new Award {Name = "Blue First", SellIn = 17, Quality = 30},

                    #endregion TestData
                }
            };

            var numberOfMismatchs = 0;

            for (var x = 0; x < LegacyCompareTestCyclesToRun; x++)
            {
                legacyApp.UpdateQualityLegacy();
                app.UpdateQuality();
                for (var i = 0; i < legacyApp.Awards.Count; i++)
                {
                    var legacyAward = legacyApp.Awards[i];
                    var award = app.Awards[i];

                    if (legacyAward.Quality != award.Quality)
                        numberOfMismatchs++;

                    if (numberOfMismatchs > ErrorThreshold)
                        break;
                }
            }

            Assert.IsTrue(numberOfMismatchs == 0);
        }

        [TestMethod]
        // NOTE: For this method to work the commented out code in Legacy must be un-commented
        public void TestBlueStarLegacyVsNew()
        {
            var legacyApp = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "Blue Star", SellIn = 2, Quality = 20},
                    new Award {Name = "Blue Star", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue Star", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue Star", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue Star", SellIn = 8, Quality = 48},
                    new Award {Name = "Blue Star", SellIn = 19, Quality = 35},
                    new Award {Name = "Blue Star", SellIn = 18, Quality = 40},
                    new Award {Name = "Blue Star", SellIn = 12, Quality = 6},
                    new Award {Name = "Blue Star", SellIn = 5, Quality = 2},
                    new Award {Name = "Blue Star", SellIn = 9, Quality = 0},
                    new Award {Name = "Blue Star", SellIn = 0, Quality = 50},
                    new Award {Name = "Blue Star", SellIn = 11, Quality = 1},
                    new Award {Name = "Blue Star", SellIn = 17, Quality = 10},
                    new Award {Name = "Blue Star", SellIn = 24, Quality = 22},
                    new Award {Name = "Blue Star", SellIn = 20, Quality = 33},
                    new Award {Name = "Blue Star", SellIn = 10, Quality = 43},
                    new Award {Name = "Blue Star", SellIn = 6, Quality = 43},
                    new Award {Name = "Blue Star", SellIn = 8, Quality = 38},
                    new Award {Name = "Blue Star", SellIn = 19, Quality = 15},
                    new Award {Name = "Blue Star", SellIn = 18, Quality = 48},
                    new Award {Name = "Blue Star", SellIn = 16, Quality = 32},
                    new Award {Name = "Blue Star", SellIn = 54, Quality = 22},
                    new Award {Name = "Blue Star", SellIn = 45, Quality = 1},
                    new Award {Name = "Blue Star", SellIn = 32, Quality = 50},
                    new Award {Name = "Blue Star", SellIn = 141, Quality = 21},
                    new Award {Name = "Blue Star", SellIn = 14, Quality = 10},
                    new Award {Name = "Blue Star", SellIn = 9, Quality = 20},
                    new Award {Name = "Blue Star", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue Star", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue Star", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue Star", SellIn = 15, Quality = 42},
                    new Award {Name = "Blue Star", SellIn = 19, Quality = 37},
                    new Award {Name = "Blue Star", SellIn = 18, Quality = 20},
                    new Award {Name = "Blue Star", SellIn = 17, Quality = 4},
                    new Award {Name = "Blue Star", SellIn = 12, Quality = 34},
                    new Award {Name = "Blue Star", SellIn = 5, Quality = 40},
                    new Award {Name = "Blue Star", SellIn = 4, Quality = 29},
                    new Award {Name = "Blue Star", SellIn = 12, Quality = 11},
                    new Award {Name = "Blue Star", SellIn = 17, Quality = 30},
                    #endregion TestData
                }
            };

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "Blue Star", SellIn = 2, Quality = 20},
                    new Award {Name = "Blue Star", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue Star", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue Star", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue Star", SellIn = 8, Quality = 48},
                    new Award {Name = "Blue Star", SellIn = 19, Quality = 35},
                    new Award {Name = "Blue Star", SellIn = 18, Quality = 40},
                    new Award {Name = "Blue Star", SellIn = 12, Quality = 6},
                    new Award {Name = "Blue Star", SellIn = 5, Quality = 2},
                    new Award {Name = "Blue Star", SellIn = 9, Quality = 0},
                    new Award {Name = "Blue Star", SellIn = 0, Quality = 50},
                    new Award {Name = "Blue Star", SellIn = 11, Quality = 1},
                    new Award {Name = "Blue Star", SellIn = 17, Quality = 10},
                    new Award {Name = "Blue Star", SellIn = 24, Quality = 22},
                    new Award {Name = "Blue Star", SellIn = 20, Quality = 33},
                    new Award {Name = "Blue Star", SellIn = 10, Quality = 43},
                    new Award {Name = "Blue Star", SellIn = 6, Quality = 43},
                    new Award {Name = "Blue Star", SellIn = 8, Quality = 38},
                    new Award {Name = "Blue Star", SellIn = 19, Quality = 15},
                    new Award {Name = "Blue Star", SellIn = 18, Quality = 48},
                    new Award {Name = "Blue Star", SellIn = 16, Quality = 32},
                    new Award {Name = "Blue Star", SellIn = 54, Quality = 22},
                    new Award {Name = "Blue Star", SellIn = 45, Quality = 1},
                    new Award {Name = "Blue Star", SellIn = 32, Quality = 50},
                    new Award {Name = "Blue Star", SellIn = 141, Quality = 21},
                    new Award {Name = "Blue Star", SellIn = 14, Quality = 10},
                    new Award {Name = "Blue Star", SellIn = 9, Quality = 20},
                    new Award {Name = "Blue Star", SellIn = 20, Quality = 30},
                    new Award {Name = "Blue Star", SellIn = 10, Quality = 25},
                    new Award {Name = "Blue Star", SellIn = 6, Quality = 9},
                    new Award {Name = "Blue Star", SellIn = 15, Quality = 42},
                    new Award {Name = "Blue Star", SellIn = 19, Quality = 37},
                    new Award {Name = "Blue Star", SellIn = 18, Quality = 20},
                    new Award {Name = "Blue Star", SellIn = 17, Quality = 4},
                    new Award {Name = "Blue Star", SellIn = 12, Quality = 34},
                    new Award {Name = "Blue Star", SellIn = 5, Quality = 40},
                    new Award {Name = "Blue Star", SellIn = 4, Quality = 29},
                    new Award {Name = "Blue Star", SellIn = 12, Quality = 11},
                    new Award {Name = "Blue Star", SellIn = 17, Quality = 30},
                    #endregion TestData
                }
            };

            var numberOfMismatchs = 0;

            for (var x = 0; x < LegacyCompareTestCyclesToRun; x++)
            {
                legacyApp.UpdateQualityLegacy();
                app.UpdateQuality();
                for (var i = 0; i < legacyApp.Awards.Count; i++)
                {
                    var legacyAward = legacyApp.Awards[i];
                    var award = app.Awards[i];

                    if (legacyAward.Quality != award.Quality)
                        numberOfMismatchs++;

                    if (numberOfMismatchs > ErrorThreshold)
                        break;
                }
            }

            Assert.IsTrue(numberOfMismatchs == 0);
        }

        [TestMethod]
        public void TestGovQualityPlusLegacyVsNew()
        {
            var legacyApp = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "Gov Quality Plus", SellIn = 2, Quality = 20},
                    new Award {Name = "Gov Quality Plus", SellIn = 20, Quality = 30},
                    new Award {Name = "Gov Quality Plus", SellIn = 10, Quality = 25},
                    new Award {Name = "Gov Quality Plus", SellIn = 6, Quality = 9},
                    new Award {Name = "Gov Quality Plus", SellIn = 8, Quality = 48},
                    new Award {Name = "Gov Quality Plus", SellIn = 19, Quality = 35},
                    new Award {Name = "Gov Quality Plus", SellIn = 18, Quality = 40},
                    new Award {Name = "Gov Quality Plus", SellIn = 12, Quality = 6},
                    new Award {Name = "Gov Quality Plus", SellIn = 5, Quality = 2},
                    new Award {Name = "Gov Quality Plus", SellIn = 9, Quality = 0},
                    new Award {Name = "Gov Quality Plus", SellIn = 0, Quality = 50},
                    new Award {Name = "Gov Quality Plus", SellIn = 11, Quality = 1},
                    new Award {Name = "Gov Quality Plus", SellIn = 17, Quality = 10},
                    new Award {Name = "Gov Quality Plus", SellIn = 24, Quality = 22},
                    new Award {Name = "Gov Quality Plus", SellIn = 20, Quality = 33},
                    new Award {Name = "Gov Quality Plus", SellIn = 10, Quality = 43},
                    new Award {Name = "Gov Quality Plus", SellIn = 6, Quality = 43},
                    new Award {Name = "Gov Quality Plus", SellIn = 8, Quality = 38},
                    new Award {Name = "Gov Quality Plus", SellIn = 19, Quality = 15},
                    new Award {Name = "Gov Quality Plus", SellIn = 18, Quality = 48},
                    new Award {Name = "Gov Quality Plus", SellIn = 16, Quality = 32},
                    new Award {Name = "Gov Quality Plus", SellIn = 54, Quality = 22},
                    new Award {Name = "Gov Quality Plus", SellIn = 45, Quality = 1},
                    new Award {Name = "Gov Quality Plus", SellIn = 32, Quality = 50},
                    new Award {Name = "Gov Quality Plus", SellIn = 141, Quality = 21},
                    new Award {Name = "Gov Quality Plus", SellIn = 14, Quality = 10},
                    new Award {Name = "Gov Quality Plus", SellIn = 9, Quality = 20},
                    new Award {Name = "Gov Quality Plus", SellIn = 20, Quality = 30},
                    new Award {Name = "Gov Quality Plus", SellIn = 10, Quality = 25},
                    new Award {Name = "Gov Quality Plus", SellIn = 6, Quality = 9},
                    new Award {Name = "Gov Quality Plus", SellIn = 15, Quality = 42},
                    new Award {Name = "Gov Quality Plus", SellIn = 19, Quality = 37},
                    new Award {Name = "Gov Quality Plus", SellIn = 18, Quality = 20},
                    new Award {Name = "Gov Quality Plus", SellIn = 17, Quality = 4},
                    new Award {Name = "Gov Quality Plus", SellIn = 12, Quality = 34},
                    new Award {Name = "Gov Quality Plus", SellIn = 5, Quality = 40},
                    new Award {Name = "Gov Quality Plus", SellIn = 4, Quality = 29},
                    new Award {Name = "Gov Quality Plus", SellIn = 12, Quality = 11},
                    new Award {Name = "Gov Quality Plus", SellIn = 17, Quality = 30},
                    #endregion TestData
                }
            };

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "Gov Quality Plus", SellIn = 2, Quality = 20},
                    new Award {Name = "Gov Quality Plus", SellIn = 20, Quality = 30},
                    new Award {Name = "Gov Quality Plus", SellIn = 10, Quality = 25},
                    new Award {Name = "Gov Quality Plus", SellIn = 6, Quality = 9},
                    new Award {Name = "Gov Quality Plus", SellIn = 8, Quality = 48},
                    new Award {Name = "Gov Quality Plus", SellIn = 19, Quality = 35},
                    new Award {Name = "Gov Quality Plus", SellIn = 18, Quality = 40},
                    new Award {Name = "Gov Quality Plus", SellIn = 12, Quality = 6},
                    new Award {Name = "Gov Quality Plus", SellIn = 5, Quality = 2},
                    new Award {Name = "Gov Quality Plus", SellIn = 9, Quality = 0},
                    new Award {Name = "Gov Quality Plus", SellIn = 0, Quality = 50},
                    new Award {Name = "Gov Quality Plus", SellIn = 11, Quality = 1},
                    new Award {Name = "Gov Quality Plus", SellIn = 17, Quality = 10},
                    new Award {Name = "Gov Quality Plus", SellIn = 24, Quality = 22},
                    new Award {Name = "Gov Quality Plus", SellIn = 20, Quality = 33},
                    new Award {Name = "Gov Quality Plus", SellIn = 10, Quality = 43},
                    new Award {Name = "Gov Quality Plus", SellIn = 6, Quality = 43},
                    new Award {Name = "Gov Quality Plus", SellIn = 8, Quality = 38},
                    new Award {Name = "Gov Quality Plus", SellIn = 19, Quality = 15},
                    new Award {Name = "Gov Quality Plus", SellIn = 18, Quality = 48},
                    new Award {Name = "Gov Quality Plus", SellIn = 16, Quality = 32},
                    new Award {Name = "Gov Quality Plus", SellIn = 54, Quality = 22},
                    new Award {Name = "Gov Quality Plus", SellIn = 45, Quality = 1},
                    new Award {Name = "Gov Quality Plus", SellIn = 32, Quality = 50},
                    new Award {Name = "Gov Quality Plus", SellIn = 141, Quality = 21},
                    new Award {Name = "Gov Quality Plus", SellIn = 14, Quality = 10},
                    new Award {Name = "Gov Quality Plus", SellIn = 9, Quality = 20},
                    new Award {Name = "Gov Quality Plus", SellIn = 20, Quality = 30},
                    new Award {Name = "Gov Quality Plus", SellIn = 10, Quality = 25},
                    new Award {Name = "Gov Quality Plus", SellIn = 6, Quality = 9},
                    new Award {Name = "Gov Quality Plus", SellIn = 15, Quality = 42},
                    new Award {Name = "Gov Quality Plus", SellIn = 19, Quality = 37},
                    new Award {Name = "Gov Quality Plus", SellIn = 18, Quality = 20},
                    new Award {Name = "Gov Quality Plus", SellIn = 17, Quality = 4},
                    new Award {Name = "Gov Quality Plus", SellIn = 12, Quality = 34},
                    new Award {Name = "Gov Quality Plus", SellIn = 5, Quality = 40},
                    new Award {Name = "Gov Quality Plus", SellIn = 4, Quality = 29},
                    new Award {Name = "Gov Quality Plus", SellIn = 12, Quality = 11},
                    new Award {Name = "Gov Quality Plus", SellIn = 17, Quality = 30},
                    #endregion TestData
                }
            };

            var numberOfMismatchs = 0;

            for (var x = 0; x < LegacyCompareTestCyclesToRun; x++)
            {
                legacyApp.UpdateQualityLegacy();
                app.UpdateQuality();
                for (var i = 0; i < legacyApp.Awards.Count; i++)
                {
                    var legacyAward = legacyApp.Awards[i];
                    var award = app.Awards[i];

                    if (legacyAward.Quality != award.Quality)
                        numberOfMismatchs++;

                    if (numberOfMismatchs > ErrorThreshold)
                        break;
                }
            }

            Assert.IsTrue(numberOfMismatchs == 0);
        }

        [TestMethod]
        public void TestTopConnectedProvidersLegacyVsNew()
        {
            var legacyApp = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "Top Connected Providres", SellIn = 2, Quality = 20},
                    new Award {Name = "Top Connected Providres", SellIn = 20, Quality = 30},
                    new Award {Name = "Top Connected Providres", SellIn = 10, Quality = 25},
                    new Award {Name = "Top Connected Providres", SellIn = 6, Quality = 9},
                    new Award {Name = "Top Connected Providres", SellIn = 8, Quality = 48},
                    new Award {Name = "Top Connected Providres", SellIn = 19, Quality = 35},
                    new Award {Name = "Top Connected Providres", SellIn = 18, Quality = 40},
                    new Award {Name = "Top Connected Providres", SellIn = 12, Quality = 6},
                    new Award {Name = "Top Connected Providres", SellIn = 5, Quality = 2},
                    new Award {Name = "Top Connected Providres", SellIn = 9, Quality = 0},
                    new Award {Name = "Top Connected Providres", SellIn = 0, Quality = 50},
                    new Award {Name = "Top Connected Providres", SellIn = 11, Quality = 1},
                    new Award {Name = "Top Connected Providres", SellIn = 17, Quality = 10},
                    new Award {Name = "Top Connected Providres", SellIn = 24, Quality = 22},
                    new Award {Name = "Top Connected Providres", SellIn = 20, Quality = 33},
                    new Award {Name = "Top Connected Providres", SellIn = 10, Quality = 43},
                    new Award {Name = "Top Connected Providres", SellIn = 6, Quality = 43},
                    new Award {Name = "Top Connected Providres", SellIn = 8, Quality = 38},
                    new Award {Name = "Top Connected Providres", SellIn = 19, Quality = 15},
                    new Award {Name = "Top Connected Providres", SellIn = 18, Quality = 48},
                    new Award {Name = "Top Connected Providres", SellIn = 16, Quality = 32},
                    new Award {Name = "Top Connected Providres", SellIn = 54, Quality = 22},
                    new Award {Name = "Top Connected Providres", SellIn = 45, Quality = 1},
                    new Award {Name = "Top Connected Providres", SellIn = 32, Quality = 50},
                    new Award {Name = "Top Connected Providres", SellIn = 141, Quality = 21},
                    new Award {Name = "Top Connected Providres", SellIn = 14, Quality = 10},
                    new Award {Name = "Top Connected Providres", SellIn = 9, Quality = 20},
                    new Award {Name = "Top Connected Providres", SellIn = 20, Quality = 30},
                    new Award {Name = "Top Connected Providres", SellIn = 10, Quality = 25},
                    new Award {Name = "Top Connected Providres", SellIn = 6, Quality = 9},
                    new Award {Name = "Top Connected Providres", SellIn = 15, Quality = 42},
                    new Award {Name = "Top Connected Providres", SellIn = 19, Quality = 37},
                    new Award {Name = "Top Connected Providres", SellIn = 18, Quality = 20},
                    new Award {Name = "Top Connected Providres", SellIn = 17, Quality = 4},
                    new Award {Name = "Top Connected Providres", SellIn = 12, Quality = 34},
                    new Award {Name = "Top Connected Providres", SellIn = 5, Quality = 40},
                    new Award {Name = "Top Connected Providres", SellIn = 4, Quality = 29},
                    new Award {Name = "Top Connected Providres", SellIn = 12, Quality = 11},
                    new Award {Name = "Top Connected Providres", SellIn = 17, Quality = 30},
                    #endregion TestData
                }
            };

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    #region TestData
                    new Award {Name = "Top Connected Providres", SellIn = 2, Quality = 20},
                    new Award {Name = "Top Connected Providres", SellIn = 20, Quality = 30},
                    new Award {Name = "Top Connected Providres", SellIn = 10, Quality = 25},
                    new Award {Name = "Top Connected Providres", SellIn = 6, Quality = 9},
                    new Award {Name = "Top Connected Providres", SellIn = 8, Quality = 48},
                    new Award {Name = "Top Connected Providres", SellIn = 19, Quality = 35},
                    new Award {Name = "Top Connected Providres", SellIn = 18, Quality = 40},
                    new Award {Name = "Top Connected Providres", SellIn = 12, Quality = 6},
                    new Award {Name = "Top Connected Providres", SellIn = 5, Quality = 2},
                    new Award {Name = "Top Connected Providres", SellIn = 9, Quality = 0},
                    new Award {Name = "Top Connected Providres", SellIn = 0, Quality = 50},
                    new Award {Name = "Top Connected Providres", SellIn = 11, Quality = 1},
                    new Award {Name = "Top Connected Providres", SellIn = 17, Quality = 10},
                    new Award {Name = "Top Connected Providres", SellIn = 24, Quality = 22},
                    new Award {Name = "Top Connected Providres", SellIn = 20, Quality = 33},
                    new Award {Name = "Top Connected Providres", SellIn = 10, Quality = 43},
                    new Award {Name = "Top Connected Providres", SellIn = 6, Quality = 43},
                    new Award {Name = "Top Connected Providres", SellIn = 8, Quality = 38},
                    new Award {Name = "Top Connected Providres", SellIn = 19, Quality = 15},
                    new Award {Name = "Top Connected Providres", SellIn = 18, Quality = 48},
                    new Award {Name = "Top Connected Providres", SellIn = 16, Quality = 32},
                    new Award {Name = "Top Connected Providres", SellIn = 54, Quality = 22},
                    new Award {Name = "Top Connected Providres", SellIn = 45, Quality = 1},
                    new Award {Name = "Top Connected Providres", SellIn = 32, Quality = 50},
                    new Award {Name = "Top Connected Providres", SellIn = 141, Quality = 21},
                    new Award {Name = "Top Connected Providres", SellIn = 14, Quality = 10},
                    new Award {Name = "Top Connected Providres", SellIn = 9, Quality = 20},
                    new Award {Name = "Top Connected Providres", SellIn = 20, Quality = 30},
                    new Award {Name = "Top Connected Providres", SellIn = 10, Quality = 25},
                    new Award {Name = "Top Connected Providres", SellIn = 6, Quality = 9},
                    new Award {Name = "Top Connected Providres", SellIn = 15, Quality = 42},
                    new Award {Name = "Top Connected Providres", SellIn = 19, Quality = 37},
                    new Award {Name = "Top Connected Providres", SellIn = 18, Quality = 20},
                    new Award {Name = "Top Connected Providres", SellIn = 17, Quality = 4},
                    new Award {Name = "Top Connected Providres", SellIn = 12, Quality = 34},
                    new Award {Name = "Top Connected Providres", SellIn = 5, Quality = 40},
                    new Award {Name = "Top Connected Providres", SellIn = 4, Quality = 29},
                    new Award {Name = "Top Connected Providres", SellIn = 12, Quality = 11},
                    new Award {Name = "Top Connected Providres", SellIn = 17, Quality = 30},
                    #endregion TestData
                }
            };

            var numberOfMismatchs = 0;

            for (var x = 0; x < LegacyCompareTestCyclesToRun; x++)
            {
                legacyApp.UpdateQualityLegacy();
                app.UpdateQuality();
                for (var i = 0; i < legacyApp.Awards.Count; i++)
                {
                    var legacyAward = legacyApp.Awards[i];
                    var award = app.Awards[i];

                    if (legacyAward.Quality != award.Quality)
                        numberOfMismatchs++;

                    if (numberOfMismatchs > ErrorThreshold)
                        break;
                }
            }

            Assert.IsTrue(numberOfMismatchs == 0);
        }

        [TestMethod]
        public void TestUnknownAward()
        {
            var cycleCount = 4;
            var startQuality = 10;
            var startSellIn = 4;

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Bleu Compare", SellIn = startSellIn, Quality = startQuality}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Bleu Compare");
            Assert.IsTrue(app.Awards[0].Quality == startQuality);
            Assert.IsTrue(app.Awards[0].SellIn == startSellIn);

            for (var x = 0; x < cycleCount; x++)
            {
                app.UpdateQuality();
            }

            // Most awards modify the quality, on unknown dont change values, start values should still be the same
            Assert.IsTrue(app.Awards[0].Quality == startQuality && app.Awards[0].SellIn == startSellIn);
        }
    }
}
