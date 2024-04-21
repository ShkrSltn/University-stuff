using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class ContractModel : BaseModel
    {
        public string company_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public float total_sum { get; set; }
        public string post_code { get; set; }
        public int inn { get; set; }
        public string payment_method { get; set; }
        public string status { get; set; }
    }
}
