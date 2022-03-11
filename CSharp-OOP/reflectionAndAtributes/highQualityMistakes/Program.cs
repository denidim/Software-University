using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer//highQualityMistakes
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
        public string AnalyzeAccessModifiers(string className)
        {

            //var test = AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm => asm.GetTypes().FirstOrDefault(type => type.Name == className));

            Type classType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == className);

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

            string result = spy.AnalyzeAccessModifiers("Hacker");//typeof(Hacker).FullName

            Console.WriteLine(result);
        }
    }
}
