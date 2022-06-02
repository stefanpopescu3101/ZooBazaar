namespace ZooBazaar_SAIA_Desktop.Tickets_Management_Forms
{
    partial class Ticket_Shop
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblAdults = new System.Windows.Forms.Label();
            this.lblChildren = new System.Windows.Forms.Label();
            this.lblSpecial = new System.Windows.Forms.Label();
            this.tbAdults = new System.Windows.Forms.TextBox();
            this.tbChildren = new System.Windows.Forms.TextBox();
            this.checkbSpecial = new System.Windows.Forms.CheckBox();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCurrentPrices = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(289, 388);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(115, 36);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(435, 388);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(682, 149);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(106, 29);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update prices";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblAdults
            // 
            this.lblAdults.AutoSize = true;
            this.lblAdults.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAdults.Location = new System.Drawing.Point(288, 218);
            this.lblAdults.Name = "lblAdults";
            this.lblAdults.Size = new System.Drawing.Size(82, 21);
            this.lblAdults.TabIndex = 3;
            this.lblAdults.Text = "Adult(qty):";
            // 
            // lblChildren
            // 
            this.lblChildren.AutoSize = true;
            this.lblChildren.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChildren.Location = new System.Drawing.Point(289, 262);
            this.lblChildren.Name = "lblChildren";
            this.lblChildren.Size = new System.Drawing.Size(104, 21);
            this.lblChildren.TabIndex = 4;
            this.lblChildren.Text = "Children(qty):";
            // 
            // lblSpecial
            // 
            this.lblSpecial.AutoSize = true;
            this.lblSpecial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSpecial.Location = new System.Drawing.Point(289, 309);
            this.lblSpecial.Name = "lblSpecial";
            this.lblSpecial.Size = new System.Drawing.Size(103, 21);
            this.lblSpecial.TabIndex = 5;
            this.lblSpecial.Text = "Special ticket:";
            // 
            // tbAdults
            // 
            this.tbAdults.Location = new System.Drawing.Point(425, 220);
            this.tbAdults.MaximumSize = new System.Drawing.Size(123, 23);
            this.tbAdults.MinimumSize = new System.Drawing.Size(123, 23);
            this.tbAdults.Name = "tbAdults";
            this.tbAdults.Size = new System.Drawing.Size(123, 23);
            this.tbAdults.TabIndex = 6;
            this.tbAdults.Text = "0";
            // 
            // tbChildren
            // 
            this.tbChildren.Location = new System.Drawing.Point(425, 260);
            this.tbChildren.MaximumSize = new System.Drawing.Size(123, 23);
            this.tbChildren.MinimumSize = new System.Drawing.Size(123, 23);
            this.tbChildren.Name = "tbChildren";
            this.tbChildren.Size = new System.Drawing.Size(123, 23);
            this.tbChildren.TabIndex = 6;
            this.tbChildren.Text = "0";
            // 
            // checkbSpecial
            // 
            this.checkbSpecial.AutoSize = true;
            this.checkbSpecial.Location = new System.Drawing.Point(426, 315);
            this.checkbSpecial.Name = "checkbSpecial";
            this.checkbSpecial.Size = new System.Drawing.Size(15, 14);
            this.checkbSpecial.TabIndex = 7;
            this.checkbSpecial.UseVisualStyleBackColor = true;
            // 
            // dpDate
            // 
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDate.Location = new System.Drawing.Point(425, 177);
            this.dpDate.MinDate = new System.DateTime(2022, 6, 2, 0, 0, 0, 0);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(123, 23);
            this.dpDate.TabIndex = 8;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDate.Location = new System.Drawing.Point(288, 179);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 21);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date:";
            // 
            // lblCurrentPrices
            // 
            this.lblCurrentPrices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentPrices.Location = new System.Drawing.Point(624, 23);
            this.lblCurrentPrices.Name = "lblCurrentPrices";
            this.lblCurrentPrices.Size = new System.Drawing.Size(164, 108);
            this.lblCurrentPrices.TabIndex = 9;
            this.lblCurrentPrices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ticket_Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCurrentPrices);
            this.Controls.Add(this.dpDate);
            this.Controls.Add(this.checkbSpecial);
            this.Controls.Add(this.tbChildren);
            this.Controls.Add(this.tbAdults);
            this.Controls.Add(this.lblSpecial);
            this.Controls.Add(this.lblChildren);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblAdults);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "Ticket_Shop";
            this.Text = "Ticket_Shop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblAdults;
        private System.Windows.Forms.Label lblChildren;
        private System.Windows.Forms.Label lblSpecial;
        private System.Windows.Forms.TextBox tbAdults;
        private System.Windows.Forms.TextBox tbChildren;
        private System.Windows.Forms.CheckBox checkbSpecial;
        private System.Windows.Forms.DateTimePicker dpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCurrentPrices;
    }
}