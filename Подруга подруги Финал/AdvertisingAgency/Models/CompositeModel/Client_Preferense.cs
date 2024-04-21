using System.Collections.Generic;

namespace AdvertisingAgency.Models.CompositeModel
{
    public class Client_Preferense
    {
        public ClientCompanyModel client { get; set; }
        public PreferenseListModel preference { get; set; } 
    }
}
