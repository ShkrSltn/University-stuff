using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models.CompositeModel
{
    public class Staff_StaffPosition_Position
    {
        public StaffModel staff { get; set; }
        public StaffPositionModel staffPosition { get; set; }

        public PositionModel position { get; set; }
    }
}
