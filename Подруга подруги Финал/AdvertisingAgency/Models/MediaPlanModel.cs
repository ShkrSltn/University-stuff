using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class MediaPlanModel : BaseModel
    {
        public int preferences_list_id { get; set; }
        public int type_of_service_id { get; set; }
        public int staff_id { get; set; }
        public int broadcast_time { get; set; }
        public float price { get; set; }
        public bool status { get; set; }
    }
}
