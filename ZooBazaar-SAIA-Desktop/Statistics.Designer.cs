
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
            this.pvwGender = new OxyPlot.WindowsForms.PlotView();
            this.tabAnimals = new System.Windows.Forms.TabPage();
            this.tabHabitats = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabEmployees.SuspendLayout();
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
            this.tabEmployees.Controls.Add(this.pvwGender);
            this.tabEmployees.Location = new System.Drawing.Point(4, 29);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployees.Size = new System.Drawing.Size(973, 646);
            this.tabEmployees.TabIndex = 0;
            this.tabEmployees.Text = "Employees";
            this.tabEmployees.UseVisualStyleBackColor = true;
            // 
            // pvwGender
            // 
            this.pvwGender.Location = new System.Drawing.Point(35, 39);
            this.pvwGender.Name = "pvwGender";
            this.pvwGender.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pvwGender.Size = new System.Drawing.Size(368, 556);
            this.pvwGender.TabIndex = 0;
            this.pvwGender.Text = "plotView1";
            this.pvwGender.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pvwGender.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pvwGender.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabAnimals
            // 
            this.tabAnimals.Location = new System.Drawing.Point(4, 29);
            this.tabAnimals.Name = "tabAnimals";
            this.tabAnimals.Size = new System.Drawing.Size(973, 646);
            this.tabAnimals.TabIndex = 2;
            this.tabAnimals.Text = "Animals";
            this.tabAnimals.UseVisualStyleBackColor = true;
            // 
            // tabHabitats
            // 
            this.tabHabitats.Location = new System.Drawing.Point(4, 29);
            this.tabHabitats.Name = "tabHabitats";
            this.tabHabitats.Padding = new System.Windows.Forms.Padding(3);
            this.tabHabitats.Size = new System.Drawing.Size(973, 646);
            this.tabHabitats.TabIndex = 1;
            this.tabHabitats.Text = "Habitats";
            this.tabHabitats.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEmployees;
        private System.Windows.Forms.TabPage tabAnimals;
        private System.Windows.Forms.TabPage tabHabitats;
        private OxyPlot.WindowsForms.PlotView pvwGender;
    }
}