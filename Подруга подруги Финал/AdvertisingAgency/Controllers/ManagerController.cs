using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisingAgency.Models;
using AdvertisingAgency.Models.CompositeModel;

namespace AdvertisingAgency.Controllers
{
    public class ManagerController : Controller
    {
        private const string postgres = "managers";
        private static StaffModel staff;
        private static StaffPositionModel staffPosition;
        public IActionResult Index()
        {
            ViewBag.WorkingMediaPlan = DaoMode.GetAllAcceptedPreferenceListByStaff(staff, postgres);

            return View();
        }

        public IActionResult ToLogin(int id)
        {
            staff = new StaffModel();
            staffPosition = new StaffPositionModel();
            staff.id = staffPosition.staff_id = id;

            DaoMode.GetStaffById(staff, postgres);
            DaoMode.GetStaffPositionByStaffId(staffPosition, postgres);

            return Redirect("/Manager");
        }

        public IActionResult Preference()
        {
            ViewBag.Preferences = DaoMode.GetAllNotAcceptedPreferenceList(postgres);

            return View();
        }

        private static int preference;
        private static int mediaplan_id;
        private static Preference_MediaPlan mediasNow;

        public IActionResult ControleProject(int id)
        {
            preference = id;
            List<Preference_MediaPlan> medias = DaoMode.GetAllAcceptedPreferenceListByStaff(staff, postgres);

            foreach(Preference_MediaPlan m in medias)
            {
                if(id == m.preference.id)
                {
                    mediasNow = m;
                    mediaplan_id = m.mediaPlan.id;
                }
            }


            List<Staff_StaffPosition_Position> Freecreatives = DaoMode.GetFullStaffInfo(postgres);
            for(int i = 0; i < Freecreatives.Count;)
            {
                if(Freecreatives[i].position.id != 3)
                {
                    Freecreatives.RemoveAt(i);
                    continue;
                }
                i++;
            }

            MediaPlanModel me = new MediaPlanModel();
            me.id = mediaplan_id;
            List<StaffModel> buysStaffs = DaoMode.GetAllBuysStaff(me, postgres);

            List<Staff_StaffPosition_Position> busystaff = new List<Staff_StaffPosition_Position>();
            foreach(Staff_StaffPosition_Position s in Freecreatives)
            {
                foreach(StaffModel b in buysStaffs)
                {
                    if(b.id == s.staff.id)
                    {
                        busystaff.Add(s);
                    }
                }
            }

            List<Staff_CreateWork> s_cw = new List<Staff_CreateWork>();

            List<CreativeWorkModel> creativeWork = DaoMode.GetAllCreativeWorkingByMedia(me, postgres);

            foreach(CreativeWorkModel c in creativeWork)
            {
                foreach(Staff_StaffPosition_Position staff in busystaff)
                {
                    if(c.worker_id == staff.staff.id)
                    {
                        Staff_CreateWork s = new Staff_CreateWork();
                        s.staff = staff.staff;
                        s.creativeWork = c;
                        s_cw.Add(s);
                    }
                }
            }

            ViewBag.BusyStaff = s_cw;

            List<StaffModel> free = DaoMode.GetAllFreeStaff(postgres);
            List<Staff_StaffPosition_Position> freestaff = new List<Staff_StaffPosition_Position>();

            foreach(Staff_StaffPosition_Position s in Freecreatives)
            {
                foreach(StaffModel staff in free)
                {
                    if(s.staff.id == staff.id)
                    {
                        freestaff.Add(s);
                    }
                }
            }

            ViewBag.CreativeManager = freestaff;
            ViewBag.Media = mediasNow;

            return View();
        }

        public IActionResult FinishMedia()
        {
            MediaPlanModel media = new MediaPlanModel();
            media.id = mediaplan_id;

            List<CreativeWorkModel> creatives = DaoMode.GetAllCreativeWorkingByMedia(media, postgres);
            foreach(CreativeWorkModel creative in creatives)
            {
                if (!creative.work_status)
                {
                    return Redirect("/Manager/ControleProject/" + mediaplan_id);
                }
            }

            DaoMode.FinishMedia(media, postgres);

            return Redirect("/Manager");
        }

        public IActionResult AddStaffToProject(int id, string specifikation)
        {
            CreativeWorkModel creative = new CreativeWorkModel();
            creative.work_status = false;
            creative.worker_id = id;
            creative.specification = specifikation;
            creative.description = "";
            creative.media_plan_id = mediaplan_id;

            DaoMode.AddCreativeWork(creative, postgres);

            return Redirect("/Manager/ControleProject/" + preference);
        }

        private static Client_Preferense preferense;
        private static TypeOfServiceModel service;

        public IActionResult MediaPlanPreference(int id)
        {
            preferense = new Client_Preferense();
            preferense.preference = new PreferenseListModel();
            preferense.preference.id = id;
            preferense = DaoMode.GetNotAcceptedPreferenceListById(preferense.preference, postgres);
            ViewBag.Preference = preferense;
            ViewBag.Service = service;

            ViewBag.Partners = DaoMode.GetFullPartnersService(postgres);

            return View();
        }

        public IActionResult AddMediaPlan(int broadcast)
        {


            if(preferense.preference.period < 1)
            {
                return Redirect("sdf");
            }

            float sum = service.price * broadcast;
            sum *= preferense.preference.period;
            if(sum > preferense.preference.max_sum)
            {
                return Redirect("/Manager/MediaPlanPreference/" + preferense.preference.id);
            }

            MediaPlanModel mediaPlan = new MediaPlanModel();
            mediaPlan.preferences_list_id = preferense.preference.id;
            mediaPlan.staff_id = staff.id;
            mediaPlan.type_of_service_id = service.id;
            mediaPlan.broadcast_time = broadcast;
            mediaPlan.price = sum;

            DaoMode.AddMediaPlan(mediaPlan, postgres);

            preferense = null;
            service = null;

            return Redirect("/Manager");
        }

        public IActionResult SelectParterServise(int id)
        {
            service = new TypeOfServiceModel();
            service.id = id;
            DaoMode.GetServiceById(service, postgres);

            return Redirect("/Manager/MediaPlanPreference/"+preferense.preference.id);
        }

        public IActionResult Out()
        {
            staff = null;
            staffPosition = null;
            service = null;
            preferense = null;
            return Redirect("/Login");
        }
    }
}
