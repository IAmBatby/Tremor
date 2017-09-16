using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ChaoticAmplifier : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;

			item.value = 120000;
			item.rare = 5;
			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaotic Amplifier");
			Tooltip.SetDefault("The less health, the more crit chance...");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statLife < 50)
			{
				player.magicCrit += 20;
				player.meleeCrit += 20;
				player.rangedCrit += 20;
			}
			if (player.statLife < 100)
			{
				player.magicCrit += 15;
				player.meleeCrit += 15;
				player.rangedCrit += 15;
			}
			if (player.statLife < 200)
			{
				player.magicCrit += 10;
				player.meleeCrit += 10;
				player.rangedCrit += 10;
			}
			if (player.statLife < 300)
			{
				player.magicCrit += 5;
				player.meleeCrit += 5;
				player.rangedCrit += 5;
			}
		}
	}
}
