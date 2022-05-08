using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZooBazaar_SAIA_Desktop {
    public partial class Employee_Scheduling : Form {
        public Employee_Scheduling() {
            InitializeComponent();
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
        }
    }
}
