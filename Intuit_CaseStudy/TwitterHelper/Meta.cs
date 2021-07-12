using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy_TwitterServices
{
    public class Meta
    {
        public string newest_id { get; set; }
        public string oldest_id { get; set; }
        public int result_count { get; set; }
        public string next_token { get; set; }
    }
}
