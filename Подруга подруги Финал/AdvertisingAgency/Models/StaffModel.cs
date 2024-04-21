using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class StaffModel : BaseModel
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime date_of_birthday { get; set; }
        public string sex { get; set; }
        public string tel { get; set; }
        public string password { get; set; }
    }
}
