using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library.Object_Classes
{
    public class Employee
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private DateTime birthdate;
        private double workHours;

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public double WorkHours { get; set; }

        public Employee(int employeeId, string firstName, string lastName, string username, string password, DateTime birthday, double workHours)
        {
            this.employeeId = EmployeeId;
            
        }
        
    }
}
