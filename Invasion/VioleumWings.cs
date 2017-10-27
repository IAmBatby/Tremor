using Terraria;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	[AutoloadEquip(EquipType.Wings)]
	public class VioleumWings : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 20;
			item.value = 500000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradox Wings");
			Tooltip.SetDefault("Allows flight and slow fall");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 180;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 10f;
			acceleration *= 2.5f;
		}
	}
}
