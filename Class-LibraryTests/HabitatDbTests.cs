using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Class_Library;
using Class_Library.Data_Access;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Class_LibraryTests
{
    [TestClass]
    public class HabitatDbTests
    {
        [TestMethod]
        public void AddHabitat_StoreNewlyCreatedHabitatWithoutId_HabitatAddedToTheDB()
        {
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 2, 5);
            var habitatDb = new HabitatDb();

            var actual = habitatDb.AddNewHabitat(habitat);
            var expected = actual > 0;

            //remove the test database entry
            habitatDb.DeleteEntry(actual);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void RemoveHabitat_StoreNewlyCreatedHabitatWithoutId_HabitatAddedToTheDB()
        {
            var habitat = new Habitat("Jungle#1", HabitatType.Arctic, 2, 5);
            var habitatDb = new HabitatDb();

            var id = habitatDb.AddNewHabitat(habitat);
            habitat.ID = id;
            var habitatRemoved = habitatDb.RemoveHabitat(habitat);

            Assert.IsTrue(id > 0);
            Assert.IsTrue(habitatRemoved);
        }

        [TestMethod]
        public void LoadHabitats_LoadAllEntriesFromDb_ShouldReturnListOf3Habitats()
        {
            var habitat1 = new Habitat("Jungle#1", HabitatType.Jungle, 2, 5);
            var habitat2 = new Habitat("Savannah#1", HabitatType.Savannah, 5, 1);
            var habitat3 = new Habitat("Swamp#1", HabitatType.Swamp, 7, 2);
            var habitats = new List<Habitat> { habitat1, habitat2, habitat3 };
            var habitatDb = new HabitatDb();
            List<int> EntryIds = new();
            foreach (var habitat in habitats)
            {
                EntryIds.Add(habitatDb.AddNewHabitat(habitat));
            }

            var dbEntries = habitatDb.LoadHabitats();
            var expected = true;
            var actual = true;
            foreach (var habitat in habitats)
            {
                if (!habitats.Contains(habitat))
                {
                    actual = false;
                }
            }

            
            // remove test entries
            foreach (var entryId in EntryIds)
            {
                habitatDb.DeleteEntry(entryId);
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateResponsibleEmployee_UpdateResponsibleEmployeeWithAValidEmployee_ShouldReturnTrue()
        {
            var oldEmployee = new Employee(1001, "Tim", "TestUser1", "12345678", "test@test.test", DateTime.Parse("01-03-2022").ToString(), DateTime.Parse("01-03-2023").ToString(),
                DateTime.Now, "permanent", 20, "Streetname", "test", 2, "employee", "test1", "password1");
            var newEmployee = new Employee(1002, "Sue", "TestUser2", "22345678", "sue@test.test", DateTime.Parse("01-03-2022").ToString(), DateTime.Parse("01-03-2023").ToString(),
                DateTime.Now, "permanent", 20, "Streetname", "test", 2, "employee", "test1", "password1");
            var habitat = new Habitat("Arctic#2", HabitatType.Arctic, 10, null, oldEmployee.Id, 7);
            var habitatDb = new HabitatDb();
            var entryId = habitatDb.AddNewHabitat(habitat);
            habitat.ID = entryId;
            var isEntryUpdated = habitatDb.UpdateResponsibleEmployee(habitat, newEmployee);

            // remove test entry
            habitatDb.DeleteEntry(entryId);

            Assert.IsTrue(isEntryUpdated);
        }

        [TestMethod]
        public void UpdateHabitat_UpdateHabitatWithValidData_ShouldReturnTrue()
        {
            
            var oldHabitat = new Habitat(888,"Arctic#2", HabitatType.Arctic, 10, null, 911, 7);
            var newHabitat = new Habitat(888, "Savannah#8", HabitatType.Savannah, 18, null, 900, 4);
            var habitatDb = new HabitatDb();
            var entryId = habitatDb.AddFullHabitat(oldHabitat);
            oldHabitat.ID = entryId;
            var isEntryUpdated = habitatDb.UpdateHabitat(oldHabitat, newHabitat);

            var actualEntry = habitatDb.LoadEntry(entryId);
            // remove test entry
            habitatDb.DeleteEntry(entryId);

            Assert.AreEqual(888, actualEntry.ID);
            Assert.AreEqual("Savannah#8", actualEntry.Title);
            Assert.AreEqual(HabitatType.Savannah, actualEntry.Type);
            Assert.AreEqual(18, actualEntry.Capacity);
            Assert.AreEqual(900, actualEntry.ResponsibleEmployeeId);
            Assert.AreEqual(4, actualEntry.RequiredEmployeesCount);
            Assert.IsTrue(isEntryUpdated);
        }
    }
}
