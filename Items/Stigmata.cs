using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Stigmata : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;

			item.value = 20000;
			item.rare = 2;
			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stigmata");
			Tooltip.SetDefault("The less health, the more damage...");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statLife < 50)
			{
				player.magicDamage += 0.20f;
				player.meleeDamage += 0.20f;
				player.rangedDamage += 0.20f;
			}
			if (player.statLife < 100)
			{
				player.magicDamage += 0.15f;
				player.meleeDamage += 0.15f;
				player.rangedDamage += 0.15f;
			}
			if (player.statLife < 200)
			{
				player.magicDamage += 0.10f;
				player.meleeDamage += 0.10f;
				player.rangedDamage += 0.10f;
			}
			if (player.statLife < 300)
			{
				player.magicDamage += 0.05f;
				player.meleeDamage += 0.05f;
				player.rangedDamage += 0.05f;
			}
		}
	}
}
