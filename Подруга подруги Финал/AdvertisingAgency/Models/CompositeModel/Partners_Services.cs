using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models.CompositeModel
{
    public class Partners_Services
    {
        public PartnersModel partners { get; set; }
        public List<TypeOfServiceModel> services { get; set; }
    }
}
