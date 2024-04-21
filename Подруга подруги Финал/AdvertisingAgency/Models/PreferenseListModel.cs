using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class PreferenseListModel : BaseModel
    {
        public int client_id { get; set; }
        public string audience { get; set; }
        public string preculiarities { get; set; }
        public int period { get; set; }
        public float max_sum { get; set; }
    }
}
