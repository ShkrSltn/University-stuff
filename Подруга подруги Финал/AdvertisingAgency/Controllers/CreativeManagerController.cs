using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisingAgency.Models;
using AdvertisingAgency.Models.CompositeModel;

namespace AdvertisingAgency.Controllers
{
    public class CreativeManagerController : Controller
    {
        private const string postgres = "creativemanager";
        private static StaffModel staff;
        private static StaffPositionModel staffPosition;
        private static CreativeWorkModel creativeWork;
        public IActionResult Index()
        {

            creativeWork = new CreativeWorkModel();
            creativeWork.worker_id = staff.id;

            bool noEmpty = DaoMode.GetCreativeWorkingByStaff(creativeWork, postgres);

            if (noEmpty)
            {
                MediaPlanModel media = new MediaPlanModel();
                media.id = creativeWork.media_plan_id;
                DaoMode.GetMediaPlanById(media, postgres);

                ViewBag.Media = media;

                PreferenseListModel preference = new PreferenseListModel();
                preference.id = media.preferences_list_id;
                DaoMode.GetPreferencesListById(preference, postgres);

                ViewBag.Preference = preference;
            }

            ViewBag.NoEmpty = noEmpty;
            ViewBag.Working = creativeWork;

            return View();
        }

        public IActionResult Update(string description)
        {
            creativeWork.description += $" {description}. ";
            DaoMode.UpdateWorking(creativeWork, postgres);

            return Redirect("/CreativeManager");
        }

        public IActionResult Finish()
        {
            DaoMode.FinishWorking(creativeWork, postgres);

            return Redirect("/CreativeManager");
        }
        
        public IActionResult ToLogin(int id)
        {
            staff = new StaffModel();
            staffPosition = new StaffPositionModel();
            staff.id = staffPosition.staff_id = id;

            DaoMode.GetStaffById(staff, postgres);
            DaoMode.GetStaffPositionByStaffId(staffPosition, postgres);

            return Redirect("/CreativeManager");
        }

        public IActionResult Out()
        {
            staff = null;
            staffPosition = null;

            return Redirect("/Login");
        }
    }
}
