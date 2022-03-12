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
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 2, 5);
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
            var expected = 3;
            var actual = dbEntries.Count;

            
            // remove test entries
            foreach (var entryId in EntryIds)
            {
                habitatDb.DeleteEntry(entryId);
            }

            Assert.AreEqual(expected, actual);
        }

    }
}
