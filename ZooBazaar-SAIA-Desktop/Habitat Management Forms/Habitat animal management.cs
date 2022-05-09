using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Class_Library;
using Class_Library.Data_Access;
using Class_Library.Managers;

namespace ZooBazaar_SAIA_Desktop
{
    public partial class Habitat_animal_management : Form
    {
        private HabitatManager habitatManager;
        private AnimalManager animalManager;
        private Habitat habitat;
        private List<Animal> habitatAnimals;
        private List<Animal> availableAnimals;
        private Animal selectedAvailableAnimal;
        private Animal selectedHabitatAnimal;
        private BindingList<Animal> bindingHabitatAnimals = new BindingList<Animal>();
        private BindingList<Animal> bindingAvailableAnimals = new BindingList<Animal>();
        public Habitat_animal_management(HabitatManager hm, AnimalManager am, Habitat h)
        {
            InitializeComponent();
            animalManager = am;
            habitatManager = hm;
            habitat = h;
            animalManager.GetAllAnimals();
            habitatAnimals = new List<Animal>();
            habitatAnimals = animalManager.GetAnimalsOfSpecifiedHabitatId(h.ID);
            availableAnimals = new List<Animal>();
            availableAnimals = animalManager.GetAnimalsWithoutHabitat();
            habitatLbl.Text = h.Title;
            foreach (var animal in availableAnimals)
            {
                bindingAvailableAnimals.Add(animal);
            }
            foreach (var animal in habitatAnimals)
            {
                bindingHabitatAnimals.Add(animal);
            }
            habitatAnimalsLb.DataSource = bindingHabitatAnimals;
            availableAnimalsLb.DataSource = bindingAvailableAnimals;
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (bindingAvailableAnimals.Count > 0)
            {
                try
                {
                    habitatManager.AddAnimal(habitat, selectedAvailableAnimal.ID);
                    animalManager.UpdateAssignedHabitat(selectedAvailableAnimal, habitat.ID);

                    bindingHabitatAnimals.Add(selectedAvailableAnimal);
                    bindingAvailableAnimals.Remove(selectedAvailableAnimal);

                    selectedHabitatAnimal = (Animal) habitatAnimalsLb.SelectedItem;
                    selectedAvailableAnimal = (Animal) availableAnimalsLb.SelectedItem;

                    // TODO write changes to db(animals and habitat)
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    MessageBox.Show("Selected habitat is full.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // TODO: show message box for each type of exceptions
                }
                catch (ArgumentException exception)
                {
                    MessageBox.Show(exception.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exception)
                {

                }
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (bindingHabitatAnimals.Count > 0)
            {
                try
                {
                    habitatManager.RemoveAnimal(habitat, selectedHabitatAnimal.ID);
                    animalManager.UpdateAssignedHabitat(selectedHabitatAnimal, null);

                    bindingAvailableAnimals.Add(selectedHabitatAnimal);
                    bindingHabitatAnimals.Remove(selectedHabitatAnimal);

                    selectedHabitatAnimal = (Animal)habitatAnimalsLb.SelectedItem;
                    selectedAvailableAnimal= (Animal)availableAnimalsLb.SelectedItem;
                }
                catch (Exception exception)
                {
                    // TODO: show message box for each type of exceptions
                }
            }
        }

        private void availableAnimalsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (availableAnimals.Count > 0)
            {
                if (selectedAvailableAnimal is null)
                {
                    selectedAvailableAnimal= availableAnimals.Last();
                }
            }
        }

        private void habitatAnimalsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (habitatAnimals.Count > 0)
            {
                selectedHabitatAnimal = (Animal)habitatAnimalsLb.SelectedItem;
                if (selectedHabitatAnimal is null)
                {
                    selectedHabitatAnimal = habitatAnimals.Last();
                }
            }
        }
    }
}
