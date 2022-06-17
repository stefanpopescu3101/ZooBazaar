using System;
using System.Collections.Generic;
using System.Text;
using Class_Library.Object_Classes;
using Class_Library.Object_Classes.Enums;
using MySqlConnector;

namespace Class_Library.Data_Access
{
    public class TicketDb : DBMediator
    {
        public TicketDb() : base() { }

        public void SetChildrenTicketPrice(decimal price, bool isSpecialTicket)
        {
            try
            {
                var sql = "UPDATE `ticket_prices` SET `children_ticket` = @price WHERE `special` = @isSpecialTicket;";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@isSpecialTicket", Convert.ToInt16(isSpecialTicket));
                this.connection.Open();
                var affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows == 0)
                {
                    throw new ArgumentNullException("Invalid sql parameters!");
                }
            }
            finally
            {
                this.connection.Close();
            }
        }

        public double GetDiscount(bool isSpecialTicket)
        {
            double discount = 0;
            try
            {
                var sql = "SELECT `discount` FROM `ticket_prices` WHERE `special` = @isSpecialTicket";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@isSpecialTicket", Convert.ToInt16(isSpecialTicket));
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    discount = Convert.ToDouble(dr[0]);
                }

                return discount;
            }
            finally
            {
                connection.Close();
            }
        }

        public void SetAdultTicketPrice(decimal price, bool isSpecialTicket)
        {
            try
            {
                var sql = "UPDATE `ticket_prices` SET `adult_ticket` = @price WHERE `special` = @isSpecialTicket;";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@isSpecialTicket", Convert.ToInt16(isSpecialTicket));
                this.connection.Open();
                var affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows == 0)
                {
                    throw new ArgumentNullException("Invalid sql parameters!");
                }
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void SetDiscount(double discount, bool isSpecialTicket)
        {
            try
            {
                var sql = "UPDATE `ticket_prices` SET `discount` = @discount WHERE `special` = @isSpecialTicket;";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@isSpecialTicket", Convert.ToInt16(isSpecialTicket));
                this.connection.Open();
                var affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows == 0)
                {
                    throw new ArgumentNullException("Invalid sql parameters!");
                }
            }
            finally
            {
                this.connection.Close();
            }
        }

        public decimal GetRegularAdultTicketPrice()
        {
            return GetTicketPrice(false, false);
        }

        public decimal GetRegularChildrenTicketPrice()
        {
            return GetTicketPrice(true, false);
        }

        public decimal GetSpecialAdultTicketPrice()
        {
            return GetTicketPrice(false, true);
        }

        public decimal GetSpecialChildrenTicketPrice()
        {
            return GetTicketPrice(true, true);
        }

        private decimal GetTicketPrice(bool isChildrenTicket, bool isSpecialTicket)
        {
            var sql = string.Empty;
            decimal price = 0m;
            
            if (isChildrenTicket)
            {
                sql = "SELECT `children_ticket` FROM `ticket_prices` WHERE `special` = @isSpecialTicket";
            }
            else
            {
                sql = "SELECT `adult_ticket` FROM `ticket_prices` WHERE `special` = @isSpecialTicket";
            }
            try
            {
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@isSpecialTicket", Convert.ToInt16(isSpecialTicket));
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    price = Convert.ToDecimal(dr[0]);
                }

                return price;
            }
            finally
            {
                connection.Close();
            }
        }

        public int SaveTicket(Ticket ticket)
        {
            try
            {
                var sql = "INSERT INTO `tickets_zoo` (adult_qty, children_qty, discount, price, seller, type, date) VALUES (@adult_qty, @children_qty, @discount, @price, @seller_id, @type, @date);";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@adult_qty", ticket.AdultQty);
                cmd.Parameters.AddWithValue("@children_qty", ticket.AdultQty);
                var discount = ticket.Discount;
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@price", ticket.Price);
                cmd.Parameters.AddWithValue("@seller_id", ticket.Seller.ID);
                cmd.Parameters.AddWithValue("@date", ticket.Date.Date);

                if (ticket.Type == TicketType.Special)
                {
                    cmd.Parameters.AddWithValue("@type", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@type", 0);
                }

                this.connection.Open();

                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;

                return (int)id;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public List<Ticket> GetAllTickets() {
            //Used for statistics, so some of the data from the database is not used
            try {
                var sql = "select * from tickets_zoo";
                var cmd = new MySqlCommand(sql, connection);
                connection.Open();
                var data = cmd.ExecuteReader();
                List<Ticket> tickets = new List<Ticket>();
                while (data.Read()) {
                    TicketType ticketType;
                    if (data.GetInt32(4) == 1) {
                        ticketType = TicketType.Special;
                    } else {
                        ticketType = TicketType.Regular;
                    }
                    tickets.Add(
                        new Ticket(
                            data.GetInt32(0),
                            data.GetInt32(1),
                            data.GetInt32(2),
                            data.GetDouble(5),
                            data.GetDateTime(7),
                            null,
                            ticketType
                            )
                        );
                }

                return tickets;
            }
            finally {
                connection.Close();
            }
        }

    }
}
