using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Author
    {
        public int id;
        public string first_name;
        public string second_name;
        public string patronymic;
        public Author()
        {

        }

        public Message Add_Author()
        {
            int a_id = Check_Author(this.first_name, this.second_name, this.patronymic);
            if (a_id != 0)
            {
                this.id = a_id;
                return new Message();
            }

            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Insert Into Author(first_name,second_name,patronymic) Values('{this.first_name}','{this.second_name}','{this.patronymic}')", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {

            }
            db.CloseConnection();

            this.id = Check_Author(this.first_name, this.second_name, this.patronymic);

            return new Message();
        }


        public static int Check_Author(string first_name, string second_name, string patronymic)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From author", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                if(npgsqlDataReader[1].ToString() == first_name && npgsqlDataReader[2].ToString() == second_name && npgsqlDataReader[3].ToString() == patronymic)
                    return Convert.ToInt32(npgsqlDataReader[0].ToString());
            }
            db.CloseConnection();

            return 0;
        }


        public void Select_Author(int id)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From author where id = '{id}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                this.id = id;
                this.first_name = npgsqlDataReader[1].ToString();
                this.second_name = npgsqlDataReader[2].ToString();
                this.patronymic = npgsqlDataReader[3].ToString();
            }
            db.CloseConnection();
        }

        public static List<Author> Authors()
        {
            List<Author> authors = new List<Author>();
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From author", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                Author a = new Author();
                a.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                a.first_name = npgsqlDataReader[1].ToString();
                a.second_name = npgsqlDataReader[2].ToString();
                a.patronymic = npgsqlDataReader[3].ToString();
                authors.Add(a);
            }
            db.CloseConnection();
            return authors;
        }
    }
}
