using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy_TwitterServices
{
    public class TwitterResponse
    {
        public List<Datum> data { get; set; }
        public UsersList includes { get; set; }
        public Meta meta { get; set; }
    }
}
