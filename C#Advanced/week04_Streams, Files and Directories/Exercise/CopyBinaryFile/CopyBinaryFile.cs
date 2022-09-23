namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream fs1 = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream fs2 = new FileStream(outputFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int bytesRead = fs1.Read(buffer);
                        if (bytesRead == 0) break;
                        fs2.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
