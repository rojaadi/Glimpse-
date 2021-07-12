using CaseStudy_TwitterServices;
using Intuit_CaseStudy_FlickrHelper;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Intuit_CaseStudy
{
    /// <summary>
    /// View Model for Glimpse Search 
    /// </summary>
    public class GlimpseViewModel:BindableBase,IDisposable
    {
        ICommand searchButtoncmd;
        ICommand requestFlickrPage;
        ICommand requestTwitterPage;
        private string searchString ;
       // private const string FlickrApi is "https://www.flickr.com/services/feeds/docs/photos_public/";
       
        private TwitterResponse data;
        private string _imagesFor;
        private string _tweetsFor;
        private ITwitterServiceHelper twitterAPI;
        private IFlickrServiceHelper flickrAPI;
        private Visibility isLoading;
        private ObservableCollection<string> _tweetIDS;
        private ObservableCollection<string> _images;

        #region Public Properties
        public ICommand SearchButtonCommand
        {
            get
            {
                return searchButtoncmd;
            }
        }

        public ICommand RequestFlickrPage
        {
            get
            {
                return requestFlickrPage;
            }
        }
       public ICommand RequestTwitterPage
        {
            get
            {
                return requestTwitterPage;
            }
        }
        public string ImagesFor
        {
            get
            {
                return _imagesFor;
            }
            set
            {
                SetProperty(ref _imagesFor, value);
            }
        }
        public string TweetsFor
        {
            get
            {
                return _tweetsFor;
            }
            set
            {
                SetProperty(ref _tweetsFor , value);
            }
        }
        public string SearchString
        {
            get
            {
                return searchString;
            }
            set
            {
                searchString = value;
            }
        }
        public Visibility SpinnerVisibility
        {
            get
            {
                return isLoading;
            }
            set
            {
                SetProperty(ref isLoading, value);
            }
        }
       
        public ObservableCollection<string> TweetIDS
        {
            get
            {
                return _tweetIDS;
            }
            set
            {
                SetProperty(ref _tweetIDS, value);
            }
        }

       
        public ObservableCollection<string> Images
        {
            get
            {
                return _images;
            }
            set
            {
                SetProperty(ref _images, value);
            }
        }

        private string _OpenClose;

        public string OpenClose
        {
            get
            {
                return _OpenClose;
            }
            set
            {
                SetProperty(ref _OpenClose, value);
            }
        }
        #endregion


        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GlimpseViewModel()
        {
            SpinnerVisibility = Visibility.Hidden;
            flickrAPI = new FlickrServiceHelper();
            twitterAPI = new TwitterServiceHelper();
            this.searchButtoncmd = new DelegateCommand((obj) => { this.ExecuteSearch(); }, (obj) => { return true; });
            this.requestFlickrPage = new DelegateCommand((obj) => { this.RequestFlickrHomePage(); }, (obj) => { return true; });
            this.requestTwitterPage = new DelegateCommand((obj) => { this.RequestTwitterHomePage(); }, (obj) => { return true; });
        }

        public GlimpseViewModel(ITwitterServiceHelper twitterHelper,IFlickrServiceHelper flickrHelper)
        {
            twitterAPI = twitterHelper;
            flickrAPI = flickrHelper;
        }
        #endregion

        #region internal methods

        /// <summary>
        /// request to open FlickrHomePage
        /// </summary>
        /// <returns></returns>
        internal bool RequestFlickrHomePage()
        {
            return flickrAPI.RequestFlickrHomePage();
        }

        /// <summary>
        /// Request to open Twitter homePage
        /// </summary>
        /// <returns></returns>
        internal bool RequestTwitterHomePage()
        {
            return twitterAPI.RequestTwitterHomePage();
        }

        /// <summary>
        /// exceute Search Functionality
        /// </summary>
        internal async void ExecuteSearch()
        {
            SpinnerVisibility = Visibility.Visible;
            await GetImages();
            await GetTweets(10);
            SpinnerVisibility = Visibility.Hidden;
        }

        /// <summary>
        /// Get Flickr Public Feed Images
        /// </summary>
        /// <returns></returns>
        internal async Task GetImages()
        {
            string flickrResult = await flickrAPI.GetImages(SearchString);
            FlickrDatas apidata = JsonConvert.DeserializeObject<FlickrDatas>(flickrResult);
            Images = new ObservableCollection<string>();
            foreach (var image in apidata.items)
            {
                OpenClose = image.media.m;
                Images.Add(image.media.m);
            }
            ImagesFor = "Images for " + SearchString;
        }

        /// <summary>
        /// Get Twitter UserIDS using Twitter API for a particular developer
        /// </summary>
        /// <param name="count"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        internal async Task GetTweets(int count, string accessToken = null)
        {
            if (accessToken == null)
            {
                accessToken = await twitterAPI.GetAccessToken();
            }

            var token = await twitterAPI.GetTweets(10,SearchString,accessToken);
            data = JsonConvert.DeserializeObject<TwitterResponse>(token);
            TweetIDS = new ObservableCollection<string>();
            foreach(var item in data.includes.users)
            {
                TweetIDS.Add("@"+item.username);
            }
            TweetsFor = "Users  tweeted for " + SearchString;
        }
        #endregion

        ~GlimpseViewModel()
        {
            flickrAPI = null;
            twitterAPI = null;
            Dispose();
        }
        public void Dispose()
        {
            // Prevent the destructor from being called
            GC.SuppressFinalize(this);
        }
    }
       
}
