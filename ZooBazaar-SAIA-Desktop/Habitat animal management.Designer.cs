namespace ZooBazaar_SAIA_Desktop
{
    partial class Habitat_animal_management
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
            this.habitatLbl = new System.Windows.Forms.Label();
            this.habitatAnimalsLb = new System.Windows.Forms.ListBox();
            this.availableAnimalsLb = new System.Windows.Forms.ListBox();
            this.habitatAnimalLbl = new System.Windows.Forms.Label();
            this.animalsLbl = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // habitatLbl
            // 
            this.habitatLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.habitatLbl.Location = new System.Drawing.Point(264, 9);
            this.habitatLbl.Name = "habitatLbl";
            this.habitatLbl.Size = new System.Drawing.Size(255, 31);
            this.habitatLbl.TabIndex = 0;
            this.habitatLbl.Text = "Habitat title";
            this.habitatLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // habitatAnimalsLb
            // 
            this.habitatAnimalsLb.FormattingEnabled = true;
            this.habitatAnimalsLb.ItemHeight = 15;
            this.habitatAnimalsLb.Location = new System.Drawing.Point(88, 115);
            this.habitatAnimalsLb.Name = "habitatAnimalsLb";
            this.habitatAnimalsLb.Size = new System.Drawing.Size(215, 244);
            this.habitatAnimalsLb.TabIndex = 1;
            this.habitatAnimalsLb.SelectedIndexChanged += new System.EventHandler(this.habitatAnimalsLb_SelectedIndexChanged);
            // 
            // availableAnimalsLb
            // 
            this.availableAnimalsLb.FormattingEnabled = true;
            this.availableAnimalsLb.ItemHeight = 15;
            this.availableAnimalsLb.Location = new System.Drawing.Point(485, 115);
            this.availableAnimalsLb.Name = "availableAnimalsLb";
            this.availableAnimalsLb.Size = new System.Drawing.Size(215, 244);
            this.availableAnimalsLb.TabIndex = 2;
            this.availableAnimalsLb.SelectedIndexChanged += new System.EventHandler(this.availableAnimalsLb_SelectedIndexChanged);
            // 
            // habitatAnimalLbl
            // 
            this.habitatAnimalLbl.AutoSize = true;
            this.habitatAnimalLbl.Location = new System.Drawing.Point(131, 77);
            this.habitatAnimalLbl.Name = "habitatAnimalLbl";
            this.habitatAnimalLbl.Size = new System.Drawing.Size(90, 15);
            this.habitatAnimalLbl.TabIndex = 3;
            this.habitatAnimalLbl.Text = "Habitat animals";
            // 
            // animalsLbl
            // 
            this.animalsLbl.AutoSize = true;
            this.animalsLbl.Location = new System.Drawing.Point(537, 77);
            this.animalsLbl.Name = "animalsLbl";
            this.animalsLbl.Size = new System.Drawing.Size(99, 15);
            this.animalsLbl.TabIndex = 0;
            this.animalsLbl.Text = "Available animals";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(350, 188);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "<-";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(350, 241);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 5;
            this.removeBtn.Text = "->";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(336, 385);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(99, 35);
            this.backBtn.TabIndex = 7;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // Habitat_animal_management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.animalsLbl);
            this.Controls.Add(this.habitatAnimalLbl);
            this.Controls.Add(this.availableAnimalsLb);
            this.Controls.Add(this.habitatAnimalsLb);
            this.Controls.Add(this.habitatLbl);
            this.Name = "Habitat_animal_management";
            this.Text = "Habitat_animal_management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label habitatLbl;
        private System.Windows.Forms.ListBox habitatAnimalsLb;
        private System.Windows.Forms.ListBox availableAnimalsLb;
        private System.Windows.Forms.Label habitatAnimalLbl;
        private System.Windows.Forms.Label animalsLbl;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button backBtn;
    }
}