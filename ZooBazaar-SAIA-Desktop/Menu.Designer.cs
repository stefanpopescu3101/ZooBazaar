
namespace ZooBazaar_SAIA_Desktop {
    partial class Menu {
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnimals = new System.Windows.Forms.Button();
            this.btnHabitats = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome, Firstname Lastname";
            // 
            // btnAnimals
            // 
            this.btnAnimals.Location = new System.Drawing.Point(35, 68);
            this.btnAnimals.Name = "btnAnimals";
            this.btnAnimals.Size = new System.Drawing.Size(733, 76);
            this.btnAnimals.TabIndex = 1;
            this.btnAnimals.Text = "Animal Management";
            this.btnAnimals.UseVisualStyleBackColor = true;
            this.btnAnimals.Click += new System.EventHandler(this.btnAnimals_Click);
            // 
            // btnHabitats
            // 
            this.btnHabitats.Location = new System.Drawing.Point(35, 160);
            this.btnHabitats.Name = "btnHabitats";
            this.btnHabitats.Size = new System.Drawing.Size(733, 76);
            this.btnHabitats.TabIndex = 2;
            this.btnHabitats.Text = "Habitat Management";
            this.btnHabitats.UseVisualStyleBackColor = true;
            this.btnHabitats.Click += new System.EventHandler(this.btnHabitats_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(35, 252);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(733, 76);
            this.btnEmployees.TabIndex = 3;
            this.btnEmployees.Text = "Employee Administration";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(35, 345);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(733, 76);
            this.btnSchedule.TabIndex = 4;
            this.btnSchedule.Text = "Employee Scheduling";
            this.btnSchedule.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.btnEmployees);
            this.Controls.Add(this.btnHabitats);
            this.Controls.Add(this.btnAnimals);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnimals;
        private System.Windows.Forms.Button btnHabitats;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnSchedule;
    }
}