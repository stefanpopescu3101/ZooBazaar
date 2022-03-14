using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library.Data_Access;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Habitat_Management : Form
    {
        private int selectedIndex = 0;
        private HabitatManager hm;
        private BindingList<Habitat> habitats;
        private BindingList<Habitat> filteredHabitats;
        public Habitat_Management() {
            InitializeComponent();
            hm = new HabitatManager();
            habitats = new BindingList<Habitat>();
            filteredHabitats = new BindingList<Habitat>();
            foreach (var habitat in hm.Habitats)
            {
                habitats.Add(habitat);
            }
            lbHabitats.DataSource = habitats;
        }

        private void lbHabitats_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = lbHabitats.SelectedIndex;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to remove this habitat?", "Remove Item", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            hm.RemoveHabitat(hm.Habitats[selectedIndex]);
            habitats.RemoveAt(selectedIndex);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            filteredHabitats = new BindingList<Habitat>();
            var searchedId = tbID.Text;
            foreach (var h in habitats)
            {
                if (h.ID.ToString().StartsWith($"{searchedId}"))
                {
                    filteredHabitats.Add(h);
                }
            }

            lbHabitats.DataSource = filteredHabitats;
        }
    }
}
