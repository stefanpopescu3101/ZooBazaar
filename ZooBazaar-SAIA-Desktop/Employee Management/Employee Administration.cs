using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library.Managers;
using Class_Library;
using ZooBazaar_SAIA_Desktop.Employee_Management;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Employee_Administration : Form {
        public EmployeeManager employeeManager = new EmployeeManager();
        private Employee loggedEmployee;

        public Employee employee;
        public Employee_Administration(Employee e) {
            InitializeComponent();
            loggedEmployee = e;
            employeeManager.GetAllEmployees();
            UpdateLVAllEmployees();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.Show();
        }

        public void UpdateLVAllEmployees()
        {
            //method to update the list view
            lvEmployees.Items.Clear();

            //puts employees in employeeID order

            foreach (Employee employee in employeeManager.employees)
            {
                
                    string[] row = {employee.FirstName, employee.LastName, employee.Bsn.ToString(), employee.Email, employee.StartDate.ToString(), employee.EndDate.ToString(), employee.birthdate.ToString(), employee.ContractType, employee.HourlyWage.ToString(),employee.Address,employee.DepartureReason,employee.ShiftsPerWeek.ToString(), employee.role, employee.ID.ToString()};
                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = employee;
                    lvEmployees.Items.Add(listViewItem);
                
            }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            
            Menu menu = new Menu(loggedEmployee);
            menu.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
              employee =  (Employee)lvEmployees.SelectedItems[0].Tag;
            
               //employee = employeeManager.GetEmployee(emp.Id);
            
            AddEmployeeForm updateEmployee = new AddEmployeeForm(employee);
            updateEmployee.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }
    }
}
