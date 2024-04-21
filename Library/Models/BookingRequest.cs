using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookingRequest
    {
        public int id;
        public int book_id;
        public int reader_id;
        public bool status;
        public BookingRequest()
        {

        }

        public static Message Add_Recques(int book_id, int reader)
        {
            Book.Request_Book(book_id);

            if(Check_BookingRequest(book_id, reader) != 0)
            {
                return new Message("Вы уже забронировали эту книгу", true);
            }

            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Insert Into BookingRequest(book_id,reader_id,status) Values('{book_id}','{reader}',true)", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {

            }
            db.CloseConnection();

            return new Message();
        }

        public static int Check_BookingRequest(int book_id, int reader_id)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From bookingrequest where book_id = '{book_id}' and reader_id = '{reader_id}' and status = true", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                return Convert.ToInt32(npgsqlDataReader[0].ToString());
            }
            db.CloseConnection();

            return 0;
        }

        public static List<int> getRecquest(int reader_id)
        {
            List<int> books_id = new List<int>();

            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select book_id From bookingrequest where reader_id = '{reader_id}' and status = true", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                books_id.Add(Convert.ToInt32(npgsqlDataReader[0].ToString()));
            }
            db.CloseConnection();

            return books_id;
        }

        public void IssueBook(int id)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Update bookingrequest set status = false where id = '{id}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {

            }
            db.CloseConnection();
        }
    }
}
