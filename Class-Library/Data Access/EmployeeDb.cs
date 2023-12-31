﻿using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace Class_Library.Data_Access
{
    public class EmployeeDb : DBMediator
    {
        public EmployeeDb() : base() { }

        public int GetEmployeeIdByUsername(string username)
        {
            int id = -1;
            try
            {
                var sql = "SELECT id FROM `employees_zoo` WHERE username = @username";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@username", username);
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    id = Convert.ToInt32(dr[0]);
                }

                return id;
            }
            finally 
            {
                connection.Close();
            }
        }
        public int AddEmployee(Employee emp)
        {
            try
            {       
                var sql = "insert into employees_zoo (id, first_name, last_name, BSN, email, first_working_date, last_working_date, birthdate, contract_type, hourly_wage, address, departure_reason, shifts_per_week, role, username, password) " +
                    "values (@Id, @first_name, @last_name, @BSN, @email, @first_working_date, @last_working_date, @birthdate, @contract_type, @hourly_wage, @address, @departure_reason, @shifts_per_week, @role, @username, @password)";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@first_name", emp.FirstName);
                cmd.Parameters.AddWithValue("@last_name", emp.LastName);
                cmd.Parameters.AddWithValue("@BSN", emp.bsn);
                cmd.Parameters.AddWithValue("@email", emp.Email);
                cmd.Parameters.AddWithValue("@first_working_date", emp.StartDate);
                cmd.Parameters.AddWithValue("@last_working_date", emp.EndDate);
                cmd.Parameters.AddWithValue("@birthdate", emp.Birthdate);
                cmd.Parameters.AddWithValue("@contract_type", emp.ContractType);
                cmd.Parameters.AddWithValue("@hourly_wage", emp.HourlyWage);
                cmd.Parameters.AddWithValue("@address", emp.Address);
                cmd.Parameters.AddWithValue("@departure_reason", emp.DepartureReason);
                cmd.Parameters.AddWithValue("@shifts_per_week", emp.ShiftsPerWeek);
                cmd.Parameters.AddWithValue("@role", emp.role);
                cmd.Parameters.AddWithValue("@username", emp.username);
                cmd.Parameters.AddWithValue("@password", emp.password);

                connection.Open();
                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;
                return (int)id;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                var sql = "select * from employees_zoo";
                var cmd = new MySqlCommand(sql, this.connection);

                connection.Open();
                var data = cmd.ExecuteReader();
                List<Employee> employees = new List<Employee>();
                while (data.Read())
                {

                    Employee employee = new Employee(Convert.ToInt32(data["id"]), data["first_name"].ToString(), data["last_name"].ToString(),
                        Convert.ToString(data["BSN"]), data["email"].ToString(), data["first_working_date"].ToString(), data["last_working_date"].ToString(),
                       Convert.ToDateTime(data["birthdate"]), data["contract_type"].ToString(), Convert.ToInt32(data["hourly_wage"]), data["address"].ToString(), data["departure_reason"].ToString(),
                        Convert.ToInt32(data["shifts_per_week"]), data["role"].ToString(), data["username"].ToString(), data["password"].ToString());

                    employees.Add(employee);


                }
                return employees;
            }
            finally
            {
                connection.Close();
            }
        }


        public void UpdateEmployeeDataInDatabase(Employee emp)
        {
            int currEmpId = emp.ID;

            connection.Open();

            // Add new user
            string sqlInsertEmployee =
                @"UPDATE employees_zoo
                 SET
                    first_name = @first_name , 
                    last_name = @last_name,
                    BSN = @BSN,
                    email = @email,
                    first_working_date = @first_working_date,
                    last_working_date = @last_working_date,
                    birthdate = @birthdate,
                    contract_type = @contract_type,
                    hourly_wage = @hourly_wage,
                    address = @address,
                    departure_reason = @departure_reason,
                    shifts_per_week = @shifts_per_week,
                    role = @role,
                    username = @username, 
                    password = @password
                 WHERE
                    id = @id
                ";


            MySqlCommand cmdEmployee = new MySqlCommand(sqlInsertEmployee, connection);
            // Account
            cmdEmployee.Parameters.Add(new MySqlParameter("id", currEmpId));
            cmdEmployee.Parameters.Add(new MySqlParameter("first_name", emp.FirstName));
            cmdEmployee.Parameters.Add(new MySqlParameter("last_name", emp.LastName));
            cmdEmployee.Parameters.Add(new MySqlParameter("BSN", emp.Bsn));
            cmdEmployee.Parameters.Add(new MySqlParameter("email", emp.Email));
            cmdEmployee.Parameters.Add(new MySqlParameter("first_working_date", emp.StartDate));
            cmdEmployee.Parameters.Add(new MySqlParameter("last_working_date", emp.EndDate));
            cmdEmployee.Parameters.Add(new MySqlParameter("birthdate", emp.Birthdate));
            cmdEmployee.Parameters.Add(new MySqlParameter("contract_type", emp.ContractType));
            cmdEmployee.Parameters.Add(new MySqlParameter("hourly_wage", emp.HourlyWage));
            cmdEmployee.Parameters.Add(new MySqlParameter("address", emp.Address));
            cmdEmployee.Parameters.Add(new MySqlParameter("departure_reason", emp.DepartureReason));
            cmdEmployee.Parameters.Add(new MySqlParameter("shifts_per_week", emp.ShiftsPerWeek));
            cmdEmployee.Parameters.Add(new MySqlParameter("role", emp.role));
            cmdEmployee.Parameters.Add(new MySqlParameter("username", emp.username));
            cmdEmployee.Parameters.Add(new MySqlParameter("password", emp.password));
            
           

            int rowsAffectedEmployee = 0;
            try
            {
                rowsAffectedEmployee = cmdEmployee.ExecuteNonQuery();
            }
            catch (MySqlException exc)
            {
                connection.Close();
                throw exc;
            }
        }

        public bool LoginValidation(string username, string password)
        {
            MySqlCommand sql = new MySqlCommand("SELECT * FROM employees_zoo WHERE username=@username AND password=@password", this.connection);

            sql.Parameters.AddWithValue("@username", username);
            sql.Parameters.AddWithValue("@password", password);

            try
            {
                this.connection.Open();

                MySqlDataReader dr = sql.ExecuteReader();

                if (dr.Read())
                {
                    return true;
                }

                return false;
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
