using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Account
    {
        public int id;
        public int role_id;
        public string str_role;
        public string login;
        public bool status;

        public Account()
        {

        }

        public void getAccount(int id)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From access.Account where id = '{id}' and status = true", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                this.id = id;
                this.login = npgsqlDataReader[1].ToString();
                this.role_id = Convert.ToInt32(npgsqlDataReader[3].ToString());
                this.status = Convert.ToBoolean(npgsqlDataReader[4].ToString());
            }
            db.CloseConnection();
            getRoleName();
        }

        public void getAccount(string login)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From access.Account where login = '{login}' and status = true", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                this.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                this.login = login;
                this.role_id = Convert.ToInt32(npgsqlDataReader[3].ToString());
                this.status = Convert.ToBoolean(npgsqlDataReader[4].ToString());
            }
            db.CloseConnection();
            getRoleName();
        }

        public void getRoleName()
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From access.Role where id = '{this.role_id}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                this.str_role = npgsqlDataReader[1].ToString();
            }
            db.CloseConnection();
        }

        public Message Add_Account(string login, string password, int role)
        {
            if(Check_Account(login) != 0)
            {
                return new Message("Пользователь с таким логином уже есть", true);
            }

            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Insert Into access.Account(login,password,role_id, status) Values('{login}','{password}','{role}',true)", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {

            }
            db.CloseConnection();

            return new Message();
        }

        public Message Authorisazia(string password)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From access.account where status = true", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                if (npgsqlDataReader[1].ToString() == this.login)
                {
                    if(npgsqlDataReader[2].ToString() == password)
                    {
                        this.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                        return new Message();
                    }
                }
            }
            db.CloseConnection();

            return new Message("Логин или пароль не правильные", true);
        }

        public static int Check_Account(string login)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From access.account where status = true", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                if (npgsqlDataReader[1].ToString() == login)
                    return Convert.ToInt32(npgsqlDataReader[0].ToString());
            }
            db.CloseConnection();

            return 0;
        }

        public static void Fired_Account(int id_account)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Update access.account set status = false where id = '{id_account}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {

            }
            db.CloseConnection();
        }
    }
}