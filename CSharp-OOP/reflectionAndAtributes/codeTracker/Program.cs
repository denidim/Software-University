using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem//codeTracker
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,AllowMultiple =true)]

    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute()
        {
        }

        public AuthorAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }

    public class Tracker
    {
        public Tracker()
        {
        }

        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);

            var methodInfo = type.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);

            foreach (var method in methodInfo)
            {
                if (method.CustomAttributes
                    .Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute atrribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {atrribute.Name}");
                    }
                }
            }
        }
    }

    [Author("Victor")]
    public class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
    
}
