using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy_TwitterServices
{
    /// <summary>
    /// Class for Flicker public feed API's which needs twitter Developer account 
    /// </summary>
    public class TwitterServiceHelper : ITwitterServiceHelper
    {
        //will be unique for each developer
        string OAuthConsumerKey = "SLcPucSA3EPn4juzxFRU1vjSG";
        string OAuthConsumerSecret = "8YDifxJkJYGlFCNUXFXlmkEJbxWXoNTBvTku6gkZDfDWChQvtG";
        //
        private string accesstoken;
        private string accesstype;

        /// <summary>
        /// Get TwitterUserID's with given string and count
        /// </summary>
        /// <param name="count"></param>
        /// <param name="SearchString"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<string> GetTweets(int count,string SearchString, string twitterAccessToken)
        {

            var url = "https://api.twitter.com/2/tweets/search/recent?query=" + SearchString + "&max_results=10&expansions=author_id&tweet.fields=created_at,lang,conversation_id&user.fields=created_at,entities";

            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, url);

            requestUserTimeline.Headers.Add("Authorization", "bearer " + twitterAccessToken);

            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);

            string token = await responseUserTimeLine.Content.ReadAsStringAsync();
            return token;
        }

        /// <summary>
        /// Get access token of developer
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAccessToken()
        {           
            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token");

            var customerInfo = Convert.ToBase64String(new UTF8Encoding()
                                      .GetBytes(OAuthConsumerKey + ":" + OAuthConsumerSecret));

            request.Headers.Add("Authorization", "Basic " + customerInfo);
            request.Content = new StringContent("grant_type=client_credentials",
                                                    Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = await httpClient.SendAsync(request);

            string token = await response.Content.ReadAsStringAsync();
            TokenAccess access = JsonConvert.DeserializeObject<TokenAccess>(token);

            accesstoken = access.access_token;
            accesstype = access.token_type;

            return accesstoken;
        }

        /// <summary>
        /// Start twitter home page
        /// </summary>
        /// <returns></returns>
        public bool RequestTwitterHomePage()
        {
            var result = Process.Start(new ProcessStartInfo("https://twitter.com/home"));
            return result.HasExited;
        }
    }
}
