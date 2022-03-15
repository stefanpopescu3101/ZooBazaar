using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar
{
    public class ShiftManager
    {
        public List<WorkShift> WorkShifts { get; private set; }
        private ShiftDb shiftMediator;

        public ShiftManager()
        {
            this.WorkShifts = new List<WorkShift>();
            this.shiftMediator = new ShiftDb();
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
            DateTime lastWorkDay = DateTime.ParseExact(employee.LastWorkingDate, "MM/dd/yyyy", null);

            for (int i = 0; i < this.WorkShifts.Count; i++)
            {
                if (this.WorkShifts[i].EmployeeId == employee.ID)
                {
                    if (DateTime.Compare(DateTime.ParseExact(this.WorkShifts[i].Date, "MM/dd/yyyy", null), lastWorkDay) > 0)
                    {
                        this.WorkShifts[i].CancelShift();
                        this.shiftMediator.UpdateShift(this.WorkShifts[i]);
                    }
                }
            }
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


        public bool CheckShiftsInTheFuture(Employee employee, string lastWorkingDate)
        {
            List<WorkShift> workShifts = this.GetActiveShifts();
            DateTime lastWorkDay = DateTime.ParseExact(lastWorkingDate, "MM/dd/yyyy", null);
            int counter = 0;

            for (int i = 0; i < workShifts.Count; i++)
            {
                if (workShifts[i].EmployeeId == employee.ID)
                {
                    if (DateTime.Compare(DateTime.ParseExact(workShifts[i].Date, "MM/dd/yyyy", null), lastWorkDay) > 0)
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
                if (this.WorkShifts[i].EmployeeId == employee.ID && this.WorkShifts[i].Date == date)
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

        public void Reset()
        {
            shiftMediator.ResetShifts();
        }



    }
}
