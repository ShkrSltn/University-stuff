using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class ClientCompanyModel : BaseModel
    {
        public string company_name { get; set; }
        public string director { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
