using System;
using System.Collections.Generic;
using System.Linq;

namespace task05_Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>(numberOfTeams);
            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] inputForTeam = Console.ReadLine()
                                    .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                string currentCreator = inputForTeam[0];
                string currentTeamNeme = inputForTeam[1];

                bool isTeamNameExist = teams
                    .Select(x => x.TeamName).Contains(currentTeamNeme);

                bool isCreatorExist = teams
                    .Any(x => x.CreatorName == currentCreator);

                if (isTeamNameExist == false && isCreatorExist == false)
                {
                    Team currentTeam = new Team(currentTeamNeme, currentCreator);

                    teams.Add(currentTeam);

                    Console.WriteLine("Team {0} has been created by {1}!", currentTeamNeme, currentCreator);
                }
                else if (isTeamNameExist)
                {
                    Console.WriteLine("Team {0} was already created!", currentTeamNeme);
                }
                else if (isCreatorExist)
                {
                    Console.WriteLine("{0} cannot create another team!", currentCreator);
                }
            }

            while (true)
            {
                string fensForTeam = Console.ReadLine();
                if (fensForTeam  == "end of assignment")
                {
                    break;
                }
                string[] inputAssignment = fensForTeam.Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);


                string fen = inputAssignment[0];

                string ofFensTeam = inputAssignment[1];

                bool isTeamExist = teams.Any(x => x.TeamName == ofFensTeam);

                bool isCreatorCheating = teams.Any(x => x.CreatorName == fen);
                bool isAlreadyFen = teams.Any(x => x.Members.Contains(fen));

                if (isTeamExist && isCreatorCheating == false && isAlreadyFen == false)
                {
                    int indexOfTeam = teams
                        .FindIndex(x => x.TeamName == ofFensTeam);

                    teams[indexOfTeam].Members.Add(fen);
                }
                else if (isTeamExist == false)
                {
                    Console.WriteLine("Team {0} does not exist!", ofFensTeam);
                }
                else if (isAlreadyFen || isCreatorCheating)
                {
                    Console.WriteLine("Member {0} cannot join team {1}!", fen, ofFensTeam);
                }
            }

            List<Team> teamWithMember = teams
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .ToList();

            List<Team> notValidTeam = teams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.TeamName)
                .ToList();

            foreach (var team in teamWithMember)
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine("- " + team.CreatorName);
                team.Members.Sort();
                Console.WriteLine(string.Join(Environment.NewLine, team.Members.Select(x => "-- " + x)));
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in notValidTeam)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
    class Team
    {
        public string TeamName { get; set; }
        public string CreatorName { get; set; }
        public List<string> Members { get; set; }

        public Team(string teamName, string creatorName)
        {
            TeamName = teamName;

            CreatorName = creatorName;

            Members = new List<string>();

        }

    }
}
