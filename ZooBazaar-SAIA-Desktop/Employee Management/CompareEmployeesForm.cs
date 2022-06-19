using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library;
using Class_Library.Data_Access;
using Class_Library.Managers;

namespace ZooBazaar_SAIA_Desktop.Employee_Management
{
    public partial class CompareEmployeesForm : Form
    {
        
        private EmployeeManager employeeManager;
        public CompareEmployeesForm(Employee existingEmployee, Employee addingEmployee)
        {
            InitializeComponent();

            employeeManager = new EmployeeManager();
  
            //Existing employee
            tbFirstName.Text = existingEmployee.FirstName;
            tbLastName.Text = existingEmployee.lastName;
            tbEmail.Text = existingEmployee.email;
            tbAddress.Text = existingEmployee.address;
            cbStatus.DisplayMember = existingEmployee.departureReason.ToString();
            cbStatus.Text = existingEmployee.DepartureReason.ToString();
            dtpBirthdate.Value = existingEmployee.birthdate;
            cbContractType.DisplayMember = existingEmployee.ContractType;
            cbContractType.Text = existingEmployee.ContractType;
            cbRole.DisplayMember = existingEmployee.Role;
            cbRole.Text = existingEmployee.Role;
            tbBsn.Text = existingEmployee.bsn;
            tbHourlyWage.Text = existingEmployee.HourlyWage.ToString();
            dtpStartDate.Value = Convert.ToDateTime(existingEmployee.StartDate);
            dtpEndDate.Value = Convert.ToDateTime(existingEmployee.EndDate);
            tbUsername.Text = existingEmployee.username;
            tbPassword.Text = string.Empty;

            //Adding employee
            tbAddingEmpFirstName.Text = addingEmployee.FirstName;
            tbAddingEmpLastName.Text = addingEmployee.LastName;
            tbAddingEmpEmail.Text = addingEmployee.Email;
            tbAddingEmpAddress.Text = addingEmployee.Address;
            cbAddingEmpStatus.DisplayMember = addingEmployee.DepartureReason.ToString();
            cbAddingEmpStatus.Text = addingEmployee.DepartureReason.ToString();
            dtpAddingEmpBirthDate.Value = addingEmployee.Birthdate;
            cbAddingEmpContract.DisplayMember = addingEmployee.ContractType;
            cbAddingEmpContract.Text = addingEmployee.ContractType;
            cbAddingEmpRole.DisplayMember = addingEmployee.Role;
            cbAddingEmpRole.Text = addingEmployee.Role;
            tbAddingEmpBsn.Text = addingEmployee.Bsn;
            tbAddingEmpHourlyWage.Text = addingEmployee.HourlyWage.ToString();
            dtpAddingEmpStartDate.Value = Convert.ToDateTime(addingEmployee.StartDate);
            dtpAddingEmpEndDate.Value = Convert.ToDateTime(addingEmployee.EndDate);
            tbAddingEmpUsername.Text = addingEmployee.username;
            tbAddingEmpPassword.Text = addingEmployee.password;
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
        }

        private void btnUpdateAddingEmp_Click(object sender, EventArgs e)
        {
            string firstName = tbAddingEmpFirstName.Text;
            string lastName = tbAddingEmpLastName.Text;
            string address = tbAddingEmpAddress.Text;
            DateTime dob = Convert.ToDateTime(dtpAddingEmpBirthDate.Value);
            string status = cbAddingEmpStatus.Text;
            string email = tbAddingEmpEmail.Text;
            string contractType = cbAddingEmpContract.Text;
            string role = cbAddingEmpRole.Text;
            string startDate = dtpAddingEmpStartDate.Value.ToString();
            string endDate = dtpAddingEmpEndDate.Value.ToString();
            string bsn = tbAddingEmpBsn.Text;
            int hourlyWage = Convert.ToInt32(tbAddingEmpHourlyWage.Text);
            string username = tbAddingEmpUsername.Text;
            string password = tbAddingEmpPassword.Text;

            Employee employee = new Employee(firstName, lastName, bsn, email, startDate, endDate, dob, contractType, hourlyWage, address, status, 0, role, username, password);

            
            int newId = employeeManager.AddEmployee(employee);
            MessageBox.Show("Employee was added");
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
