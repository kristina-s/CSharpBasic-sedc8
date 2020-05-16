using Linq.SpecialEdition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Linq.SpecialEdition
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("John", "Doe", 22, "G1", 'M', new List<string>(){"C#", "SQL"}),
                new Student("Anna", "Bakers", 31, "G3", 'F', new List<string>(){"Javascript", "Docker"}),
                new Student("Tanya", "Walters", 24, "G2", 'F', new List<string>(){"Java", "Docker"}),
                new Student("Tim", "Yung", 26, "G1", 'M', new List<string>(){"React", "CSS"}),
                new Student("Kathy", "Donovan", 19, "G4", 'F', new List<string>(){"C#", "SQL"}),
                new Student("James", "Hughs", 36, "G3", 'M', new List<string>(){"C#", "React", "SQL", "Vue"}),
                new Student("Trey", "Anders", 27, "G2", 'M', new List<string>(){"Javascript", "CSS"}),
                new Student("Diana", "Jones", 30, "G4", 'F', new List<string>(){"CSS", "HTML"}),
                new Student("Eric", "White", 20, "G1", 'M', new List<string>(){"SQL", "React"}),
                new Student("Angela", "Johnson", 28, "G2", 'F', new List<string>(){"React", "Javascript", "CSS", "Vue"}),
                new Student("Chris", "Peterson", 25, "G1", 'M', new List<string>(){"C#", "SQL", "Docker"}),
            };

            // METHOD SYNTAX OF WRITING LINQ


            // Task 01 - find AGE of youngest and oldest student
            // MIN & MAX return the minimum or maximum value in an list
            int youngestAge = students
                                    .Select(st => st.Age)
                                    .Min();
            int oldestAge = students
                                    .Select(st => st.Age)
                                    .Max();
            Console.WriteLine("Age of youngest student is {0} and of the oldest is {1}", youngestAge, oldestAge);

            // Task 02 - find SUM of all ages of all students
            // SUM returns sum of all elements in an list
            int sumOfAge = students
                                    .Select(st => st.Age)
                                    .Sum();  
            Console.WriteLine("Sum of all ages is {0}", sumOfAge);

            // Task 03 - find AVERAGE of all ages of all students
            // AVERAGE returns average of all elements in an list
            double averageAge = students
                                    .Select(st => st.Age)
                                    .Average();
            Console.WriteLine("Average age of the students is {0:0.##}", averageAge);

            // Task 04 - order students by name in ascending order / descending order
            // ORDERBY and ORDERBYDESCENDING are used to order elements in an list
            var ascendingOrder = students
                                        .OrderBy(st => st.Firstname)
                                        .ToList();
            Console.WriteLine("============== ASCENDING ORDER ===============");
            ascendingOrder.ForEach(st => Console.WriteLine(st.Firstname));

            var descendingOrder = students
                                        .OrderByDescending(st => st.Firstname)
                                        .ToList();
            Console.WriteLine("============== DESCENDING ORDER ===============");
            descendingOrder.ForEach(st => Console.WriteLine(st.Firstname));

            // Task 05 - group elements by group
            // GROUP BY is used for grouping elements
            // mix with Dictionary for better way of keeping the students in groups
            Console.WriteLine("============== GROUP BY ===============");

            Dictionary<string, List<Student>> studentDictionary = new Dictionary<string, List<Student>>();
            var group4 = students
                                .GroupBy(st => st.Group);
            foreach(var item in group4)
            {
                studentDictionary.Add(item.Key, item.ToList());
            };

            List<Student> g4Students = null;
            var areThereStudentsInG4 = studentDictionary.TryGetValue("G4", out g4Students);
            Console.WriteLine(areThereStudentsInG4 == null ? "No students in G4" : $"Number of students in G4 is {g4Students.Count}");
            // this is same as
            if(areThereStudentsInG4 == null)
            {
                Console.WriteLine("No students in G4");
            } else
            {
                Console.WriteLine($"Number of students in G4 is {g4Students.Count}");
            }
            // fancy way
            Console.WriteLine(!areThereStudentsInG4 ? "No students in G4" : $"Number of students in G4 is {g4Students.Count}");

            // Task 06 - find person with most skills
            Console.WriteLine("============== FirstOrDefault / SingleOrDefalut ===============");

            int mostSkills = students
                                    .Select(st => st.Skills.Count)
                                    .Max();
            Student mostSkilledStudent01 = students
                                                .Where(st => st.Skills.Count == mostSkills)
                                                .FirstOrDefault();

            // the same written in a more complex way by nesting linq methods
            Student mostSkilledStudent00 = students
                                                .Where(st => st.Skills.Count == students.Select(st => st.Skills.Count).Max())
                                                .FirstOrDefault();
                                                

            // another way
            Student mostSkilledStudent02 = students
                                                .FirstOrDefault(st => st.Skills.Count == mostSkills);
            //Student mostSkilledStudent03 = students
            //                                    .SingleOrDefault(st => st.Skills.Count == mostSkills);
            Console.WriteLine("Most skilled is {0}", mostSkilledStudent01.Firstname);
            Console.WriteLine("Most skilled is {0}", mostSkilledStudent02.Firstname);
            //Console.WriteLine("Most skilled is {0}", mostSkilledStudent03.Firstname);

            // FirstOrDefault returns a first item of potentially multiple (or default if none exists).
            // SingleOrDefault assumes that there is a single item and returns it (or default if none exists). Multiple items are a violation of contract, an exception is thrown.


            // QUERY SYNTAX OF WRITING LINQ

            var mostSkilledQuery = from st in students
                              where st.Skills.Count == mostSkills
                              select st.Firstname;
            // List<> { "James", "Name" }
            Console.WriteLine(mostSkilledQuery.FirstOrDefault());

            var youngerThan30 = from st in students
                                where st.Age < 30
                                select st.Firstname;
            // List<> { "Mary", "Jim" }
            Console.WriteLine(youngerThan30.FirstOrDefault());

            Console.ReadLine();
        }
    }
}
