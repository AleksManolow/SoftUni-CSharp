namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                string sentence = wordsReader.ReadToEnd().ToLower();
                string[] allWords = sentence.Split(' ');
                for (int i = 0; i < allWords.Length; i++)
                {
                    wordCounts.Add(allWords[i], 0);
                }
            }

            using (StreamReader textReader = new StreamReader(textFilePath))
            {
                string line = textReader.ReadLine();
                while (line != null)
                {
                    string[] wordInLine = line
                        .ToLower()
                        .Split(new char[] { ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in wordInLine)
                    {
                        if (wordCounts.ContainsKey(word))
                        {
                            wordCounts[word]++;
                        }
                    }

                    line = textReader.ReadLine();
                }
            }
            wordCounts = wordCounts
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            using (StreamWriter write = new StreamWriter(outputFilePath))
            {
                foreach (var word in wordCounts)
                {
                    write.WriteLine(word.Key + " - " + word.Value);
                }
            }
        }

    }
}
