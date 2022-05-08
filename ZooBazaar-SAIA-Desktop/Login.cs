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
using Class_Library.Object_Classes;

namespace ZooBazaar_SAIA_Desktop 
{
    public partial class Login : Form 
    {
        private EmployeeManager employeeManager;

        public Login() {
            InitializeComponent();

            employeeManager = new EmployeeManager();
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
        }

 

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password = Hasher.ComputeSha256Hash(tbPassword.Text);
            if(employeeManager.CheckCredentials(tbUsername.Text, password)!=null)
            {
                Employee employee = employeeManager.CheckCredentials(tbUsername.Text, password);

                
                this.Hide();
                Menu menu = new Menu(employee);
                menu.Show();
            }
            else
            {
                MessageBox.Show("This credentials do not exist!");
            }
            
            
        }
    }
}
