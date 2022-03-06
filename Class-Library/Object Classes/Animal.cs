using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library {
    public class Animal {
        private int ID;
        private string name;
        private string species;
        private string sex;
        private DateTime birthday;
        private string habitat;
        private string status;
        private DateTime arrivalDate;
        private DateTime departureDate;

        //constructor for adding new animal
        //TODO: initialise the status
        public Animal(string name, string species, string sex, DateTime birthday, DateTime arrivalDate) {
            this.name = name;
            this.species = species;
            this.sex = sex;
            this.birthday = birthday;
            this.arrivalDate = arrivalDate;
        }

        //constructor for getting animal from the database
        public Animal(int id, string name, string species, string sex, DateTime birthday, string habitat, string status, DateTime arrivalDate, DateTime departureDate) {
            this.ID = id;
            this.name = name;
            this.species = species;
            this.sex = sex;
            this.birthday = birthday;
            this.habitat = habitat;
            this.status = status;
            this.arrivalDate = arrivalDate;
            this.departureDate = departureDate;
        }

        //get the details of the animal, after selecting an ID
        public Animal GetAnimal(int id) {
            //TODO: get the selected animal from the list
            Animal a = new Animal("a","a","a",new DateTime(),new DateTime()); //just temporary
            return a;
        }

        //update animal information, not all information can be changed
        public void UpdateAnimal(string name, string species, string sex) {
            this.name = name;
            this.species = species;
            this.sex = sex;
        }

        //remove the animal, which means setting a departure date
        //TODO: change the status
        public void RemoveAnimal(DateTime departureDate) {
            this.departureDate = departureDate;
        }

        //assigning the animal to a habitat
        public void AssignHabitat(string habitat) {
            this.habitat = habitat;
        }
    }
}
