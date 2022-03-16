using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public string BSN { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ContractType { get; set; }
        public int HourlyWage { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string DepartureReason { get; set; }
        public int ShiftsPerWeek { get; set; }

        public Employee(int id, string firstName, string lastName,string username, string password, string bsn, string email, DateTime startDate, DateTime endDate, DateTime birthdate, string contractType, int hourlyWage, string address, string role, string departureReason, int shiftsPerWeek)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Password = password;
            this.BSN = bsn;
            this.Email = email;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Birthdate = birthdate;
            this.ContractType = contractType;
            this.HourlyWage = hourlyWage;
            this.Address = address;
            this.Role = role;
            this.DepartureReason = departureReason;
            this.ShiftsPerWeek = shiftsPerWeek;
        }

    }
}