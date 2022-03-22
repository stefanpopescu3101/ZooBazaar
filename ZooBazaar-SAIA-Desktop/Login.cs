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

namespace ZooBazaar_SAIA_Desktop 
{
    public partial class Login : Form 
    {
        private EmployeeManager employeeManager;

        public Login() {
            InitializeComponent();

            employeeManager = new EmployeeManager();
        }

 

        private void btnLogin_Click(object sender, EventArgs e) 
        {
            if(employeeManager.CheckCredentials(tbUsername.Text, tbPassword.Text)!=null)
            {
                Employee employee = employeeManager.CheckCredentials(tbUsername.Text, tbPassword.Text);

                
                this.Hide();
                Menu menu = new Menu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("This credentials do not exist!");
            }
            
            
        }
    }
}
