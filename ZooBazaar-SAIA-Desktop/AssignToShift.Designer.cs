
namespace ZooBazaar_SAIA_Desktop
{
    partial class AssignToShift
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
            this.lbShiftDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveFromTheShift = new System.Windows.Forms.Button();
            this.btnAddToShift = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lbPeopleInShift = new System.Windows.Forms.ListBox();
            this.lbAvailablePeople = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbShiftDate
            // 
            this.lbShiftDate.AutoSize = true;
            this.lbShiftDate.Location = new System.Drawing.Point(287, 18);
            this.lbShiftDate.Name = "lbShiftDate";
            this.lbShiftDate.Size = new System.Drawing.Size(41, 20);
            this.lbShiftDate.TabIndex = 19;
            this.lbShiftDate.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(560, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Assigned Employees";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(51, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Available Employees";
            // 
            // btnRemoveFromTheShift
            // 
            this.btnRemoveFromTheShift.Location = new System.Drawing.Point(355, 248);
            this.btnRemoveFromTheShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveFromTheShift.Name = "btnRemoveFromTheShift";
            this.btnRemoveFromTheShift.Size = new System.Drawing.Size(86, 31);
            this.btnRemoveFromTheShift.TabIndex = 16;
            this.btnRemoveFromTheShift.Text = "Remove";
            this.btnRemoveFromTheShift.UseVisualStyleBackColor = true;
            this.btnRemoveFromTheShift.Click += new System.EventHandler(this.btnRemoveFromTheShift_Click);
            // 
            // btnAddToShift
            // 
            this.btnAddToShift.Location = new System.Drawing.Point(355, 209);
            this.btnAddToShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddToShift.Name = "btnAddToShift";
            this.btnAddToShift.Size = new System.Drawing.Size(86, 31);
            this.btnAddToShift.TabIndex = 15;
            this.btnAddToShift.Text = "Assign";
            this.btnAddToShift.UseVisualStyleBackColor = true;
            this.btnAddToShift.Click += new System.EventHandler(this.btnAddToShift_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(40, 512);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(214, 31);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(40, 473);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(214, 31);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(40, 435);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(213, 27);
            this.tbSearch.TabIndex = 12;
            // 
            // lbPeopleInShift
            // 
            this.lbPeopleInShift.FormattingEnabled = true;
            this.lbPeopleInShift.ItemHeight = 20;
            this.lbPeopleInShift.Location = new System.Drawing.Point(529, 39);
            this.lbPeopleInShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbPeopleInShift.Name = "lbPeopleInShift";
            this.lbPeopleInShift.Size = new System.Drawing.Size(226, 364);
            this.lbPeopleInShift.TabIndex = 11;
            // 
            // lbAvailablePeople
            // 
            this.lbAvailablePeople.FormattingEnabled = true;
            this.lbAvailablePeople.ItemHeight = 20;
            this.lbAvailablePeople.Location = new System.Drawing.Point(40, 39);
            this.lbAvailablePeople.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbAvailablePeople.Name = "lbAvailablePeople";
            this.lbAvailablePeople.Size = new System.Drawing.Size(213, 364);
            this.lbAvailablePeople.TabIndex = 10;
            // 
            // AssignToShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 600);
            this.Controls.Add(this.lbShiftDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoveFromTheShift);
            this.Controls.Add(this.btnAddToShift);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lbPeopleInShift);
            this.Controls.Add(this.lbAvailablePeople);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AssignToShift";
            this.Text = "AssignToShift";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbShiftDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveFromTheShift;
        private System.Windows.Forms.Button btnAddToShift;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ListBox lbPeopleInShift;
        private System.Windows.Forms.ListBox lbAvailablePeople;
    }
}