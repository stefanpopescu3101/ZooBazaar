using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library {
    public class Animal {
        public enum Sex {
            Female, Male, Unknown
        }

        public int ID { get; set; }
        public string name { get; set; }
        public string species { get; set; }
        public Sex sex { get; set; }
        public DateTime birthday { get; set; }
        public string habitat { get; set; }
        public bool isInZoo { get; set; }
        public string health { get; set; }
        public DateTime arrivalDate { get; set; }
        public DateTime departureDate { get; set; }

        //constructor for adding new animal
        //TODO: initialise the status
        public Animal(string name, string species, Sex sex, DateTime birthday, DateTime arrivalDate, string health) {
            this.name = name;
            this.species = species;
            this.sex = sex;
            this.birthday = birthday;
            this.arrivalDate = arrivalDate;
            this.health = health;
            //check current date, compare with arrival, determine if animal is in zoo
            if (arrivalDate < DateTime.Today) {
                this.isInZoo = true;
            } else {
                this.isInZoo = false;
            }
            this.departureDate = DateTime.MinValue; //unassigned
        }

        //constructor for getting animal from the database
        public Animal(int id, string name, string species, Sex sex, DateTime birthday, string habitat, bool isInZoo, string health, DateTime arrivalDate, DateTime departureDate) {
            this.ID = id;
            this.name = name;
            this.species = species;
            this.sex = sex;
            this.birthday = birthday;
            this.habitat = habitat;
            this.isInZoo = isInZoo;
            this.health = health;
            this.arrivalDate = arrivalDate;
            this.departureDate = departureDate;
        }

        //get the details of the animal, after selecting an ID
        public Animal GetAnimal(int id) {
            //TODO: get the selected animal from the list
            Animal a = new Animal("a","a",Sex.Female,new DateTime(),new DateTime(), "a"); //just temporary
            return a;
        }

        //update animal information, not all information can be changed
        public void UpdateAnimal(string name, string species, Sex sex) {
            this.name = name;
            this.species = species;
            this.sex = sex;
        }

        //remove the animal, which means setting a departure date
        //TODO: change the status
        public void RemoveAnimal(DateTime departureDate) {
            this.departureDate = departureDate;
            //check current date, compare with departure, determine if animal is in zoo
        }

        //assigning the animal to a habitat
        public void AssignHabitat(string habitat) {
            this.habitat = habitat;
        }
    }
}
