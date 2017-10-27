using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class PetsBuffs : GlobalBuff
	{
		public override void Update(int type, Player player, ref int buffIndex)
		{
			if (type == 41)
			{
				player.buffImmune[44] = true;
				player.buffImmune[46] = true;
				player.buffImmune[47] = true;
			}
			if (type == 42)
			{
				player.statDefense += 8;
			}
			if (type == 45)
			{
				player.moveSpeed += 0.15f;
			}
			if (type == 50)
			{
				player.aggro -= 400;
			}
			if (type == 51)
			{
				player.jumpBoost = true;
			}
			if (type == 52)
			{
				player.endurance += 0.20f;
			}
			if (type == 53)
			{
				player.autoJump = true;
			}
			if (type == 54)
			{
				player.armorPenetration += 8;
			}
			if (type == 55)
			{
				player.detectCreature = true;
			}
			if (type == 56)
			{
				player.manaRegenDelayBonus++;
				player.manaRegenBonus += 20;
			}
			if (type == 61)
			{
				player.meleeDamage += 0.08f;
				player.magicDamage += 0.08f;
				player.rangedDamage += 0.08f;
				player.thrownDamage += 0.08f;
				player.minionDamage += 0.08f;
			}
			if (type == 65)
			{
				player.findTreasure = true;
			}
			if (type == 81)
			{
				player.spikedBoots = 1;
				player.spikedBoots = 2;
			}
			if (type == 82)
			{
				player.statManaMax2 += 100;
			}
			if (type == 84)
			{
				player.maxMinions += 1;
			}
			if (type == 85)
			{
				player.meleeCrit += 8;
				player.magicCrit += 8;
				player.rangedCrit += 8;
				player.thrownCrit += 8;
			}
			if (type == 91)
			{
				player.meleeSpeed += 0.1f;
			}
			if (type == 92)
			{
				player.aggro += 400;
			}
			if (type == 127)
			{
				player.pickSpeed -= 0.12f;
			}
			if (type == 136)
			{
				player.lifeRegen += 5;
			}
			if (type == 154)
			{
				player.statLifeMax2 += 50;
			}
		}
		/*
				public override void ModifyBuffTip(int type, ref string tip, ref int rare)
				{
					if (type == 41)
					{
						tip = "Grants immunity to frozen effects");
					}
					if (type == 42)
					{
						tip = "Increases your defense");
					}
					if (type == 45)
					{
						tip = "Gives extra speed");
					}
					if (type == 50)
					{
						tip = "Enemies are less likely to target you");
					}
					if (type == 51)
					{
						tip = "Increases jump height");
					}
					if (type == 52)
					{
						tip = "Reduces damage taken by 20%";
					}
					if (type == 53)
					{
						tip = "Allows auto-jump");
					}
					if (type == 54)
					{
						tip = "Increases armor penetration");
					}
					if (type == 55)
					{
						tip = "Detects creatures");
					}
					if (type == 56)
					{
						tip = "Increases mana regeneration rate");
					}
					if (type == 61)
					{
						tip = "8% increased damage";
					}
					if (type == 65)
					{
						tip = "Detect treasures and ores");
					}
					if (type == 81)
					{
						tip = "Grants ability to climb walls");
					}
					if (type == 82)
					{
						tip = "Increase maximum mana by 100");
					}
					if (type == 84)
					{
						tip = "Allows you to summon another minion");
					}
					if (type == 85)
					{
						tip = "8% increased all crit chanse";
					}
					if (type == 91)
					{
						tip = "Increases your melee speed");
					}
					if (type == 92)
					{
						tip = "Enemies are more likely to target you");
					}
					if (type == 127)
					{
						tip = "Make your pickaxe faster");
					}
					if (type == 136)
					{
						tip = "Increases regeneration");
					}
					if (type == 154)
					{
						tip = "Increases max health by 50");
					}
				}
		*/
	}
}
