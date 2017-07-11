using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class FurCoat : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 34;
			item.value = 600;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fur Coat");
			Tooltip.SetDefault("");
		}

	}
}
