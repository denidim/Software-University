using System;

namespace miliratyElite
{
    public interface Isalary
    {
        decimal Salary { get; }
    }


    public abstract class Soldier : Isoldier
    {
        private string id;
        private string firstName;
        private string lastName;

        protected Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }

    public interface Isoldier
    {
        string Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }
    
    public class Private:Soldier,Isalary
    {
        public Private(string id, string firstName, string lastName,decimal salary)
            : base(id,firstName,lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }
    }

    public class LieutenantGeneral : Soldier, Isalary
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }
    }

    public abstract class SpecialisedSoldier : Soldier
    {
        protected SpecialisedSoldier(string id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
        }
    }
}
