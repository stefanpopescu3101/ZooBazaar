using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Menu : Form {
        public Menu() {
            InitializeComponent();
        }

        private void btnAnimals_Click(object sender, EventArgs e) {
            //Animal Management button is clicked
            this.Hide();
            Animal_Management animal_Management = new Animal_Management();
            animal_Management.Show();
        }

        private void btnHabitats_Click(object sender, EventArgs e) {
            //Habitat Management button is clicked
            this.Hide();
            Habitat_Management habitat_Management = new Habitat_Management();
            habitat_Management.Show();
        }

        private void btnEmployees_Click(object sender, EventArgs e) {
            //Employee admin button is clicked
            this.Hide();
            Employee_Administration employee_Administration = new Employee_Administration();
            employee_Administration.Show();
        }
    }
}
