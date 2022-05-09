using System;
using System.Collections.Generic;
using System.Xml;
using Class_Library.Managers;

namespace Class_Library.Data_Access
{
    public class HabitatManager
    {
        private readonly HabitatDb habitatDb;
        private readonly AnimalManager animalManager;
        public List<Habitat> Habitats { get; set; }

        public HabitatManager()
        {
            habitatDb = new HabitatDb();
            Habitats = new List<Habitat>();
            animalManager = new AnimalManager();
            LoadHabitats();
            LoadAnimals();
        }

        // test version, that disables loading from db
        public HabitatManager(bool test)
        {
            habitatDb = new HabitatDb();
            Habitats = new List<Habitat>();
        }

        private void LoadHabitats()
        {
            Habitats= habitatDb.LoadHabitats();
        }

        private void LoadAnimals()
        {
            animalManager.GetAllAnimals();
            foreach (var habitat in Habitats)
            {
                var animals = animalManager.GetAnimalsOfSpecifiedHabitatId(habitat.ID);
                foreach (var animal in animals)
                {
                    try
                    {
                        AddAnimal(habitat, animal.ID);
                    }
                    catch (Exception e)
                    {
                        //do nothing intentionally
                    }
                }
            }
        }


        public void AddHabitat(Habitat habitat)
        {
            if (habitat == null)
            {
                throw new ArgumentNullException("Missing habitat");
            }
            if (Habitats.Contains(habitat))
            {
                throw new ArgumentException("This habitat already exists.");
            }

            Habitats.Add(habitat);
            habitat.ID = habitatDb.AddNewHabitat(habitat);
        }

        public void RemoveHabitat(Habitat habitat)
        {
            Habitats.Remove(habitat);
            habitatDb.RemoveHabitat(habitat);
        }

        public void UpdateHabitat(Habitat oldHabitat, Habitat newHabitat)
        {
            oldHabitat.Title = newHabitat.Title;
            oldHabitat.Type = newHabitat.Type;
            oldHabitat.Capacity = newHabitat.Capacity;
            oldHabitat.RequiredEmployeesCount = newHabitat.RequiredEmployeesCount;
            oldHabitat.FeedingTime = newHabitat.FeedingTime;
            if (newHabitat.AnimalIds.Count > 0)
            {
                oldHabitat.AnimalIds = newHabitat.AnimalIds;
            }

            if (newHabitat.ResponsibleEmployeeId != null)
            {
                oldHabitat.ResponsibleEmployeeId = newHabitat.ResponsibleEmployeeId;
            }
            habitatDb.UpdateHabitat(oldHabitat, newHabitat);
        }

        public void AddAnimal(Habitat habitat, int? animalId)
        {
            if (habitat.AnimalIds.Count < habitat.Capacity)
            {
                if (animalId == null)
                {
                    throw new ArgumentNullException("Missing animal");
                }
                if (IsSpecifiedAnimalIsInHabitat(habitat, animalId))
                {
                    throw new ArgumentException("This animal is already stored in this habitat.");
                }

                if (!IsHabitatSafe(habitat, (int)animalId))
                {
                    throw new ArgumentException("This habitat is too dangerous for this animal.");
                }

                if (!IsHabitatSuitable(habitat, (int)animalId))
                {
                    throw new ArgumentException("This habitat isn't suitable for this animal.");
                }

                habitat.AnimalIds.Add((int)animalId);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Habitat is full!");
            }
        }

        /*
                 * check if animal is predator
                 * if true:
                 *  check habitat inhabitants
                 *  if empty - animal can be assigned to the habitat
                 *
                 *  if there are other predators, check if they are of the same species
                 *  if true - animal can be assigned to the habitat
                 *  else animal can't be assigned to this habitat
                 * else
                 *  check if there are predators in the habitat
                 *  animal cannot be assigned to the habitat
                 *  else animal can be assigned
                 */
        private bool IsHabitatSafe(Habitat habitat, int animalId)
        {
            var output = false;
            var animal = animalManager.GetAnimalById(animalId);
            if (animal == null)
            {
                output =  false;
            }
            if (habitat.AnimalIds.Count == 0)
            {
                output =  true;
            }

            var predatorsPresent = AreThereAnyPredators(habitat);
            if (animal.isPredator)
            {
                if (predatorsPresent)
                {
                    //   if there are other predators, check if they are of the same species
                    //   if true - animal can be assigned to the habitat
                    //   else animal can't be assigned to this habitat
                    var predator = GetPredator(habitat);
                    output = (animal.species.Equals(predator.species));
                }
            }
            else
            {
                output = !predatorsPresent;
            }

            return output;
        }

        private bool IsHabitatSuitable(Habitat habitat, int animalId)
        {
            // consider replacing with query to db for speed
            var animal = animalManager.GetAnimalById(animalId);
            if (habitat.Type == animal.animalType)
            {
                return true;
            }

            return false;
        }

        private bool AreThereAnyPredators(Habitat habitat)
        {
            foreach (var habitatAnimalId in habitat.AnimalIds)
            {
                var animal = animalManager.GetAnimalById(habitatAnimalId);
                if (animal.isPredator)
                {
                    return true;
                }
            }

            return false;
        }

        private Animal GetPredator(Habitat habitat)
        {
            foreach (var habitatAnimalId in habitat.AnimalIds)
            {
                var animal = animalManager.GetAnimalById(habitatAnimalId);
                if (animal.isPredator)
                {
                    return animal;
                }
            }

            return null;
        }

        public void RemoveAnimal(Habitat habitat, int? animalId)
        {
            if (animalId == null)
            {
                throw new ArgumentNullException("Missing animal!");
            }

            if (IsSpecifiedAnimalIsInHabitat(habitat, animalId))
            {
                habitat.AnimalIds.Remove((int)animalId);
                // habitatDb.RemoveAnimal(habitat, animal);
            }
        }

        private bool IsSpecifiedAnimalIsInHabitat(Habitat habitat, int? animalId)
        {
            if (animalId == null)
            {
                return false;
            }

            return habitat.AnimalIds.Contains((int)animalId);
        }

        public void AssignResponsibleEmployee(Habitat habitat, Employee responsibleEmployee)
        {
            if (responsibleEmployee == null)
            {
                throw new ArgumentNullException("Missing responsible employee!");
            }
            habitat.ResponsibleEmployeeId = responsibleEmployee.Id;
            habitatDb.UpdateResponsibleEmployee(habitat, responsibleEmployee);
        }

        public Habitat GetHabitatById(int id)
        {
            var output = Habitats.Find(x => x.ID == id);
            return output;
        }

    }
}