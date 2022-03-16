using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public class Employee
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int bsn { get; set; }
        public string email { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string birthdate { get; set; }
        public string contractType { get; set; }
        public int hourlyWage { get; set; }
        public string address { get; set; }
        public string departureReason { get; set; }
        public int shiftsPerWeek { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        
      
        public string DepartureReason
        {
            get { return departureReason; }
            set { departureReason = value; }
        }
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Name
        {
            get { return firstName + " " + lastName; }
        }

        public string FirstName
        {
            get { return firstName; }
        }
        public string LastName
        {
            get { return lastName; }
        }
        public int Bsn
        {
            get { return bsn; }
        }
        public string Email
        {
            get { return email; }
        }
        public string StartDate
        {
            get { return startDate; }
        }
        public string EndDate
        {
            get { return endDate; }
        }
        public string Birthdate
        {
            get { return birthdate; }
        }
        public string ContractType
        {
            get { return contractType; }
        }
        public double HourlyWage
        {
            get { return hourlyWage; }
        }
        public int ShiftsPerWeek
        {
            get { return shiftsPerWeek; }
        }
        public string Address
        {
            get { return address; }
        }
       
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        
        public string FullName
        {
            get { return firstName + " " + lastName; }
        }

        public Employee(int id, string firstName, string lastName,int bsn, string email, string startDate, string endDate, string birthdate, string contractType, int hourlyWage, string address, string departureReason, int shiftsPerWeek, string role, string username, string password )
        {
            this.Id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.bsn = bsn;
            this.email = email;
            this.startDate = startDate;
            this.endDate = endDate;
            this.birthdate = birthdate;
            this.contractType = contractType;
            this.hourlyWage = hourlyWage;
            this.address = address;
            this.Role = role;
            this.DepartureReason = departureReason;
            this.shiftsPerWeek = shiftsPerWeek;
            
        }

    }
}