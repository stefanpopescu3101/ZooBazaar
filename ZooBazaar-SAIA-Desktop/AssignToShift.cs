﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Class_Library;
using Class_Library.Managers;
using System.Windows.Forms;
using Class_Library.Data_Access;

namespace ZooBazaar_SAIA_Desktop
{
    public partial class AssignToShift : Form
    {
        ShiftManager shiftM;
        Scheduler scheduler;
        
        HabitatManager habitatManager;
        List<string> habitatsTitles;
        string shiftType;
        string date;
        string monday;
        string sunday;

        public AssignToShift(Scheduler scheduler, ShiftManager shiftM, string shiftType, string date, string monday, string sunday)
        {
            InitializeComponent();
            habitatManager = new HabitatManager();
            habitatsTitles = new List<string>();
            
            this.shiftM = shiftM;
            this.shiftType = shiftType;
            this.date = date;
            this.sunday = sunday;
            this.monday = monday;
            this.scheduler = scheduler;
            DisplayInfo();
            DisplayEmployees();
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
        }

        private void DisplayInfo()
        {
            this.lbShiftDate.Text = this.date + " " + this.shiftType;

        }

        private void DisplayEmployees()
        {
            this.lbAvailablePeople.Items.Clear();
            lbPeopleInShift.Items.Clear();

            List<Employee> availableEmployees = this.scheduler.GetAvailableEmployees(this.date, this.monday, this.sunday);

            foreach (Employee employee in availableEmployees)
            {
                this.lbAvailablePeople.Items.Add("ID: " + employee.Id + " - " + employee.FirstName + " " + employee.LastName);
            }

            List<Employee> peopleInShift = this.scheduler.GetAssignedEmployeesToShift(this.date, this.shiftType);

            foreach (Employee employee in peopleInShift)
            {
                this.lbPeopleInShift.Items.Add("ID: " + employee.Id + " - " + employee.FirstName + " " + employee.LastName);
            }

            

            //Habitat initialization

            habitatsTitles = habitatManager.GetHabitatsTitles();
            cmbHabitat.DataSource = habitatsTitles;
        }

        private void btnAddToShift_Click(object sender, EventArgs e)
        {
            if (lbAvailablePeople.SelectedIndex > -1 && cmbHabitat.Text!="")
            {
                string emp = lbAvailablePeople.SelectedItem.ToString();
                string[] words = emp.Split(' ');
                int id = Convert.ToInt32(words[1]);
                Employee employee = scheduler.EmployeeManager.GetEmployee(id);
                Habitat habitat = habitatManager.GetHabitatByTitle(cmbHabitat.Text);

                
                
                WorkShift workShift = new WorkShift(employee.ID, employee.Name, this.date, this.shiftType, Convert.ToDecimal(employee.HourlyWage), 8, habitat.ID, habitat.Title);
                shiftM.Add(workShift);

                
            }
            else { MessageBox.Show("Please select an employee first."); }

            MessageBox.Show("Employee has been assigned successfully!");
            DisplayEmployees();

        }

        private void btnRemoveFromTheShift_Click(object sender, EventArgs e)
        {
            if (lbPeopleInShift.SelectedIndex > -1)
            {
                string emp = lbPeopleInShift.SelectedItem.ToString();
                string[] words = emp.Split(' ');
                int id = Convert.ToInt32(words[1]);
                Employee employee = scheduler.EmployeeManager.GetEmployee(id);

                this.shiftM.RemoveEmployeesCurrentShifts(employee, this.date);

                MessageBox.Show("The shift has been successfully canceled for the selected employee.");
            }
            else { MessageBox.Show("Please select an employee to be removed from the schedule."); }
            DisplayEmployees();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != null)
            {
                List<Employee> foundemployees = scheduler.Search(tbSearch.Text);
                this.lbAvailablePeople.Items.Clear();
                foreach (Employee employee in foundemployees)
                {
                    this.lbAvailablePeople.Items.Add("ID: " + employee.ID + " - " + employee.FirstName + " " + employee.LastName);
                }

                tbSearch.Text = "";
            }
            else
            {
                MessageBox.Show("please fill in the text box");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DisplayEmployees();
            tbSearch.Text = "";
        }
    }

    
}
