﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Library;
using System.Windows.Forms;
using Class_Library.Data_Access;

namespace ZooBazaar_SAIA_Desktop
{
    public partial class Form1 : Form
    {

        private int indexMonth = DateTime.Now.Month;
        private int indexYear = DateTime.Now.Year;
        private int numberOfHabitats;
        ShiftManager shiftManager;
        Scheduler scheduler;
        HabitatManager habitatManager;
        private Employee loggedEmployee;
        Label label;
        public Form1(Employee e)
        {
            scheduler = new Scheduler();
            shiftManager = new ShiftManager();
            habitatManager = new HabitatManager();
            numberOfHabitats = habitatManager.GetHabitats().Count * 2;
            loggedEmployee = e;
            InitializeComponent();
            
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
            RefreshCalender();
        }

        

        private void RefreshCalender()
        {
            pCalender.Controls.Clear();
            int j = 1;
            for (int i = 0; i < 6; i++)
            {
                Panel weekPanel = new Panel { Dock = DockStyle.Bottom, Height = 100 };
                for (int l = 0; l < 6 && j <= DateTime.DaysInMonth(indexYear, indexMonth); l++)
                {
                    Panel p = new Panel { Dock = DockStyle.Right, Width = 180 };
                    Button button = new Button { Dock = DockStyle.Bottom };
                    Button button2 = new Button { Dock = DockStyle.Bottom };
                    Button button3 = new Button { Dock = DockStyle.Bottom };
                    button.Tag = new DateTime(indexYear, indexMonth, j);
                    button2.Tag = new DateTime(indexYear, indexMonth, j);
                    button3.Tag = new DateTime(indexYear, indexMonth, j);

                    DateTime date = (DateTime)button.Tag;

                    //FIRST BUTTON
                    if (scheduler.GetShiftsForDayPeriod(date.ToString("d"), "MORNING").Count == numberOfHabitats)
                    {
                        button.BackColor = Color.Green;
                    }
                    else if (scheduler.GetShiftsForDayPeriod(date.ToString("d"), "MORNING").Count == 0)
                    {
                        button.BackColor = Color.Red;
                    }
                    else
                    {
                        button.BackColor = Color.Yellow;
                    }

                    //SECOND BUTTON
                    if (scheduler.GetShiftsForDayPeriod(date.ToString("d"), "AFTERNOON").Count == numberOfHabitats)
                    {
                        button2.BackColor = Color.Green;
                    }
                    else if (scheduler.GetShiftsForDayPeriod(date.ToString("d"), "AFTERNOON").Count == 0)
                    {
                        button2.BackColor = Color.Red;
                    }
                    else
                    {
                        button2.BackColor = Color.Yellow;
                    }

                    //THIRD BUTTON
                    if (scheduler.GetShiftsForDayPeriod(date.ToString("d"), "EVENING").Count == numberOfHabitats)
                    {
                        button3.BackColor = Color.Green;
                    }
                    else if (scheduler.GetShiftsForDayPeriod(date.ToString("d"), "EVENING").Count == 0)
                    {
                        button3.BackColor = Color.Red;
                    }
                    else
                    {
                        button3.BackColor = Color.Yellow;
                    }

                    p.Controls.Add(label = new Label { Text = (j++).ToString(), Dock = DockStyle.Top });

                    

                    
                    p.Controls.Add(button);
                    p.Controls.Add(button2);
                    p.Controls.Add(button3);
                    weekPanel.Controls.Add(p);
                    button.Click += Button_Click;       
                    button2.Click += Button2_Click;
                    button3.Click += Button3_Click;
                    button.Text = "MORNING";
                    button2.Text = "AFTERNOON";
                    button3.Text = "EVENING";
                    button.Height = 26;
                    button2.Height = 26;
                    button3.Height = 26;
                }
                pCalender.Controls.Add(weekPanel);
            }
            ShowInLabel();

        }

