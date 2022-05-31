using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library.Managers;
using Class_Library;
using OxyPlot;
using OxyPlot.Series;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Statistics : Form {
        private Employee loggedEmployee;
        public Statistics(Employee e) {
            InitializeComponent();
            loggedEmployee = e;
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
            CreateModels();
        }

        private void CreateModels() {
            //Create the following OxyPlot models
            CreateGenderModel();
        }

        private void CreateGenderModel() {
            //Pie chart of gender distribution of employees
            PlotModel genderModel = new PlotModel { Title = "Gender Distribution" };
            dynamic genderSeries = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };
            genderSeries.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            genderSeries.Slices.Add(new PieSlice("Asia", 4157) { IsExploded = true });

            genderModel.Series.Add(genderSeries);

            pvwGender.Model = genderModel;
        }

        private void btnBack_Click(object sender, EventArgs e) {
            //Return to the main menu
            Menu menu = new Menu(loggedEmployee);
            menu.Show();
            this.Close();
        }
    }
}
