using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Brutallisk
{
	[AutoloadEquip(EquipType.Wings)]
	public class BrutalliskWings : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 20;

			item.value = 100000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brutallisk Wings");
			Tooltip.SetDefault("Allows flight and slow fall");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 290;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.45f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 10f;
			acceleration *= 4.5f;
		}
	}
}
