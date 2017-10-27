using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.Motherboard.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class MotherboardMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 28;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Motherboard Mask");
			Tooltip.SetDefault("");
		}
	}
}
