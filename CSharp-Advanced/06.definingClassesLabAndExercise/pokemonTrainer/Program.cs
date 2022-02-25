using System;
using System.Collections.Generic;
using System.Linq;

namespace pokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons {get;set;}

        public Trainer(List<Pokemon> pokemons)
        {
            Pokemons = pokemons;
        }

        public override string ToString()
        {
            int count = Pokemons.Count;
            return $"{Name} {NumberOfBadges} {count}";
        }
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }

    public class StartUp//Program
    {
        static void Main(string[] args)
        {
            //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
            List<Trainer> trainers = new List<Trainer>();
            string command;

            while ((command = Console.ReadLine()) != "Tournament")
            {
                Trainer trainer = new Trainer(new List<Pokemon>());
                Pokemon pokemon = new Pokemon();

                string[] tockens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tockens[0];

                string pokemonName = tockens[1];
                string element = tockens[2];
                int health = int.Parse(tockens[3]);

                pokemon.Name = pokemonName;
                pokemon.Element = element;
                pokemon.Health = health;

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    trainer.Name = trainerName;
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
                else
                {
                    var curr = trainers.Find(t => t.Name == trainerName);
                    curr.Pokemons.Add(pokemon);
                }
            }

            string elements;
            while ((elements = Console.ReadLine()) != "End")
            {
                Func<Trainer, bool> pokemonExist = t => t.Pokemons.Any(e => e.Element == elements);
                Func<Trainer, bool> pokemonDontExist = t => t.Pokemons.All(e => e.Element != elements);

                foreach (var trainer in trainers.Where(pokemonExist))
                {
                    trainer.NumberOfBadges += 1;
                }

                foreach (var trainer in trainers.Where(pokemonDontExist))
                {
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        pokemon.Health -= 10;
                        if (pokemon.Health <= 0)
                        {
                            trainer.Pokemons.Remove(pokemon);
                            break;
                        }
                    }

                }
            }
            foreach (var item in trainers.OrderByDescending(x=>x.NumberOfBadges))
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
