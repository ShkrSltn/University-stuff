using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AdvertisingAgency.Models;
using AdvertisingAgency.Models.CompositeModel;
using System;

namespace AdvertisingAgency.Controllers
{
    public class DirectorController : Controller
    {
        private const string postgres = "director";
        private static StaffModel staff;
        private static StaffPositionModel staffPosition;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ToLogin(int id)
        {
            staff = new StaffModel();
            staffPosition = new StaffPositionModel();
            staff.id = staffPosition.staff_id = id;

            DaoMode.GetStaffById(staff, postgres);
            DaoMode.GetStaffPositionByStaffId(staffPosition, postgres);

            return Redirect("/Director");
        }

        public IActionResult Staff()
        {
            List<Staff_StaffPosition_Position> staff_staffPositions = DaoMode.GetFullStaffInfo(postgres);

            List<Staff_StaffPosition_Position> staff_Working = new List<Staff_StaffPosition_Position>();
            List<Staff_StaffPosition_Position> staff_Fire = new List<Staff_StaffPosition_Position>();

            foreach(Staff_StaffPosition_Position staff in staff_staffPositions)
            {
                if (staff.staffPosition.end_work == new DateTime())
                {
                    staff_Working.Add(staff);
                }
                else
                {
                    staff_Fire.Add(staff);
                }
            }

            ViewBag.WorkingStaffs = staff_Working;
            ViewBag.FireStaffs = staff_Fire;

            return View();
        }

        public IActionResult AddStaff(string first_name, string last_name, DateTime date_of_birthday, string sex, string tel, string password, int position)
        {
            Staff_StaffPosition_Position staff = new Staff_StaffPosition_Position();

            staff.staff = new StaffModel();
            staff.staff.first_name = first_name;
            staff.staff.last_name = last_name;
            staff.staff.date_of_birthday = date_of_birthday;
            staff.staff.sex = sex;
            staff.staff.tel = tel;
            staff.staff.password = password;

            staff.position = new PositionModel();
            staff.position.id = position;

            DaoMode.AddStaff(staff, postgres);


            return Redirect("/Director/Staff");
        }

        public IActionResult FireStaff(int id)
        {
            StaffPositionModel staff = new StaffPositionModel();
            staff.id = id;
            DaoMode.FireStaff(staff, postgres);

            return Redirect("/Director/Staff");
        }

        public IActionResult Partner()
        {
            ViewBag.Partners = DaoMode.GetFullPartnersService(postgres);

            return View();
        }

        public IActionResult AddPartner(string name)
        {
            PartnersModel partners = new PartnersModel();
            partners.name = name;

            if (DaoMode.CheckPartnerByName(partners, postgres))
            {
                return Redirect("/Director/Partner");
            }

            DaoMode.AddPartner(partners, postgres);

            return Redirect("/Director/Partner");
        }

        public IActionResult AddService(int partner, string name, float price)
        {
            TypeOfServiceModel service = new TypeOfServiceModel();
            service.partners_id = partner;
            service.platform_type = name;
            service.price = price;

            if(DaoMode.CheckService(service, postgres))
            {
                return Redirect("/Director/Partner");
            }

            DaoMode.AddService(service, postgres);

            return Redirect("/Director/Partner");
        }

        public IActionResult Out()
        {
            staff = null;
            staffPosition = null;

            return Redirect("/Login");
        }
    }
}
