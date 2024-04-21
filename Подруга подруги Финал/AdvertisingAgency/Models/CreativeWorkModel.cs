using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class CreativeWorkModel : BaseModel
    {
        public int media_plan_id { get; set; }
        public bool work_status { get; set; }
        public int worker_id { get; set; }
        public string specification { get; set; }
        public string description { get; set; }
    }
}
