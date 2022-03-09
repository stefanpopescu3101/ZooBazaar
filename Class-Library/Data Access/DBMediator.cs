using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace Class_Library.Data_Access
{
    public abstract class DBMediator
    {
        protected MySqlConnection connection;

        public DBMediator()
        {
            string connectionInfo =
                "Server=studmysql01.fhict.local;" +
                "Uid=dbi467287;" +
                "Database=dbi467287;" +
                "Pwd=prj;" +
                "SslMode=none";

            this.connection = new MySqlConnection(connectionInfo);
        }
    }
}
