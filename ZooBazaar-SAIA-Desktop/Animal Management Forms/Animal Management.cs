using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Animal_Management : Form {
        public Animal_Management() {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            //button Search is clicked
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            //button Add is clicked
            Add_Animal add_Animal = new Add_Animal();
            add_Animal.Show();
        }

        private void btnView_Click(object sender, EventArgs e) {
            //button View is clicked
            Animal_Details animal_Details = new Animal_Details();
            animal_Details.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            //button Update is clicked
            Update_Animal update_Animal = new Update_Animal();
            update_Animal.Show();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            //button Remove is clicked
            Remove_Animal remove_Animal = new Remove_Animal();
            remove_Animal.Show();
        }

        private void btnHabitat_Click(object sender, EventArgs e) {
            //button Assign to habitat is clicked
        }
    }
}
