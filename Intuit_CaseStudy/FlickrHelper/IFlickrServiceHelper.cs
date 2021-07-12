using System.Threading.Tasks;

namespace Intuit_CaseStudy_FlickrHelper
{
    public interface IFlickrServiceHelper
    {
        Task<string> GetImages(string SearchString);
        bool RequestFlickrHomePage();
    }
}