using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace ZooBazaar_SAIA_Desktop {
    public class FormStyleUpdater {
        private Form form;
        public FormStyleUpdater(Form currentForm) {
            form = currentForm;
        }

        //Use this function to update the style any time a form is created
        public void UpdateStyle() {
            form.BackColor = Color.FromArgb(107, 206, 255);
            UpdateStyleRecursive(form.Controls);
        }
        private void UpdateStyleRecursive(ControlCollection controls) {
            foreach (Control control in controls) {
                if (control.Controls != null) //Check if there are nested controls
                    UpdateStyleRecursive(control.Controls);
                //These are the style updates:
                control.Font = new Font("Franklin Gothic Medium", 10);
                if (control is Button) {
                    control.BackColor = Color.FromArgb(23,103,179);
                    control.ForeColor = Color.White;
                }
            }
        }
    }
}
