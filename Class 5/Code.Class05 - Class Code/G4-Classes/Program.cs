using System;

namespace G4_Classes
{
    class Program
    {
        public class Student
        {
            //PROPERTIES
            public string FirstName;
            public string LastName;

            public DateTime DateOfBirth;

            // ACCESS MODIFIER - PRIVATE
            private int Age;

            //METHODS
            public void SayHello()
            {
                Console.WriteLine($"Hello I'm {FirstName} {LastName}");

                HowOld(DateTime.Today);
                Console.WriteLine($"Also, I`m {Age} years old. :)");
            }

            private void HowOld(DateTime today)
            {
                if (today.Month < DateOfBirth.Month)
                    Age = today.Year - DateOfBirth.Year - 1;

                Age = today.Year - DateOfBirth.Year;
            }
        }

        static void Main(string[] args)
        {

            Student student01 = new Student();
            student01.FirstName = "Kristina";
            student01.LastName = "Spasevska";
            student01.DateOfBirth = new DateTime(1987, 3, 26);


            // we cannot access private properties from program
            //student01.Age = 27;

            student01.SayHello();

            Console.ReadLine();
        }
    }
}
