
namespace ZooBazaar_SAIA_Desktop {
    partial class Update_Animal {
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
            this.btnSave = new System.Windows.Forms.Button();
            this.dtArrival = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtBirthday = new System.Windows.Forms.DateTimePicker();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSpecies = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(159, 452);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 29);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtArrival
            // 
            this.dtArrival.Location = new System.Drawing.Point(21, 391);
            this.dtArrival.Name = "dtArrival";
            this.dtArrival.Size = new System.Drawing.Size(468, 27);
            this.dtArrival.TabIndex = 24;
            this.dtArrival.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Date of arrival:";
            // 
            // dtBirthday
            // 
            this.dtBirthday.Location = new System.Drawing.Point(21, 314);
            this.dtBirthday.Name = "dtBirthday";
            this.dtBirthday.Size = new System.Drawing.Size(468, 27);
            this.dtBirthday.TabIndex = 22;
            this.dtBirthday.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // cbSex
            // 
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] {
            "Female",
            "Male",
            "Unknown"});
            this.cbSex.Location = new System.Drawing.Point(21, 240);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(468, 28);
            this.cbSex.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Birthday:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Sex:";
            // 
            // tbSpecies
            // 
            this.tbSpecies.Location = new System.Drawing.Point(21, 165);
            this.tbSpecies.Name = "tbSpecies";
            this.tbSpecies.Size = new System.Drawing.Size(468, 27);
            this.tbSpecies.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Species:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(21, 94);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(468, 27);
            this.tbName.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Edit the details of the animal, then click save to update it";
            // 
            // Update_Animal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 508);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtArrival);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtBirthday);
            this.Controls.Add(this.cbSex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSpecies);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Update_Animal";
            this.Text = "Update_Animal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtArrival;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtBirthday;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSpecies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}