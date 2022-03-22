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

        public Employee_Administration() {
            InitializeComponent();
            employeeManager.GetAllEmployees();
            UpdateLVAllEmployees();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.Show();
        }

        private void UpdateLVAllEmployees()
        {
            //method to update the list view
            lvEmployees.Items.Clear();

            //puts employees in employeeID order

            foreach (Employee employee in employeeManager.employees)
            {
                
                    string[] row = {employee.FirstName, employee.LastName, employee.Bsn.ToString(), employee.Email, employee.StartDate.ToString(), employee.EndDate.ToString(), employee.birthdate.ToString(), employee.ContractType, employee.HourlyWage.ToString(),employee.Address,employee.DepartureReason,employee.ShiftsPerWeek.ToString(), employee.role };
                    var listViewItem = new ListViewItem(row);
                    lvEmployees.Items.Add(listViewItem);
                
            }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
