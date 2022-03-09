using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace Class_Library.Data_Access
{
    internal class HabitatDb : DBMediator
    {
        public HabitatDb() : base()
        {}

        public bool AddHabitat(Habitat h)
        {
            try
            {
                var sql = "INSERT INTO Habitat (Title) VALUES (@title);";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@title", h.Title);
                this.connection.Open();

                var affectedRows = cmd.ExecuteNonQuery();
                return (affectedRows == 1);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }

    public class Habitat
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }

    public class HabitatManager
    {
        private readonly HabitatDb habitatDb;
        public List<Habitat> Habitats { get; set; }

        public HabitatManager()
        {
            habitatDb = new HabitatDb();
            Habitats = new List<Habitat>();
        }

        public void AddHabitat(Habitat habitat)
        {
            habitatDb.AddHabitat(habitat);
        }

        public void Test()
        {
            habitatDb.AddHabitat(new Habitat {Title = "Test case"});
        }
    }

}
