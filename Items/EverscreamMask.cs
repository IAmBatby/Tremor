using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class EverscreamMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 32;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Everscream Mask");
			Tooltip.SetDefault("");
		}

	}
}
