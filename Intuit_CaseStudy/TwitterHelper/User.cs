using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy_TwitterServices
{
    public class User
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public Entities entities { get; set; }
    }
}
