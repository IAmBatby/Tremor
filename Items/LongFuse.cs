using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class LongFuse : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 25000;
			item.rare = 5;
			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Long Fuse");
			Tooltip.SetDefault("Alchemical weapons throws further");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("LongFuseBuff"), 2);
		}
	}
}
