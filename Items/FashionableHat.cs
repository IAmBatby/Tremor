using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class FashionableHat : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 22;
			item.value = 80000;
			item.rare = 11;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fashionable Hat");
			Tooltip.SetDefault("");
		}

	}
}
