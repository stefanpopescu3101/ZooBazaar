using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Login : Form {
        public Login() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            //Log in button is clicked
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
