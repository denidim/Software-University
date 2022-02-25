using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    public class EvenLines
    {

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader streamReader = new StreamReader(inputFilePath);
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            string line = "";
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();

                if (counter % 2 == 0)
                {
                    string[] toReplace = new string[] { "-", ",", ".", "!", "?" };

                    foreach (var item in toReplace)
                    {
                        if (line.Contains(item))
                        {
                            line = line.Replace(item, "@");
                        }
                    }

                    List<string> output = line.Split().ToList();

                    output.Reverse();

                    line = string.Join(" ", output);
                    sb.AppendLine(line);
                }

                counter++;
            }
            return sb.ToString().Trim();
        }
    }
}
