﻿
namespace ZooBazaar_SAIA_Desktop {
    partial class Statistics {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnBack = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.pvwContract = new OxyPlot.WindowsForms.PlotView();
            this.pvwWages = new OxyPlot.WindowsForms.PlotView();
            this.pvwEmployeeAge = new OxyPlot.WindowsForms.PlotView();
            this.tabAnimals = new System.Windows.Forms.TabPage();
            this.pvwAge = new OxyPlot.WindowsForms.PlotView();
            this.pvwPredator = new OxyPlot.WindowsForms.PlotView();
            this.pvwHealth = new OxyPlot.WindowsForms.PlotView();
            this.tabHabitats = new System.Windows.Forms.TabPage();
            this.pvwHabitats = new OxyPlot.WindowsForms.PlotView();
            this.tabControl1.SuspendLayout();
            this.tabEmployees.SuspendLayout();
            this.tabAnimals.SuspendLayout();
            this.tabHabitats.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(810, 698);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(171, 29);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back to menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEmployees);
            this.tabControl1.Controls.Add(this.tabAnimals);
            this.tabControl1.Controls.Add(this.tabHabitats);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(981, 679);
            this.tabControl1.TabIndex = 1;
            // 
            // tabEmployees
            // 
            this.tabEmployees.Controls.Add(this.pvwContract);
            this.tabEmployees.Controls.Add(this.pvwWages);
            this.tabEmployees.Controls.Add(this.pvwEmployeeAge);
            this.tabEmployees.Location = new System.Drawing.Point(4, 29);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployees.Size = new System.Drawing.Size(973, 646);
            this.tabEmployees.TabIndex = 0;
            this.tabEmployees.Text = "Employees";
            this.tabEmployees.UseVisualStyleBackColor = true;
            // 
            // pvwContract
            // 
            this.pvwContract.Location = new System.Drawing.Point(31, 39);
            this.pvwContract.Name = "pvwContract";
            this.pvwContract.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pvwContract.Size = new System.Drawing.Size(297, 575);
            this.pvwContract.TabIndex = 3;
            this.pvwContract.Text = "plotView1";
            this.pvwContract.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pvwContract.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pvwContract.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // pvwWages
            // 
            this.pvwWages.Location = new System.Drawing.Point(354, 39);
            this.pvwWages.Name = "pvwWages";
            this.pvwWages.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pvwWages.Size = new System.Drawing.Size(589, 283);
            this.pvwWages.TabIndex = 2;
            this.pvwWages.Text = "plotView1";
            this.pvwWages.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pvwWages.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pvwWages.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // pvwEmployeeAge
            // 
            this.pvwEmployeeAge.Location = new System.Drawing.Point(354, 346);
            this.pvwEmployeeAge.Name = "pvwEmployeeAge";
            this.pvwEmployeeAge.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pvwEmployeeAge.Size = new System.Drawing.Size(589, 265);
            this.pvwEmployeeAge.TabIndex = 1;
            this.pvwEmployeeAge.Text = "plotView1";
            this.pvwEmployeeAge.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pvwEmployeeAge.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pvwEmployeeAge.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabAnimals
            // 
            this.tabAnimals.Controls.Add(this.pvwAge);
            this.tabAnimals.Controls.Add(this.pvwPredator);
            this.tabAnimals.Controls.Add(this.pvwHealth);
            this.tabAnimals.Location = new System.Drawing.Point(4, 29);
            this.tabAnimals.Name = "tabAnimals";
            this.tabAnimals.Size = new System.Drawing.Size(973, 646);
            this.tabAnimals.TabIndex = 2;
            this.tabAnimals.Text = "Animals";
            this.tabAnimals.UseVisualStyleBackColor = true;
            // 
            // pvwAge
            // 
            this.pvwAge.Location = new System.Drawing.Point(18, 374);
            this.pvwAge.Name = "pvwAge";
            this.pvwAge.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pvwAge.Size = new System.Drawing.Size(925, 251);
            this.pvwAge.TabIndex = 2;
            this.pvwAge.Text = "plotView1";
            this.pvwAge.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pvwAge.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pvwAge.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // pvwPredator
            // 
            this.pvwPredator.Location = new System.Drawing.Point(512, 17);
            this.pvwPredator.Name = "pvwPredator";
            this.pvwPredator.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pvwPredator.Size = new System.Drawing.Size(431, 340);
            this.pvwPredator.TabIndex = 1;
            this.pvwPredator.Text = "plotView1";
            this.pvwPredator.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pvwPredator.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pvwPredator.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // pvwHealth
            // 
            this.pvwHealth.Location = new System.Drawing.Point(18, 17);
            this.pvwHealth.Name = "pvwHealth";
            this.pvwHealth.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pvwHealth.Size = new System.Drawing.Size(456, 340);
            this.pvwHealth.TabIndex = 0;
            this.pvwHealth.Text = "plotView1";
            this.pvwHealth.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pvwHealth.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pvwHealth.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabHabitats
            // 
            this.tabHabitats.Controls.Add(this.pvwHabitats);
            this.tabHabitats.Location = new System.Drawing.Point(4, 29);
            this.tabHabitats.Name = "tabHabitats";
            this.tabHabitats.Padding = new System.Windows.Forms.Padding(3);
            this.tabHabitats.Size = new System.Drawing.Size(973, 646);
            this.tabHabitats.TabIndex = 1;
            this.tabHabitats.Text = "Habitats";
            this.tabHabitats.UseVisualStyleBackColor = true;
            // 
            // pvwHabitats
            // 
            this.pvwHabitats.Location = new System.Drawing.Point(23, 75);
            this.pvwHabitats.Name = "pvwHabitats";
            this.pvwHabitats.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pvwHabitats.Size = new System.Drawing.Size(923, 400);
            this.pvwHabitats.TabIndex = 0;
            this.pvwHabitats.Text = "plotView1";
            this.pvwHabitats.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pvwHabitats.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pvwHabitats.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 749);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnBack);
            this.Name = "Statistics";
            this.Text = "Statistics";
            this.tabControl1.ResumeLayout(false);
            this.tabEmployees.ResumeLayout(false);
            this.tabAnimals.ResumeLayout(false);
            this.tabHabitats.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEmployees;
        private System.Windows.Forms.TabPage tabAnimals;
        private System.Windows.Forms.TabPage tabHabitats;
        private OxyPlot.WindowsForms.PlotView pvwContract;
        private OxyPlot.WindowsForms.PlotView pvwWages;
        private OxyPlot.WindowsForms.PlotView pvwEmployeeAge;
        private OxyPlot.WindowsForms.PlotView pvwHealth;
        private OxyPlot.WindowsForms.PlotView pvwAge;
        private OxyPlot.WindowsForms.PlotView pvwPredator;
        private OxyPlot.WindowsForms.PlotView pvwHabitats;
    }
}