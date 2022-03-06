using System;
using military.Interfaces;

namespace military.Models
{
    public class Private:Soldier,IPrivate
    {
        public Private(int id, string firstName, string lastName,decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            //Name: <firstName> <lastName> Id: <id> Salary: <salary>

            return $"{base.ToString()} Salary: {Salary:f2}";
        }


    }
}
