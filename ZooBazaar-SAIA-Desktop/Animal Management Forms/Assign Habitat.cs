using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library;
using Class_Library.Managers;
using Class_Library.Data_Access;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Assign_Habitat : Form {
        private Animal animal;
        public Assign_Habitat(Animal a) {
            InitializeComponent();
            animal = a;
            FillHabitatList();
        }

        private void btnAssign_Click(object sender, EventArgs e) {
            //Confirmation button clicked
            animal.habitat = cbHabitat.SelectedItem.ToString();
            //TODO: finish this, save/get habitat id
        }

        private void FillHabitatList() {
            HabitatDb habitatDb = new HabitatDb();
            List<Habitat> habitats = habitatDb.LoadHabitats();
            foreach (Habitat h in habitats) {
                cbHabitat.Items.Add(h.Title);
            }
        }
    }
}
