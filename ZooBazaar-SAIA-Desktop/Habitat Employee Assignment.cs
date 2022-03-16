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

namespace ZooBazaar_SAIA_Desktop {
    public partial class Habitat_Employee_Assignment : Form
    {
        private Habitat habitat;
        private HabitatManager habitatManager;
        private int newResponsibleEmpId;
        private List<Employee> testEmployeeList;
        public Habitat_Employee_Assignment(HabitatManager hm, Habitat h)
        {
            InitializeComponent();
            habitatManager = hm;
            habitat = h;
            testEmployeeList = new List<Employee>
            {
                new Employee {Id = 1, FirstName = "John", LastName = "Smith"},
                new Employee {Id = 2, FirstName = "Sue", LastName = "Storm"},
                new Employee {Id = 3, FirstName = "Mary", LastName = "Jane"},
                new Employee {Id = 4, FirstName = "Bob", LastName = "Tornton"},
                new Employee {Id = 5, FirstName = "Adam", LastName = "Colt"}
            };
            cbEmployees.DataSource = testEmployeeList;
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
            output = testEmployeeList.First(x => x.Id == id);

            return output;
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            //consider changing habitat class to store employee, instead of just id
            habitat.ResponsibleEmployeeId = newResponsibleEmpId;
            habitatManager.AssignResponsibleEmployee(habitat, testEmployeeList[newResponsibleEmpId]);
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
