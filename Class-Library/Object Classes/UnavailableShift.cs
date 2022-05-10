using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library.Object_Classes
{
    public class UnavailableShift
    {
        public int EmployeeId { get; private set; }

        public string UnavailableDay { get; set; }

        public UnavailableShift(int employeeID, string unavailableTime)
        {
            this.EmployeeId = employeeID;
            this.UnavailableDay = unavailableTime;
        }

        public override string ToString()
        {
            return $"ID : {EmployeeId}, Day : {UnavailableDay}";
        }
    }
}
