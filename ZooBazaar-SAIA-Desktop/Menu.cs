using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Class_Library;

namespace ZooBazaar_SAIA_Desktop 
{
    public partial class Menu : Form
    {
        private Employee loggedEmployee;
        public Menu() 
        {
            InitializeComponent();
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
        }

        public Menu(Employee e)
        {
            InitializeComponent();
            loggedEmployee = e;
            userNameLbl.Text = loggedEmployee.FullName;
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
        }

        private void btnAnimals_Click(object sender, EventArgs e) {
            //Animal Management button is clicked            
            Animal_Management animal_Management = new Animal_Management(loggedEmployee);
            animal_Management.Show();
            this.Close();
        }

        private void btnHabitats_Click(object sender, EventArgs e) {
            //Habitat Management button is clicked
            btnAssignEmployeesToWork habitat_Management = new btnAssignEmployeesToWork(loggedEmployee);
            habitat_Management.Show();
            this.Close();
        }

        private void btnEmployees_Click(object sender, EventArgs e) {
            //Employee admin button is clicked
            Employee_Administration employee_Administration = new Employee_Administration(loggedEmployee);
            employee_Administration.Show();
            this.Close();
        }

        private void btnSchedule_Click(object sender, EventArgs e) {
            Form1 shift_Management = new Form1(loggedEmployee);
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

        private void btnStatistics_Click(object sender, EventArgs e) {
            Statistics statistics = new Statistics(loggedEmployee);
            statistics.Show();
            this.Close();
        }
    }
}
