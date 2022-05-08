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
    public partial class Update_Animal : Form {
        private Animal a;
        public Update_Animal(Animal a) {
            InitializeComponent();
            this.a = a;
            FillDetails();
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
        }

        private void FillDetails() {
            tbName.Text = a.name;
            tbSpecies.Text = a.species;
            cbSex.SelectedItem = a.sex.ToString();
            dtBirthday.Value = a.birthday;
            tbHealth.Text = a.health;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            //Save button clicked
            string newHealth;
            if (String.IsNullOrEmpty(tbHealth.Text)) {
                newHealth = "Healthy"; //the "health" textbox was empty, so the animal is healthy
            } else {
                newHealth = tbHealth.Text;
            }
            a.name = tbName.Text;
            a.species = tbSpecies.Text;
            a.sex = Enum.Parse<Animal.Sex>(cbSex.Text);
            a.health = newHealth;
            a.birthday = dtBirthday.Value;
            
            AnimalManager animalManager = new AnimalManager();
            animalManager.UpdateAnimal(a);
            MessageBox.Show("The animal was updated");
            this.Close();
        }
    }
}
