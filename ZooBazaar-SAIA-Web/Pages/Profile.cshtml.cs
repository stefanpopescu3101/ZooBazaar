using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Class_Library;
using Class_Library.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZooBazaar_SAIA_Web.Pages
{
    
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }
        public EmployeeManager EmployeeManager;
        public ProfileModel()
        {
            EmployeeManager = new EmployeeManager();
        }
        public void OnGet()
        {

            if (Request.Cookies.ContainsKey("user"))
            {
                var username = Request.Cookies["user"];
                foreach(Employee emp in EmployeeManager.GetAllEmployees())
                {
                    if(emp.username == username)
                    {
                        Employee = emp;
                    }
                }
            }

           
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                EmployeeManager.UpdateEmployee(Employee);
                return new RedirectToPageResult("Index");
                
            }
            else
            {
                return Page();
            }
        }
    }
}
