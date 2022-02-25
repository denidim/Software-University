using System;
using System.IO;

namespace CopyDirectory
{
    public class CopyDirectory
    {
        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath,true);
            }
            Directory.CreateDirectory(outputPath);

            string[] files = Directory.GetFiles(inputPath);

            foreach (var item in files)
            {
                string name = Path.GetFileName(item);
                string destFile = Path.Combine(outputPath, name);
                File.Copy(item, destFile, true);
            }
        }
    }
}
