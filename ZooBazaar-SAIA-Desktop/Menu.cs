using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZooBazaar_SAIA_Desktop 
{
    public partial class Menu : Form 
    {
        

        public Menu() 
        {
            InitializeComponent();

        }

        private void btnAnimals_Click(object sender, EventArgs e) {
            //Animal Management button is clicked            
            Animal_Management animal_Management = new Animal_Management();
            animal_Management.Show();
            this.Close();
        }

        private void btnHabitats_Click(object sender, EventArgs e) {
            //Habitat Management button is clicked
            Habitat_Management habitat_Management = new Habitat_Management();
            habitat_Management.Show();
            this.Close();
        }

        private void btnEmployees_Click(object sender, EventArgs e) {
            //Employee admin button is clicked
            Employee_Administration employee_Administration = new Employee_Administration();
            employee_Administration.Show();
            this.Close();
        }

        private void btnSchedule_Click(object sender, EventArgs e) {
            Form1 shift_Management = new Form1();
            shift_Management.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            //Logging out, allow a new user to log in
            //TODO
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
