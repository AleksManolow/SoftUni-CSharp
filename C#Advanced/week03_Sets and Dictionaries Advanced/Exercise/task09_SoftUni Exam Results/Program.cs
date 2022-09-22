using System;
using System.Collections.Generic;
using System.Linq;

namespace task09_SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> languages = new Dictionary<string, int>();
            Dictionary<string, List<int>> candidates = new Dictionary<string, List<int>>();

            string[] input = Console.ReadLine().Split('-');
            while (input[0]!= "exam finished")
            {
                if (input[1] == "banned")
                {
                    candidates.Remove(input[0]);
                }
                else
                {
                    string name = input[0];
                    string langluage = input[1];
                    int points = int.Parse(input[2]);
                    if (!languages.ContainsKey(langluage))
                    {
                        languages.Add(langluage, 0);
                    }
                    languages[langluage]++;
                    if (!candidates.ContainsKey(name))
                    {
                        candidates.Add(name, new List<int>());
                    }
                    candidates[name].Add(points);
                }
                input = Console.ReadLine().Split('-');
            }
            candidates = candidates
                .OrderByDescending(x => x.Value.Max())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Results:");
            foreach (var candidate in candidates)
            {
                Console.WriteLine($"{candidate.Key} | {candidate.Value.Max()}");
            }
            languages = languages
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Submissions:");
            foreach (var language in languages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }

        }
    }
}
