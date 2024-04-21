using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class LoginController : Controller
    {
        public static Message message = new Message();

        public ActionResult Index()
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult Authorization(string login, string password)
        {
            Account a = new Account();
            a.login = login;
            Message m = a.Authorisazia(password);
            if (m.error)
            {
                message = m;
                return Redirect("/Login");
            }
            a.getAccount(a.login);

            if (a.str_role == "Administrator")
                return Redirect("/Administrator/Authorization?account_id=" + a.id);
            if (a.str_role == "Librarian")
                return Redirect("/Librarian/Authorization?account_id=" + a.id);
            if (a.str_role == "Reader")
                return Redirect("/Reader/Authorization?account_id=" + a.id);
            return Redirect("/Login");
        }

        public ActionResult Registration(string first_name, string second_name, string patronymic, string telNo, string password)
        {
            Message m = new Message();
            Reader r = new Reader();
            r.first_name = first_name;
            r.second_name = second_name;
            r.patronymic = patronymic;
            r.telNo = telNo;

            m = r.Add_Reder(password);
            if (m.error)
            {
                message = m;
                return Redirect("/Login");
            }

            return Redirect("/Reader/Authorization?account_id=" + r.account_id);
        }
    }
}
