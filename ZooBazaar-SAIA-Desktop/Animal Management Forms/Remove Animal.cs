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
    public partial class Remove_Animal : Form {
        private Animal animal;
        public Remove_Animal(Animal a) {
            InitializeComponent();
            animal = a;
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            //Removal is confirmed
            string newHealth = "";
            if (cbReason.SelectedIndex == 0) { //Check to see if the animal is still alive
                newHealth = "Healthy";
            } else if (cbReason.SelectedIndex == 1) {
                newHealth = "Deceased";
            }
            animal.health = newHealth;
            animal.departureDate = dtDeparture.Value;
            animal.isInZoo = false;
            AnimalManager animalManager = new AnimalManager();
            animalManager.RemoveAnimal(animal);
            this.Close();
        }
    }
}
