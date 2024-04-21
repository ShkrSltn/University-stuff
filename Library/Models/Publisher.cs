using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Publisher
    {
        public int id;
        public string name;

        public Publisher()
        {

        }

        public Message Add_Publisher()
        {
            int p_id = Check_Publisher(this.name);
            if (p_id != 0)
            {
                this.id = p_id;
                return new Message();
            }

            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Insert Into publisher(publisher_name) Values('{this.name}')", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                 
            }
            db.CloseConnection();

            this.id = Check_Publisher(this.name);
            return new Message();
        }

        public static int Check_Publisher(string name)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From publisher", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                if (npgsqlDataReader[1].ToString() == name)
                    return Convert.ToInt32(npgsqlDataReader[0].ToString());
            }
            db.CloseConnection();

            return 0;
        }

        public void Select_Publisher(int publisher_id)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From publisher where id = '{publisher_id}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                this.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                this.name = npgsqlDataReader[1].ToString();
            }
            db.CloseConnection();
        }

        public static List<Publisher> Publishers()
        {
            List<Publisher> publishers = new List<Publisher>();
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From publisher", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                Publisher p = new Publisher();
                p.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                p.name = npgsqlDataReader[1].ToString();
                publishers.Add(p);
            }
            db.CloseConnection();
            return publishers;
        }
    }
}
