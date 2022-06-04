using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library;
using Class_Library.Managers;
using Class_Library.Object_Classes.Enums;

namespace ZooBazaar_SAIA_Desktop.Tickets_Management_Forms
{
    public partial class Update_Ticket_Prices : Form
    {
    private Employee loggedEmployee;
    private readonly TicketManager ticketManager;
        public Update_Ticket_Prices(Employee e)
        {
            InitializeComponent();
            loggedEmployee = e;
            ticketManager = new TicketManager();
            FormStyleUpdater styleUpdater = new FormStyleUpdater(this);
            styleUpdater.UpdateStyle();
            LoadData();
        }

        private void LoadData()
        {
            tbAdultRegular.Text = ticketManager.GetPriceRegularAdultsTickets().ToString();
            tbAdultSpecial.Text = ticketManager.GetPriceSpecialAdultsTickets().ToString();
            tbChildrenRegular.Text = ticketManager.GetPriceRegularChildrenTickets().ToString();
            tbChildrenSpecial.Text = ticketManager.GetPriceSpecialChildrenTickets().ToString();
            tbDiscountRegular.Text = ticketManager.GetDiscount(TicketType.Regular).ToString();
            tbDiscountSpecial.Text = ticketManager.GetDiscount(TicketType.Special).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValidData())
            {
                MessageBox.Show("Data invalid!");
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            var adultRegularTicker = Decimal.Parse(tbAdultRegular.Text);
            var adultSpecialTicker = Decimal.Parse(tbAdultSpecial.Text);
            var childrenRegularTicker = Decimal.Parse(tbChildrenRegular.Text);
            var childrenSpecialTicker = Decimal.Parse(tbChildrenSpecial.Text);
            var discountRegular = Double.Parse(tbDiscountRegular.Text);
            var discountSpecial = Double.Parse(tbDiscountSpecial.Text);


            ticketManager.SetPriceAdultTickets(adultRegularTicker, TicketType.Regular);
            ticketManager.SetPriceAdultTickets(adultSpecialTicker, TicketType.Special);
            ticketManager.SetPriceChildrenTickets(childrenRegularTicker, TicketType.Regular);
            ticketManager.SetPriceChildrenTickets(childrenSpecialTicker, TicketType.Special);
            ticketManager.SetDiscount(discountRegular, TicketType.Regular);
            ticketManager.SetDiscount(discountSpecial, TicketType.Special);
            MessageBox.Show("Prices successfully updated!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidData()
        {
            if (Decimal.TryParse(tbAdultRegular.Text, out decimal adultTicketRegular))
            {
                if (adultTicketRegular < 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (Decimal.TryParse(tbAdultSpecial.Text, out decimal adultTicketSpecial))
            {
                if (adultTicketSpecial < 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (Decimal.TryParse(tbChildrenRegular.Text, out decimal childrenTicketRegular))
            {
                if (childrenTicketRegular < 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (Decimal.TryParse(tbChildrenSpecial.Text, out decimal childrenTicketSpecial))
            {
                if (childrenTicketSpecial < 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (Double.TryParse(tbDiscountRegular.Text, out double regularDiscount))
            {
                if (regularDiscount < 0 || regularDiscount > 100)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (Double.TryParse(tbDiscountSpecial.Text, out double specialDiscount))
            {
                if (specialDiscount < 0 || specialDiscount > 100)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
