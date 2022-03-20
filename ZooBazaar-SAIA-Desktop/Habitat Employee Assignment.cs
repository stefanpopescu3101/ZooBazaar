using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Class_Library;
using Class_Library.Data_Access;
using Class_Library.Managers;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Habitat_Employee_Assignment : Form
    {
        private Habitat habitat;
        private HabitatManager habitatManager;
        private int newResponsibleEmpId;
        private List<Employee> employeeList;
        private EmployeeManager employeeManager;
        public Habitat_Employee_Assignment(HabitatManager hm, Habitat h)
        {
            InitializeComponent();
            habitatManager = hm;
            habitat = h;
            employeeList = new List<Employee>();
            employeeList = employeeManager.GetAllEmployees();
            cbEmployees.DataSource = employeeList;
            if (habitat.ResponsibleEmployeeId == null)
            {
                pResponsibleValueLbl.Text = "None";
            }
            else
            {
                var employee = TestDemoFunc_GetEmployeeById(habitat.ResponsibleEmployeeId.GetValueOrDefault());
                if (employee != null)
                {
                    pResponsibleValueLbl.Text = employee.ToString();
                }
                else
                {
                    pResponsibleValueLbl.Text = "Unrecognized employee";
                }
            }
        }

        // used to test and demo functionality of this form
        public Employee TestDemoFunc_GetEmployeeById(int id)
        {
            Employee output;
            output = employeeList.First(x => x.Id == id);

            return output;
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            //consider changing habitat class to store employee, instead of just id
            habitat.ResponsibleEmployeeId = newResponsibleEmpId;
            habitatManager.AssignResponsibleEmployee(habitat, employeeList[newResponsibleEmpId]);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            newResponsibleEmpId = cbEmployees.SelectedIndex;
        }
    }
}
