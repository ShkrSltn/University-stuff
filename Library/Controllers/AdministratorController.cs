using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class AdministratorController : Controller
    {
        public static Employee admin = new Employee();
        public static Message message = new Message();
        public static List<Message> messages = new List<Message>();
        public ActionResult Index()
        {
            ViewBag.Message = message;
            ViewBag.Employee = admin;
            return View();
        }

        public ActionResult Authorization(int account_id)
        {
            admin.Select_Employee_Account(account_id);
            return Redirect("/Administrator");
        }

        public ActionResult Fired(int id)
        {
            Models.Employee.Fired(id);

            return Redirect("/Administrator/Employee");
        }

        public ActionResult Employee()
        {
            ViewBag.Message = message;
            ViewBag.Employee = admin;
            ViewBag.Employees = Models.Employee.Employees();
            return View();
        }

        public ActionResult Add_Employee(string first_name, string second_name, string patronymic, DateTime year_of_birtch, string telNo, string password)
        {
            Employee e = new Employee();
            e.first_name = first_name;
            e.second_name = second_name;
            e.patronymic = patronymic;
            e.year_of_birtch = year_of_birtch;
            e.telNo = telNo;

            message = e.Add_Employee(password);

            return Redirect("/Administrator/Employee");
        }

        public ActionResult Book()
        {
            ViewBag.Employee = admin;
            ViewBag.Message = message;
            ViewBag.Messages = messages;

            List<Book> book = Models.Book.Books();
            List<Book> books = new List<Book>();

            foreach (Book b in book)
            {
                bool flags = true;
                foreach (Book bb in books)
                {
                    if (bb.name_book == b.name_book)
                    {
                        flags = false;
                        continue;
                    }
                }
                if (flags)
                {
                    Book bk = new Book();
                    bk.name_book = b.name_book;
                    bk.number_of_copies++;
                    bk.author_id = b.author_id;
                    bk.number_of_pages = b.number_of_pages;
                    bk.publisher_id = b.publisher_id;
                    bk.str_the_year_of_publisher = b.str_the_year_of_publisher;
                    bk.genre = b.genre;
                    books.Add(bk);
                }
                else
                {
                    foreach (Book bb in books)
                    {
                        if (bb.name_book == b.name_book)
                        {
                            bb.number_of_copies++;
                        }
                    }
                }
            }

            ViewBag.Books = books;

            return View();
        }

        public ActionResult Add_Now_Book(string book_name, string author_name, string publisher, string genre, int count, int pages, DateTime year)
        {
            messages = new List<Message>();
            Message m = new Message();
            Publisher p = new Publisher();
            p.name = publisher;
            m = p.Add_Publisher();
            if (m.error)
            {
                message = new Message("Не удалось добавть новое издание", true);
                return Redirect("/Administrator/Book");
            }

            Author a = new Author();

            a.first_name = "";
            a.second_name = "";
            a.patronymic = "";
            int count_name = 0;

            string str = "";
            foreach (char c in author_name)
            {
                if (c == ' ' && count_name == 0)
                {
                    a.second_name = str;
                    str = "";
                    count_name++;
                }
                else if (c == ' ' && count_name == 1)
                {
                    a.first_name = str;
                    str = "";
                    count_name++;
                }
                else
                {
                    str += c;
                }
            }
            a.patronymic = "";
            if (count_name == 1)
                a.first_name = str;
            else
                a.patronymic = str;


            m = a.Add_Author();

            if (m.error)
            {
                m = new Message("Не удалось добавить автора",true);
                return Redirect("/Administrator/Book");
            }

            Book b = new Book();
            b.name_book = book_name;
            b.author_id = a.id;
            b.publisher_id = p.id;
            b.genre = genre;
            b.number_of_pages = pages;
            b.the_year_of_publisher = year;

            for(int i = 0; i<count; i++)
            {
                b.Add_Book();
            }
            int max_id = Models.Book.getMaxid_Book()- count + 1;

            m.str_message += "запешите в книгу номера: ";
            for (int i = 0; i < count; i++)
            {
                messages.Add(new Message(max_id + "\n",false));
                max_id++;
            }

            message = m;

            return Redirect("/Administrator/Book");
        }

        public ActionResult Add_Book(string book_name, int count)
        {
            messages = new List<Message>();
            Message m = new Message();
            Book b = Models.Book.getBook(book_name);
            if(b == null)
            {
                message = new Message("такой книги нет", true);
            }

            for (int i = 0; i < count; i++)
            {
                b.Add_Book();
            }

            int max_id = Models.Book.getMaxid_Book() - count + 1;

            for (int i = 0; i < count; i++)
            {
                messages.Add(new Message(max_id + "\n", false));
                max_id++;
            }

            message = m;

            return Redirect("/Administrator/Book");
        }
    }
}
