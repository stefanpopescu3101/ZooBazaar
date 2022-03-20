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
        }

        public void GetAllAnimals() {
            Animals = animalDb.GetAllAnimals();
        }

        public int AddAnimal(Animal a) {
            int newID = animalDb.AddNewAnimal(a);
            return newID;
        }

        public void UpdateAnimal(Animal a) {
            animalDb.UpdateAnimal(a);
        }

        public void RemoveAnimal(Animal a) {
            animalDb.UpdateStatus(a);
        }
    }
}
