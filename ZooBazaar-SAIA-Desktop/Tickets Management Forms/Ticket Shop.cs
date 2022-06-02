using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library;
using Class_Library.Data_Access;
using Class_Library.Managers;
using Class_Library.Object_Classes.Enums;

namespace ZooBazaar_SAIA_Desktop.Tickets_Management_Forms
{
    public partial class Ticket_Shop : Form
    {
        private Employee loggedEmployee;
        private readonly TicketManager ticketManager;

        public Ticket_Shop(Employee e)
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
            var discountSpecial = ticketManager.GetDiscount(TicketType.Special);
            var discountRegular = ticketManager.GetDiscount(TicketType.Regular);
            var childrenTicketRegular = ticketManager.GetPriceRegularChildrenTickets();
            var childrenTicketSpecial = ticketManager.GetPriceSpecialChildrenTickets();
            var adultTicketRegular = ticketManager.GetPriceRegularAdultsTickets();
            var adultTicketSpecial = ticketManager.GetPriceSpecialAdultsTickets();
            lblCurrentPrices.Text = $"Adult(regular) : {AddFormatSign(adultTicketRegular)} \nAdult(special) : {AddFormatSign(adultTicketSpecial)}" +
                                    $"\nChildren(regular) : {AddFormatSign(childrenTicketRegular)} \nChildren(special) : {AddFormatSign(childrenTicketSpecial)}" +
                                    $"\nDiscount(regular): {AddFormatSign(discountRegular)} \nDiscount(special): {AddFormatSign(discountSpecial)}";
        }

        private static string AddFormatSign(double discount)
        {
            var output = discount.ToString();

            if (discount > 0)
            {
                output += " %";
            }

            return output;
        }

        private static string AddFormatSign(decimal price)
        {
            var output = price.ToString();

            if (price > 0)
            {
                output += " €";
            }

            return output;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var updateTicket = new Update_Ticket_Prices(loggedEmployee);
            updateTicket.ShowDialog();
            if (updateTicket.DialogResult == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // validate data
            var ticketType = checkbSpecial.Checked ? TicketType.Special : TicketType.Regular;
            var discount = ticketManager.GetDiscount(ticketType);
            var date = dpDate.Value.Date;
            var adultQty = int.Parse(tbAdults.Text);
            var childrenQty = int.Parse(tbChildren.Text);
            if (adultQty == 0 && childrenQty == 0)
            {
                MessageBox.Show("Please check entered data!");
                return;
            }
            var printTicket = new Print_Ticket(loggedEmployee, adultQty, childrenQty, discount, date, ticketType);
            printTicket.ShowDialog();
            if (printTicket.DialogResult == DialogResult.OK)
            {
                // remove afterwards
                MessageBox.Show("Print successfull!");
            }
            else
            {
                MessageBox.Show("Print canceled!");
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(loggedEmployee);
            menu.Show();
            this.Close();
        }
    }
}
