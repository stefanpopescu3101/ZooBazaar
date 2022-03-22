using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace Class_Library.Data_Access {
    class AnimalDb : DBMediator {
        public AnimalDb() : base() { }

        public int AddNewAnimal(Animal a) {
            try {
                var sql = "insert into animals_zoo (Name, Species, Sex, Birthday, IsInZoo, Health, ArrivalDate, DepartureDate) values (@name, @species, @sex, @birthday, @isinzoo, @health, @arrivaldate, @departuredate)";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@name", a.name);
                cmd.Parameters.AddWithValue("@species", a.species);
                cmd.Parameters.AddWithValue("@sex", a.sex.ToString());
                cmd.Parameters.AddWithValue("@birthday", a.birthday);
                cmd.Parameters.AddWithValue("@isinzoo", a.isInZoo);
                cmd.Parameters.AddWithValue("@health", a.health);
                cmd.Parameters.AddWithValue("@arrivaldate", a.arrivalDate);
                cmd.Parameters.AddWithValue("@departuredate", a.departureDate);

                connection.Open();
                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;
                return (int)id;
            } finally {
                connection.Close();
            }
        }

        public List<Animal> GetAllAnimals() {
            try {
                var sql = "select * from animals_zoo";
                var cmd = new MySqlCommand(sql, this.connection);

                connection.Open();
                var data = cmd.ExecuteReader();
                int? habitatId = null;
                List<Animal> animals = new List<Animal>();
                while (data.Read()) {
                    try
                    {
                        habitatId = Convert.ToInt32(data[9]);
                    }
                    catch (Exception e)
                    {
                        habitatId = null;
                    }
                    animals.Add(
                        new Animal(
                            data.GetInt32(0),
                            data.GetString(1),
                            data.GetString(2),
                            Enum.Parse<Animal.Sex>(data.GetString(3)),
                            data.GetDateTime(4),
                            habitatId,
                            data.GetBoolean(5),
                            data.GetString(6),
                            data.GetDateTime(7),
                            data.GetDateTime(8)
                            )
                        );
                }
                return animals;
            } finally {
                connection.Close();
            }     
        }

        internal bool RemoveHabitat(List<Animal> animals, int habitatId)
        {
            try
            {
                var sql = "UPDATE `animals_zoo` SET `HabitatID`= @null WHERE `HabitatID`= @habitatId";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@habitatId", habitatId);
                cmd.Parameters.AddWithValue("@null", DBNull.Value);

                connection.Open();
                var affectedRows = cmd.ExecuteNonQuery();

                return affectedRows == animals.Count;
            }
            finally
            {
                connection.Close();
            }
        }

        internal bool UpdateAssignedHabitat(Animal a, int? newHabitatId)
        {
            try
            {
                var sql = "update animals_zoo set HabitatID = @habitatId where ID = @id";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@id", a.ID);
                cmd.Parameters.AddWithValue("@habitatId", newHabitatId);

                connection.Open();
                var affectedRows = cmd.ExecuteNonQuery();

                return (affectedRows == 1);

            }
            finally
            {
                connection.Close();
            }
        }


        public void UpdateAnimal(Animal a) {
            try {
                var sql = "update animals_zoo set Name = @name, Species = @species, Sex = @sex, Birthday = @birthday, Health = @health where ID = @id";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@name", a.name);
                cmd.Parameters.AddWithValue("@species", a.species);
                cmd.Parameters.AddWithValue("@sex", a.sex.ToString());
                cmd.Parameters.AddWithValue("@birthday", a.birthday);
                cmd.Parameters.AddWithValue("@health", a.health);
                cmd.Parameters.AddWithValue("@id", a.ID);

                connection.Open();
                cmd.ExecuteNonQuery();             
            } finally {
                connection.Close();
            }
        }

        public void UpdateStatus(Animal a) {
            try {
                var sql = "update animals_zoo set DepartureDate = @departuredate, IsInZoo = @isinzoo, Health = @health where ID = @id";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@departuredate", a.departureDate);
                cmd.Parameters.AddWithValue("@isinzoo", a.isInZoo);
                cmd.Parameters.AddWithValue("@health", a.health);
                cmd.Parameters.AddWithValue("@id", a.ID);

                connection.Open();
                cmd.ExecuteNonQuery();
            } finally {
                connection.Close();
            }
        }
    }
}
