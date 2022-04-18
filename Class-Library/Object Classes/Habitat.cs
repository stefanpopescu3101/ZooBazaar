using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Principal;
using Class_Library.Object_Classes.Enums;

namespace Class_Library.Data_Access
{
    public class Habitat
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public HabitatType Type { get; set; }
        public int Capacity { get; set; }
        public List<int> AnimalIds { get; set; }
        public int? ResponsibleEmployeeId { get; set; }
        public int RequiredEmployeesCount { get; set; }
        public FeedingTime FeedingTime { get; set; }

        public Habitat(string title, HabitatType type, int capacity, int requiredEmployeesCount, FeedingTime feedingTime) : this(0, title, type,
            capacity, new List<int>(),
            null, requiredEmployeesCount, feedingTime)
        {
        }

        public Habitat(string title, HabitatType type, int capacity, List<int> animalIds,
            int? responsibleEmployeeId, int requiredEmployeesCount, FeedingTime feedingTime) : this(0, title, type,
            capacity, animalIds,
            responsibleEmployeeId, requiredEmployeesCount, feedingTime)
        {
        }

        public Habitat(int id, string title, HabitatType type, int capacity, List<int> animalIds,
            int? responsibleEmployeeId, int requiredEmployeesCount, FeedingTime feedingTime)
        {
            this.ID = id;
            this.Title = title;
            this.Type = type;
            this.Capacity = capacity;
            if (animalIds == null)
            {
                this.AnimalIds = new List<int>();
            }
            else
            {
                this.AnimalIds = animalIds;
            }
            this.ResponsibleEmployeeId = responsibleEmployeeId;
            this.RequiredEmployeesCount = requiredEmployeesCount;
            this.FeedingTime = feedingTime;
        }

        public override string ToString()
        
        {
            //    string animals = string.Empty;
            //    string responsibleEmployee = string.Empty;
            //    if (ResponsibleEmployeeId == null)
            //    {
            //        responsibleEmployee = "None";
            //    }
            //    else
            //    {
            //        // replace after employee class is implemented properly
            //        responsibleEmployee = $"\n\tEmployee with id: {ResponsibleEmployeeId}";
            //    }

            //    foreach (var animal in Animals)
            //    {
            //        animals += "\n" + "\t" + animal.ToString();
            //    }

            //    if (string.IsNullOrWhiteSpace(animals))
            //    {
            //        animals = "None";
            //    }
            //    return
            //        $"Id: {ID}\nTitle: {Title}\nType: {Type.ToString()}\nCapacity: {Capacity}\nAnimals: {animals}\nResponsible Employee: {responsibleEmployee}\n" +
            //        $"Required employees: {RequiredEmployeesCount}";
            int numOfCharacters = ID.ToString().Length;


            var str = $"{ID,-5}";
            for (
                var i = 0; 
                i < (5 - numOfCharacters); i++)
            {
                str += " ";
            }

            str += $"\t{Title,-16}";

            return str;

        }
    }
    }