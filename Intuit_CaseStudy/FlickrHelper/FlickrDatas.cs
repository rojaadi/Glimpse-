using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuit_CaseStudy_FlickrHelper
{
    public class FlickrDatas
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public DateTime modified { get; set; }
        public string generator { get; set; }
        public List<ImageItem> items { get; set; }
    }
}
