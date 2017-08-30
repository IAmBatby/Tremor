using Terraria;
using Terraria.ModLoader;

namespace Tremor.Tiles
{
	public class RuinBlocks : GlobalTile
	{
		public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
        {
			if(type == 120)
			{
                if (Main.tile[i, j - 1].type == mod.TileType("RuinAltar"))
                {
                    return false;
                }
			}
			return true;
		}
	}
}
