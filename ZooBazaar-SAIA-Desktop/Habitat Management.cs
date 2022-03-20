using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Class_Library.Data_Access;

namespace ZooBazaar_SAIA_Desktop
{
    public partial class Habitat_Management : Form
    {
        private int selectedIndex = 0;
        private Habitat selectedHabitat;
        private HabitatManager hm;
        private BindingList<Habitat> habitats;
        private BindingList<Habitat> filteredHabitats;
        private bool isFiltered = false;

        public Habitat_Management()
        {
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
                selectedHabitat = filteredHabitats.Count > 0 ? filteredHabitats[selectedIndex] : null;
            }
            else
            {
                selectedHabitat = habitats.Count > 0 ? habitats[selectedIndex] : null;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedHabitat == null) return;
            MessageBox.Show("Are you sure you want to remove this habitat?", "Remove Item",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            hm.RemoveHabitat(selectedHabitat);
            var temp = GetIndexOf(selectedHabitat, habitats);
            var temp2 = GetIndexOf(selectedHabitat, filteredHabitats);

            // trigger event or update selected item
            if (selectedIndex == 0)
            {
                if (!isFiltered)
                {
                    if (habitats.Count > 1)
                    {
                        selectedHabitat = habitats[1];
                    }
                }
                else
                {
                    selectedHabitat = null;
                }
            }
            habitats.RemoveAt(temp);
            if (temp2 == -1) return;
            if (isFiltered && filteredHabitats.Count == 1)
            {
                isFiltered = false;
                selectedIndex = 0;
                lbHabitats.DataSource = habitats;
            }
            else if (isFiltered && filteredHabitats.Count > 1)
            {
                selectedHabitat = filteredHabitats[1];
            }

            filteredHabitats.RemoveAt(temp2);
        }

        private static int GetIndexOf(Habitat h, BindingList<Habitat> bHabitats)
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

        private void btnView_Click(object sender, EventArgs e)
        {
            var habitatDetails = new Habitat_Details(selectedHabitat);
            habitatDetails.ShowDialog();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            var assigningResponsibleEmployee = new Habitat_Employee_Assignment(hm, selectedHabitat);
            assigningResponsibleEmployee.ShowDialog();
            if (assigningResponsibleEmployee.DialogResult == DialogResult.Cancel)
            {
                return;
            }

            habitats.ElementAt(GetIndexOf(selectedHabitat, habitats)).ResponsibleEmployeeId = selectedHabitat.ResponsibleEmployeeId;
            if (isFiltered)
            {
                filteredHabitats.ElementAt(GetIndexOf(selectedHabitat, filteredHabitats)).ResponsibleEmployeeId = selectedHabitat.ResponsibleEmployeeId;
                filteredHabitats.ResetBindings();
            }
            habitats.ResetBindings();
            filteredHabitats.ResetBindings();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var habitatEditor = new Habitat_Editor(hm);
            habitatEditor.ShowDialog();
            if (habitatEditor.DialogResult == DialogResult.Cancel)
            {
                return;
            }

            isFiltered = false;
            habitats.Add(hm.Habitats.Last());
            lbHabitats.DataSource = habitats;
            filteredHabitats.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var habitatEditor = new Habitat_Editor(hm, selectedHabitat);
            habitatEditor.ShowDialog();
            if (habitatEditor.DialogResult == DialogResult.Cancel)
            {
                return;
            }

            habitats.ResetBindings();
            filteredHabitats.ResetBindings();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
