using System.Threading.Tasks;

namespace CaseStudy_TwitterServices
{
    public interface ITwitterServiceHelper
    {
        Task<string> GetAccessToken();
        Task<string> GetTweets(int count, string SearchString, string accessToken );
        bool RequestTwitterHomePage();
    }
}