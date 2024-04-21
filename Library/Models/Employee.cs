using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Employee
    {
        public int id;
        public string first_name;
        public string second_name;
        public string patronymic;
        public string pasportNo;
        public DateTime year_of_birtch;
        public string str_year_of_birtch;
        public string telNo;
        public string position;
        public int account_id;
        public Employee()
        {

        }

        public static int Check_Employee(string telNo)
        {
            int i = 0;
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From Employee where telNo = '{telNo}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                i = Convert.ToInt32(npgsqlDataReader[0].ToString());
            }
            db.CloseConnection();

            Account a = new Account();
            a.getAccount(i);
            if (a.status)
            {
                return i;
            }

            return 0;
        }

        public void Select_Employee_Account(int account_id)
        {
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From Employee Where account_id = {account_id}", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                this.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                this.first_name = npgsqlDataReader[1].ToString();
                this.second_name = npgsqlDataReader[2].ToString();
                this.patronymic = npgsqlDataReader[3].ToString();
                this.str_year_of_birtch = npgsqlDataReader[4].ToString();
                this.telNo = npgsqlDataReader[5].ToString();
                this.account_id = Convert.ToInt32(npgsqlDataReader[6].ToString());
            }
            db.CloseConnection();
            Account a = new Account();
            a.id = this.account_id;
            a.getAccount(a.id);
            a.getRoleName();
            this.position = a.str_role;
        }

        public static List<Employee> Employees()
        {
            List<Employee> employees = new List<Employee>();
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From Employee", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                Employee e = new Employee();
                e.id = Convert.ToInt32(npgsqlDataReader[0].ToString());
                e.first_name = npgsqlDataReader[1].ToString();
                e.second_name = npgsqlDataReader[2].ToString();
                e.patronymic = npgsqlDataReader[3].ToString();
                e.str_year_of_birtch = npgsqlDataReader[4].ToString();
                e.telNo = npgsqlDataReader[5].ToString();
                e.account_id = Convert.ToInt32(npgsqlDataReader[6].ToString());
                employees.Add(e);
            }
            db.CloseConnection();

            List<Employee> employees_final = new List<Employee>();
            foreach (Employee e in employees)
            {
                Account a = new Account();
                a.id = e.account_id;
                a.getAccount(a.id);
                a.getRoleName();
                e.position = a.str_role;
                if (a.status)
                {
                    employees_final.Add(e);
                }
            }

            return employees_final;
        }

        public Message Add_Employee(string password)
        {
            Message m = new Message();
            Account a = new Account();
            m = a.Add_Account(this.telNo, password, 2);
            if(m.error)
            {
                return new Message("Пользователь с таким номером телефона уже существует", true);
            }

            this.account_id = Account.Check_Account(this.telNo);

            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Insert Into Employee(first_name,second_name,patronymic,year_of_birtch,telno,account_id) Values('{this.first_name}','{this.second_name}','{this.patronymic}','{this.year_of_birtch.ToString("dd-MM-yyyy")}','{this.telNo}','{this.account_id}')", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {

            }
            db.CloseConnection();

            return new Message();
        }

        public static void Fired(int id)
        {
            int id_account = 0;
            ConnectionBD db = new ConnectionBD("postgres");
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand($"Select * From Employee where id = '{id}'", db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                id_account = Convert.ToInt32(npgsqlDataReader[6].ToString());
            }
            db.CloseConnection();

            Account.Fired_Account(id_account);
        }
    }
}