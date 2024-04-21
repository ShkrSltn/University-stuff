using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class TypeOfServiceModel : BaseModel
    {
        public string platform_type { get; set; }
        public int partners_id { get; set; }
        public float price { get; set; }
    }
}
