using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library;
using Class_Library.Managers;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Add_Animal : Form {
        public Add_Animal() {
            InitializeComponent();
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            //Save the details
            string newHealth;
            if (String.IsNullOrEmpty(tbHealth.Text)) {
                newHealth = "Healthy"; //the "health" textbox was empty, so the animal is healthy
            } else {
                newHealth = tbHealth.Text;
            }
            Animal newAnimal = new Animal(tbName.Text, tbSpecies.Text, Enum.Parse<Animal.Sex>(cbSex.Text), dtBirthday.Value, dtArrival.Value, newHealth);
            AnimalManager animalManager = new AnimalManager();
            int newID = animalManager.AddAnimal(newAnimal);
            MessageBox.Show("The animal was added to the list, with ID number " + newID.ToString());
            this.Close();
        }
    }
}
