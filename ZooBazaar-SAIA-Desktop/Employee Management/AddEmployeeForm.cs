using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library;
using Class_Library.Managers;

namespace ZooBazaar_SAIA_Desktop.Employee_Management
{
    public partial class AddEmployeeForm : Form
    {
        private Employee employee;
        private EmployeeManager employeeManager;

        public AddEmployeeForm()
        {
            this.employee = employee;
            this.employeeManager = new EmployeeManager();

            InitializeComponent();
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = tbFirstName.Text;
                string lastName = tbLastName.Text;
                string address = tbAddress.Text;
                DateTime dob = Convert.ToDateTime(dtpBirthdate.Value);
                string status = cbStatus.Text;
                string email = tbEmail.Text;
                string contractType = cbContractType.Text;
                string role = cbRole.Text;
                DateTime startDate = Convert.ToDateTime(dtpStartDate.Value.Date);
                DateTime endDate = dtpEndDate.Value;
                string bsn = tbBsn.Text;
                int hourlyWage =Convert.ToInt32(tbHourlyWage.Text);
                string username = tbUsername.Text;
                string password = tbPassword.Text;

                if (employee == null) //if making a new employee (not updating employee)
                {
                    Employee newEmployee = new Employee(0, firstName, lastName, bsn, email, startDate, endDate, dob, contractType, hourlyWage, address, status, 0, role, username, password);
                    
                    
                    int newId = employeeManager.AddEmployee(newEmployee);

                    MessageBox.Show("Employee was added");
                }
                else
                {
                    MessageBox.Show("Somthing went wrong");
                }
            }
            catch
            {

            }
        }
    }
}
