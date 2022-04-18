
namespace ZooBazaar_SAIA_Desktop
{
    partial class Habitat_Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.titleLbl = new System.Windows.Forms.Label();
            this.typeLbl = new System.Windows.Forms.Label();
            this.capacityLbl = new System.Windows.Forms.Label();
            this.reqEmployeesLbl = new System.Windows.Forms.Label();
            this.reqEmployeesTb = new System.Windows.Forms.TextBox();
            this.capacityTb = new System.Windows.Forms.TextBox();
            this.titleTb = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.typeCb = new System.Windows.Forms.ComboBox();
            this.feedingTimeLbl = new System.Windows.Forms.Label();
            this.feedingValueCb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(257, 276);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(164, 37);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLbl.Location = new System.Drawing.Point(39, 51);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(42, 21);
            this.titleLbl.TabIndex = 14;
            this.titleLbl.Text = "Title";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.typeLbl.Location = new System.Drawing.Point(39, 90);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(45, 21);
            this.typeLbl.TabIndex = 14;
            this.typeLbl.Text = "Type";
            // 
            // capacityLbl
            // 
            this.capacityLbl.AutoSize = true;
            this.capacityLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.capacityLbl.Location = new System.Drawing.Point(39, 129);
            this.capacityLbl.Name = "capacityLbl";
            this.capacityLbl.Size = new System.Drawing.Size(72, 21);
            this.capacityLbl.TabIndex = 14;
            this.capacityLbl.Text = "Capacity";
            // 
            // reqEmployeesLbl
            // 
            this.reqEmployeesLbl.AutoSize = true;
            this.reqEmployeesLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.reqEmployeesLbl.Location = new System.Drawing.Point(39, 179);
            this.reqEmployeesLbl.Name = "reqEmployeesLbl";
            this.reqEmployeesLbl.Size = new System.Drawing.Size(195, 21);
            this.reqEmployeesLbl.TabIndex = 14;
            this.reqEmployeesLbl.Text = "Required employees(qty)";
            // 
            // reqEmployeesTb
            // 
            this.reqEmployeesTb.Location = new System.Drawing.Point(248, 177);
            this.reqEmployeesTb.Name = "reqEmployeesTb";
            this.reqEmployeesTb.Size = new System.Drawing.Size(226, 23);
            this.reqEmployeesTb.TabIndex = 18;
            // 
            // capacityTb
            // 
            this.capacityTb.Location = new System.Drawing.Point(248, 131);
            this.capacityTb.Name = "capacityTb";
            this.capacityTb.Size = new System.Drawing.Size(226, 23);
            this.capacityTb.TabIndex = 18;
            // 
            // titleTb
            // 
            this.titleTb.Location = new System.Drawing.Point(248, 53);
            this.titleTb.Name = "titleTb";
            this.titleTb.Size = new System.Drawing.Size(226, 23);
            this.titleTb.TabIndex = 18;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(59, 276);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(164, 37);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // typeCb
            // 
            this.typeCb.FormattingEnabled = true;
            this.typeCb.Location = new System.Drawing.Point(248, 92);
            this.typeCb.Name = "typeCb";
            this.typeCb.Size = new System.Drawing.Size(226, 23);
            this.typeCb.TabIndex = 19;
            // 
            // feedingTimeLbl
            // 
            this.feedingTimeLbl.AutoSize = true;
            this.feedingTimeLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.feedingTimeLbl.Location = new System.Drawing.Point(39, 221);
            this.feedingTimeLbl.Name = "feedingTimeLbl";
            this.feedingTimeLbl.Size = new System.Drawing.Size(106, 21);
            this.feedingTimeLbl.TabIndex = 14;
            this.feedingTimeLbl.Text = "Feeding time";
            // 
            // feedingValueCb
            // 
            this.feedingValueCb.FormattingEnabled = true;
            this.feedingValueCb.Location = new System.Drawing.Point(248, 219);
            this.feedingValueCb.Name = "feedingValueCb";
            this.feedingValueCb.Size = new System.Drawing.Size(226, 23);
            this.feedingValueCb.TabIndex = 19;
            // 
            // Habitat_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 348);
            this.Controls.Add(this.feedingValueCb);
            this.Controls.Add(this.typeCb);
            this.Controls.Add(this.titleTb);
            this.Controls.Add(this.capacityTb);
            this.Controls.Add(this.reqEmployeesTb);
            this.Controls.Add(this.reqEmployeesLbl);
            this.Controls.Add(this.capacityLbl);
            this.Controls.Add(this.feedingTimeLbl);
            this.Controls.Add(this.typeLbl);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Habitat_Editor";
            this.Text = "Habitat_Editor_Placeholder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Label capacityLbl;
        private System.Windows.Forms.Label reqEmployeesLbl;
        private System.Windows.Forms.TextBox reqEmployeesTb;
        private System.Windows.Forms.TextBox capacityTb;
        private System.Windows.Forms.TextBox titleTb;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox typeCb;
        private System.Windows.Forms.Label feedingTimeLbl;
        private System.Windows.Forms.ComboBox feedingValueCb;
    }
}