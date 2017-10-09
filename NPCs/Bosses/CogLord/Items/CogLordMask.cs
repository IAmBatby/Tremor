using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.CogLord.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class CogLordMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 24;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Mask");
			Tooltip.SetDefault("");
		}

	}
}
