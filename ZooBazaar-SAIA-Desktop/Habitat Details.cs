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
    public partial class Habitat_Details : Form
    {
        private Habitat habitat;
        public Habitat_Details(Habitat h)
        {
            InitializeComponent();
            this.habitat = h;
            idValueLbl.Text = h.ID.ToString();
            titleValueLbl.Text = h.Title;
            typeValueLbl.Text = h.Type.ToString();
            capacityValueLbl.Text = h.Capacity.ToString();
            if (h.ResponsibleEmployeeId == null)
            {
                responsibleValueLbl.Text = "None";
            }
            else
            {
                responsibleValueLbl.Text = h.ResponsibleEmployeeId.ToString();
            }

            if (h.Animals.Count == 0)
            {
                animalsLb.Items.Add("None");
            }
            else
            {
                animalsLb.DataSource = h.Animals;
            }

            reqEmpValueLbl.Text = h.RequiredEmployeesCount.ToString();
        }



        private void btnAssign_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
