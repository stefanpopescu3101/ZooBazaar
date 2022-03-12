using System;
using System.Collections.Generic;
using System.Text;
using Class_Library.Data_Access;
using MySqlConnector;

namespace Class_Library.Data_Access
{
    public class HabitatDb : DBMediator
    {
        public HabitatDb() : base()
        {}

        public int AddNewHabitat(Habitat h)
        {
            try
            {
                var sql = "INSERT INTO Habitat (title, habitat_type, capacity, responsible_employee_id, required_employees_count) VALUES (@title, @type, @capacity, @responsibleEmployeeId, @requiredEmployeesCount);";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@title", h.Title);
                cmd.Parameters.AddWithValue("@type", (int)h.Type);
                cmd.Parameters.AddWithValue("@capacity", h.Capacity);
                if (h.ResponsibleEmployeeId != null)
                {
                    cmd.Parameters.AddWithValue("@responsibleEmployeeId", h.ResponsibleEmployeeId);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@responsibleEmployeeId", null);
                }
                cmd.Parameters.AddWithValue("@requiredEmployeesCount", h.RequiredEmployeesCount);

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

        public bool RemoveHabitat(Habitat habitat)
        {
            try
            {
                var sql = "DELETE FROM `habitat` WHERE id = @id;";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@id", habitat.ID);
                this.connection.Open();
                var affectedRows = cmd.ExecuteNonQuery();

                return (affectedRows > 0);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool UpdateHabitat(Habitat oldHabitat, Habitat newHabitat)
        {
            throw new NotImplementedException();
        }

        public void AddAnimal(Habitat habitat, Animal animal)
        {
            throw new NotImplementedException();
        }

        public void RemoveAnimal(Habitat habitat, Animal animal)
        {
            throw new NotImplementedException();
        }

        public void UpdateResponsibleEmployee(Habitat habitat, Employee responsibleEmployee)
        {
            throw new NotImplementedException();
        }

        public List<Habitat> LoadHabitats()
        {
            try
            {
                var sql = "SELECT `id`, `title`, `habitat_type`, `capacity`, `responsible_employee_id`, `required_employees_count` FROM `habitat`;";
                var cmd = new MySqlCommand(sql, this.connection);

                this.connection.Open();
                var dr = cmd.ExecuteReader();
                var habitats = new List<Habitat>();
                while (dr.Read())
                {
                    var id = Convert.ToInt32(dr[0]);
                    var title = Convert.ToString(dr[1]);
                    var type = (HabitatType)(Convert.ToInt32(dr[2]));
                    var capacity = Convert.ToInt32(dr[3]);
                    int? responsibleEmployeeId = null;
                    try
                    {
                        responsibleEmployeeId = Convert.ToInt32(dr[4]);

                    }
                    catch (Exception e)
                    {
                        
                    }

                    var requiredEmployeesCount = Convert.ToInt32(dr[5]);
                    habitats.Add(new Habitat(id, title, type, capacity, null, responsibleEmployeeId, requiredEmployeesCount));
                }

                return habitats;
            }
            finally
            {
                this.connection.Close();
            }
        }

        // used for tests
        public void DeleteEntry(int id)
        {
            try
            {
                var sql = "DELETE FROM `habitat` WHERE id = @id;";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@id", id);
                this.connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
