using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class BeforeTheContractModel : BaseModel
    {
        public int media_plan_id { get; set; }
        public int contract_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }
}
