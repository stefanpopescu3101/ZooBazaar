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

                this.connection.Open();
                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;
                return (int)id;
            } finally {
                this.connection.Close();
            }
        }

        //public List<Animal> GetAllAnimals() {

        //}
    }
}
