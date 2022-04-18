using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library;
using Class_Library.Data_Access;
using Class_Library.Managers;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Habitat_Details : Form
    {
        private Habitat habitat;
        private AnimalManager animalManager;
        private EmployeeManager employeeManager;
        private List<Animal> animals;
        private BindingList<string> bindingAnimals = new BindingList<string>();
        public Habitat_Details(Habitat h, AnimalManager am, EmployeeManager em)
        {
            InitializeComponent();
            this.habitat = h;
            idValueLbl.Text = h.ID.ToString();
            titleValueLbl.Text = h.Title;
            typeValueLbl.Text = h.Type.ToString();
            capacityValueLbl.Text = h.Capacity.ToString();
            feedingTimeValueLbl.Text = h.FeedingTime.ToString();
            animalManager = am;
            employeeManager = em;
            animals = new List<Animal>();
            animals = animalManager.GetAnimalsOfSpecifiedHabitatId(habitat.ID);
            if (h.ResponsibleEmployeeId == null)
            {
                responsibleValueLbl.Text = "None";
            }
            else
            {
                var responsibleEmployee = employeeManager.GetEmployee((int)h.ResponsibleEmployeeId);
                responsibleValueLbl.Text = $"{responsibleEmployee.FullName}";
            }

            if (animals.Count == 0)
            {
                animalsLb.Items.Add("None");
            }
            else
            {
                animalsLb.DataSource = bindingAnimals;
                foreach (var animal in animals)
                {
                    bindingAnimals.Add($"{animal.name} the {animal.species}");
                }
            }
            bindingAnimals.ResetBindings();
            reqEmpValueLbl.Text = h.RequiredEmployeesCount.ToString();
            animalsLb.SelectionMode = SelectionMode.None;
        }



        private void btnAssign_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void animalsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
