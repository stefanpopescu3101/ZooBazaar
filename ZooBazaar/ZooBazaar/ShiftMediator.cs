using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ZooBazaar
{
    public class ShiftMediator : DataAccess
    {
        public bool Add(WorkShift shift)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO workshifts_zoo (employeeID, employeeName, type, Date, wageForShift, hoursWorked)" +
                "VAlUES (@employeeID, @employeeName, @type, @Date, @wageForShift, @hoursWorked)";
                SqlQuery(query);
                AddWithValue("@employeeID", shift.EmployeeId);
                AddWithValue("@employeeName", shift.EmployeeName);
                AddWithValue("@type", shift.Type);
                AddWithValue("@Date", shift.Date);
                AddWithValue("@wageForShift", shift.WageForShift);
                AddWithValue("@hoursWorked", shift.HoursWorked);
                NonQueryEx();
                shift.ID = Convert.ToInt32(command.LastInsertedId);

                Close();

                return true;
            }
            else
            {
                Close();
                return false;
            }
        }



        public bool Remove(WorkShift shift)
        {
            if (ConnOpen())
            {
                query = "DELETE from workshifts_zoo WHERE id = @workshift_id";
                SqlQuery(query);
                AddWithValue("@workshift_id", shift.ID);
                NonQueryEx();



                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }



        public List<WorkShift> GetAll()
        {
            if (ConnOpen())
            {
                query = "SELECT * FROM workshifts_zoo";
                SqlQuery(query);



                List<WorkShift> workshifts = new List<WorkShift>();
                MySqlDataReader reader = command.ExecuteReader();
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
                Close();
                return workshifts;



            }
            else
            {
                Close();
                return null;
            }
        }



        //Method for shift cancellation
        public bool Update(WorkShift shift)
        {
            if (ConnOpen())
            {
                query = "UPDATE workshifts_zoo SET Cancelled = @Cancelled WHERE id = @id";



                SqlQuery(query);
                AddWithValue("@Cancelled", "True");
                AddWithValue("@id", shift.ID);
                NonQueryEx();



                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }



        public void Reset()
        {
            if (ConnOpen())
            {
                query = "DELETE FROM workshifts_zoo ";
                SqlQuery(query);
                NonQueryEx();



                Close();
            }
            else
            {
                Close();
            }
        }

        public bool CheckAvailability(int id, string date)
        {
            if (ConnOpen())
            {
                query = "SELECT * from unavailability_zoo WHERE unavailableDay=@date and employee_id=@ID";
                SqlQuery(query);

                AddWithValue("@ID", id);
                AddWithValue("@date", date);

                List<string> test = new List<string>();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    test.Add(reader["employeeId"].ToString());
                }

                if (test.Count == 0)
                {
                    Close();
                    return true;


                }
                else
                {
                    Close();
                    return false;



                }



            }
            else
            {
                Close();
                return false;

            }
        }
    }
}