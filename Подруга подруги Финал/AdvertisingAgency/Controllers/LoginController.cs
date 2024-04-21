using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisingAgency.Models;

namespace AdvertisingAgency.Controllers
{
    public class LoginController : Controller
    {
        const string postgres = "loginto"; 
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult ToLogin(string tel, string password)
        {
            StaffModel staff = new StaffModel();
            ClientCompanyModel client = new ClientCompanyModel();

            staff.tel = client.tel = client.email = tel;
            staff.password = client.password = password;

            if (DaoMode.StaffLogin(staff, postgres))
            {
                StaffPositionModel staffPosition = new StaffPositionModel();
                staffPosition.staff_id = staff.id;
                DaoMode.GetStaffPositionByStaffId(staffPosition, postgres);
                if(staffPosition.position_id == 1)
                    return Redirect("/Director/ToLogin/"+staff.id);
                if (staffPosition.position_id == 3)
                    return Redirect("/CreativeManager/ToLogin/"+staff.id);
                if (staffPosition.position_id == 2)
                    return Redirect("/Manager/ToLogin/"+staff.id);

                return Redirect("/Director");
            }

            if(DaoMode.ClientLogin(client, postgres))
            {
                return Redirect("/Client/ToLogin/"+client.id);
            }

            return Redirect("/Login");
        }

        public IActionResult Register(string company_name, string city, string street, string first_name, string last_name, string tel, string email, string password)
        {
            ClientCompanyModel client = new ClientCompanyModel();
            client.company_name = company_name;
            client.director = first_name + " " + last_name;
            client.city = city;
            client.street = street;
            client.first_name = first_name;
            client.last_name = last_name;
            client.tel = tel;
            client.email = email;
            client.password = password;

            if (DaoMode.CheckClientByCompanyName(client, postgres))
            {
                return Redirect("/Login");
            }
            if (DaoMode.CheckClientByTel(client, postgres))
            {
                return Redirect("/Login");
            }
            if (DaoMode.CheckClientByEmail(client, postgres))
            {
                return Redirect("/Login");
            }

            if(DaoMode.AddClient(client, postgres))
            {
                return Redirect("/Client/ToLogin/" + client.id);
            }

            return Redirect("/Login");
        }
    }
}
