using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library.Managers;
using Class_Library;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Animal_Management : Form {
        private AnimalManager animalManager = new AnimalManager();
        private Employee loggedEmployee;

        public Animal_Management(Employee e) {
            InitializeComponent();
            loggedEmployee = e;
            animalManager.GetAllAnimals();
            RefreshList(animalManager.Animals);
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
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
            if (lbAnimals.SelectedIndex != -1) {
                Animal selectedAnimal = (Animal)lbAnimals.SelectedItem;
                Animal_Details animal_Details = new Animal_Details(selectedAnimal);
                animal_Details.Show();
            } else {
                MessageBox.Show("Please select an animal from the list");
            }            
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            //button Update is clicked
            if (lbAnimals.SelectedIndex != -1) {
                Animal selectedAnimal = (Animal)lbAnimals.SelectedItem;
                Update_Animal update_Animal = new Update_Animal(selectedAnimal);
                update_Animal.Show();
            } else {
                MessageBox.Show("Please select an animal from the list");
            }
            
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            //button Remove is clicked
            if (lbAnimals.SelectedIndex != -1) {
                Animal selectedAnimal = (Animal)lbAnimals.SelectedItem;
                Remove_Animal remove_Animal = new Remove_Animal(selectedAnimal);
                remove_Animal.Show();
            } else {
                MessageBox.Show("Please select an animal from the list");
            }           
        }

        private void btnHabitat_Click(object sender, EventArgs e) {
            //button Assign to habitat is clicked
            if (lbAnimals.SelectedIndex != -1) {
                Animal selectedAnimal = (Animal)lbAnimals.SelectedItem;
                Assign_Habitat assign_Habitat = new Assign_Habitat(selectedAnimal, animalManager);
                assign_Habitat.Show();
            } else {
                MessageBox.Show("Please select an animal from the list");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            //Button refresh list is clicked
            animalManager.GetAllAnimals();
            RefreshList(animalManager.Animals);
        }

        private void RefreshList(List<Animal> animals) {
            lbAnimals.Items.Clear();
            foreach (Animal a in animals) {
                lbAnimals.Items.Add(a);
            }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            //Return to the main menu
            Menu menu = new Menu(loggedEmployee);
            menu.Show();
            this.Close();
        }
    }
}
