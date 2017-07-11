using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor
{
	class CustomDrop : GlobalTile
	{
		public override bool Drop(int i, int j, int type)
		{
			if (type == TileID.Emerald)
			{
				if (Main.rand.Next(20) == 1)
				{
					Item.NewItem(i * 16, j * 16, 48, 32, mod.ItemType("EmeraldStone"));
					goto il;
				}
			}
			return true;
			il: return false;
		}
	}
}
