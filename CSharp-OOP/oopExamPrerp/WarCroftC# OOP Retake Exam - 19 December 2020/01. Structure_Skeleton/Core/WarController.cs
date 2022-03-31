using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly IList<Character> characters;
		private readonly Stack<Item> items;

		public WarController()
		{
			characters = new List<Character>();
			items = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string charType = args[0];
            string name = args[1];

			Character character;
			if (charType == "Warrior")
			{
				character = new Warrior(name);
			}
			else if (charType == "Priest")
			{
				character = new Priest(name);
			}
			//Type classType = Assembly
			//	.GetCallingAssembly()
			//	.GetTypes()
			//	.FirstOrDefault(x => x.Name == charType);
			//
			//if (classType != null)
			//{
			//	character = (Character)Activator
			//		.CreateInstance(classType, new object[] { name });
            //}
            else
            {
				throw new ArgumentException(string
					.Format(ExceptionMessages
					.InvalidCharacterType, charType));
            }

			characters.Add(character);

			return string.Format(SuccessMessages
				.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item;
			if (itemName == "HealthPotion")
			{
				item = new HealthPotion();
			}
			else if (itemName == "FirePotion")
			{
				item = new FirePotion();
			}

			//Type classType = Assembly
			//	.GetCallingAssembly()
			//	.GetTypes()
			//	.FirstOrDefault(x => x.Name == itemName);

			//if (classType != null)
			//{
			//	item = (Item)Activator
			//		.CreateInstance(classType, new object[] {});
			//}
			else
			{
				throw new ArgumentException(string
					.Format(ExceptionMessages
					.InvalidItem, itemName));
			}

			items.Push(item);

			return string.Format(SuccessMessages
				.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			var curr = characters
				.FirstOrDefault(x => x
				.Name == characterName);

            if (curr == null)
            {
				throw new ArgumentException(string
					.Format(ExceptionMessages
					.CharacterNotInParty, characterName));
            }
            if (items.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages
					.ItemPoolEmpty);
            }

			var currItem = items.Pop();

			curr.Bag.AddItem(currItem);

			return string.Format(string.Format(SuccessMessages
				.PickUpItem, characterName, currItem
				.GetType().Name));
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			var currChar = characters
				.FirstOrDefault(x => x
				.Name == characterName);

			var currItem = currChar.Bag.GetItem(itemName);


            if (currChar == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

			currChar.UseItem(currItem);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

            foreach (var item in characters.OrderByDescending(x=>x.IsAlive).ThenByDescending(x=>x.Health))
            {
				sb.AppendLine(item.ToString().TrimEnd());
			}
			sb.AppendLine();//todo check here (new Lines)????

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			var currAttacker = characters
				.FirstOrDefault(x => x
				.Name == attackerName);

			var currReciever = characters
				.FirstOrDefault(x => x
				.Name == receiverName);

			if (currAttacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}

			if (currReciever == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

            if (currAttacker.GetType().Name == "Priest")
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

			Warrior warrior = currAttacker as Warrior;

			warrior.Attack(currReciever);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{attackerName} attacks {receiverName} for {currAttacker.AbilityPoints} hit points! {receiverName} has {currReciever.Health}/{currReciever.BaseHealth} HP and {currReciever.Armor}/{currReciever.BaseArmor} AP left!");

            if (!currReciever.IsAlive)
            {
				sb.AppendLine($"{receiverName} is dead!");
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			var currHealer = characters
				.FirstOrDefault(x => x
				.Name == healerName);

			var currReceiver = characters
				.FirstOrDefault(x => x
				.Name == healingReceiverName);

            if (currHealer == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

			if (currReceiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
			}

            if (currHealer.GetType().Name == "Warrior")
            {
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal,healerName));
            }

			Priest priest = currHealer as Priest;

			priest.Heal(currReceiver);

			if (currReceiver.Health > 100)
			{
				currReceiver
					.Health = 100;
			}
			return $"{healerName} heals {healingReceiverName} for {currHealer.AbilityPoints}! {healingReceiverName} has {currReceiver.Health} health now!";
		}
	}
}
