namespace EvenLines
{
    using System;
    using System.IO;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string outStr = string.Empty;

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = reader.ReadLine();
                int count = 0;
                while (line != null)
                {
                    if (count % 2 == 0)
                    {
                        line = string.Join('@', line.Split(new char[] { '-', ',', '.', '!', '?' }));
                        string[] tempArr = line.Split(' ');
                        for (int i = tempArr.Length - 1; i >= 0; i--)
                        {
                            outStr = outStr + ' ' + tempArr[i];
                        }
                        outStr += "\n";    
                    }
                    
                    count++;
                    line = reader.ReadLine();
                }
            }


            return outStr;
        }
    }
}
