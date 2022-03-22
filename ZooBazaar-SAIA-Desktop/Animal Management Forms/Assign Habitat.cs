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
        private List<Habitat> habitats;
        private HabitatDb habitatDb;
        private AnimalManager animalManager;
        public Assign_Habitat(Animal a, AnimalManager am) {
            InitializeComponent();
            animal = a;
            animalManager = am;
            FillHabitatList();
        }

        // I think, that it's better to store animal id as int not as string.
        // If there is no assigned habitat store it as null.
        private void btnAssign_Click(object sender, EventArgs e) {
            //Confirmation button clicked
            var index = cbHabitat.SelectedIndex;
            if (index != -1)
            {
                var selectedHabitatId = habitats[index].ID;
                animal.habitat = selectedHabitatId;
                animalManager.UpdateAssignedHabitat(animal, selectedHabitatId);
            }
            this.Close();

            //TODO: finish this, save/get habitat id
        }

        private void FillHabitatList() {
            habitatDb = new HabitatDb();
            habitats = new List<Habitat>();
            habitats = habitatDb.LoadHabitats();
            cbHabitat.DataSource = habitats;
        }
    }
}
