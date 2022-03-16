using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library.Data_Access;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Habitat_Management : Form
    {
        private int selectedIndex = 0;
        private Habitat selectedHabitat;
        private HabitatManager hm;
        private BindingList<Habitat> habitats;
        private BindingList<Habitat> filteredHabitats;
        private bool isFiltered = false;
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
            if (isFiltered)
            {
                if (filteredHabitats.Count > 0)
                {
                    selectedHabitat = filteredHabitats[selectedIndex];
                }
                else
                {
                    selectedHabitat = null;
                }
            }
            else
            {
                if (habitats.Count > 0)
                {
                    selectedHabitat = habitats[selectedIndex];
                }
                else
                {
                    selectedHabitat = null;
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedHabitat != null)
            {
                MessageBox.Show("Are you sure you want to remove this habitat?", "Remove Item", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                hm.RemoveHabitat(selectedHabitat);
                var temp = GetIndexOf(selectedHabitat, habitats);
                var temp2 = GetIndexOf(selectedHabitat, filteredHabitats);

                habitats.RemoveAt(temp);
                if (temp2 != -1)
                {
                    if (isFiltered && filteredHabitats.Count == 1)
                    {
                        isFiltered = false;
                        lbHabitats.DataSource = habitats;
                        selectedIndex = 0;
                    }
                    filteredHabitats.RemoveAt(temp2);
                }
            }
        }

        private int GetIndexOf(Habitat h, BindingList<Habitat> bHabitats)
        {
            var output = bHabitats.IndexOf(h);

            return output;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            filteredHabitats = new BindingList<Habitat>();
            selectedIndex = 0;
            var searchedId = tbID.Text;
            if (tbID.Text != string.Empty)
            {
                foreach (var h in habitats)
                {
                    if (h.ID.ToString().Contains($"{searchedId}"))
                    {
                        filteredHabitats.Add(h);
                    }
                }

                tbID.Text = string.Empty;
                if (filteredHabitats.Count > 0)
                {
                    lbHabitats.DataSource = filteredHabitats;
                    selectedHabitat = filteredHabitats[0];
                    isFiltered = true;
                }
            }
            else
            {
                lbHabitats.DataSource = habitats;
                selectedHabitat = habitats[0];
                isFiltered = false;
            }
        }

    }
}
