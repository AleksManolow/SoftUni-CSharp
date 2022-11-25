using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;

		private double health;

		private double armor;

		public Character(string name, double health, double armor, double abilityPoints, Bag bag)
		{
			Name= name;
			BaseHealth= health;
			Health= health;
			BaseArmor = armor;
			Armor= armor;	
			AbilityPoints= abilityPoints;
			Bag = bag;	
		}
		
		public IBag Bag { get; private set; }
		public double AbilityPoints { get; private set; }
		public double Armor
		{
			get 
			{ 
				return armor;
			}
			private set 
			{ 
				armor = value;
				if (armor < 0)
				{
					armor = 0;
				}
			}
		}

		public double BaseArmor  { get; private set; }
		public double Health
        {
			get 
			{ 
				return health;
			}
			set 
			{
				health = value;
                if (health < 0)
                {
                    health = 0;
					IsAlive= true;
                }

                if (health > BaseHealth)
				{
					health = BaseHealth;
				}
				
				
			}
		}

		public double BaseHealth { get; private set; }
		public string Name
		{
			get 
			{ 
				return name;
			}
			private set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
				}
				name = value;
			}
		}

		public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
		{
			this.EnsureAlive();
			double leftPoints = hitPoints - this.Armor > 0 ? hitPoints - this.Armor : 0;
			this.Armor -= hitPoints;
			this.Health -= leftPoints;

			if (this.Health == 0)
			{
				IsAlive= false;
			}
		}
        public void UseItem(Item item)
		{
            this.EnsureAlive();
			item.AffectCharacter(this);
        }

    }
}