        private void Button_Click(object sender, EventArgs e)
        {
            DateTime date = (DateTime)((Button)sender).Tag;

            // lastMonday is always the Monday before nextSunday.
            // When date is a Sunday, lastMonday will be tomorrow.     
            int offset = date.DayOfWeek - DayOfWeek.Monday;
            DateTime lastMonday = date.AddDays(-offset);
            DateTime nextSunday = lastMonday.AddDays(6);
            if (CheckIfDateInThePast(DateTime.Now.Month, DateTime.Now.Year, date))
            {
                AssignToShift shift = new AssignToShift(scheduler, shiftManager, "MORNING", date.ToString("d"), lastMonday.ToString("d"), nextSunday.ToString("d"));
                shift.ShowDialog();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DateTime date = (DateTime)((Button)sender).Tag;
            // lastMonday is always the Monday before nextSunday.
            // When date is a Sunday, lastMonday will be tomorrow.     
            int offset = date.DayOfWeek - DayOfWeek.Monday;
            DateTime lastMonday = date.AddDays(-offset);
            DateTime nextSunday = lastMonday.AddDays(6);
            if (CheckIfDateInThePast(DateTime.Now.Month, DateTime.Now.Year, date))
            {
                AssignToShift shift = new AssignToShift(scheduler, shiftManager, "AFTERNOON", date.ToString("d"), lastMonday.ToString("d"), nextSunday.ToString("d"));
                shift.ShowDialog();
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            DateTime date = (DateTime)((Button)sender).Tag;
            // lastMonday is always the Monday before nextSunday.
            // When date is a Sunday, lastMonday will be tomorrow.     
            int offset = date.DayOfWeek - DayOfWeek.Monday;
            DateTime lastMonday = date.AddDays(-offset);
            DateTime nextSunday = lastMonday.AddDays(6);
            if (CheckIfDateInThePast(DateTime.Now.Month, DateTime.Now.Year, date))
            {
                AssignToShift shift = new AssignToShift(scheduler, shiftManager, "EVENING", date.ToString("d"), lastMonday.ToString("d"), nextSunday.ToString("d"));
                shift.ShowDialog();
            }
        }
        private void ShowInLabel()
        {
            lbDate.Text = indexMonth.ToString() + ", " + indexYear.ToString();
        }


        private bool CheckIfDateInThePast(int month, int year, DateTime date)
        {
            if (month != 1)
            {
                month--;
            }
            else
            {
                month = 12;
                year--;
            }
            int lasdate = DateTime.DaysInMonth(year, month);
            string currentDate = new DateTime(year, month, lasdate).ToString("d");
            if (DateTime.Compare(date, DateTime.ParseExact(currentDate, "dd/MM/yyyy", null)) < 0)
            {
                MessageBox.Show("You can not schedule employees for a date in the past.");
                return false;
            }
            return true;
        }

        private void btnAutoSchedule_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The schedulling is ongoing! Please don't stop the application from running until the process is over!");

            
            

            Scheduler scheduler = new Scheduler();

            DateTime date = new DateTime();
            date = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            DateTime lastDayofMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            int offset = firstDayOfMonth.DayOfWeek - DayOfWeek.Monday;
            DateTime lastMonday = firstDayOfMonth;
            DateTime nextSunday = lastMonday.AddDays(6);



            scheduler.ScheduleWeek(lastMonday.ToString("d"), nextSunday.ToString("d"));
            scheduler.ScheduleWeekHabitats(lastMonday.ToString("d"), nextSunday.ToString("d"));

            lastMonday = lastMonday.AddDays(7);
            nextSunday = nextSunday.AddDays(7);

            scheduler.ScheduleWeek(lastMonday.ToString("d"), nextSunday.ToString("d"));
            scheduler.ScheduleWeekHabitats(lastMonday.ToString("d"), nextSunday.ToString("d"));

            lastMonday = lastMonday.AddDays(7);
            nextSunday = nextSunday.AddDays(7);

            scheduler.ScheduleWeek(lastMonday.ToString("d"), nextSunday.ToString("d"));
            scheduler.ScheduleWeekHabitats(lastMonday.ToString("d"), nextSunday.ToString("d"));

            lastMonday = lastMonday.AddDays(7);
            nextSunday = nextSunday.AddDays(7);

            scheduler.ScheduleWeek(lastMonday.ToString("d"), nextSunday.ToString("d"));
            scheduler.ScheduleWeekHabitats(lastMonday.ToString("d"), nextSunday.ToString("d"));

            lastMonday = lastMonday.AddDays(7);

            scheduler.ScheduleWeek(lastMonday.ToString("d"), lastDayofMonth.ToString("d"));
            scheduler.ScheduleWeekHabitats(lastMonday.ToString("d"), lastDayofMonth.ToString("d"));

            

            MessageBox.Show("Employees have been assigned successfully for one month!");
        }

        private void PreviousMonth()
        {
            if (indexMonth != 1)
            {
                indexMonth--;
            }
            else
            {
                indexMonth = 12;
                indexYear--;
            }
            RefreshCalender();
        }

        private void NextMonth()
        {
            if (indexMonth != 12)
            {
                indexMonth++;
            }
            else
            {
                indexMonth = 1;
                indexYear++;
            }
            RefreshCalender();
        }

        private void btnScheduleReset_Click(object sender, EventArgs e)
        {
            Scheduler scheduler = new Scheduler();
            scheduler.Reset();

            RefreshCalender();

            MessageBox.Show("All the schedule entries have been deleted!");
        }

        private void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            PreviousMonth();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            NextMonth();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            Menu menu = new Menu(loggedEmployee);
            menu.Show();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
