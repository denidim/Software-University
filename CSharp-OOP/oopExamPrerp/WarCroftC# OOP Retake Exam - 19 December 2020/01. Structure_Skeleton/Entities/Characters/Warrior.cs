using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character,IAttacker
    {
        //100 Base Health, 50 Base Armor, 40 Ability Points, and a Satchel as a bag.
        private const double constBaseHealth = 100;
        private const double constBaseArmor = 50;
        private const double constAbilityPoints = 40;

        public Warrior(string name)
            : base(name,
                  constBaseHealth,
                  constBaseArmor,
                  constAbilityPoints,
                  new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (this.Equals(character))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

                character.TakeDamage(constAbilityPoints);
        }
    }
}
