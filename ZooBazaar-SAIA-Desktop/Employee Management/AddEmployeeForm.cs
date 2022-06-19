using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library;
using Class_Library.Managers;
using Class_Library.Object_Classes;
using MySqlConnector;
//using System.Net.Mail;


namespace ZooBazaar_SAIA_Desktop.Employee_Management
{
    public partial class AddEmployeeForm : Form
    {
        private int ok;
        private EmployeeManager employeeManager;
        private Employee employee1;
        string text = "An employee with the same BSN already exists, would you like to compare them?";
        string title = "Employee exists";
        MessageBoxButtons MessageBoxButtons = new MessageBoxButtons();
        public List<Employee> employees;


        public AddEmployeeForm()
        {
            ok = 0;
            this.employeeManager = new EmployeeManager();
            InitializeComponent();
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
            employees = employeeManager.GetAllEmployees();
        }

        public AddEmployeeForm(Employee employee)
        {
            ok = 1;
            InitializeComponent();
            employee1 = employee;
            this.employeeManager = new EmployeeManager();
            tbFirstName.Text = employee.FirstName;
            tbLastName.Text = employee.lastName;
            tbEmail.Text = employee.email;
            tbAddress.Text = employee.address;
            cbStatus.DisplayMember = employee.departureReason.ToString();
            dtpBirthdate.Value = employee.birthdate;
            cbContractType.DisplayMember = employee.ContractType;
            cbRole.DisplayMember = employee.Role;
            tbBsn.Text = employee.bsn;
            tbHourlyWage.Text = employee.HourlyWage.ToString();
            dtpStartDate.Value = Convert.ToDateTime(employee.StartDate);
            dtpEndDate.Value = Convert.ToDateTime(employee.EndDate);
            tbUsername.Text = employee.username;
            tbPassword.Text = employee.password;
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {


            try
            {

                if (ok == 0) //if making a new employee (not updating employee)
                {


                    btnAddEmp.Text = "Add employee";
                    string firstName = tbFirstName.Text;
                    string lastName = tbLastName.Text;
                    string address = tbAddress.Text;
                    DateTime dob = Convert.ToDateTime(dtpBirthdate.Value);
                    string status = cbStatus.Text;
                    string email = tbEmail.Text;
                    string contractType = cbContractType.Text;
                    string role = cbRole.Text;
                    string startDate = dtpStartDate.Value.ToString();
                    string endDate = dtpEndDate.Value.ToString();
                    string bsn = tbBsn.Text;
                    int hourlyWage = Convert.ToInt32(tbHourlyWage.Text);
                    string username = tbUsername.Text;
                    string password = tbPassword.Text;

                    //Using the outlook ref to create the email
                    //Outlook._Application _app = new Outlook.Application();
                    //Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                    //mail.To = tbEmail.Text;
                    //mail.Subject = "Login redentials!";
                    //string randomPassword = RandomString(10, true);
                    //mail.Body = "Username: " + username + " " + "Password: " + randomPassword ;
                    //mail.Importance = Outlook.OlImportance.olImportanceNormal;
                    //((Outlook._MailItem)mail).Send();
                    //MailMessage mail = new MailMessage();
                    //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    //mail.From = new MailAddress("your_email_address@gmail.com");
                    //mail.To.Add(tbEmail.Text);
                    //mail.Subject = "Login redentials!";
                    //mail.Body = "Username: " + username + " " + "Password: " + randomPassword;

                    //SmtpServer.Port = 587;
                    //SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                    //SmtpServer.EnableSsl = true;

                    password = Hasher.ComputeSha256Hash(password);

                    Employee newEmployee = new Employee(firstName, lastName, bsn, email, startDate, endDate, dob, contractType, hourlyWage, address, status, 0, role, username, password);

                    bool okk = false;
                  
                    foreach (Employee employee in employees)
                    {
                        if (employee.Bsn == newEmployee.Bsn)
                        {
                            okk = true;
                            DialogResult result = MessageBox.Show(text, title, MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                CompareEmployeesForm compareEmployeesForm = new CompareEmployeesForm(employee, newEmployee);
                                compareEmployeesForm.Show();
                                break;
                            }
                        }

                    }

                    if (okk == false)
                    {
                        int newId = employeeManager.AddEmployee(newEmployee);
                        MessageBox.Show("Employee was added");
                        this.Close();
                    }
                    

                }
                else
                {
                    tbPassword.Visible = true;
                    lbPassword.Visible = true;

                    btnAddEmp.Text = "Update employee";
                    employee1.firstName = tbFirstName.Text;
                    employee1.lastName = tbLastName.Text;
                    employee1.address = tbAddress.Text;
                    employee1.birthdate = Convert.ToDateTime(dtpBirthdate.Value);
                    employee1.departureReason = cbStatus.Text;
                    employee1.email = tbEmail.Text;
                    employee1.contractType = cbContractType.Text;
                    employee1.role = cbRole.Text;
                    employee1.startDate = dtpStartDate.Value.ToString();
                    employee1.endDate = dtpEndDate.Value.ToString();
                    employee1.bsn = tbBsn.Text;
                    employee1.hourlyWage = Convert.ToInt32(tbHourlyWage.Text);
                    employee1.username = tbUsername.Text;
                    employee1.password = Hasher.ComputeSha256Hash(tbPassword.Text);


                    employee1.shiftsPerWeek = 0;


                    employeeManager.UpdateEmployee(employee1);

                    MessageBox.Show("Employee was updated");
                    this.Close();

                }
            }
            catch (MySqlException mse)
            {
                MessageBox.Show(mse.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        
    }
}
