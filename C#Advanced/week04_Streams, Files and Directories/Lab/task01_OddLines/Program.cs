namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader read = new StreamReader(inputFilePath))
            {
                int count = 0;
                string line = read.ReadLine();  
                using (StreamWriter write = new StreamWriter(outputFilePath))
                {
                    while (line != null)
                    {
                        if (count % 2 == 1)
                            write.WriteLine(line);
                        count++;
                        line = read.ReadLine();
                    }  
                }
            }
        }
    }
}

