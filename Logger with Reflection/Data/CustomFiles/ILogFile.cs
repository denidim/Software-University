using System.Text;

namespace Data.CustomFiles
{
    public interface ILogFile
    {
        void Write(string message);

        int Size { get; }
    }
}
