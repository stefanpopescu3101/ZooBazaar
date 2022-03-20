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
    public class HabitatManagerTests
    {
        [TestMethod]
        public void AddHabitat_StoreValidHabitat_HabitatAddedToTheListAndDb()
        {
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 2, 5);
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
            var habitat = new Habitat("Arctic#1", HabitatType.Arctic, 2, 5);
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
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 2, 5);
            var animal = new Animal("Johny", "cat", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            hm.AddAnimal(habitat, animal);

            var expected = 1;
            var actual = hm.Habitats.First().Animals.Count;
            var actualAnimal = hm.Habitats.First().Animals.First();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(animal, actualAnimal);
        }

        [TestMethod]
        public void AddAnimal_StoreAnimalWhenHabitatIsFull_ShouldReturnArgumentOutOfRangeException()
        {
            var animal = new Animal("Johny", "cat", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var animal2 = new Animal("Sam", "dog", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 1, new List<Animal> {animal}, null, 5);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            var argumentOfRangeCaught = false;
            try
            {
                hm.AddAnimal(habitat, animal2);
            }
            catch (ArgumentOutOfRangeException e)
            {
                argumentOfRangeCaught = true;
            }


            var expected = 1;
            var actual = hm.Habitats.First().Animals.Count;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(argumentOfRangeCaught);
        }

        [TestMethod]
        public void AddAnimal_StoreInvalidAnimal_ShouldReturnArgumentNullException()
        {
            var animal = new Animal("Johny", "cat", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var animal2 = new Animal("Sam", "dog", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, 5);
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
            var actual = hm.Habitats.First().Animals.Count;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(argumentOfRangeCaught);
        }

        [TestMethod]
        public void AddAnimal_StoreSameAnimal_ShouldReturnArgumentException()
        {
            var animal = new Animal("Johny", "cat", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, new List<Animal> { animal }, null, 5);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            var argumentExceptionCaught = false;
            try
            {
                hm.AddAnimal(habitat, animal);
            }
            catch (ArgumentException e)
            {
                argumentExceptionCaught = true;
            }

            var expected = 1;
            var actual = hm.Habitats.First().Animals.Count;

            Assert.IsTrue(argumentExceptionCaught);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAnimal_RemoveExistingAnimalFromHabitat_ShouldRemoveExactlyOneAnimal()
        {
            var animal = new Animal("Johny", "cat", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var animal2 = new Animal("Sam", "dog", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, new List<Animal> { animal, animal2 }, null, 5);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            hm.RemoveAnimal(habitat, animal);

            var expected = 1;
            var actual = hm.Habitats.First().Animals.Count;
            var actualAnimal = hm.Habitats.First().Animals.First();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(animal2, actualAnimal);
        }

        [TestMethod]
        public void RemoveAnimal_RemoveNotExistingAnimalFromHabitat_ShouldRemoveExactlyOneAnimal()
        {
            var animal = new Animal("Johny", "cat", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var animal2 = new Animal("Sam", "dog", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, new List<Animal> { animal }, null, 5);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);
            hm.RemoveAnimal(habitat, animal2);

            var expected = 1;
            var actual = hm.Habitats.First().Animals.Count;
            var actualAnimal = hm.Habitats.First().Animals.First();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(animal, actualAnimal);
        }

        [TestMethod]
        public void RemoveAnimal_RemoveNullFromHabitat_ShouldThrowArgumentNullException()
        {
            var animal = new Animal("Johny", "cat", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var animal2 = new Animal("Sam", "dog", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, new List<Animal> { animal, animal2 }, null, 5);
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
            var actual = hm.Habitats.First().Animals.Count;


            Assert.AreEqual(expected, actual);
            Assert.IsTrue(argumentNullExceptionCaught);
        }

        [TestMethod]
        public void UpdateHabitat_UpdateTitleTypeCapacityAndRequiredEmployees_ShouldUpdateHabitat()
        {
            var oldHabitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, 5);
            var newHabitat = new Habitat("Forest#1", HabitatType.Forest, 2, 3);
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
            var animal = new Animal("Johny", "cat", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var animal2 = new Animal("Sam", "dog", Animal.Sex.Male, DateTime.Now, DateTime.Now, "healthy");
            var oldHabitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, 5);
            var newHabitat = new Habitat("Forest#1", HabitatType.Forest, 2, new List<Animal> { animal, animal2 }, null, 3);
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
            Assert.IsTrue(hm.Habitats.First().Animals.SequenceEqual(new List<Animal>{ animal, animal2 }));
        }

        [TestMethod]
        public void UpdateHabitat_UpdateTitleTypeCapacityRequiredEmployeesAndResponsibleEmployee_ShouldUpdateHabitat()
        {
            var employee = new Employee {Id = 2, FirstName = "John", LastName = "Smith"};
            var oldHabitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, 5);
            var newHabitat = new Habitat("Forest#1", HabitatType.Forest, 2, null, employee.Id, 3);
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
            var employee = new Employee {Id = 2, FirstName = "John", LastName = "Smith" };
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, 5);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);

            hm.AssignResponsibleEmployee(habitat, employee);
            var responsibleEmployeeId = hm.Habitats.First().ResponsibleEmployeeId;

            Assert.AreEqual(employee.Id, responsibleEmployeeId);
        }

        [TestMethod]
        public void AssignResponsibleEmployee_ReplaceAlreadyAssignedEmployeeWithAValidEmployee_ShouldSetProperly()
        {
            var oldEmployee = new Employee {Id = 2, FirstName = "Sue", LastName = "Storm" };
            var newEmployee = new Employee {Id = 9, FirstName = "John", LastName = "Smith" };
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, null, oldEmployee.Id, 5);
            var hm = new HabitatManager(true);
            hm.Habitats.Add(habitat);

            hm.AssignResponsibleEmployee(habitat, newEmployee);
            var actualResponsibleEmployeeId = hm.Habitats.First().ResponsibleEmployeeId;

            Assert.AreEqual(actualResponsibleEmployeeId, newEmployee.Id);
        }

        [TestMethod]
        public void AssignResponsibleEmployee_ReplaceAlreadyAssignedEmployeeWithANull_ShouldThrowArgumentNullException()
        {
            var oldEmployee = new Employee { Id = 2, FirstName = "Sue", LastName = "Storm" };
            var habitat = new Habitat("Jungle#1", HabitatType.Jungle, 5, null, oldEmployee.Id, 5);
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
            Assert.AreEqual(oldEmployee.Id, responsibleEmployeeId);
        }

        [TestMethod]
        public void GetHabitatById_GetExistingHabitat_ShouldReturnExactlyOneHabitat()
        {
            var hm = new HabitatManager(true);
            var habitat1 = new Habitat(1, "Test1", HabitatType.Jungle, 3, null, null, 5);
            var habitat2 = new Habitat(2, "Test2", HabitatType.Arctic, 4, null, null, 1);
            var habitat3 = new Habitat(3, "Test3", HabitatType.Savannah, 5, null, null, 2);

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
            var habitat1 = new Habitat(1, "Test1", HabitatType.Jungle, 3, null, null, 5);
            var habitat2 = new Habitat(2, "Test2", HabitatType.Arctic, 4, null, null, 1);
            var habitat3 = new Habitat(3, "Test3", HabitatType.Savannah, 5, null, null, 2);

            hm.Habitats.Add(habitat1);
            hm.Habitats.Add(habitat2);
            hm.Habitats.Add(habitat3);

            var actual = hm.GetHabitatById(4);

            Assert.AreEqual(null, actual);
        }

    }
}