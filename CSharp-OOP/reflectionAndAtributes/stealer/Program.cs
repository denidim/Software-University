using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
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

        public string StealFieldInfo(string name,params string[] fieldsNames)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation:");
            sb.AppendLine(name);

            Type type = Type.GetType(name);

            FieldInfo[] fields = type.GetFields(BindingFlags.Static|BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic);

            Object instance = Activator.CreateInstance(type, new object[] { });

            foreach (FieldInfo fieldName in fields.Where(x=>fieldsNames.Contains(x.Name)))
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
            string result = spy.StealFieldInfo("Stealer.Hacker","username","password");
            Console.WriteLine(result);
        }
    }
}
