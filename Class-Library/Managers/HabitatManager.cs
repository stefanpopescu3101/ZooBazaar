using System;
using System.Collections.Generic;
using System.Xml;
using Class_Library.Managers;

namespace Class_Library.Data_Access
{
    public class HabitatManager
    {
        private readonly HabitatDb habitatDb;
        public List<Habitat> Habitats { get; set; }

        public HabitatManager()
        {
            habitatDb = new HabitatDb();
            Habitats = new List<Habitat>();
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
            var animalManager = new AnimalManager();
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

                habitat.AnimalIds.Add((int)animalId);
                // habitatDb.AddAnimal(habitat, animal);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Habitat is full!");
            }
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