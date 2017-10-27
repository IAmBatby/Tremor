using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice
{
	public class IceWallW : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = false;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = 1;
			item.consumable = true;
			item.createWall = mod.WallType("IceWall");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Everfrost Wall");
			Tooltip.SetDefault("");
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
		}

	}
}
