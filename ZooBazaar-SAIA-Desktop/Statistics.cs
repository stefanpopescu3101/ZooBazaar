using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library.Managers;
using Class_Library;
using Class_Library.Data_Access;
using Class_Library.Object_Classes;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Statistics : Form {
        private Employee loggedEmployee;

        //Lists for storing data
        private List<Employee> employees;
        private List<Animal> animals;
        private List<Habitat> habitats;
        private List<WorkShift> workshifts;
        private List<Ticket> tickets;

        public Statistics(Employee e) {
            InitializeComponent();
            loggedEmployee = e;
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
            CreateModels();
        }

        private void CreateModels() {
            //Get all the needed data (employees, animals, habitats, total wages, and ticket sales)
            EmployeeManager employeeManager = new EmployeeManager();
            employees = employeeManager.GetAllEmployees();
            AnimalManager animalManager = new AnimalManager();
            animalManager.GetAllAnimals();
            animals = animalManager.Animals;
            HabitatManager habitatManager = new HabitatManager();
            habitats = habitatManager.GetHabitats();
            ShiftManager shiftManager = new ShiftManager();
            workshifts = shiftManager.GetAll();
            TicketManager ticketManager = new TicketManager();
            tickets = ticketManager.GetAllTickets();

            //Create the following OxyPlot models, which provide data for the graphs
            CreateContractModel();
            CreateWagesModel();
            CreateEmpAgeModel();

            CreateHealthModel();
            CreatePredatorModel();
            CreateAnimalAgeModel();

            CreateHabitatModel();

            CreateFinancesModel();
        }

        private void CreateContractModel() {
            //Count number of parttime/fulltime employees
            int parttime = 0;
            int fulltime = 0;
            foreach (Employee e in employees) {
                if (e.ContractType == "Part Time") {
                    parttime++;
                } else if (e.ContractType == "Full Time") {
                    fulltime++;
                }
            }
            //Pie chart of contract types
            PlotModel contractModel = new PlotModel { Title = "Contract types" };
            var contractSeries = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };
            contractSeries.Slices.Add(new PieSlice("Part time", parttime) { IsExploded = true });
            contractSeries.Slices.Add(new PieSlice("Full time", fulltime) { IsExploded = true });

            contractModel.Series.Add(contractSeries);
            pvwContract.Model = contractModel;
        }

        private void CreateWagesModel() {
            //Create list of wages
            List<double> wages = new List<double>();
            foreach (Employee e in employees) {
                wages.Add(e.HourlyWage);
            }
            //Graph of hourly wages
            PlotModel wagesModel = new PlotModel { Title = "Distribution of hourly wages" };
            wagesModel.Axes.Add(new LinearAxis() { Title = "Hourly wage", Position = AxisPosition.Bottom });
            wagesModel.Axes.Add(new LinearAxis() { Title = "Frequency", Position = AxisPosition.Left });
            var wagesSeries = new HistogramSeries { FillColor = OxyColors.Green, StrokeColor = OxyColors.Black, StrokeThickness = 2 };
            var bins = HistogramHelpers.CreateUniformBins(1, 50, 50);
            var binningOptions = new BinningOptions(BinningOutlierMode.IgnoreOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.ExcludeExtremeValues);
            var items = HistogramHelpers.Collect(wages, bins, binningOptions);

            wagesSeries.Items.AddRange(items);
            wagesModel.Series.Add(wagesSeries);
            pvwWages.Model = wagesModel;
        }

        private void CreateEmpAgeModel() {
            //Create list of ages
            List<double> ages = new List<double>();
            foreach (Employee e in employees) {
                TimeSpan age = DateTime.Today - e.Birthdate;
                int years = (age.Days / 365);
                ages.Add(years);
            }
            //Graph of hourly wages
            PlotModel agesModel = new PlotModel { Title = "Distribution of employee ages" };
            agesModel.Axes.Add(new LinearAxis() { Title = "Age", Position = AxisPosition.Bottom });
            agesModel.Axes.Add(new LinearAxis() { Title = "Frequency", Position = AxisPosition.Left });
            var agesSeries = new HistogramSeries { FillColor = OxyColors.Blue, StrokeColor = OxyColors.Black, StrokeThickness = 2 };
            var bins = HistogramHelpers.CreateUniformBins(15, 65, 50);
            var binningOptions = new BinningOptions(BinningOutlierMode.IgnoreOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.ExcludeExtremeValues);
            var items = HistogramHelpers.Collect(ages, bins, binningOptions);

            agesSeries.Items.AddRange(items);
            agesModel.Series.Add(agesSeries);
            pvwEmployeeAge.Model = agesModel;
        }

        private void CreateHealthModel() {
            //Count healthy and unhealthy animals
            int healthy = 0;
            int unhealthy = 0;
            foreach (Animal a in animals) {
                if (a.isInZoo == true) {
                    if (a.health == "Healthy") {
                        healthy++;
                    } else {
                        unhealthy++;
                    }
                }                
            }
            //Pie chart of health condition
            PlotModel healthModel = new PlotModel { Title = "Health conditions" };
            var healthSeries = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };
            healthSeries.Slices.Add(new PieSlice("Healthy", healthy) { IsExploded = true });
            healthSeries.Slices.Add(new PieSlice("Unhealthy", unhealthy) { IsExploded = true });

            healthModel.Series.Add(healthSeries);
            pvwHealth.Model = healthModel;
        }

        private void CreatePredatorModel() {
            //Count predator and prey animals
            int predator = 0;
            int prey = 0;
            foreach (Animal a in animals) {
                if (a.isInZoo == true) {
                    if (a.isPredator == true) {
                        predator++;
                    } else {
                        prey++;
                    }
                }
            }
            //Pie chart of predator/prey division
            PlotModel predatorModel = new PlotModel { Title = "Predator and Prey animals" };
            var predatorSeries = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };
            predatorSeries.Slices.Add(new PieSlice("Predator", predator) { IsExploded = true });
            predatorSeries.Slices.Add(new PieSlice("Prey", prey) { IsExploded = true });

            predatorModel.Series.Add(predatorSeries);
            pvwPredator.Model = predatorModel;
        }

        private void CreateAnimalAgeModel() {
            //Get list of animal ages
            List<double> ages = new List<double>();
            foreach (Animal a in animals) {
                if (a.isInZoo == true) {
                    TimeSpan age = DateTime.Today - a.birthday;
                    int years = (age.Days / 365);
                    ages.Add(years);
                }
            }
            //Graph of animal ages
            PlotModel agesModel = new PlotModel { Title = "Distribution of animal ages" };
            agesModel.Axes.Add(new LinearAxis() { Title = "Age", Position = AxisPosition.Bottom });
            agesModel.Axes.Add(new LinearAxis() { Title = "Frequency", Position = AxisPosition.Left });
            var agesSeries = new HistogramSeries { FillColor = OxyColors.Orange, StrokeColor = OxyColors.Black, StrokeThickness = 2 };
            var bins = HistogramHelpers.CreateUniformBins(0, 25, 26);
            var binningOptions = new BinningOptions(BinningOutlierMode.IgnoreOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.ExcludeExtremeValues);
            var items = HistogramHelpers.Collect(ages, bins, binningOptions);

            agesSeries.Items.AddRange(items);
            agesModel.Series.Add(agesSeries);
            pvwAge.Model = agesModel;
        }

        private void CreateHabitatModel() {
            //Get list of habitats, then get animals for each habitat
            Dictionary<string, int> habitatsWithAnimals = new Dictionary<string, int>();
            int animalCount = 0;
            foreach (Habitat h in habitats) {
                foreach (Animal a in animals) {
                    if (a.habitat == h.ID) {
                        animalCount++;
                    }
                }
                if (animalCount > 0) {
                    habitatsWithAnimals.Add(h.Title, animalCount);
                }
                animalCount = 0;
            }
            //Create lists for easier use in the graph
            List<string> habitatList = new List<string>(); ;
            List<int> animalsList = new List<int>(); ;
            foreach (var ha in habitatsWithAnimals) {
                habitatList.Add(ha.Key);
                animalsList.Add(ha.Value);
            }
            //Graph of habitats, with the number of animals for each
            var habitatModel = new PlotModel { Title = "Number of animals in each habitat" };
            CategoryAxis catAxis = new CategoryAxis { Title = "Habitats", Position = AxisPosition.Left };
            habitatModel.Axes.Add(new LinearAxis() { Title = "Nr. of animals", Position = AxisPosition.Bottom });
            foreach (string h in habitatList) {
                catAxis.Labels.Add(h);
            }
            habitatModel.Axes.Add(catAxis);
            var habitatSeries = new BarSeries();
            foreach (int a in animalsList) {
                habitatSeries.Items.Add(new BarItem(a));
            }

            habitatModel.Series.Add(habitatSeries);
            pvwHabitats.Model = habitatModel;
        }

        private void CreateFinancesModel() {
            //Summarise data about total employee wages
            decimal totalWages = 0;
            foreach (WorkShift w in workshifts) {
                //Multiply the wage per hour with the nr of hours, then add it to the total
                decimal sumOfShift = w.WageForShift * w.HoursWorked;
                totalWages += sumOfShift;
            }
            //Sumarise ticket sales
            decimal totalTickets = 0;
            foreach (Ticket t in tickets) {
                totalTickets += t.Price;
            }

            //Create the graph and fill it
            var financesModel = new PlotModel { Title = "Expenses vs. Income of the current month" };
            CategoryAxis catAxis = new CategoryAxis { Position = AxisPosition.Left };
            financesModel.Axes.Add(new LinearAxis() { Title = "Amount in Euro (€)", Position = AxisPosition.Bottom });
            catAxis.Labels.Add("Total employee wages paid");
            catAxis.Labels.Add("Total earnings from ticket sales");
            financesModel.Axes.Add(catAxis);
            var financesSeries = new BarSeries();
            financesSeries.Items.Add(new BarItem((double)totalWages));
            financesSeries.Items.Add(new BarItem((double)totalTickets));
            financesModel.Series.Add(financesSeries);
            pvwFinances.Model = financesModel;

            //Show profit/loss
            decimal profits = totalTickets - totalWages;
            lblprofitloss.Text = profits.ToString();
            lbleur.Font = new Font(lbleur.Font.FontFamily, 25);
            lblprofitloss.Font = new Font(lblprofitloss.Font.FontFamily, 25);
            if (profits < 0) { //It's a loss, turn everything red
                lbllossorprofit.Text = "Lost";
                lbleur.ForeColor = Color.Red;
                lblprofitloss.ForeColor = Color.Red;
                lbllossorprofit.ForeColor = Color.Red;
            } else { //It's profitable, turn everything green
                lbllossorprofit.Text = "Earned";
                lbleur.ForeColor = Color.Red;
                lblprofitloss.ForeColor = Color.Red;
                lbllossorprofit.ForeColor = Color.Red;
            }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            //Return to the main menu
            Menu menu = new Menu(loggedEmployee);
            menu.Show();
            this.Close();
        }
    }
}
