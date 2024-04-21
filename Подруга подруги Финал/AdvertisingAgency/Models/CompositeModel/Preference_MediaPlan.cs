using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models.CompositeModel
{
    public class Preference_MediaPlan
    {
        public PreferenseListModel preference { get; set; }
        public MediaPlanModel mediaPlan { get; set; }
        public BeforeTheContractModel before { get; set; }
        public ContractModel contract { get; set; }
    }
}
