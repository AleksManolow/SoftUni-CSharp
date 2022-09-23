namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader read = new StreamReader(inputFilePath))
            {
                int count = 0;
                string line = read.ReadLine();
                using (StreamWriter write = new StreamWriter(outputFilePath))
                {
                    while (line != null)
                    {
                        write.WriteLine(count + ". " + line);
                        count++;
                        line = read.ReadLine();
                    }
                }
            }
        }
    }
}
