using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer//collector
{
    public class Hacker
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";

        public string Password
        {
            get => this.password;
            set => this.password = value;
        }

        private int Id { get; set; }

        public double BankAccountBalance { get; private set; }

        public void DownloadAllBankAccountsInTheWorld()
        {
        }
    }

    public class Spy
    {
        internal string CollectGettersAndSetters(string investigatedclass)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(investigatedclass);


            MethodInfo[] allMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var method in allMethods)
            {
                if (method.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
                else if (method.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
            }

            return sb.ToString().Trim();

        }

        public string RevealPrivateMethods(string investigatedclass)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {investigatedclass}");

            Type type = Type.GetType(investigatedclass);

            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            MethodInfo[] privareMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            foreach (var privateMethodna in privareMethods)
            {
                sb.AppendLine($"{privateMethodna.Name}");
            }


            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string investigatedclass)
        {
            Type classType = Type.GetType(investigatedclass);
            //Type classType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == className);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);

            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (var item in fields)
            {
                sb.AppendLine($"{item.Name} must be private!");
            }
            foreach (var item in nonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");

            }
            foreach (var item in publicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }

        public string StealFieldInfo(string name, params string[] fieldsNames)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation:");

            sb.AppendLine(name);

            Type classType = Type.GetType(name);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            Object instance = Activator.CreateInstance(classType, new object[] { });

            foreach (FieldInfo fieldName in fields.Where(x => fieldsNames.Contains(x.Name)))
            {
                string value = (string)fieldName.GetValue(instance);
                sb.AppendLine($"{fieldName.Name} = {fieldName.GetValue(instance)}");
            }

            return sb.ToString().Trim();
        }

        
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
