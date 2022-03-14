using System;
using System.Collections.Generic;
using System.Text;
using Class_Library.Data_Access;

namespace Class_Library.Managers {
    public class AnimalManager {
        private readonly AnimalDb animalDb;
        public List<Animal> Animals { get; set; }

        public AnimalManager() {
            animalDb = new AnimalDb();
            Animals = new List<Animal>();
            GetAllAnimals();
        }

        public void GetAllAnimals() {
            
        }

        public void AddAnimal(Animal a) {

            int newID = animalDb.AddNewAnimal(a);
        }
    }
}
