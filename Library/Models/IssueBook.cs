using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class IssueBook
    {
        public int id;
        public int book_id;
        public int reader_id;
        public int employee_id;
        public string start_date;
        public string end_date;
        public bool status;
        public IssueBook()
        {

        }

        public Message Add_IssueBook(string name_book, string login)
        {
            int id_account = Account.Check_Account(login);
            if(id_account == 0)
            {
                return new Message("Пользователя с таким номером телефона не существует", true);
            }
            this.reader_id = Reader.Check_Reader(login);
            if (this.reader_id == 0)
            {
                return new Message("Пользователя с таким номером телефона не существует", true);
            }

            BookingRequest b_r = new BookingRequest();

            bool flags = true;
            List<int> bokings_request_id = BookingRequest.getRecquest(this.reader_id);
            for(int i = 0; i<bokings_request_id.Count; i++)
            {
                int bookingrequest_id = BookingRequest.Check_BookingRequest(bokings_request_id[i], this.reader_id);
                if (bookingrequest_id == 0)
                {
                    continue;
                }
                else
                {
                    book_id = bokings_request_id[i];
                    b_r.id = bookingrequest_id;
                    flags = false;
                }
            }

            if (flags)
            {
                this.book_id = Book.Check_Book(name_book);
                if (this.book_id == 0)
                {
                    return new Message("Такой книги нет или все они забронировани", true);
                }
            }
            else
            {
                b_r.IssueBook(b_r.id);
            }

            Book.Request_Book(this.book_id);

            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Insert Into issueBook(book_id,reader_id,employee_id,start_date,status) Values('{this.book_id}','{this.reader_id}','{this.employee_id}','{DateTime.Now.ToString("dd-MM-yyyy")}','true')", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                
            }
            db.CloseConnection();

            return new Message("Выдайте книгу с номером "+ this.book_id, false);
        }

        public static int Check_IssueBook(int id_book)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From issueBook where book_id = '{id_book}' and status = true", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                return Convert.ToInt32(npgsqlDataReader[0].ToString());
            }
            db.CloseConnection();

            return 0;
        }

        public static Message Return_book(int id_book)
        {
            int id_issueBook = Check_IssueBook(id_book);
            if(id_book == 0)
            {
                return new Message("Эта книга не была здана, она была украдена", true);
            }

            Book.Return_book(id_book);

            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Update IssueBook set end_date = '{DateTime.Now.ToString("dd-MM-yyyy")}', status = false where id = '{id_issueBook}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {

            }
            db.CloseConnection();

            return new Message();
        }
    }
}
