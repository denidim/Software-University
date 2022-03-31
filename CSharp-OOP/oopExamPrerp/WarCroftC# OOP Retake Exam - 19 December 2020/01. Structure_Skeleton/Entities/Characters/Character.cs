using System;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        public IBag Bag { get; }

        public double BaseHealth { get; }

        public double BaseArmor { get; }

        public double AbilityPoints { get; }

        protected Character(string name,
                         double health,
                         double armor,
                         double abilityPoints,
                         IBag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        private string name;
        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }

        private double health;
        public double Health
        {
            get => health;

            internal set
            {
                if (value < 0)
                {
                    health = 0;
                }
                if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                else
                    health = value;//todo wtf?????
            }
        }

        private double armor;
        public double Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else if (value > BaseHealth)
                {
                   armor= BaseHealth;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public bool IsAlive { get; set; } = true;

        public void UseItem(Item item)
        {
            EnsureAlive();

            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }


        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                double HealthToBeReduced = hitPoints - Armor;
                Health -= HealthToBeReduced;
                Armor = 0;
            }
            if (Health <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string aliveOrDead = null;
            if (IsAlive)
            {
                aliveOrDead = "Alive";
            }
            else
            {
                aliveOrDead = "Dead";
            }

            sb.AppendLine($"{this.Name} - HP: {Health}/{BaseHealth}, AP: {armor}/{BaseArmor}, Status: {aliveOrDead}");

            return sb.ToString().TrimEnd(); 
        }

        // TODO: Implement the rest of the class.

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}