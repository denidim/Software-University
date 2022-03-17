using System.Linq;
using System.Text;

namespace Data.CustomFiles
{
    public class LogFile : ILogFile
    {
        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size => sb.ToString().Where(ch => char.IsLetter(ch)).Sum(x => x);

        public void Write(string message)
        {
            sb.Append(message);
        }
    }
}
