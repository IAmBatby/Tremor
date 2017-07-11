using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ConcentratedTincture : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 450000;
			item.rare = 5;
			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Concentrated Tincture");
			Tooltip.SetDefault("Increases life regeneration from healing flasks");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("ConcentratedTinctureBuff"), 2);
		}
	}
}
