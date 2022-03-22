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
    public partial class Habitat_Editor : Form
    {
        private Habitat oldHabitat;
        private Habitat newHabitat;
        private HabitatManager habitatManager;
        private bool updateMode;
        public Habitat_Editor(HabitatManager hm)
        {
            InitializeComponent();
            this.Text = "Create New Habitat";
            updateMode = false;
            this.habitatManager = hm;
            typeCb.DataSource = Enum.GetValues(typeof(HabitatType));
            typeCb.SelectedItem = typeCb.Items[^1];
        }

        public Habitat_Editor(HabitatManager hm, Habitat h)
        {
            InitializeComponent();
            this.Text = "Update Habitat";
            updateMode = true;
            this.habitatManager = hm;
            this.oldHabitat = h;
            titleTb.Text = h.Title;
            typeCb.DataSource = Enum.GetValues(typeof(HabitatType));
            typeCb.SelectedItem = typeCb.Items[(int)oldHabitat.Type];
            capacityTb.Text = h.Capacity.ToString();
            reqEmployeesTb.Text = h.RequiredEmployeesCount.ToString();
        }

        private bool IsValidEntry()
        {
            var output = true;

            if (string.IsNullOrWhiteSpace(titleTb.Text)) output = false;
            else if (string.IsNullOrWhiteSpace(capacityTb.Text)) output = false;
            else if (string.IsNullOrWhiteSpace(reqEmployeesTb.Text)) output = false;
            else if (typeCb.SelectedIndex == -1) output = false;
            else if (!IsValidNumber(capacityTb.Text)) output = false;
            else if (!IsValidNumber(reqEmployeesTb.Text)) output = false;

            return output;
        }

        private bool IsValidNumber(string numberEntry)
        {
            var output = false;

            if (!int.TryParse(numberEntry, out int number)) return output;
            if (number > 0 && number < 100)
            {
                output = true;
            }

            return output;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValidEntry())
            {
                MessageBox.Show("Please check your entry again.", "Invalid entry");
                return;
            }
            var title = titleTb.Text;
            var capacity = int.Parse(capacityTb.Text);
            var requiredEmployees = int.Parse(reqEmployeesTb.Text);
            HabitatType type = (HabitatType)typeCb.SelectedItem;
            newHabitat = new Habitat(title, type, capacity, null, null, requiredEmployees);
            if (updateMode)
            {
                habitatManager.UpdateHabitat(oldHabitat, newHabitat);
            }
            else
            {
                habitatManager.AddHabitat(newHabitat);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
