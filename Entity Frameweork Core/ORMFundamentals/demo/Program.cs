using demo.Models;
using System;
using System.Linq;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SoftUniContext();

            db.Towns.Add(new Town {Name= "Pernik" });
            db.SaveChanges();

            Console.WriteLine(db.Employees.Count()); 

            var employees = db.Employees
                .Where(x => x.FirstName.StartsWith("N"))
                .OrderByDescending(x => x.Salary)
                .Select(x => new {x.FirstName,x.LastName,x.Salary })
                .ToList();

            foreach (var item in employees)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} => {item.Salary}");
            }

            var departments = db.Employees.GroupBy(x => x.Department.Name)
                .Select(x => new {Name = x.Key, Count = x.Count() })
                .ToList();

            foreach (var item in departments)
            {
                Console.WriteLine($"{item.Name} => {item.Count}");
            }
        }
    }
}
