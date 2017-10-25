using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Heaven
{
	[AutoloadEquip(EquipType.Body)]
	public class HeavenBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 18;

			item.value = 6000;
			item.rare = 3;
			item.defense = 7;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heaven Breastplate");
			Tooltip.SetDefault("12% increased ranged damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.12f;
		}

	}
}
