using System;

namespace task03_Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string fileName = text.Substring(text.LastIndexOf("\\") + 1, text.LastIndexOf(".") - text.LastIndexOf("\\") - 1);
            string fileExtension = text.Substring(text.LastIndexOf(".") + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
