﻿using System;
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
                List<Animal> animals = new List<Animal>();
                while (data.Read()) {
                    animals.Add(
                        new Animal(
                            data.GetInt32(0),
                            data.GetString(1),
                            data.GetString(2),
                            Enum.Parse<Animal.Sex>(data.GetString(3)),
                            data.GetDateTime(4),
                            "",
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
    }
}