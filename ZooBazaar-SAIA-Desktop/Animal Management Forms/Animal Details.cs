using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Animal_Details : Form {
        public Animal_Details(Animal a) {
            InitializeComponent();
            FillDetails(a);
        }

        private void FillDetails(Animal a) {
            //Fill all the labels with the detailed information about the animal
            lblID.Text = a.ID.ToString();
            lblName.Text = a.name;
            lblSpecies.Text = a.species;
            lblSex.Text = a.sex.ToString();
            lblBirthday.Text = a.birthday.ToString();
            if (a.habitat == null)
            {
                lblHabitat.Text = "";
            }
            else
            {
                lblHabitat.Text = a.habitat.ToString();
            }
            if (a.isInZoo) {
                lblStatus.Text = "In the zoo";
            } else {
                lblStatus.Text = "Not in the zoo";
            }
            lblHealth.Text = a.health;
            lblArrival.Text = a.arrivalDate.ToString();
            lblDeparture.Text = a.departureDate.ToString();            
        }
    }
}
