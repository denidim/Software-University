using System;
using System.Collections.Generic;
using System.Linq;

namespace footballTeamGenerator
{
    public abstract class Skills
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        protected Skills(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get => endurance;
            private set
            {
                ThrowExeptionAndSetName(value, nameof(Endurance));
                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                ThrowExeptionAndSetName(value, nameof(Sprint));
                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private set
            {
                ThrowExeptionAndSetName(value,nameof(Dribble));
                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                ThrowExeptionAndSetName(value, nameof(Passing));
                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                ThrowExeptionAndSetName(value, nameof(Shooting));
                shooting = value;
            }
        }

        private void ThrowExeptionAndSetName(int value,string name)
        {
            if (value < 0 || value > 100)
            {
                throw new Exception($"{name} should be between 0 and 100.");
            }
        }
    }

    public class Player : Skills
    {
        private string name;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
            : base(endurance, sprint, dribble, passing, shooting)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                name = value;
            }
        }

        public double SkillLevel => (double)(Endurance + Sprint + Dribble + Passing + Shooting) / 5;
    }

    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                name = value;
            }
        }

        public IReadOnlyCollection<Player> Players
        {
            get => players;
        }

        public void Add(Player player)
        {
            players.Add(player);
        }

        public void Remove(string playerName)
        {
            Player currPlayer = players.FirstOrDefault(x => x.Name == playerName);

            if (players.Contains(currPlayer))
            {
                players.Remove(currPlayer);
            }
            else
            {
                throw new Exception($"Player {playerName} is not in {Name} team.");
            }
        }
        public int Rating
        {
            get => players.Count == 0
                ? 0
                : (int)Math.Round(players.Average(x => x.SkillLevel));
        }
    }

    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (input[0] == "Team")
                    {
                        string name = input[1];

                        if (!teams.ContainsKey(name))
                        {
                            teams.Add(name, new Team(name));
                        }
                    }

                    if (input[0] == "Add")
                    {
                        string teamName = input[1];

                        string playerName = input[2];

                        int endurance = int.Parse(input[3]);
                        int sprint = int.Parse(input[4]);
                        int dribble = int.Parse(input[5]);
                        int passing = int.Parse(input[6]);
                        int shooting = int.Parse(input[7]);

                        if (teams.ContainsKey(teamName))
                        {
                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams[teamName].Add(player);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                    }
                    if (input[0] == "Remove")
                    {
                        string teamName = input[1];
                        string playerName = input[2];
                        teams[teamName].Remove(playerName);
                    }
                    if (input[0] == "Rating")
                    {
                        string teamName = input[1];
                        if (teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
