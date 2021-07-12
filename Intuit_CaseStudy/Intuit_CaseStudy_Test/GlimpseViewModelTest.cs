using CaseStudy_TwitterServices;
using Intuit_CaseStudy;
using Intuit_CaseStudy_FlickrHelper;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuit_CaseStudy_Test
{
    [TestFixture]
    public class GlimpseViewModelTest
    {
        private GlimpseViewModel glimpse;
        private ITwitterServiceHelper twitterAPI;
        private IFlickrServiceHelper flickrAPI;

        [SetUp]
        public void SetUp()
        {
            twitterAPI = MockRepository.GenerateStrictMock<ITwitterServiceHelper>();
            flickrAPI = MockRepository.GenerateStrictMock<IFlickrServiceHelper>();
            glimpse = new GlimpseViewModel(twitterAPI,flickrAPI);
        }
        [Test]
        public void ExecuteSearchTest()
        {
            Task<string> task = Task<string>.Factory.StartNew(() =>
            {
                string flickrResult = null;
                var flickrResultPath = "flickr.json";
                using (StreamReader reader = new StreamReader(flickrResultPath))
                {
                   flickrResult = reader.ReadToEnd();
                }
                return flickrResult;
            });
            Task<string> task2 = Task<string>.Factory.StartNew(() =>
            {
                string oAuthResult = null;
                var oAuthResultPath = "OAuthTwitter.json";
                using (StreamReader reader = new StreamReader(oAuthResultPath))
                {
                    oAuthResult = reader.ReadToEnd();
                }
                return oAuthResult;
            });
            Task<string> task3 = Task<string>.Factory.StartNew(() =>
            {
                string twitterResult = null;
                var twitterResultPath = "twitter.json";
                using (StreamReader reader = new StreamReader(twitterResultPath))
                {
                    twitterResult = reader.ReadToEnd();
                }
                return twitterResult;
            });
            glimpse.SearchString = "nature";
            
            
            flickrAPI.Expect(d => d.GetImages("nature")).IgnoreArguments().Return(task);
            twitterAPI.Expect(d => d.GetAccessToken()).Return(task2);
            twitterAPI.Expect(d => d.GetTweets(10, "nature", "")).IgnoreArguments().Return(task3);
            glimpse.ExecuteSearch();
            flickrAPI.VerifyAllExpectations();
        }

        [Test]
        public void GetImagesTest()
        {
            Task<string> task = Task<string>.Factory.StartNew(() =>
            {
                string flickrResult = null;
                var flickrResultPath = "flickr.json";
                using (StreamReader reader = new StreamReader(flickrResultPath))
                {
                    flickrResult = reader.ReadToEnd();
                }
                return flickrResult;
            });
            flickrAPI.Expect(d => d.GetImages("nature")).IgnoreArguments().Return(task);
            glimpse.SearchString = "nature";
            var result = glimpse.GetImages();
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetTweetsTest()
        {
            Task<string> task2 = Task<string>.Factory.StartNew(() =>
            {
                string oAuthResult = null;
                var oAuthResultPath = "OAuthTwitter.json";
                using (StreamReader reader = new StreamReader(oAuthResultPath))
                {
                    oAuthResult = reader.ReadToEnd();
                }
                return oAuthResult;
            });
            Task<string> task3 = Task<string>.Factory.StartNew(() =>
            {
                string twitterResult = null;
                var twitterResultPath = "twitter.json";
                using (StreamReader reader = new StreamReader(twitterResultPath))
                {
                    twitterResult = reader.ReadToEnd();
                }
                return twitterResult;
            });
            glimpse.SearchString = "nature";
            twitterAPI.Expect(d => d.GetAccessToken()).Return(task2);
            twitterAPI.Expect(d => d.GetTweets(10, "nature", "")).IgnoreArguments().Return(task3);
            var result = glimpse.GetTweets(10);
            Assert.IsNotNull(result);
        }

        [Test]
        public void RequetFlickrhomePageTest()
        {
            flickrAPI.Expect(d => d.RequestFlickrHomePage()).Return(true);
            Assert.IsTrue(glimpse.RequestFlickrHomePage());
        }
        [Test]
        public void RequetTwitterhomePageTest()
        {
            twitterAPI.Expect(d => d.RequestTwitterHomePage()).Return(true);
            Assert.IsTrue(glimpse.RequestTwitterHomePage());
        }
        [Test]
        public void ExecuteSearchExceptionTest()
        {          
            Task<string> task2 = Task<string>.Factory.StartNew(() =>
            {
                string oAuthResult = null;
                var oAuthResultPath = "OAuthTwitter.json";
                using (StreamReader reader = new StreamReader(oAuthResultPath))
                {
                    oAuthResult = reader.ReadToEnd();
                }
                return oAuthResult;
            });
            Task<string> task3 = Task<string>.Factory.StartNew(() =>
            {
                string twitterResult = null;
                var twitterResultPath = "twitter.json";
                using (StreamReader reader = new StreamReader(twitterResultPath))
                {
                    twitterResult = reader.ReadToEnd();
                }
                return twitterResult;
            });
            glimpse.SearchString = "nature";


            flickrAPI.Expect(d => d.GetImages("nature")).IgnoreArguments().Throw(new Exception());
            twitterAPI.Expect(d => d.GetAccessToken()).Return(task2);
            twitterAPI.Expect(d => d.GetTweets(10, "nature", "")).IgnoreArguments().Return(task3);
            glimpse.ExecuteSearch();
            Assert.IsNull(glimpse.TweetIDS);
        }

        [Test]
        public void GetImagesExceptionTest()
        {
            flickrAPI.Expect(d => d.GetImages("nature")).IgnoreArguments().Throw(new Exception());
            glimpse.SearchString = "nature";
            var result = glimpse.GetImages();
            Assert.IsNull(glimpse.ImagesFor);
        }

        [Test]
        public void GetTweetsExceptionTest()
        {
            Task<string> task2 = Task<string>.Factory.StartNew(() =>
            {
                string oAuthResult = null;
                var oAuthResultPath = "OAuthTwitter.json";
                using (StreamReader reader = new StreamReader(oAuthResultPath))
                {
                    oAuthResult = reader.ReadToEnd();
                }
                return oAuthResult;
            });
          
            glimpse.SearchString = "nature";
            twitterAPI.Expect(d => d.GetAccessToken()).Return(task2);
            twitterAPI.Expect(d => d.GetTweets(10, "nature", "")).IgnoreArguments().Throw(new Exception());
            var result = glimpse.GetTweets(10);
            Assert.IsNull(glimpse.TweetsFor);
        }

        [Test,ExpectedException(typeof(TimeoutException))]
        public void RequetFlickrhomePageExceptionTest()
        {
            flickrAPI.Expect(d => d.RequestFlickrHomePage()).Throw(new TimeoutException());
            glimpse.RequestFlickrHomePage();
        }
        [Test,ExpectedException(typeof(TimeoutException))]
        public void RequetTwitterhomePageExceptionTest()
        {
            twitterAPI.Expect(d => d.RequestTwitterHomePage()).Throw(new TimeoutException());
            glimpse.RequestTwitterHomePage();
        }
        [Test]
        public void ConstructorTest()
        {
            glimpse = new GlimpseViewModel();
            Assert.IsNull( glimpse.OpenClose);
        }
        [TearDown]
        public void TearDown()
        {
            twitterAPI = null;
            flickrAPI = null;
            glimpse = null;
        }
       
    }
}
