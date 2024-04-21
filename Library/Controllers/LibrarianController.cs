using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class LibrarianController : Controller
    {
        public static Employee admin = new Employee();
        public static Message message = new Message();
        public static List<Book> books = new List<Book>();

        public ActionResult Index()
        {
            ViewBag.Message = message;
            ViewBag.Employee = admin;
            ViewBag.Books = books;
            return View();
        }

        public ActionResult Authorization(int account_id)
        {
            admin.Select_Employee_Account(account_id);
            return Redirect("/Librarian");
        }

        public ActionResult IssueBook(string book_name, string telNo)
        {
            IssueBook i = new IssueBook();
            i.employee_id = admin.id;

            message = i.Add_IssueBook(book_name, telNo);

            return Redirect("/Librarian");
        }

        public ActionResult Return_Book(int bookNo)
        {
            message = Models.IssueBook.Return_book(bookNo);

            return Redirect("/Librarian");
        }

        public ActionResult Find_Book(string name_book)
        {
            books = new List<Book>() ;
            Book b = Book.getBooks(name_book);
            books.Add(b);

            return Redirect("/Librarian");
        }

        public ActionResult Find_Author(string name_author)
        {
            books = new List<Book>();
            Book b = new Book();

            Author a = new Author();

            a.first_name = "";
            a.second_name = "";
            a.patronymic = "";
            int count_name = 0;

            string str = "";
            foreach (char c in name_author)
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

            a.id = Author.Check_Author(a.first_name, a.second_name, a.patronymic);

            books = Book.getBook_Author(a.id);

            return Redirect("/Librarian");
        }

        public ActionResult Find_Publisher(string name_publisher)
        {
            books = new List<Book>();

            Publisher p = new Publisher();

            p.id = Publisher.Check_Publisher(name_publisher);

            books = Book.getBook_Publisher(p.id);

            return Redirect("/Librarian");
        }
    }
}
