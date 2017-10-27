using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Heaven
{
	[AutoloadEquip(EquipType.Legs)]
	public class HeavenLeggings : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 6000;

			item.rare = 3;
			item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heaven Leggings");
			Tooltip.SetDefault("15% decreased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed -= 0.15f;
		}
	}
}
