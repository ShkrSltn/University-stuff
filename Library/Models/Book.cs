using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public int id;
        public string name_book;
        public int author_id;
        public string str_author;
        public int publisher_id;
        public string str_publisher;
        public DateTime the_year_of_publisher;
        public string str_the_year_of_publisher;
        public int number_of_copies = 0;
        public int number_of_pages;
        public string genre;
        public bool status;
        public Book()
        {

        }

        public static int getMaxid_Book()
        {
            int max_id = 0;
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select max(id) From Book", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                max_id = Convert.ToInt32(npgsqlDataReader[0].ToString());
            }
            db.CloseConnection();

            return max_id;
        }

        public Message Add_Book()
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Insert Into Book(book_name,author_id,publisher_id,publishing_year,number_of_pages,genre,status) Values('{this.name_book}','{author_id}','{publisher_id}','{this.the_year_of_publisher.ToString("dd-MM-yyyy")}','{this.number_of_pages}','{this.genre}',true)", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {

            }
            db.CloseConnection();

            return new Message();
        }

        public static List<Book> Books()
        {
            List<Book> book = new List<Book>();
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From Book", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                Book b = new Book();
                b.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                b.name_book = npgsqlDataReader[1].ToString();
                b.author_id = Convert.ToInt32(npgsqlDataReader[2].ToString());
                b.publisher_id = Convert.ToInt32(npgsqlDataReader[3].ToString());
                b.str_the_year_of_publisher = npgsqlDataReader[4].ToString();
                b.number_of_pages = Convert.ToInt32(npgsqlDataReader[5].ToString());
                b.genre = npgsqlDataReader[6].ToString();
                b.status = Convert.ToBoolean(npgsqlDataReader[7].ToString());
                book.Add(b);
            }
            db.CloseConnection();

            List<Book> books = new List<Book>();

            foreach (Book b1 in book)
            {
                bool flag = false;
                foreach (Book b2 in books)
                {
                    if (b1.name_book == b2.name_book)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    if (b1.status)
                    {
                        foreach (Book b2 in books)
                        {
                            if (b2.name_book == b1.name_book)
                                b2.number_of_copies++;
                        }
                    }
                }
                else
                {
                    Book b3 = new Book();
                    b3.name_book = b1.name_book;
                    b3.author_id = b1.author_id;
                    b3.publisher_id = b1.publisher_id;
                    b3.str_the_year_of_publisher = b1.str_the_year_of_publisher;
                    b3.number_of_pages = b1.number_of_pages;
                    b3.genre = b1.genre;
                    if (b1.status)
                    {
                        b3.number_of_copies = 1;
                    }
                    books.Add(b1);
                }
            }

            foreach (Book b4 in books)
            {
                Author a = new Author();
                a.Select_Author(b4.author_id);
                b4.str_author = a.first_name + " " + a.second_name + " " + a.patronymic;

                Publisher p = new Publisher();
                p.Select_Publisher(b4.publisher_id);
                b4.str_publisher = p.name;

                b4.number_of_copies++;
            }

            return books;
        }

        public static Book getBook(string name_book)
        {
            Book b = new Book();
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From book where book_name = '{name_book}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                b.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                b.name_book = npgsqlDataReader[1].ToString();
                b.author_id = Convert.ToInt32(npgsqlDataReader[2].ToString());
                b.publisher_id = Convert.ToInt32(npgsqlDataReader[3].ToString());
                b.str_the_year_of_publisher = npgsqlDataReader[4].ToString();
                b.number_of_pages = Convert.ToInt32(npgsqlDataReader[5].ToString());
                b.genre = npgsqlDataReader[6].ToString();
                b.status = Convert.ToBoolean(npgsqlDataReader[7].ToString());
            }
            db.CloseConnection();

            return b;
        }

        public static List<Book> getBook_Author(int author_id)
        {
            List<Book> book = new List<Book>();
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From book where author_id = '{author_id}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                Book b = new Book();
                b.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                b.name_book = npgsqlDataReader[1].ToString();
                b.author_id = Convert.ToInt32(npgsqlDataReader[2].ToString());
                b.publisher_id = Convert.ToInt32(npgsqlDataReader[3].ToString());
                b.str_the_year_of_publisher = npgsqlDataReader[4].ToString();
                b.number_of_pages = Convert.ToInt32(npgsqlDataReader[5].ToString());
                b.genre = npgsqlDataReader[6].ToString();
                b.status = Convert.ToBoolean(npgsqlDataReader[7].ToString());
                book.Add(b);
            }
            db.CloseConnection();

            List<Book> books = new List<Book>();

            foreach (Book b1 in book)
            {
                bool flag = false;
                foreach (Book b2 in books)
                {
                    if (b1.name_book == b2.name_book)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    if (b1.status)
                    {
                        foreach (Book b2 in books)
                        {
                            if (b2.name_book == b1.name_book)
                                b2.number_of_copies++;
                        }
                    }
                }
                else
                {
                    Book b3 = new Book();
                    b3.name_book = b1.name_book;
                    b3.author_id = b1.author_id;
                    b3.publisher_id = b1.publisher_id;
                    b3.str_the_year_of_publisher = b1.str_the_year_of_publisher;
                    b3.number_of_pages = b1.number_of_pages;
                    b3.genre = b1.genre;
                    if (b1.status)
                    {
                        b3.number_of_copies = 1;
                    }
                    books.Add(b1);
                }
            }

            foreach (Book b4 in books)
            {
                Author a = new Author();
                a.Select_Author(b4.author_id);
                b4.str_author = a.first_name + " " + a.second_name + " " + a.patronymic;

                Publisher p = new Publisher();
                p.Select_Publisher(b4.publisher_id);
                b4.str_publisher = p.name;

                b4.number_of_copies++;
            }

            return books;
        }

        public static List<Book> getBook_Publisher(int publisher_id)
        {
            List<Book> book = new List<Book>();
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From book where publisher_id = '{publisher_id}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                Book b = new Book();
                b.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                b.name_book = npgsqlDataReader[1].ToString();
                b.author_id = Convert.ToInt32(npgsqlDataReader[2].ToString());
                b.publisher_id = Convert.ToInt32(npgsqlDataReader[3].ToString());
                b.str_the_year_of_publisher = npgsqlDataReader[4].ToString();
                b.number_of_pages = Convert.ToInt32(npgsqlDataReader[5].ToString());
                b.genre = npgsqlDataReader[6].ToString();
                b.status = Convert.ToBoolean(npgsqlDataReader[7].ToString());
                book.Add(b);
            }
            db.CloseConnection();

            List<Book> books = new List<Book>();

            foreach(Book b1 in book)
            {
                bool flag = false;
                foreach(Book b2 in books)
                {
                    if(b1.name_book == b2.name_book)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    if (b1.status)
                    {
                        foreach(Book b2 in books)
                        {
                            if (b2.name_book == b1.name_book)
                                b2.number_of_copies++;
                        }
                    }
                }
                else
                {
                    Book b3 = new Book();
                    b3.name_book = b1.name_book;
                    b3.author_id = b1.author_id;
                    b3.publisher_id = b1.publisher_id;
                    b3.str_the_year_of_publisher = b1.str_the_year_of_publisher;
                    b3.number_of_pages = b1.number_of_pages;
                    b3.genre = b1.genre;
                    if (b1.status)
                    {
                        b3.number_of_copies = 1;
                    }
                    books.Add(b1);
                }
            }

            foreach(Book b4 in books)
            {
                Author a = new Author();
                a.Select_Author(b4.author_id);
                b4.str_author = a.first_name + " " + a.second_name + " " + a.patronymic;

                Publisher p = new Publisher();
                p.Select_Publisher(b4.publisher_id);
                b4.str_publisher = p.name;

                b4.number_of_copies++;
            }

            return books;
        }

        public static Book getBooks(string name_book)
        {
            List<Book> books = new List<Book>();
            Book b = new Book();
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From book where book_name = '{name_book}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                b.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                b.name_book = npgsqlDataReader[1].ToString();
                b.author_id = Convert.ToInt32(npgsqlDataReader[2].ToString());
                b.publisher_id = Convert.ToInt32(npgsqlDataReader[3].ToString());
                b.str_the_year_of_publisher = npgsqlDataReader[4].ToString();
                b.number_of_pages = Convert.ToInt32(npgsqlDataReader[5].ToString());
                b.genre = npgsqlDataReader[6].ToString();
                b.status = Convert.ToBoolean(npgsqlDataReader[7].ToString());
                books.Add(b);
            }
            db.CloseConnection();
            int count = 0;
            for(int i = 0; i<books.Count; i++)
            {
                if (books[i].status)
                    count++;
            }
            b.number_of_copies = count;

            Author a = new Author();
            a.Select_Author(b.author_id);
            b.str_author = a.first_name + " " + a.second_name + " " + a.patronymic;

            Publisher p = new Publisher();
            p.Select_Publisher(b.publisher_id);
            b.str_publisher = p.name;

            return b;
        }

        public static int Check_Book(string name_book)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From book where book_name = '{name_book}' and status = 'true'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                return Convert.ToInt32(npgsqlDataReader[0].ToString());
            }
            db.CloseConnection();

            return 0;
        }

        public static int Check_Book_Recquest(string name_book)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From book where book_name = '{name_book}' and status = 'false'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                return Convert.ToInt32(npgsqlDataReader[0].ToString());
            }
            db.CloseConnection();

            return 0;
        }

        public static void Request_Book(int id)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Update Book set status = 'false' where id = '{id}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {

            }
            db.CloseConnection();
        }

        public static Message Return_book(int book_id)
        {
            if(Check_Book_id(book_id) == 0)
            {
                return new Message("Такой книги нет в базе данных", true);
            }

            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Update Book set status = 'true' where id = '{book_id}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {

            }
            db.CloseConnection();

            return new Message();
        }

        public static int Check_Book_id(int id)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From Book where id = '{id}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                return Convert.ToInt32(npgsqlDataReader[0].ToString());
            }
            db.CloseConnection();

            return 0;
        }

        public static Book getBook_id(int id_book)
        {
            Book b = new Book();
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From book where id = '{id_book}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                b.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                b.name_book = npgsqlDataReader[1].ToString();
                b.author_id = Convert.ToInt32(npgsqlDataReader[2].ToString());
                b.publisher_id = Convert.ToInt32(npgsqlDataReader[3].ToString());
                b.str_the_year_of_publisher = npgsqlDataReader[4].ToString();
                b.number_of_pages = Convert.ToInt32(npgsqlDataReader[5].ToString());
                b.genre = npgsqlDataReader[6].ToString();
                b.status = Convert.ToBoolean(npgsqlDataReader[7].ToString());
            }
            db.CloseConnection();

            Author a = new Author();
            a.Select_Author(b.author_id);
            b.str_author = a.first_name + " " + a.second_name + " " + a.patronymic;

            Publisher p = new Publisher();
            p.Select_Publisher(b.publisher_id);
            b.str_publisher = p.name;

            return b;
        }
    }
}
