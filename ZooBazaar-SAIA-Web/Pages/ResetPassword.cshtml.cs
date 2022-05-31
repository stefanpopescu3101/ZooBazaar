using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Class_Library;
using Class_Library.Managers;

namespace ZooBazaar_SAIA_Web.Pages
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }
        public EmployeeManager EmployeeManager;

        public void OnGet()
        {
            if (Request.Cookies.ContainsKey("user"))
            {
                var username = Request.Cookies["user"];
                foreach (Employee emp in EmployeeManager.GetAllEmployees())
                {
                    if (emp.username == username)
                    {
                        Employee = emp;
                    }
                }
            }
        }
    }
}
