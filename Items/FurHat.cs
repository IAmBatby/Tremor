using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class FurHat : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 22;
			item.value = 10000;
			item.rare = 2;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fur Hat");
			Tooltip.SetDefault("");
		}

	}
}
