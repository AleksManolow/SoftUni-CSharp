using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
        private List<Character> characters;
        private List<Item> items;
        public WarController()
        {
            characters = new List<Character>();
            items = new List<Item>();
        }
        public string JoinParty(string[] args)
		{
			string characterType = args[0];
            string name = args[1];

            Character character;
            switch (characterType)
			{
				case "Warrior":
					character = new Warrior(name);
					break;
                case "Priest":
                    character = new Priest(name);
                    break;
                default:
					throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}
			characters.Add(character);
			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

            Item item = null;
            switch (itemName)
            {
                case "FirePotion":
                    item = new FirePotion();
                    break;
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }
			items.Add(item);
			return string.Format(SuccessMessages.AddItemToPool, itemName);

        }

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			Character character = characters.FirstOrDefault(x => x.Name == characterName);
			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			if (!items.Any())
			{
				throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
            }
			character.Bag.AddItem(items.Last());

			items.RemoveAt(items.Count - 1);
			return string.Format(SuccessMessages.PickUpItem, characterName, items.GetType().Name);
        }

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = characters.FirstOrDefault(x => x.Name == characterName);
			if (character == null)
			{
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var character in characters.OrderByDescending(x => x.IsAlive).OrderByDescending(x => x.Health))
			{
                string lifeStatus = character.IsAlive == true ? "Alive" : "Dead";

                sb.AppendLine(string.Format(SuccessMessages.CharacterStats,
					character.Name, 
					character.Health, character.BaseHealth ,
					character.Armor, character.BaseArmor,
                    lifeStatus));
			}
			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = characters.FirstOrDefault(x => x.Name == attackerName);
			Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);
			if (attacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiver));
			}

			if (attacker.GetType().Name == "Priest")
			{
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
			Warrior warrior = attacker as Warrior;
			warrior.Attack(receiver);

			StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName,
                attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor,
                receiver.BaseArmor));

            if (receiver.IsAlive == false)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

            return sb.ToString().TrimEnd();
        }

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

            var targetHealer = characters.FirstOrDefault(c => c.Name == healerName);
            var targetToHeal = characters.FirstOrDefault(c => c.Name == healingReceiverName);
            if (targetHealer == null)
			{
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
			if (targetToHeal == null) 
			{
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

			if (targetHealer.GetType().Name == "Warrior")
			{
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Priest healer = targetHealer as Priest;
            healer.Heal(targetToHeal);

            return string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, healer.AbilityPoints,
                healingReceiverName, targetToHeal.Health);

        }
	}
}
