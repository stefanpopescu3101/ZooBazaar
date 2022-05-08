using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Library.Managers;
using Class_Library.Data_Access;

namespace Class_Library
{
    public class Scheduler
    {
        public List<WorkShift> AllShifts { get { return this.shiftManager.GetActiveShifts(); } }

        private ShiftManager shiftManager;
        private EmployeeManager employeeManager;
        private EmployeeDb employeeMediator;
       

        public EmployeeManager EmployeeManager { get { return employeeManager; } }
        public Scheduler()
        {
            this.shiftManager = new ShiftManager();
            this.employeeManager = new EmployeeManager();
            this.employeeMediator = new EmployeeDb();
        }

        public int CheckNumberOfAssignedEmployees(string date, string type)
        {
            int assignedEmployees = 0;
            foreach (WorkShift shift in this.AllShifts)
            {
                if (shift.Date == date && shift.Type == type)
                {
                    assignedEmployees++;
                }
            }
            return assignedEmployees;
        }

        public List<Employee> GetAssignedEmployeesToShift(string date, string type)
        {
            List<Employee> employees = new List<Employee>();
            foreach (WorkShift ws in AllShifts)
            {
                foreach (Employee emp in employeeManager.GetEmployees())
                {
                    if (ws.Date == date && ws.Type == type && ws.EmployeeId == emp.Id)
                    {
                        employees.Add(emp);
                    }
                }
            }
            return employees;
        }
        public List<Employee> GetAvailableEmployees(string date, string shiftType)
        {
            List<Employee> employees = new List<Employee>();
            foreach (WorkShift ws in AllShifts)
            {
                foreach (Employee emp in employeeManager.GetEmployees())
                {
                    if (ws.Date != date && ws.Type != shiftType && ws.EmployeeId == emp.Id)
                    {
                        employees.Add(emp);
                    }
                }
            }
            return employees;
        }



        public void ScheduleWeek(string monday1, string sunday1)
        {
            List<Employee> availableEmployees = new List<Employee>();
            ShiftManager sm = new ShiftManager();
            int employeesMorning;
            int employeesAfternoon;
            int employeesEvening;



            DateTime monday = DateTime.ParseExact(monday1, "d", null);
            DateTime actualDay = monday;
            DateTime sunday = DateTime.ParseExact(sunday1, "d", null);

            while (monday <= sunday)
            {
                availableEmployees = GetAvailableEmployees(actualDay.ToString("d"), monday.ToString("d"), sunday.ToString("d"));

                employeesMorning = 0;
                employeesAfternoon = 0;
                employeesEvening = 0;

                if (availableEmployees != null)
                {
                    foreach (Employee employee in availableEmployees)
                    {
                        if (shiftManager.CheckAvailability(employee.Id, monday.ToString("d")) == true)
                        {
                            if (employeesMorning < 8)
                            {
                                if (employee.ContractType == "Full Time")
                                {
                                    WorkShift shift = new WorkShift(employee.Id, employee.Name, monday.ToString("d"), "MORNING", Convert.ToDecimal(employee.HourlyWage), 8);
                                    sm.Add(shift);
                                    employeesMorning++;
                                }
                                else
                                {
                                    WorkShift shift = new WorkShift(employee.ID, employee.Name, monday.ToString("d"), "MORNING", Convert.ToDecimal(employee.HourlyWage), 6);
                                    sm.Add(shift);
                                    employeesMorning++;
                                }
                            }

                            if (employeesAfternoon < 8)
                            {
                                if (employee.ContractType == "Full Time")
                                {
                                    WorkShift shift = new WorkShift(employee.ID, employee.Name, monday.ToString("d"), "AFTERNOON", Convert.ToDecimal(employee.HourlyWage), 8);
                                    sm.Add(shift);
                                    employeesAfternoon++;
                                }
                                else
                                {
                                    WorkShift shift = new WorkShift(employee.ID, employee.Name, monday.ToString("d"), "AFTERNOON", Convert.ToDecimal(employee.HourlyWage), 6);
                                    sm.Add(shift);
                                    employeesAfternoon++;
                                }
                            }

                            if (employeesEvening < 8)
                            {
                                if (employee.ContractType == "Full Time")
                                {
                                    WorkShift shift = new WorkShift(employee.ID, employee.Name, monday.ToString("d"), "EVENING", Convert.ToDecimal(employee.HourlyWage), 8);
                                    sm.Add(shift);
                                    employeesEvening++;
                                }
                                else
                                {
                                    WorkShift shift = new WorkShift(employee.ID, employee.Name, monday.ToString("d"), "EVENING", Convert.ToDecimal(employee.HourlyWage), 6);
                                    sm.Add(shift);
                                    employeesEvening++;
                                }
                            }

                        }




                    }
                }



                monday = monday.AddDays(1);

            }
        }

        public void Reset()
        {
            ShiftManager sm = new ShiftManager();
            sm.Reset();
        }

        private bool MaximumShifts(Employee employee, string monday1, string sunday1)
        {
            DateTime monday = DateTime.ParseExact(monday1, "dd/MM/yyyy", null);
            DateTime sunday = DateTime.ParseExact(sunday1, "dd/MM/yyyy", null);
            int numberOfShifts = 0;

            foreach (WorkShift shift in this.AllShifts)
            {
                if (shift.EmployeeId == employee.Id)
                {
                    if (DateTime.Compare(monday, DateTime.ParseExact(shift.Date, "dd/MM/yyyy", null)) <= 0 &&
                    DateTime.Compare(sunday, DateTime.ParseExact(shift.Date, "dd/MM/yyyy", null)) >= 0)
                    {
                        numberOfShifts++;
                    }
                }
            }
            if (employee.ContractType == "FullTime")
            {
                if (numberOfShifts >= 5) { return true; }
            }
            else if (employee.ContractType == "PartTime")
            {
                if (numberOfShifts >= 4) { return true; }
            }
            return false;
        }
        private bool CheckEmployeesShiftsForToday(int employeeID, string date)
        {
            List<WorkShift> shiftsToday = this.shiftManager.GetShiftsForSpecificDate(date);
            if (shiftsToday.Count > 0)
            {
                foreach (WorkShift shift in shiftsToday)
                {
                    if (shift.EmployeeId == employeeID)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public List<Employee> GetAvailableEmployees(string date, string monday, string sunday)
        {
            List<Employee> employees = this.employeeManager.GetEmployees();
            List<Employee> availableEmployees = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (!this.MaximumShifts(employee, monday, sunday))
                {

                    if (this.CheckEmployeesShiftsForToday(employee.Id, date))
                    {
                        availableEmployees.Add(employee);
                    }

                }
            }
            return availableEmployees;
        }
        public List<Employee> Search(string item)
        {
            List<Employee> employees = this.employeeManager.GetEmployees();
            List<Employee> foundemployees = new List<Employee>();
            foreach (Employee emp in employees)
            {
                if (item == emp.FirstName || item == emp.LastName || item == emp.Id.ToString())
                {
                    foundemployees.Add(emp);
                }
            }
            return foundemployees;
        }
    }
}
