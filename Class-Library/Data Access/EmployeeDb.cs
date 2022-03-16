using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace Class_Library.Data_Access
{
    class EmployeeDb : DBMediator
    {
        public EmployeeDb() : base() { }


        public int AddEmployee(Employee emp)
        {
            try
            {
                var sql = "insert into employees_zoo (first_name, last_name, BSN, email, first_working_date, last_working_date, birthdate, contract_type, hourly_wage, address, departure_reason, shifts_per_week, role, username, password) " +
                    "values (@first_name, @last_name, @BSN, @email, @first_working_date, @last_working_date, @birthdate, @contract_type, @hourly_wage, @address, @departure_reason, @shifts_per_week, @role, @username, @password)";
                var cmd = new MySqlCommand(sql, this.connection);
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
                cmd.Parameters.AddWithValue("@role", emp.Role);
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

                    Employee employee = employee = new Employee(Convert.ToInt32(data["id"]), data["first_name"].ToString(), data["last_name"].ToString(),
                        Convert.ToInt32(data["BSN"]), data["email"].ToString(), data["first_working_date"].ToString(), data["last_working_date"].ToString(),
                        data["birthdate"].ToString(), data["contract_type"].ToString(), Convert.ToInt32(data["hourly_wage"]), data["address"].ToString(), data["departure_reason"].ToString(),
                        Convert.ToInt32(data["shifts_per_week"]),data["role"].ToString(), data["username"].ToString(), data["password"].ToString());

                    employees.Add(employee);

                    
                }
                return employees;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
