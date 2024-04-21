using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Reader
    {
        public int id;
        public string first_name;
        public string second_name;
        public string patronymic;
        public string telNo;
        public int account_id;

        public Reader()
        {

        }

        public Message Add_Reder(string password)
        {
            if(Check_Reader(this.telNo) != 0)
            {
                return new Message("Пользователь с таким номером телефона уже существует", true);
            }
            if(Employee.Check_Employee(this.telNo) != 0)
            {
                return new Message("Пользователь с таким номером телефона уже существует", true);
            }

            Account a = new Account();
            a.Add_Account(this.telNo, password, 3);
            a.getAccount(this.telNo);
            this.account_id = a.id;

            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Insert Into Reader(first_name,second_name,patronymic,telno,account_id) Values('{this.first_name}','{this.second_name}','{this.patronymic}','{this.telNo}','{a.id}')", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {

            }
            db.CloseConnection();

            return new Message();
        }

        public static int Check_Reader(string telNo)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From reader where telNo = '{telNo}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                return Convert.ToInt32(npgsqlDataReader[0].ToString());
            }
            db.CloseConnection();


            return 0;
        }

        public void get_Reader(int account_id)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From reader where account_id = '{account_id}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                this.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                this.first_name = npgsqlDataReader[1].ToString();
                this.second_name = npgsqlDataReader[2].ToString();
                this.patronymic = npgsqlDataReader[3].ToString();
                this.telNo = npgsqlDataReader[4].ToString();
                this.account_id = Convert.ToInt32(npgsqlDataReader[5].ToString());
            }
            db.CloseConnection();
        }
    }
}
