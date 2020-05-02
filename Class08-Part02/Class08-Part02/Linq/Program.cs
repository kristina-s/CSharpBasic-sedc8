using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Simple examples linq
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            

            // Select (similar with map in JS)
            List<int> addOneToElements = numbers
                                            .Select(x => x * x)
                                            .ToList();
            // Where (similar with filter in JS)
            List<int> greaterThanThree = numbers
                                            .Where(x => x > 3)
                                            .ToList();
            foreach (var item in greaterThanThree)
            {
                Console.WriteLine(item);
            }

            numbers.ForEach(x => Console.WriteLine(x));

            // Data for LINQ manipulation
            List<Dog> dogs = new List<Dog>()
            {
                new Dog(){Name = "Sparky", Age = 2},
                new Dog(){Name = "Butch", Age = 1},
                new Dog(){Name = "Zoe", Age = 3},
                new Dog(){Name = "Sia", Age = 1},
                new Dog(){Name = "William", Age = 4},
                new Dog(){Name = "Billy", Age = 1},
                new Dog(){Name = "Buck", Age = 2}
            };
            // Where
            // All dogs with name longer than 3 letters
            List<Dog> longerThan3 = dogs.Where(x => x.Name.Length > 3).ToList();
            // All dogs that have a name starting with S
            List<Dog> startingWithS = dogs.Where(x => x.Name.StartsWith("S")).ToList();
            // First dog that is of age 1 and have a name that starts with B
            Dog Age1WithB = dogs.Where(x => x.Age == 1).Where(x => x.Name.StartsWith("B")).FirstOrDefault();
            // Select
            // All names of dogs
            List<string> namesOfDogs = dogs.Select(x => x.Name).ToList();
            // All ages of dogs
            List<int> agesOfDogs = dogs.Select(x => x.Age).ToList();
            // All names of dogs that are the age of 2
            List<string> dogsOfAge = dogs.Where(x => x.Age == 2).Select(x => x.Name).ToList();

            Console.ReadLine();
        }
    }
}

