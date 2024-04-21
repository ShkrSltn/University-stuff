using System.Collections.Generic;
using Npgsql;

namespace AdvertisingAgency.Models
{
    public abstract class BaseModel
    {
        public int id { get; set; }
    }
}
