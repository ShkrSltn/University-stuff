using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace AdvertisingAgency.Models
{
    public class PositionModel:BaseModel
    {
        public string name { get; set; }
        public float salary { get; set; }
    }
}
