﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public class WorkShift
    {
        public int ID { get; set; }
        public int EmployeeId { get; private set; }
        public string EmployeeName { get; private set; }
        public string Date { get; private set; }
        public string Type { get; private set; }
        public decimal WageForShift { get; private set; }
        public int HoursWorked { get; private set; }
        
        public string HabitatName { get; private set; }
        public int HabitatID { get; private set; }

        public bool Cancelled { get; private set; }

        public WorkShift(int id, int employeeId, string employee, string date, string type, decimal wage, int hours, int habitatId, string habitatName)
        {
            this.ID = id;
            this.EmployeeId = employeeId;
            this.EmployeeName = employee;
            this.Date = date;
            this.Type = type;
            this.WageForShift = wage;
            this.HoursWorked = hours;
            this.HabitatID = habitatId;
            this.HabitatName = habitatName;
            this.Cancelled = false;
        }

        public WorkShift(int employeeId, string employee, string date, string type, decimal wage, int hours, int habitatId, string habitatName)
        {
            this.EmployeeId = employeeId;
            this.EmployeeName = employee;
            this.Date = date;
            this.Type = type;
            this.WageForShift = wage;
            this.HoursWorked = hours;
            this.HabitatID = habitatId;
            this.HabitatName = habitatName;
        }

        public void UpdateInfo(int employeeId, string employee, string date, string type, decimal wage, int hours, int habitatId, string habitatName)
        {
            this.EmployeeId = employeeId;
            this.EmployeeName = employee;
            this.Date = date;
            this.Type = type;
            this.WageForShift = wage;
            this.HoursWorked = hours;
            this.HabitatID = habitatId;
            this.HabitatName = habitatName;
            this.Cancelled = false;
        }

        public bool CancelShift()
        {
            if (!this.Cancelled)
            {
                this.Cancelled = true;
                return true;
            }
            else { return false; }
        }

        //public override string ToString()
        //{
        //    return "ID: " + this.ID + ", Employee ID:" + this.EmployeeId + " - " + this.EmployeeName;
        //}
    }

}
