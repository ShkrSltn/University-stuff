using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models.CompositeModel
{
    public class Staff_CreateWork
    {
        public StaffModel staff { get; set; }
        public CreativeWorkModel creativeWork { get; set; }
    }
}
