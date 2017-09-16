using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GoldenStar : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 36;
			item.height = 38;
			item.value = 12500;

			item.rare = 9;
			item.expert = true;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Star");
			Tooltip.SetDefault("The less health, the more alchemical damage\n'Rare alchemical artifact'");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statLife < 50)
			{
				player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.35f;
			}
			if (player.statLife < 100)
			{
				player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.25f;
			}
			if (player.statLife < 200)
			{
				player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.15f;
			}
			if (player.statLife < 300)
			{
				player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.05f;
			}
		}

	}
}
