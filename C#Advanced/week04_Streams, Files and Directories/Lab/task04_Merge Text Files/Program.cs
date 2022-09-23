namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader readFirstFile = new StreamReader(firstInputFilePath))
            {
                using (StreamReader readSecoundFile = new StreamReader(secondInputFilePath))
                {
                    string lineF = readFirstFile.ReadLine();
                    string lineS = readSecoundFile.ReadLine();
                    using (StreamWriter write = new StreamWriter(outputFilePath))
                    {
                        while (lineF != null || lineS != null)
                        {
                            if (lineF != null)
                            {
                                write.WriteLine(lineF);
                            }

                            if (lineS != null)
                            {
                                write.WriteLine(lineS);
                            }
                            lineF = readFirstFile.ReadLine();
                            lineS = readSecoundFile.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
