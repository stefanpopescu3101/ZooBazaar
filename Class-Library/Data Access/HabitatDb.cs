using System;
using System.Collections.Generic;
using System.Text;
using Class_Library.Data_Access;
using Class_Library.Object_Classes.Enums;
using MySqlConnector;

namespace Class_Library.Data_Access
{
    public class HabitatDb : DBMediator
    {
        public HabitatDb() : base()
        {}

        // adds newly created habitat to db and assigns id to this instance
        public int AddNewHabitat(Habitat h)
        {
            try
            {
                var sql = "INSERT INTO Habitat (title, habitat_type, capacity, responsible_employee_id, required_employees_count, feeding_time) VALUES (@title, @type, @capacity, @responsibleEmployeeId, @requiredEmployeesCount, @feedingTime);";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@title", h.Title);
                cmd.Parameters.AddWithValue("@type", (int)h.Type);
                cmd.Parameters.AddWithValue("@capacity", h.Capacity);
                cmd.Parameters.AddWithValue("@feedingTime", (int)h.FeedingTime);
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
            try
            {
                var sql = "UPDATE `habitat` SET `title` = @title, `habitat_type` = @habitatType, `capacity` = @capacity, `responsible_employee_id` = @responsibleEmployeeId, `required_employees_count` = @requiredEmployeesCount, `feeding_time` = @feedingTime" +
                          "  WHERE `id` = @id;";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@id", oldHabitat.ID);
                cmd.Parameters.AddWithValue("@title", newHabitat.Title);
                cmd.Parameters.AddWithValue("@habitatType", (int)newHabitat.Type);
                cmd.Parameters.AddWithValue("@capacity", newHabitat.Capacity);
                cmd.Parameters.AddWithValue("@responsibleEmployeeId", newHabitat.ResponsibleEmployeeId);
                cmd.Parameters.AddWithValue("@requiredEmployeesCount", newHabitat.RequiredEmployeesCount);
                cmd.Parameters.AddWithValue("@feedingTime", newHabitat.FeedingTime);
                this.connection.Open();
                var affectedRows = cmd.ExecuteNonQuery();

                return (affectedRows == 1);
            }
            finally
            {
                this.connection.Close();
            }
        }

        // subject to be removed
        public void AddAnimal(Habitat habitat, Animal animal)
        {
            throw new NotImplementedException();
        }

        // subject to be removed
        public void RemoveAnimal(Habitat habitat, Animal animal)
        {
            throw new NotImplementedException();
        }



        public bool UpdateResponsibleEmployee(Habitat habitat, Employee responsibleEmployee)
        {
            try
            {
                var sql = "UPDATE `habitat` SET responsible_employee_id = @responsibleEmployeeId WHERE `id` = @habitatId;";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@responsibleEmployeeId", responsibleEmployee.Id);
                cmd.Parameters.AddWithValue("@habitatId", habitat.ID);
                this.connection.Open();
                var affectedRows = cmd.ExecuteNonQuery();

                return (affectedRows == 1);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public List<Habitat> LoadHabitats()
        {
            try
            {
                var sql = "SELECT `id`, `title`, `habitat_type`, `capacity`, `responsible_employee_id`, `required_employees_count`, `feeding_time` FROM `habitat`;";
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
                    var feedingTime = (FeedingTime)(Convert.ToInt32(dr[6]));
                    try
                    {
                        responsibleEmployeeId = Convert.ToInt32(dr[4]);

                    }
                    catch (Exception e)
                    {
                        // do nothing
                    }

                    var requiredEmployeesCount = Convert.ToInt32(dr[5]);
                    habitats.Add(new Habitat(id, title, type, capacity, null, responsibleEmployeeId, requiredEmployeesCount, feedingTime));
                }

                return habitats;
            }
            finally
            {
                this.connection.Close();
            }
        }

        // used for tests
        public int AddFullHabitat(Habitat h)
        {
            try
            {
                var sql = "INSERT INTO Habitat (id ,title, habitat_type, capacity, responsible_employee_id, required_employees_count, feeding_time) VALUES (@id, @title, @type, @capacity, @responsibleEmployeeId, @requiredEmployeesCount, @feedingTime);";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@id", h.ID);
                cmd.Parameters.AddWithValue("@title", h.Title);
                cmd.Parameters.AddWithValue("@type", (int)h.Type);
                cmd.Parameters.AddWithValue("@capacity", h.Capacity);
                cmd.Parameters.AddWithValue("@feedingTime", (int)h.FeedingTime);
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

        public Habitat LoadEntry(int entryId)
        {
            int id = 0;
            string title = string.Empty;
            HabitatType type = HabitatType.Default;
            int capacity = 0;
            int? responsibleEmployeeId = null;
            int requiredEmployeesCount = 0;
            FeedingTime feedingTime = 0;

            try
            {
                var sql = "SELECT *  FROM `habitat` WHERE id = @id;";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@id", entryId);
                this.connection.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    id = Convert.ToInt32(dr[0]);
                    title = Convert.ToString(dr[1]);
                    type = (HabitatType) (Convert.ToInt32(dr[2]));
                    capacity = Convert.ToInt32(dr[3]);
                    feedingTime = (FeedingTime) (Convert.ToInt32(dr[6]));
                    try
                    {
                        responsibleEmployeeId = Convert.ToInt32(dr[4]);

                    }
                    catch (Exception e)
                    {
                        // do nothing
                    }

                    requiredEmployeesCount = Convert.ToInt32(dr[5]);
                }
            }

            finally
            {
                this.connection.Close();
            }

            return new Habitat(id, title, type, capacity, null, responsibleEmployeeId, requiredEmployeesCount, feedingTime);
        }

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
