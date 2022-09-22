using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace task08_Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> candidates = new SortedDictionary<string, Dictionary<string, int>>();

            string[] inputContest = Console.ReadLine().Split(':');  
            while (inputContest[0] != "end of contests")
            {
                contests.Add(inputContest[0], inputContest[1]);

                inputContest = Console.ReadLine().Split(':');
            }

            string[] inputCandidates = Console.ReadLine().Split("=>");
            while (inputCandidates[0] != "end of submissions")
            {
                string contentName = inputCandidates[0];
                string contentPass = inputCandidates[1];
                string candidatName = inputCandidates[2];
                int pointsContent = int.Parse(inputCandidates[3]);
                
                if (contests.ContainsKey(contentName) && contests[contentName] == contentPass)
                {
                    if (!candidates.ContainsKey(candidatName))
                    {
                        candidates.Add(candidatName, new Dictionary<string, int>());
                    }
                    if (!candidates[candidatName].ContainsKey(contentName))
                    {
                        candidates[candidatName].Add(contentName, pointsContent);
                    }

                    if (candidates[candidatName][contentName] < pointsContent)
                    {
                        candidates[candidatName][contentName] = pointsContent;
                    }
                }
                inputCandidates = Console.ReadLine().Split("=>");
            }

            string bestCandidate = candidates.OrderByDescending(x => x.Value.Values.Sum()).First().Key;
            int bestCandidateTotalPoints = candidates[bestCandidate].Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidateTotalPoints} points.");

            Console.WriteLine("Ranking:");
            foreach (var candidate in candidates)
            {
                var orderByPoints = candidate.Value.OrderByDescending(x => x.Value);
                Console.WriteLine(candidate.Key);
                foreach (var couse in orderByPoints)
                {
                    Console.WriteLine($"#  {couse.Key} -> {couse.Value}");
                }
            }
            
        }
    }
}
