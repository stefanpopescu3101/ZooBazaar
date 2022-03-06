
namespace ZooBazaar_SAIA_Desktop {
    partial class Assign_Habitat {
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbHabitat = new System.Windows.Forms.ComboBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a habitat to move this animal into";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Habitat:";
            // 
            // cbHabitat
            // 
            this.cbHabitat.FormattingEnabled = true;
            this.cbHabitat.Location = new System.Drawing.Point(26, 104);
            this.cbHabitat.Name = "cbHabitat";
            this.cbHabitat.Size = new System.Drawing.Size(277, 28);
            this.cbHabitat.TabIndex = 2;
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(71, 162);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(185, 29);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Text = "Move animal";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // Assign_Habitat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 258);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.cbHabitat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Assign_Habitat";
            this.Text = "Assign Habitat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbHabitat;
        private System.Windows.Forms.Button btnAssign;
    }
}