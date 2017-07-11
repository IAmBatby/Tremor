using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Ice.Dungeon
{
	public class DungeonBlock : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileMerge[Type][mod.TileType("IceBlock")] = true;
			Main.tileMerge[Type][mod.TileType("VeryVeryIce")] = true;
			Main.tileMerge[Type][147] = true;
			dustType = mod.DustType("IceDust");
			drop = mod.ItemType("DungeonBlockItem");
			AddMapEntry(new Color(70, 156, 213));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
		}
	}
}