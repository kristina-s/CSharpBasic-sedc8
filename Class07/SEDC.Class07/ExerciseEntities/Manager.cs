using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseEntities
{
    public class Manager: Employee
    {
        protected double Bonus { get; set; }

        public Manager()
        {

        }

        public Manager(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        public void AddBonus(double bonus)
        {
            Bonus = bonus;
        }

        public override double GetSalary()
        {
            return Salary += Bonus;
        }
    }
}
