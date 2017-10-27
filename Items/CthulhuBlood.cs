using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CthulhuBlood : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 30;
			item.maxStack = 1;

			item.value = 255000;
			item.rare = 8;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottled Cthulhu Blood");
			Tooltip.SetDefault("Increased life regeneration\n" +
"Increased alchemical damage and critical strike chance by 25%");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += 3;
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.25f;
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 25;
		}
	}
}
