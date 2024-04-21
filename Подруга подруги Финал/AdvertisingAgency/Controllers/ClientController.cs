using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisingAgency.Models;
using AdvertisingAgency.Models.CompositeModel;

namespace AdvertisingAgency.Controllers
{
    public class ClientController : Controller
    {
        private const string postgres = "client";
        private static ClientCompanyModel client;

        public IActionResult Index()
        {
            ViewBag.Client = client;

            List<PreferenseListModel> preferenseListsOld = DaoMode.GetAllPreferencListClient(client, postgres);
            PreferenseListModel preferense = new PreferenseListModel();
            preferense.client_id = client.id;
            List<Preference_MediaPlan> preference_Medias = DaoMode.GetFullPreferenceListAccepted(preferense, postgres);

            List<Preference_MediaPlan> preference_Medias_Contract = new List<Preference_MediaPlan>();
            List<Preference_MediaPlan> preference_Medias_Accepted = new List<Preference_MediaPlan>();
            List<PreferenseListModel> preferenseListsNow = new List<PreferenseListModel>();

            foreach(PreferenseListModel p in preferenseListsOld)
            {
                bool isPush = false;
                foreach(Preference_MediaPlan p_m in preference_Medias)
                {
                    if(p.id == p_m.preference.id)
                    {
                        isPush = true;
                    }

                    if(p_m.before == null)
                    {
                        bool isAdd = true;
                        foreach(Preference_MediaPlan pm in preference_Medias_Accepted)
                        {
                            if(pm.preference.id == p_m.preference.id)
                            {
                                isAdd = false;
                            }
                        }
                        if (isAdd)
                        {
                            preference_Medias_Accepted.Add(p_m);
                        }
                    }
                    else
                    {
                        bool isAdd = true;
                        foreach (Preference_MediaPlan pm in preference_Medias_Contract)
                        {
                            if (pm.preference.id == p_m.preference.id)
                            {
                                isAdd = false;
                            }
                        }
                        if (isAdd)
                        {
                            preference_Medias_Contract.Add(p_m);
                        }
                        
                    }
                }
                if (!isPush)
                {
                    preferenseListsNow.Add(p);
                }
            }

            ViewBag.Preferences = preferenseListsNow;
            ViewBag.AcceptedPreference = preference_Medias_Accepted;
            ViewBag.ContractPreference = preference_Medias_Contract;

            return View();
        }
        public IActionResult ToLogin(int id)
        {
            client = new ClientCompanyModel();
            client.id = id;

            DaoMode.GetClientById(client, postgres);

            return Redirect("/Client");
        }

        public IActionResult Preference()
        {
            ViewBag.Client = client;

            return View();
        }

        public IActionResult AddPreference(string audience, string preculiarities, int period, float max_sum)
        {
            PreferenseListModel preferens = new PreferenseListModel();
            preferens.client_id = client.id;
            preferens.audience = audience;
            preferens.preculiarities = preculiarities;
            preferens.period = period;
            preferens.max_sum = max_sum;

            DaoMode.AddPreferenceList(preferens, postgres);

            return Redirect("/Client");
        }

        public IActionResult EnterIntoAContract(int preference_id, string post_code, int inn, string payment_method)
        {
            ContractModel contract = new ContractModel();
            contract.company_name = client.company_name;
            contract.first_name = client.first_name;
            contract.last_name = client.last_name;
            contract.post_code = post_code;
            contract.inn = inn;
            contract.payment_method = payment_method;

            PreferenseListModel preferense = new PreferenseListModel();
            preferense.id = preference_id;
            DaoMode.GetPreferencesListById(preferense, postgres);

            MediaPlanModel mediaPlan = new MediaPlanModel();
            mediaPlan.preferences_list_id = preference_id;
            DaoMode.CheckMediaPlanByPreference(mediaPlan, postgres);

            contract.total_sum = mediaPlan.price;
            if(!DaoMode.AddContract(contract, postgres))
            {
                return Redirect("adas");
            }

            BeforeTheContractModel before = new BeforeTheContractModel();
            before.contract_id = contract.id;
            before.media_plan_id = mediaPlan.id;
            before.start_date = DateTime.Now;
            before.end_date = DateTime.Now.AddDays(preferense.period);

            DaoMode.AddBefore(before, postgres);

            return Redirect("/Client");
        }

        public IActionResult CloseContract(int id)
        {
            BeforeTheContractModel before = new BeforeTheContractModel();
            before.id = id;
            DaoMode.CloseBefore(before, postgres);

            return Redirect("/Client");
        }

        public IActionResult Out()
        {
            client = null;
            return Redirect("/Login");
        }
    }
}
