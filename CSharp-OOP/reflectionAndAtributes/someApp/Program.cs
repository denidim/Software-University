using System;

namespace AuthorProblem//createAttribute
{
    //[AttributeUsage(AttributeTargets.Method |
    // AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
    //[Author("Victor")]
    public class StartUp
    {
        //[Author("George")]
        static void Main(string[] args)
        {
        }
    }
}
