using System;
using System.Collections.Generic;
using System.Text;
using Class_Library.Data_Access;
using MySqlConnector;



namespace Class_Library
{
    public class ShiftDb : DBMediator
    {

        public ShiftDb() : base()
        { }

        public bool AddNewShift(WorkShift shift)
        {
            try
            {
                connection.Open();

                var query = "INSERT INTO workshifts_zoo (employeeID, employeeName, type, Date, wageForShift, hoursWorked)" +
                "VAlUES (@employeeID, @employeeName, @type, @Date, @wageForShift, @hoursWorked)";
                var cmd = new MySqlCommand(query, this.connection);
                
                cmd.Parameters.AddWithValue("@employeeID", shift.EmployeeId);
                cmd.Parameters.AddWithValue("@employeeName", shift.EmployeeName);
                cmd.Parameters.AddWithValue("@type", shift.Type);
                cmd.Parameters.AddWithValue("@Date", shift.Date);
                cmd.Parameters.AddWithValue("@wageForShift", shift.WageForShift);
                cmd.Parameters.AddWithValue("@hoursWorked", shift.HoursWorked);


                cmd.ExecuteNonQuery();
                shift.ID = Convert.ToInt32(cmd.LastInsertedId);


                return true;
            }
            finally
            {
                this.connection.Close();
            }


            
        }



        public bool RemoveShift(WorkShift shift)
        {
            try
            {
                var query = "DELETE from workshifts_zoo WHERE id = @workshift_id";
                var cmd = new MySqlCommand(query, this.connection);

                cmd.Parameters.AddWithValue("@workshift_id", shift.ID);
                cmd.ExecuteNonQuery();


                return true;
            }
            finally
            {
                this.connection.Close();
            }
        }



        public List<WorkShift> GetAllShifts()
        {
            try
            {
                var query = "SELECT * FROM workshifts_zoo";
                var cmd = new MySqlCommand(query, this.connection);

                this.connection.Open();

                List<WorkShift> workshifts = new List<WorkShift>();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    WorkShift workshift = new WorkShift(
                    Convert.ToInt32(reader["employeeID"]),
                    reader["employeeName"].ToString(),
                    reader["Date"].ToString(),
                    (reader["type"]).ToString(),
                    Convert.ToDecimal(reader["wageForShift"]),
                    Convert.ToInt32(reader["hoursWorked"]));



                    workshift.ID = Convert.ToInt32(reader["id"]);
                    if (reader["Cancelled"].ToString() == "True") { workshift.CancelShift(); }



                    workshifts.Add(workshift);
                }
                
                return workshifts;



            }
            finally
            {
                this.connection.Close();
            }
        }


        //Method for shift cancellation
        public bool UpdateShift(WorkShift shift)
        {
            try
            {
                this.connection.Open();

                var query = "UPDATE workshifts_zoo SET Cancelled = @Cancelled WHERE id = @id";
                var cmd = new MySqlCommand(query, this.connection);


                
                cmd.Parameters.AddWithValue("@Cancelled", "True");
                cmd.Parameters.AddWithValue("@id", shift.ID);
                cmd.ExecuteNonQuery();



               
                return true;
            }
            finally
            {
                this.connection.Close();
            }
        }



        public void ResetShifts()
        {
            try
            {
                this.connection.Open();

                var query = "DELETE FROM workshifts_zoo ";
                var cmd = new MySqlCommand(query, this.connection);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool CheckShiftAvailability(int id, string date)
        {
            try
            {
                this.connection.Open();

                var query = "SELECT * from unavailability_zoo WHERE unavailableDay=@date and employee_id=@ID";
                var cmd = new MySqlCommand(query, this.connection);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@date", date);

                List<string> test = new List<string>();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    test.Add(reader["employeeId"].ToString());
                }

                if (test.Count == 0)
                {
                    this.connection.Close();
                    return true;


                }
                else
                {
                    this.connection.Close();
                    return false;
                }



            }
            finally
            {
                this.connection.Close();

            }
        }
    }
}