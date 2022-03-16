
namespace ZooBazaar_SAIA_Desktop
{
    partial class Habitat_Employee_Assignment
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
            this.btnOk = new System.Windows.Forms.Button();
            this.responsibleLbl = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.cbEmployees = new System.Windows.Forms.ComboBox();
            this.pResponsibleLbl = new System.Windows.Forms.Label();
            this.pResponsibleValueLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(190, 188);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(139, 37);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // responsibleLbl
            // 
            this.responsibleLbl.AutoSize = true;
            this.responsibleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.responsibleLbl.Location = new System.Drawing.Point(98, 96);
            this.responsibleLbl.Name = "responsibleLbl";
            this.responsibleLbl.Size = new System.Drawing.Size(209, 21);
            this.responsibleLbl.TabIndex = 14;
            this.responsibleLbl.Text = "New responsible employee";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(347, 188);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(139, 37);
            this.BtnCancel.TabIndex = 13;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbEmployees
            // 
            this.cbEmployees.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbEmployees.FormattingEnabled = true;
            this.cbEmployees.Location = new System.Drawing.Point(367, 98);
            this.cbEmployees.Name = "cbEmployees";
            this.cbEmployees.Size = new System.Drawing.Size(180, 29);
            this.cbEmployees.TabIndex = 18;
            this.cbEmployees.SelectedIndexChanged += new System.EventHandler(this.cbEmployees_SelectedIndexChanged);
            // 
            // pResponsibleLbl
            // 
            this.pResponsibleLbl.AutoSize = true;
            this.pResponsibleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pResponsibleLbl.Location = new System.Drawing.Point(98, 44);
            this.pResponsibleLbl.Name = "pResponsibleLbl";
            this.pResponsibleLbl.Size = new System.Drawing.Size(231, 21);
            this.pResponsibleLbl.TabIndex = 14;
            this.pResponsibleLbl.Text = "Current responsible employee";
            // 
            // pResponsibleValueLbl
            // 
            this.pResponsibleValueLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pResponsibleValueLbl.Location = new System.Drawing.Point(367, 44);
            this.pResponsibleValueLbl.Name = "pResponsibleValueLbl";
            this.pResponsibleValueLbl.Size = new System.Drawing.Size(180, 21);
            this.pResponsibleValueLbl.TabIndex = 19;
            this.pResponsibleValueLbl.Text = "Placeholder Name";
            // 
            // Habitat_Employee_Assignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 253);
            this.Controls.Add(this.pResponsibleValueLbl);
            this.Controls.Add(this.cbEmployees);
            this.Controls.Add(this.pResponsibleLbl);
            this.Controls.Add(this.responsibleLbl);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnOk);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Habitat_Employee_Assignment";
            this.Text = "Habitat_Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label responsibleLbl;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ComboBox cbEmployees;
        private System.Windows.Forms.Label pResponsibleLbl;
        private System.Windows.Forms.Label pResponsibleValueLbl;
    }
}