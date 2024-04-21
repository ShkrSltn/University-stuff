using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class ReaderController : Controller
    {
        public static Reader read = new Reader();
        public static Message message = new Message();
        public static List<Book> books = new List<Book>();
        public static List<Book> bookeds = new List<Book>();

        public IActionResult Index()
        {
            ViewBag.Message = message;
            ViewBag.Reader = read;
            ViewBag.Books = books;
            ViewBag.Bookeds = bookeds;

            return View();
        }

        public ActionResult Authorization(int account_id)
        {
            bookeds = new List<Book>();
            books = new List<Book>();
            books = Book.Books();

            read.get_Reader(account_id);
            return Redirect("/Reader");
        }

        public ActionResult Find_Book(string name_book)
        {
            bookeds = new List<Book>();
            books = new List<Book>();
            Book b = Book.getBooks(name_book);
            books.Add(b);

            return Redirect("/Reader");
        }

        public ActionResult Find_Author(string name_author)
        {
            bookeds = new List<Book>();
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

            return Redirect("/Reader");
        }

        public ActionResult Find_Publisher(string name_publisher)
        {
            bookeds = new List<Book>();
            books = new List<Book>();

            Publisher p = new Publisher();

            p.id = Publisher.Check_Publisher(name_publisher);

            books = Book.getBook_Publisher(p.id);

            return Redirect("/Reader");
        }

        public ActionResult All_Book()
        {
            bookeds = new List<Book>();

            books = Book.Books();

            return Redirect("/Reader");
        }

        public ActionResult Request_Book(string name)
        {
            int id_book = Book.Check_Book(name);
            BookingRequest.Add_Recques(id_book, read.id);

            return Redirect("/Reader");
        }

        public ActionResult Booked()
        {
            books = new List<Book>();
            bookeds = new List<Book>();

            List<int> books_id = BookingRequest.getRecquest(read.id);

            for(int i = 0; i<books_id.Count; i++)
            {
                bookeds.Add(Book.getBook_id(books_id[i]));
            }

            return Redirect("/Reader");
        }

        public ActionResult Cancel_Booking(int id)
        {
            int id_bookRequest = BookingRequest.Check_BookingRequest(id, read.id);
            BookingRequest br = new BookingRequest();
            br.IssueBook(id_bookRequest);
            Book.Return_book(id);

            return Booked();
        }
    }
}
