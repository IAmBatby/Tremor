using Terraria.ModLoader;

namespace Tremor.Items.Bone
{
	[AutoloadEquip(EquipType.Head)]
	public class BoneMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 24;
			item.rare = 2;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Mask");
			Tooltip.SetDefault("");
		}

	}
}
