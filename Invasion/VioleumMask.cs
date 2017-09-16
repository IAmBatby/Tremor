using Terraria.ModLoader;

namespace Tremor.Invasion
{
	[AutoloadEquip(EquipType.Head)]
	public class VioleumMask : ModItem
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
			DisplayName.SetDefault("Violeum Mask");
			Tooltip.SetDefault("");
		}

		public override bool DrawHead()
		{
			return false;
		}
	}
}
