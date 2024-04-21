using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class StaffPositionModel : BaseModel
    {
        public int staff_id { get; set; }
        public int position_id { get; set; }
        public DateTime start_work { get; set; }
        public DateTime end_work { get; set; }
    }
}
