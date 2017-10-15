using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class AndasCore : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 20;

			item.value = 500000;
			item.rare = 10;
			item.expert = true;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Andas Core");
			Tooltip.SetDefault("Allows flight\n" +
"Has infinite flight time\n" +
"Has big flight speed");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 9999999;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true; //�।��� ����஢����
			player.armorEffectDrawShadowLokis = true; //�����쪨� ⥭�
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 3f;
			ascentWhenRising = 2f;
			maxCanAscendMultiplier = 3f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 40f;
			acceleration *= 4f;
		}
	}
}
