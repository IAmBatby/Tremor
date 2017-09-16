using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class LeatherShirt : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 18;
			item.value = 200;
			item.rare = 1;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leather Shirt");
			Tooltip.SetDefault("");
		}

	}
}
