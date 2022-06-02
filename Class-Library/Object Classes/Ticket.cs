using System;
using System.Collections.Generic;
using System.Text;
using Class_Library.Object_Classes.Enums;

namespace Class_Library.Object_Classes
{
    public class Ticket
    {
        public int? Id { get; set; }
        public decimal Price { get; set; }
        public int AdultQty { get; set; }
        public int ChildrenQty { get; set; }
        public double Discount { get; set; }
        public DateTime Date { get; set; }
        public Employee Seller { get; set; }
        public TicketType Type { get; set; }

        public Ticket()
        {
            
        }

        public Ticket(decimal price, int adultQty, int childrenQty, double discount, DateTime date, Employee seller, TicketType type)
        {
            Price = price;
            AdultQty = adultQty;
            ChildrenQty = childrenQty;
            Discount = discount;
            Date = date;
            Seller = seller;
            Type = type;
        }

        public Ticket(int? id, decimal price, int adults, int children, double discount, DateTime date, int employeeId, TicketType ticketType)
        {
            Id = id;
            Price = price;
            AdultQty = adults;
            ChildrenQty = children;
            Discount = discount;
            Date = date;
            // employee id to employee
            // tickettype to Type
        }
    }
}
