using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
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

        public List<Animal> GetAnimalsOfSpecifiedHabitatId(int id)
        {
            var output = new List<Animal>();

            output = Animals.FindAll(animal => animal.habitat == id);

            return output;
        }

        public List<Animal> GetAnimalsWithoutHabitat()
        {
            var output = new List<Animal>();

            output = Animals.FindAll(animal => animal.habitat is null);

            return output;
        }

        public void UpdateAssignedHabitat(Animal animal, int? newHabitatId)
        {
            if (animal is null)
            {
                throw new ArgumentNullException("Invalid animal");
            }

            if (!animalDb.UpdateAssignedHabitat(animal, newHabitatId))
            {
                throw new ExternalException("Couldn't update db.");
            }

            Animals.First(a => a.Equals(animal)).habitat = newHabitatId;
        }

        // this method will be invoked, when habitat gets deleted, to prevent animals to be assigned to habitat, that doesn't exist anymore
        public void RemoveHabitat(int? habitatId)
        {
            if (habitatId is null)
            {
                throw new ArgumentNullException("Invalid habitat id.");
            }
            var animals = Animals.FindAll(a => a.habitat == habitatId);
            foreach (var animal in animals)
            {
                animal.habitat = null;
            }
            if (animals.Count > 0)
            {
                var isHabitatRemoved = animalDb.RemoveHabitat(animals, (int)habitatId);
                if (!isHabitatRemoved)
                {
                    throw new Exception("Error while updating db.");
                }
            }
        }
    }
}
