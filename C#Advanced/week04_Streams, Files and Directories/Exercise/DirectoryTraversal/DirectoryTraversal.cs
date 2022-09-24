namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);
            Dictionary<string, List<FileInfo>> extentionsInfo = new Dictionary<string, List<FileInfo>>();
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extention = fileInfo.Extension;
                if (!extentionsInfo.ContainsKey(extention))
                {
                    extentionsInfo.Add(extention, new List<FileInfo>());
                }
                extentionsInfo[extention].Add(fileInfo);
            }

            var ordered = extentionsInfo.OrderByDescending(entry => entry.Value.Count).ThenBy(entry => entry.Key);
            var sb = new StringBuilder();
            foreach (var extension in ordered)
            {
                sb.AppendLine(extension.Key);
                var orderedList = extension.Value.OrderByDescending(x => x.Length);
                foreach (var fileInfo in orderedList)
                {
                    sb.AppendLine($"--{fileInfo.Name} - {fileInfo.Length / 1024:f3}kb");
                }
            }
            return sb.ToString();

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string pathReport = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(pathReport, textContent);
        }
    }
}
