using System;
using System.Collections.Generic;
using System.Text;
using Class_Library;
using Class_Library.Data_Access;

namespace Class_Library.Managers
{
    public class EmployeeManager
    {
        private readonly EmployeeDb employeeDb;
        private static int id = 0;
        public List<Employee> employees { get; set; }
        //EmployeesMediator employeesMediator;

        public EmployeeManager()
        {
            employees = new List<Employee>();
            employeeDb = new EmployeeDb();
            Load();
        }
        public void GenerateUsernameAndPassword(Employee emp)
        {
            string userName = emp.FirstName.Substring(0, 1) + emp.LastName.Substring(0, 1) + emp.Id;
            emp.username = userName;
            emp.password = emp.Id + id++.ToString();
            //employeesMediator.UpdateUsernameAndPassword(emp);

        }
        public Employee CheckCredentials(string username, string password)
        {
            foreach (Employee emp in GetEmployees())
            {
                if (emp.username == username && emp.password == password)
                {
                    return emp;
                }
            }
            return null;
        }
        public int AddEmployee(Employee employee)
        {
            employees.Add(employee);
            int newID = employeeDb.AddEmployee(employee);
            return newID;
        }

        public void UpdateEmployee(Employee employee)
        {
            employeeDb.UpdateEmployeeDataInDatabase(employee);
        }

        public void RemoveEmployee(Employee emp)
        {
            //employeesDb.RemoveEmployee(emp);
            employees.Remove(emp);
        }

        public Employee GetEmployee(int id)
        {
            foreach (Employee e in GetEmployees())
            {
                if (e.Id == id)
                {
                    return e;
                }
            }
            return null;
        }

        public int GetEmployeeId(int id)
        {
            foreach (Employee e in GetEmployees())
            {
                if (e.Id == id)
                {
                    return e.Id;
                }
            }
            return 0;
        }

        public List<Employee> GetAllEmployees()
        {
            employees = employeeDb.GetAllEmployees();
            return employees;
        }
        public List<Employee> GetEmployees()
        {
            employees = employeeDb.GetAllEmployees();
            return employees;
        }
        public void Load()
        {
            //employees = employeesMediator.GetEmployees();
        }
        /*/public List<Employee> GetEmployeeOfDepartment(Department depart)
        {
            return employeesMediator.GetEmployeesOfDepartment(depart);
        }
        
        public void UpdateRoleAndDepartment(Employee emp, string department, string Role)
        {
            employeesMediator.UpdateRoleAndDepartment(emp, department, Role);
        }
        /*/
        public void Update(Employee employee, string firstName, string lastName, string email,
            string contractType, string address,
            string department)
        {
            //employee.UpdateInfo(firstName, lastName, email, contractType, address, department);
           // employeesMediator.Update(employee);
        }

        public void TerminateEmployeesContract(Employee employee, string endDate, string reason)
        {
            //employeesMediator.TerminateContract(employee, endDate, reason);
            //employee.TerminateContract(reason, endDate);
        }
    }
}
