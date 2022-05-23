using Class_Library.Object_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public class ShiftManager
    {
        public List<WorkShift> WorkShifts { get; private set; }

        public List<UnavailableShift> UnavailableShifts { get; private set; }

        private ShiftDb shiftMediator;

        public ShiftManager()
        {
            this.WorkShifts = new List<WorkShift>();
            this.UnavailableShifts = new List<UnavailableShift>();
            this.shiftMediator = new ShiftDb();
            this.LoadUnavailable();
        }

        public bool Add(WorkShift workShift)
        {
            if (workShift != null)
            {
                this.WorkShifts.Add(workShift);
                this.shiftMediator.AddNewShift(workShift);
                return true;
            }
            else { return false; }
        }

        public bool Remove(WorkShift workShift)
        {
            if (this.Get(workShift.ID) != null)
            {
                this.shiftMediator.RemoveShift(workShift);
                this.WorkShifts.Remove(workShift);
                return true;
            }
            else { return false; }

        }

        public bool CancelShift(WorkShift shift)
        {
            if (shift.CancelShift() && this.shiftMediator.UpdateShift(shift))
            {
                return true;
            }
            else { return false; }
        }

        public WorkShift Get(int id)
        {
            foreach (WorkShift workShift in this.GetAll())
            {
                if (workShift.ID == id) { return workShift; }
            }
            return null;
        }

        public List<WorkShift> GetAll()
        {
            this.Load();
            return this.WorkShifts;
        }

        public void UpdateInfo(WorkShift shift, int employeeId, string employee, string date, string type, decimal wage, int hours, int habitatId, string habitatName)
        {
            shift.UpdateInfo(employeeId, employee, date, type, wage, hours, habitatId, habitatName);
            shiftMediator.UpdateInfo(shift);
        }

        public List<WorkShift> GetActiveShifts()
        {
            List<WorkShift> activeShifts = new List<WorkShift>();
            foreach (WorkShift workShift in this.GetAll())
            {
                if (!workShift.Cancelled)
                {
                    activeShifts.Add(workShift);
                }
            }
            return activeShifts;
        }

        public List<WorkShift> GetCancelledShifts()
        {
            List<WorkShift> cancelledShifts = new List<WorkShift>();
            foreach (WorkShift workShift in this.GetAll())
            {
                if (workShift.Cancelled)
                {
                    cancelledShifts.Add(workShift);
                }
            }
            return cancelledShifts;
        }

        public void RemoveEmployeesFutureShifts(Employee employee)
        {
            this.Load();
            DateTime lastWorkDay = DateTime.ParseExact(employee.EndDate, "dd/MM/yyyy", null);

            for (int i = 0; i < this.WorkShifts.Count; i++)
            {
                if (this.WorkShifts[i].EmployeeId == employee.Id)
                {
                    if (DateTime.Compare(DateTime.ParseExact(this.WorkShifts[i].Date, "dd/MM/yyyy", null), lastWorkDay) > 0)
                    {
                        this.WorkShifts[i].CancelShift();
                        this.shiftMediator.UpdateShift(this.WorkShifts[i]);
                    }
                }
            }
        }

        public List<WorkShift> GetShiftsForSpecificDateHabitats(string date)
        {
            List<WorkShift> workShifts = new List<WorkShift>();
            foreach (WorkShift shift in shiftMediator.GetAllShifts())
            {
                if (shift.Date == date)
                {
                    workShifts.Add(shift);
                }
            }
            return workShifts;
        }

        public List<WorkShift> GetShiftsForSpecificDate(string date)
        {
            List<WorkShift> workShifts = new List<WorkShift>();
            foreach (WorkShift shift in this.GetActiveShifts())
            {
                if (shift.Date == date)
                {
                    workShifts.Add(shift);
                }
            }
            return workShifts;
        }

        //public List<WorkShift> GetUnavailableShiftsEmployee(int v)
        //{
        //    //List<UnavailableShift> unavailableShifts = new List<UnavailableShift>();
        //    //foreach (UnavailableShift shift in GetUnavailableShifts())
        //    //{
        //    //    if (shift.EmployeeId == id)
        //    //    {
        //    //        unavailableShifts.Add(shift);
        //    //    }
        //    //}
        //    //return unavailableShifts;
        //}

        public bool CheckShiftsInTheFuture(Employee employee, string lastWorkingDate)
        {
            List<WorkShift> workShifts = this.GetActiveShifts();
            DateTime lastWorkDay = DateTime.ParseExact(lastWorkingDate, "dd/MM/yyyy", null);
            int counter = 0;

            for (int i = 0; i < workShifts.Count; i++)
            {
                if (workShifts[i].EmployeeId == employee.Id)
                {
                    if (DateTime.Compare(DateTime.ParseExact(workShifts[i].Date, "dd/MM/yyyy", null), lastWorkDay) > 0)
                    {
                        counter++;
                    }
                }
            }
            if (counter > 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveEmployeesCurrentShifts(Employee employee, string date)
        {
            this.Load();

            for (int i = 0; i < this.WorkShifts.Count; i++)
            {
                if (this.WorkShifts[i].EmployeeId == employee.Id && this.WorkShifts[i].Date == date)
                {
                    this.WorkShifts[i].CancelShift();
                    this.shiftMediator.UpdateShift(WorkShifts[i]);
                }
            }
            return true;
        }

        public bool CheckAvailability(int id, string date)
        {
            if (shiftMediator.CheckShiftAvailability(id, date) == true)
            {
                return true;
            }
            return false;
        }

        public bool Load()
        {
            this.WorkShifts = this.shiftMediator.GetAllShifts();
            if (this.WorkShifts != null)
            {
                return true;
            }
            else { return false; }
        }


        public List<WorkShift> PreviousMonth(int id, int month, int year)
        {
            if (month != 1)
            {
                month--;
            }
            else
            {
                month = 12;
                year--;
            }
            string date = new DateTime(year, month, 1).ToString("d");
            string lastdate = DateTime.DaysInMonth(year, month).ToString();
            string lastDate = new DateTime(year, month, Convert.ToInt32(lastdate)).ToString("d");
            List<WorkShift> workShiftsOfCurrentMonth = new List<WorkShift>();
            foreach (WorkShift shift in GetActiveShifts())
            {
                if (shift.EmployeeId == id)
                {
                    if (DateTime.ParseExact(shift.Date, "dd/MM/yyyy", null) >= DateTime.ParseExact(date, "dd/MM/yyyy", null) && DateTime.ParseExact(shift.Date, "dd/MM/yyyy", null) <= DateTime.ParseExact(lastDate, "dd/MM/yyyy", null))
                    {
                        workShiftsOfCurrentMonth.Add(shift);
                    }
                }
            }
            return workShiftsOfCurrentMonth;
        }


        public List<WorkShift> GetWorkShiftsOfCurrentMonth(int id, int month, int year)
        {
            string date = new DateTime(year, month, 1).ToString("d");
            string lastdate = DateTime.DaysInMonth(year, month).ToString();
            string lastDate = new DateTime(year, month, Convert.ToInt32(lastdate)).ToString("d");
            List<WorkShift> workShiftsOfCurrentMonth = new List<WorkShift>();
            foreach (WorkShift shift in GetActiveShifts())
            {
                if (shift.EmployeeId == id)
                {
                    if (DateTime.ParseExact(shift.Date, "dd/MM/yyyy", null) >= DateTime.ParseExact(date, "dd/MM/yyyy", null) && DateTime.ParseExact(shift.Date, "dd/MM/yyyy", null) <= DateTime.ParseExact(lastDate, "dd/MM/yyyy", null))
                    {
                        workShiftsOfCurrentMonth.Add(shift);
                    }
                }
            }
            return workShiftsOfCurrentMonth;
        }

        public List<WorkShift> NextMonth(int id, int month, int year)
        {
            if (month != 12)
            {
                month++;
            }
            else
            {
                month = 1;
                year++;
            }
            string date = new DateTime(year, month, 1).ToString("d");
            string lastdate = DateTime.DaysInMonth(year, month).ToString();
            string lastDate = new DateTime(year, month, Convert.ToInt32(lastdate)).ToString("d");
            List<WorkShift> workShiftsOfCurrentMonth = new List<WorkShift>();
            foreach (WorkShift shift in GetActiveShifts())
            {
                if (shift.EmployeeId == id)
                {
                    if (DateTime.ParseExact(shift.Date, "dd/MM/yyyy", null) >= DateTime.ParseExact(date, "dd/MM/yyyy", null) && DateTime.ParseExact(shift.Date, "dd/MM/yyyy", null) <= DateTime.ParseExact(lastDate, "dd/MM/yyyy", null))
                    {
                        workShiftsOfCurrentMonth.Add(shift);
                    }
                }
            }
            return workShiftsOfCurrentMonth;
        }

        public List<UnavailableShift> GetUnavailableShifts()
        {
            List<UnavailableShift> unavailableShifts = new List<UnavailableShift>();
            foreach (UnavailableShift unavailableShift in this.UnavailableShifts)
            {
                unavailableShifts.Add(unavailableShift);
            }

            return unavailableShifts;
        }

        public List<UnavailableShift> GetUnavailableShiftsEmployee(int id)
        {

            List<UnavailableShift> unavailableShifts = new List<UnavailableShift>();
            foreach (UnavailableShift shift in GetUnavailableShifts())
            {
                if (shift.EmployeeId == id)
                {
                    unavailableShifts.Add(shift);
                }
            }
            return unavailableShifts;
        }

        public bool AddUnavailableShift(UnavailableShift shift)
        {
            
            if (shift != null)
            {
                this.UnavailableShifts.Add(shift);
                this.shiftMediator.AddUnavailableShift(shift);
                return true;
            }

            return false;
        }

        public bool LoadUnavailable()
        {
            this.UnavailableShifts = this.shiftMediator.GetAllUnavailable();
            if (this.UnavailableShifts != null)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            shiftMediator.ResetShifts();
        }



    }
}
