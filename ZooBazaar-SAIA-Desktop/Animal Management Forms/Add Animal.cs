using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Add_Animal : Form {
        public Add_Animal() {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            //Save the details
            Animal newAnimal = new Animal(tbName.Text, tbSpecies.Text, Enum.Parse<Animal.Sex>(cbSex.Text), dtBirthday.Value, dtArrival.Value);

        }
    }
}
