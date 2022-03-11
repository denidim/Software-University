using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem//codeTracker
{
    public class Tracker
    {
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

}

