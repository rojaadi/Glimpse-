using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Intuit_CaseStudy_FlickrHelper
{
    /// <summary>
    /// Class for Flicker public feed API's
    /// </summary>
    public class FlickrServiceHelper : IFlickrServiceHelper
    {
        /// <summary>
        /// Get Flickr Images with given input string 
        /// </summary>
        /// <param name="SearchString"></param>
        /// <returns></returns>
        public  async Task<string> GetImages(string SearchString)
        {

            HttpClient client = new HttpClient();

            var url = "https://www.flickr.com/services/feeds/photos_public.gne" + "?format=json&nojsoncallback=1"
                + "&tags=" + SearchString;
            string flickrResult = await client.GetStringAsync(url);
            return flickrResult;
        } 

        /// <summary>
        /// Launch Flickr homepage
        /// </summary>
        /// <returns></returns>
        public bool RequestFlickrHomePage()
        {
            var result = Process.Start(new ProcessStartInfo("https://www.flickr.com/"));
            return result.HasExited;
        }
    }
}
