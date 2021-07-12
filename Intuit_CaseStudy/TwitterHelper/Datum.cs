using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy_TwitterServices
{
    public class Datum
    {
        public string lang { get; set; }
        public string text { get; set; }
        public string author_id { get; set; }
        public string conversation_id { get; set; }
        public string id { get; set; }
        public DateTime created_at { get; set; }
    }
}
