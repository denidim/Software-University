using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class DirectoryTraversal
{
    public static Dictionary<string, List<FileInfo>> TraverseDirectory(string inputFolderPath)
    {
        Dictionary<string, List<FileInfo>> fileDictionary = new Dictionary<string, List<FileInfo>>();

        string[] files = Directory.GetFiles(inputFolderPath);

        foreach (var file in files)
        {

            FileInfo info = new FileInfo(file);

            string extencion = info.Extension;

            if (!fileDictionary.ContainsKey(file))
            {
                fileDictionary.Add(extencion, new List<FileInfo>());
            }
            fileDictionary[extencion].Add(info);
        }

        return fileDictionary;
    }

    public static void WriteReportToDesktop(Dictionary<string, List<FileInfo>> fileDictionary)
    {
        using StreamWriter strWtiter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt");

        foreach (var item in fileDictionary.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
        {
            strWtiter.WriteLine($"{item.Key}");

            foreach (var fileInfo in item.Value.OrderBy(x => Math.Ceiling((double)x.Length / 1024)))
            {
                strWtiter.WriteLine($"--{fileInfo.Name} - {Math.Ceiling((double)fileInfo.Length / 1024)}kb");
            }
        }

    }
}

