using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest:Character,IHealer
    {
        //50 Base Health, 25 Base Armor, 40 Ability Points, and a Backpack as a bag.

        private const double constBaseHealth = 50;
        private const double constBaseArmor = 25;
        private const double constAbilityPoints = 40;

        public Priest(string name)
           : base(name,
                 constBaseHealth,
                 constBaseArmor,
                 constAbilityPoints,
                 new Backpack())
        {
        }

        public void Heal(Character character)
        {
            this.EnsureAlive();
            if (character.IsAlive)
            {
                character.Health += AbilityPoints;
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        
    }
}
