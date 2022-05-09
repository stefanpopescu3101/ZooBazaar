using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Class_Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Class_Library.Managers;
using Class_Library.Data_Access;

namespace ZooBazaar_SAIA_Web.Pages
{
    public class ScheduleModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        public Employee Emp { get; set; }
        [BindProperty]
        public DateTime UnavailableDate { get; set; }
        ///public UnavailableShift Unavailable { get; set; }
        private EmployeeDb med = new EmployeeDb();
        public EmployeeManager manager;
        ShiftDb shiftMediator = new ShiftDb();
        public ShiftManager shiftManager;

        public List<WorkShift> workShifts = new List<WorkShift>();
        ///public List<UnavailableShift> unavailableShifts = new List<UnavailableShift>();
        public List<WorkShift> unavailableShifts = new List<WorkShift>();

        public ScheduleModel()
        {
            manager = new EmployeeManager();
            manager.Load();
            shiftManager = new ShiftManager();
        }

        //public void OnGet()
        //{
        //    if (HttpContext.Session.Get("id") != null)
        //    {
        //        string id = HttpContext.Session.GetString("id");
        //        if (manager.GetEmployee(Convert.ToInt32(id)) != null)
        //        {
        //            this.Emp = manager.GetEmployee(Convert.ToInt32(id));
        //            Name = Emp.FirstName + " " + Emp.LastName;


        //        }
        //    }
        //}


        public IActionResult OnPostReset()
        {
            // string id = HttpContext.Session.GetString("id");
            string id = Request.Cookies["id"];
            this.workShifts = shiftManager.GetWorkShiftsOfCurrentMonth(Convert.ToInt32(id), DateTime.Now.Month, DateTime.Now.Year);
            this.Emp = manager.GetEmployee(Convert.ToInt32(id));
            Name = Emp.FirstName + " " + Emp.LastName;
            return Page();
        }

        public IActionResult OnPostPrevious()
        {
            // string id = HttpContext.Session.GetString("id");
            string id = Request.Cookies["id"];
            this.workShifts = shiftManager.PreviousMonth(Convert.ToInt32(id), DateTime.Now.Month, DateTime.Now.Year);
            this.Emp = manager.GetEmployee(Convert.ToInt32(id));
            Name = Emp.FirstName + " " + Emp.LastName;
            return Page();
        }
        public IActionResult OnPostNext()
        {
            // string id = HttpContext.Session.GetString("id");
            string id = Request.Cookies["id"];
            this.workShifts = shiftManager.NextMonth(Convert.ToInt32(id), DateTime.Now.Month, DateTime.Now.Year);
            this.Emp = manager.GetEmployee(Convert.ToInt32(id));
            Name = Emp.FirstName + " " + Emp.LastName;
            return Page();
        }

        public IActionResult OnPostShow()
        {
            // string id = HttpContext.Session.GetString("id");
            string id = Request.Cookies["id"];
            /// this.unavailableShifts = shiftManager.GetUnavailableShiftsEmployee(Convert.ToInt32(id));
            return Page();
        }


        public IActionResult OnPostConfirm()
        {
            // string id = HttpContext.Session.GetString("id");
            string id = Request.Cookies["id"];
            var date = DateTime.Parse(UnavailableDate.ToString()).ToShortDateString();
           /// this.Unavailable = new UnavailableShift(Convert.ToInt32(id), date);
           ///this.shiftManager.AddUnavailableShift(Unavailable);
            return Page();


        }
    }
}
