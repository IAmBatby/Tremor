using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class IndifferentTotemMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 24;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Indifferent Totem Mask");
			Tooltip.SetDefault("");
		}

	}
}
