namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Reflection.PortableExecutable;
    using System.Threading;
    using static System.Net.Mime.MediaTypeNames;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string line = reader.ReadLine();
                    int countLine = 0;

                    while (line != null)
                    {
                        int characters = 0;
                        int punctuationMarks = 0;

                        foreach (var ch in line)
                        {
                            if (ch == '-' || ch == '.' || ch == ',' || ch == '!'
                                || ch == '?' || ch == '\'')
                            {
                                punctuationMarks++;
                            }
                            else if ((ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122))
                            {
                                characters++;
                            }
                        }
                       
                        writer.WriteLine($"Line {countLine}: {line} ({characters})({punctuationMarks})");

                        countLine++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
