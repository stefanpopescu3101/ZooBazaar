using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Class_Library;
using Class_Library.Managers;
using Class_Library.Object_Classes;
using Class_Library.Object_Classes.Enums;

namespace ZooBazaar_SAIA_Desktop.Tickets_Management_Forms
{
    public partial class Print_Ticket : Form
    {
        private Employee loggedEmployee;
        private readonly TicketManager ticketManager;
        private Ticket ticket;
        public Print_Ticket(Employee e, int adultQty, int childrenQty, double discount,DateTime date,TicketType ticketType)
        {
            InitializeComponent();
            loggedEmployee = e;
            ticketManager = new TicketManager();
            this.BackColor = Color.FromArgb(107, 206, 255);
            ticket = ticketManager.GenerateTicket(adultQty, childrenQty, discount, date, loggedEmployee, (int)ticketType);
            lblAdults.Text = ticket.AdultQty.ToString();
            if (ticket.AdultQty == 0)
            {
                lblTicketAdults.Visible = false;
            }
            else
            {
                lblTicketAdults.Visible = true;
                lblTicketAdults.Text = lblAdults.Text + " adult(s)";
            }
            lblChildren.Text = ticket.ChildrenQty.ToString();
            if (ticket.ChildrenQty == 0)
            {
                lblTicketChildren.Visible = false;
            }
            else
            {
                lblTicketChildren.Visible = true;
                lblTicketChildren.Text = lblChildren.Text + " kid(s)";
            }
            lblPrice.Text = ticket.Price.ToString() + " €";
            lblDiscount.Text = ticket.Discount.ToString() + " %";
            lblDate.Text = ticket.Date.ToShortDateString();
            lblTicketDate.Text = lblDate.Text;
            lblSeller.Text = ticket.Seller.FullName;
            lblTicketType.Text = ticket.Type.ToString();
            lblTicketTypeT.Text = lblTicketType.Text;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ticketManager.SellTicket(ticket);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
