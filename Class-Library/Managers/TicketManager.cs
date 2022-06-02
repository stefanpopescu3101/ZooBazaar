using System;
using System.Collections.Generic;
using System.Text;
using Class_Library.Data_Access;
using Class_Library.Object_Classes;
using Class_Library.Object_Classes.Enums;

namespace Class_Library.Managers
{
    public class TicketManager
    {
        private readonly TicketDb ticketDb;
        public TicketManager()
        {
            ticketDb = new TicketDb();
        }

        public double GetDiscount(TicketType ticketType)
        {
            bool isSpecialTicket = (ticketType == TicketType.Special);
            return ticketDb.GetDiscount(isSpecialTicket);
        }

        public void SetDiscount(double discount, TicketType ticketType)
        {
            bool isSpecialTicket = (ticketType == TicketType.Special);
            ticketDb.SetDiscount(discount, isSpecialTicket);
        }

        public decimal GetPriceRegularAdultsTickets()
        {
            return ticketDb.GetRegularAdultTicketPrice();
        }

        public decimal GetPriceSpecialAdultsTickets()
        {
            return ticketDb.GetSpecialAdultTicketPrice();
        }

        public decimal GetPriceRegularChildrenTickets()
        {
            return ticketDb.GetRegularChildrenTicketPrice();
        }

        public decimal GetPriceSpecialChildrenTickets()
        {
            return ticketDb.GetSpecialChildrenTicketPrice();
        }

        public void SetPriceAdultTickets(decimal price, TicketType ticketType)
        {
            bool isSpecialTicket = (ticketType == TicketType.Special);
            ticketDb.SetAdultTicketPrice(price, isSpecialTicket);
        }

        public void SetPriceChildrenTickets(decimal price, TicketType ticketType)
        {
            bool isSpecialTicket = (ticketType == TicketType.Special);
            ticketDb.SetChildrenTicketPrice(price, isSpecialTicket);
        }

        // think of input data
        public Ticket GenerateTicket(int adultQty, int childrenQty, double discount, DateTime date, Employee seller, int ticketType)
        {
            var type = (TicketType) ticketType;
            var price = CalculatePrice(adultQty, childrenQty, type, discount);
            return new Ticket(price, adultQty, childrenQty, discount, date, seller, type);
        }

        //private string GenerateDescription(int adultQty, int childrenQty, DateTime date, TicketType ticketType)
        //{
        //    var ticketDescription = string.Empty;

        //    return ticketDescription;
        //}

        private decimal CalculatePrice(int adultQty, int childrenQty, TicketType ticketType,  double discount)
        {
            decimal adultTicketPrice = 0m;
            decimal childrenTicketPrice = 0m;
            decimal finalPrice = 0m;

            if (ticketType == TicketType.Regular)
            {
                adultTicketPrice = ticketDb.GetRegularAdultTicketPrice();
                childrenTicketPrice = ticketDb.GetRegularChildrenTicketPrice();
                finalPrice = (adultTicketPrice * adultQty + childrenTicketPrice * childrenQty) * (1 - (decimal)(discount / 100));
            }
            else if (ticketType == TicketType.Special)
            {
                adultTicketPrice = ticketDb.GetSpecialAdultTicketPrice();
                childrenTicketPrice = ticketDb.GetSpecialChildrenTicketPrice();
                finalPrice = (adultTicketPrice * adultQty + childrenTicketPrice * childrenQty) * (1 - (decimal)discount / 100);
            }
            else
            {
                throw new ArgumentException("Invalid ticket type!");
            }

            return finalPrice;
        }

        public void SellTicket(Ticket ticket)
        {
            ticket.Id = ticketDb.SaveTicket(ticket);
        }
    }
}
