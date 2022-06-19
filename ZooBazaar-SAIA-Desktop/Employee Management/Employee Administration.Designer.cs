
namespace ZooBazaar_SAIA_Desktop {
    partial class Employee_Administration {
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
            this.btnShifts = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lvEmployees = new System.Windows.Forms.ListView();
            this.chFirstName = new System.Windows.Forms.ColumnHeader();
            this.chLastName = new System.Windows.Forms.ColumnHeader();
            this.chBSN = new System.Windows.Forms.ColumnHeader();
            this.chEmail = new System.Windows.Forms.ColumnHeader();
            this.chStartDate = new System.Windows.Forms.ColumnHeader();
            this.chEndDate = new System.Windows.Forms.ColumnHeader();
            this.chBirthdate = new System.Windows.Forms.ColumnHeader();
            this.chContractType = new System.Windows.Forms.ColumnHeader();
            this.chHourlyWage = new System.Windows.Forms.ColumnHeader();
            this.chAddress = new System.Windows.Forms.ColumnHeader();
            this.chDepartureReason = new System.Windows.Forms.ColumnHeader();
            this.chShiftsPerWeek = new System.Windows.Forms.ColumnHeader();
            this.chRole = new System.Windows.Forms.ColumnHeader();
            this.chId = new System.Windows.Forms.ColumnHeader();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShifts
            // 
            this.btnShifts.Location = new System.Drawing.Point(969, 509);
            this.btnShifts.Name = "btnShifts";
            this.btnShifts.Size = new System.Drawing.Size(267, 49);
            this.btnShifts.TabIndex = 20;
            this.btnShifts.Text = "View Upcoming Shifts of Employee";
            this.btnShifts.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(969, 395);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(267, 49);
            this.btnRemove.TabIndex = 19;
            this.btnRemove.Text = "Remove Employee";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(969, 261);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(267, 49);
            this.btnView.TabIndex = 17;
            this.btnView.Text = "View Employee Details";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(969, 197);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(267, 49);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add Employee";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbID);
            this.groupBox1.Location = new System.Drawing.Point(969, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 125);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search for employees";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(79, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 29);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Employee ID:";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(7, 53);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(254, 27);
            this.tbID.TabIndex = 0;
            // 
            // lvEmployees
            // 
            this.lvEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFirstName,
            this.chLastName,
            this.chBSN,
            this.chEmail,
            this.chStartDate,
            this.chEndDate,
            this.chBirthdate,
            this.chContractType,
            this.chHourlyWage,
            this.chAddress,
            this.chDepartureReason,
            this.chShiftsPerWeek,
            this.chRole,
            this.chId});
            this.lvEmployees.FullRowSelect = true;
            this.lvEmployees.HideSelection = false;
            this.lvEmployees.Location = new System.Drawing.Point(11, 21);
            this.lvEmployees.Name = "lvEmployees";
            this.lvEmployees.Size = new System.Drawing.Size(951, 551);
            this.lvEmployees.TabIndex = 21;
            this.lvEmployees.UseCompatibleStateImageBehavior = false;
            this.lvEmployees.View = System.Windows.Forms.View.Details;
            // 
            // chFirstName
            // 
            this.chFirstName.Text = "First name";
            this.chFirstName.Width = 80;
            // 
            // chLastName
            // 
            this.chLastName.Text = "Last name";
            this.chLastName.Width = 80;
            // 
            // chBSN
            // 
            this.chBSN.Text = "BSN";
            this.chBSN.Width = 40;
            // 
            // chEmail
            // 
            this.chEmail.Text = "Email";
            this.chEmail.Width = 70;
            // 
            // chStartDate
            // 
            this.chStartDate.Text = "Start date";
            this.chStartDate.Width = 70;
            // 
            // chEndDate
            // 
            this.chEndDate.Text = "End date";
            this.chEndDate.Width = 70;
            // 
            // chBirthdate
            // 
            this.chBirthdate.Text = "Birthdate";
            this.chBirthdate.Width = 70;
            // 
            // chContractType
            // 
            this.chContractType.Text = "Contract type";
            this.chContractType.Width = 70;
            // 
            // chHourlyWage
            // 
            this.chHourlyWage.Text = "Hourly wage";
            this.chHourlyWage.Width = 70;
            // 
            // chAddress
            // 
            this.chAddress.Text = "Address";
            this.chAddress.Width = 70;
            // 
            // chDepartureReason
            // 
            this.chDepartureReason.Text = "Departure reason";
            this.chDepartureReason.Width = 70;
            // 
            // chShiftsPerWeek
            // 
            this.chShiftsPerWeek.Text = "Shifts per week";
            this.chShiftsPerWeek.Width = 70;
            // 
            // chRole
            // 
            this.chRole.Text = "Role";
            this.chRole.Width = 70;
            // 
            // chId
            // 
            this.chId.Text = "Id";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1032, 571);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(146, 29);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Back to menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(969, 328);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(267, 49);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update Employee Details";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Employee_Administration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 631);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lvEmployees);
            this.Controls.Add(this.btnShifts);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Name = "Employee_Administration";
            this.Text = "Employee Administration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShifts;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.ListView lvEmployees;
        private System.Windows.Forms.ColumnHeader chFirstName;
        private System.Windows.Forms.ColumnHeader chLastName;
        private System.Windows.Forms.ColumnHeader chBSN;
        private System.Windows.Forms.ColumnHeader chEmail;
        private System.Windows.Forms.ColumnHeader chStartDate;
        private System.Windows.Forms.ColumnHeader chEndDate;
        private System.Windows.Forms.ColumnHeader chBirthdate;
        private System.Windows.Forms.ColumnHeader chContractType;
        private System.Windows.Forms.ColumnHeader chHourlyWage;
        private System.Windows.Forms.ColumnHeader chAddress;
        private System.Windows.Forms.ColumnHeader chDepartureReason;
        private System.Windows.Forms.ColumnHeader chShiftsPerWeek;
        private System.Windows.Forms.ColumnHeader chRole;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.Button btnUpdate;
    }
}