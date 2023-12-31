using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Class_Library;
using Class_Library.Data_Access;
using Class_Library.Object_Classes.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Class_LibraryTests
{
    [TestClass]
    public class HabitatManagerTests
    {
        [TestMethod]
        public void AddHabitat_StoreValidHabitat_HabitatAddedToTheListAndDb()
        {
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 2, 5, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            var habitatDb = new HabitatDb();
            hm.AddHabitat(habitat);

            var actual = hm.Habitats.Count;
            var expected = 1;

            habitatDb.DeleteEntry(habitat.ID);

            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void AddHabitat_StoreDuplicateOfHabitat_HabitatAddedToTheListAndDb()
        {
            var habitat = new Habitat("Arctic#1", HabitatType.Arctic, 2, 5, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            var habitatDb = new HabitatDb();
            var argumentExceptionCaught = false;

            try
            {
                hm.AddHabitat(habitat);
                hm.AddHabitat(habitat);
            }
            catch (Exception e)
            {
                argumentExceptionCaught = true;
            }
            var actual = hm.Habitats.Count;
            var expected = 1;

            habitatDb.DeleteEntry(habitat.ID);

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(argumentExceptionCaught);
        }

        [TestMethod]
        public void AddHabitat_StoreEmptyHabitat_ShouldReturnArgumentException()
        {
            var hm = new HabitatManager(true);
            var nullExceptionCaught = false;
            try
            {
                hm.AddHabitat(null);
            }
            catch (ArgumentNullException e)
            {
                nullExceptionCaught = true;
            }

            var actual = hm.Habitats.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(nullExceptionCaught);
        }

        [TestMethod]
        public void AddAnimal_StoreAnimalWhenHabitatIsntEmpty_ShouldStoreAnimal()
        {
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 2, 5, FeedingTime.Morning);
            var animalId = 5;
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            hm.AddAnimal(habitat, animalId);

            var expected = 1;
            var actual = hm.Habitats.First().AnimalIds.Count;
            var actualAnimalId = hm.Habitats.First().AnimalIds.First();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(animalId, actualAnimalId);
        }

        [TestMethod]
        public void AddAnimal_StoreAnimalWhenHabitatIsFull_ShouldReturnArgumentOutOfRangeException()
        {
            var animalId1 = 3;
            var animalId2 = 5;
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 1, new List<int> {animalId1}, null, 5, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            var argumentOfRangeCaught = false;
            try
            {
                hm.AddAnimal(habitat, animalId2);
            }
            catch (ArgumentOutOfRangeException e)
            {
                argumentOfRangeCaught = true;
            }


            var expected = 1;
            var actual = hm.Habitats.First().AnimalIds.Count;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(argumentOfRangeCaught);
        }

        [TestMethod]
        public void AddAnimal_StoreInvalidAnimal_ShouldReturnArgumentNullException()
        {
            var animal = new Animal("Johny", "cat", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var animal2 = new Animal("Sam", "dog", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, 5, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            var argumentOfRangeCaught = false;
            try
            {
                hm.AddAnimal(habitat, null);
            }
            catch (ArgumentNullException e)
            {
                argumentOfRangeCaught = true;
            }


            var expected = 0;
            var actual = hm.Habitats.First().AnimalIds.Count;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(argumentOfRangeCaught);
        }

        [TestMethod]
        public void AddAnimal_StoreSameAnimal_ShouldReturnArgumentException()
        {
            var animalId = 8;
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, new List<int> { animalId }, null, 5, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            var argumentExceptionCaught = false;
            try
            {
                hm.AddAnimal(habitat, animalId);
            }
            catch (ArgumentException e)
            {
                argumentExceptionCaught = true;
            }

            var expected = 1;
            var actual = hm.Habitats.First().AnimalIds.Count;

            Assert.IsTrue(argumentExceptionCaught);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAnimal_RemoveExistingAnimalFromHabitat_ShouldRemoveExactlyOneAnimal()
        {
            var animalId1 = 7;
            var animalId2 = 9;
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, new List<int> { animalId1, animalId2 }, null, 5, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            hm.RemoveAnimal(habitat, animalId1);

            var expected = 1;
            var actual = hm.Habitats.First().AnimalIds.Count;
            var actualAnimal = hm.Habitats.First().AnimalIds.First();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(animalId2, actualAnimal);
        }

        [TestMethod]
        public void RemoveAnimal_RemoveNotExistingAnimalFromHabitat_ShouldRemoveExactlyOneAnimal()
        {
            var animalId1 = 7;
            var animalId2 = 2;
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, new List<int> { animalId1 }, null, 5, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            hm.RemoveAnimal(habitat, animalId2);

            var expected = 1;
            var actual = hm.Habitats.First().AnimalIds.Count;
            var actualAnimal = hm.Habitats.First().AnimalIds.First();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(animalId1, actualAnimal);
        }

        [TestMethod]
        public void RemoveAnimal_RemoveNullFromHabitat_ShouldThrowArgumentNullException()
        {
            var animalId1 = 4;
            var animalId2 = 118;
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, new List<int> { animalId1, animalId2 }, null, 5, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            var argumentNullExceptionCaught = false;
            try
            {
                hm.RemoveAnimal(habitat, null);
            }
            catch (ArgumentNullException e)
            {
                argumentNullExceptionCaught = true;
            }
            var expected = 2;
            var actual = hm.Habitats.First().AnimalIds.Count;


            Assert.AreEqual(expected, actual);
            Assert.IsTrue(argumentNullExceptionCaught);
        }

        [TestMethod]
        public void UpdateHabitat_UpdateTitleTypeCapacityAndRequiredEmployees_ShouldUpdateHabitat()
        {
            var oldHabitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, 5, FeedingTime.Morning);
            var newHabitat = new Habitat("Forest#1", HabitatType.Forest, 2, 3, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(oldHabitat);

            hm.UpdateHabitat(oldHabitat, newHabitat);
            var actualTitle = hm.Habitats.First().Title;
            var actualType = hm.Habitats.First().Type;
            var actualCapacity = hm.Habitats.First().Capacity;
            var actualRequiredEmployeesCount = hm.Habitats.First().RequiredEmployeesCount;

            Assert.AreEqual("Forest#1", actualTitle);
            Assert.AreEqual(HabitatType.Forest, actualType);
            Assert.AreEqual(2, actualCapacity);
            Assert.AreEqual(3, actualRequiredEmployeesCount);
            Assert.IsTrue(hm.Habitats.Count == 1);
        }

        [TestMethod]
        public void UpdateHabitat_UpdateTitleTypeCapacityRequiredEmployeesAndAnimals_ShouldUpdateHabitat()
        {
            var animalId1 = 12;
            var animalId2 = 21;
            var oldHabitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, 5, FeedingTime.Morning);
            var newHabitat = new Habitat("Forest#1", HabitatType.Forest, 2, new List<int> { animalId1, animalId2 }, null, 3, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(oldHabitat);

            hm.UpdateHabitat(oldHabitat, newHabitat);
            var actualTitle = hm.Habitats.First().Title;
            var actualType = hm.Habitats.First().Type;
            var actualCapacity = hm.Habitats.First().Capacity;
            var actualRequiredEmployeesCount = hm.Habitats.First().RequiredEmployeesCount;

            Assert.AreEqual("Forest#1", actualTitle);
            Assert.AreEqual(HabitatType.Forest, actualType);
            Assert.AreEqual(2, actualCapacity);
            Assert.AreEqual(3, actualRequiredEmployeesCount);
            Assert.IsTrue(hm.Habitats.Count == 1);
            Assert.IsTrue(hm.Habitats.First().AnimalIds.SequenceEqual(new List<int>{ animalId1, animalId2 }));
        }

        [TestMethod]
        public void UpdateHabitat_UpdateTitleTypeCapacityRequiredEmployeesAndResponsibleEmployee_ShouldUpdateHabitat()
        {
            var employee = new Employee(1001, "Tim", "TestUser1", "12345678", "test@test.test", DateTime.Parse("01-03-2022").ToString(), DateTime.Parse("01-03-2023").ToString(),
                DateTime.Now, "permanent", 20, "Streetname", "test", 2, "employee", "test1", "password1");
            var oldHabitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, 5, FeedingTime.Morning);
            var newHabitat = new Habitat("Forest#1", HabitatType.Forest, 2, null, employee.Id, 3, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(oldHabitat);

            hm.UpdateHabitat(oldHabitat, newHabitat);
            var actualTitle = hm.Habitats.First().Title;
            var actualType = hm.Habitats.First().Type;
            var actualCapacity = hm.Habitats.First().Capacity;
            var actualRequiredEmployeesCount = hm.Habitats.First().RequiredEmployeesCount;
            var actualResponsibleEmployee = hm.Habitats.First().ResponsibleEmployeeId;

            Assert.AreEqual("Forest#1", actualTitle);
            Assert.AreEqual(HabitatType.Forest, actualType);
            Assert.AreEqual(2, actualCapacity);
            Assert.AreEqual(3, actualRequiredEmployeesCount);
            Assert.IsTrue(hm.Habitats.Count == 1);
            Assert.AreEqual(employee.Id, actualResponsibleEmployee);
        }

        [TestMethod]
        public void AssignResponsibleEmployee_SetAValidEmployeeToAHabitatWithoutAssignedResponsibleEmployee_ShouldSetProperly()
        {
            var employee = new Employee(1001, "Tim", "TestUser1", "12345678", "test@test.test", DateTime.Parse("01-03-2022").ToString(), DateTime.Parse("01-03-2023").ToString(),
                DateTime.Now, "permanent", 20, "Streetname", "test", 2, "employee", "test1", "password1");
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, 5, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);

            hm.AssignResponsibleEmployee(habitat, employee);
            var responsibleEmployeeId = hm.Habitats.First().ResponsibleEmployeeId;

            Assert.AreEqual(employee.Id, responsibleEmployeeId);
        }

        [TestMethod]
        public void AssignResponsibleEmployee_ReplaceAlreadyAssignedEmployeeWithAValidEmployee_ShouldSetProperly()
        {
            var oldEmployee = new Employee(1001, "Tim", "TestUser1", "12345678", "test@test.test", DateTime.Parse("01-03-2022").ToString(), DateTime.Parse("01-03-2023").ToString(),
                DateTime.Now, "permanent", 20, "Streetname", "test", 2, "employee", "test1", "password1");
            var newEmployee = new Employee(1002, "Sue", "TestUser2", "22345678", "sue@test.test", DateTime.Parse("01-03-2022").ToString(), DateTime.Parse("01-03-2023").ToString(),
                DateTime.Now, "permanent", 20, "Streetname", "test", 2, "employee", "test1", "password1");
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, null, oldEmployee.Id, 5, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);

            hm.AssignResponsibleEmployee(habitat, newEmployee);
            var actualResponsibleEmployeeId = hm.Habitats.First().ResponsibleEmployeeId;

            Assert.AreEqual(actualResponsibleEmployeeId, newEmployee.Id);
        }

        [TestMethod]
        public void AssignResponsibleEmployee_ReplaceAlreadyAssignedEmployeeWithANull_ShouldThrowArgumentNullException()
        {
            var employee = new Employee (1001, "Tim", "TestUser1", "12345678", "test@test.test", DateTime.Parse("01-03-2022").ToString(), DateTime.Parse("01-03-2023").ToString(),
                DateTime.Now, "permanent", 20, "Streetname", "test", 2, "employee", "test1", "password1");
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, null, employee.Id, 5, FeedingTime.Morning);
            var hm = new HabitatManager(true);
            var argumentNullExceptionCaught = false;
            hm.Habitats.Add(habitat);
            try
            {
                hm.AssignResponsibleEmployee(habitat, null);
            }
            catch (ArgumentNullException e)
            {
                argumentNullExceptionCaught = true;
            }
            var responsibleEmployeeId = hm.Habitats.First().ResponsibleEmployeeId;

            Assert.IsTrue(argumentNullExceptionCaught);
            Assert.AreEqual(employee.Id, responsibleEmployeeId);
        }

        [TestMethod]
        public void GetHabitatById_GetExistingHabitat_ShouldReturnExactlyOneHabitat()
        {
            var hm = new HabitatManager(true);
            var habitat1 = new Habitat(1, "Test1", HabitatType.Jungle, 3, null, null, 5, FeedingTime.Morning);
            var habitat2 = new Habitat(2, "Test2", HabitatType.Arctic, 4, null, null, 1, FeedingTime.Morning);
            var habitat3 = new Habitat(3, "Test3", HabitatType.Savannah, 5, null, null, 2, FeedingTime.Morning);

            hm.Habitats.Add(habitat1);
            hm.Habitats.Add(habitat2);
            hm.Habitats.Add(habitat3);

            var actual= hm.GetHabitatById(2);
            var expected = habitat2;

            Assert.IsTrue(expected.Equals(actual));
        }

        [TestMethod]
        public void GetHabitatById_GetNotExistingHabitat_ShouldReturnNull()
        {
            var hm = new HabitatManager(true);
            var habitat1 = new Habitat(1, "Test1", HabitatType.Jungle, 3, null, null, 5, FeedingTime.Morning);
            var habitat2 = new Habitat(2, "Test2", HabitatType.Arctic, 4, null, null, 1, FeedingTime.Morning);
            var habitat3 = new Habitat(3, "Test3", HabitatType.Savannah, 5, null, null, 2, FeedingTime.Morning);

            hm.Habitats.Add(habitat1);
            hm.Habitats.Add(habitat2);
            hm.Habitats.Add(habitat3);

            var actual = hm.GetHabitatById(4);

            Assert.AreEqual(null, actual);
        }

    }
}