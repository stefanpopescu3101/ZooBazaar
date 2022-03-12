using System;
using System.Collections.Generic;

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
            // LoadHabitats();
        }

        public void LoadHabitats()
        {
            habitatDb.LoadHabitats();
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
            // habitat.ID = habitatDb.AddNewHabitat(habitat);
        }

        public void RemoveHabitat(Habitat habitat)
        {
            Habitats.Remove(habitat);
            // habitatDb.RemoveHabitat(habitat);
        }

        public void UpdateHabitat(Habitat oldHabitat, Habitat newHabitat)
        {
            oldHabitat.Title = newHabitat.Title;
            oldHabitat.Type = newHabitat.Type;
            oldHabitat.Capacity = newHabitat.Capacity;
            oldHabitat.RequiredEmployeesCount = newHabitat.RequiredEmployeesCount;
            if (newHabitat.Animals.Count > 0)
            {
                oldHabitat.Animals = newHabitat.Animals;
            }

            if (newHabitat.ResponsibleEmployeeId != null)
            {
                oldHabitat.ResponsibleEmployeeId = newHabitat.ResponsibleEmployeeId;
            }
            // habitatDb.UpdateHabitat(oldHabitat, newHabitat);
        }

        public void AddAnimal(Habitat habitat, Animal animal)
        {
            if (habitat.Animals.Count < habitat.Capacity)
            {
                if (animal == null)
                {
                    throw new ArgumentNullException("Missing animal");
                }
                else if (habitat.Animals.Contains(animal))
                {
                    throw new ArgumentException("This animal is already stored in this habitat.");
                }
                habitat.Animals.Add(animal);
                // habitatDb.AddAnimal(habitat, animal);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Habitat is full!");
            }
        }

        public void RemoveAnimal(Habitat habitat, Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException("Missing animal!");
            }
            habitat.Animals.Remove(animal);
            // habitatDb.RemoveAnimal(habitat, animal);
        }

        public void AssignResponsibleEmployee(Habitat habitat, Employee responsibleEmployee)
        {
            if (responsibleEmployee == null)
            {
                throw new ArgumentNullException("Missing responsible employee!");
            }
            habitat.ResponsibleEmployeeId = responsibleEmployee.Id;
            // habitatDb.UpdateResponsibleEmployee(habitat, responsibleEmployee);
        }

    }
}