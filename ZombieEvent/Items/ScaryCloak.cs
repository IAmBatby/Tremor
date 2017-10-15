using Terraria;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class ScaryCloak : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 20;
			item.alpha = 100;
			item.value = 1100;
			item.rare = 3;
			item.defense = 3;

			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scary Cloak");
			Tooltip.SetDefault("Makes the player invisible\n" +
	  "Increases magic and summon damage and critical strike chanse by 8");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.magicDamage += 0.08f;
			player.magicCrit += 8;
			player.minionDamage += 0.08f;
			//player.minionCrit += 8;
			player.shroomiteStealth = true;
		}
	}
}
