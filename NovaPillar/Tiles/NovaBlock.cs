using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Tiles
{
	public class NovaBlock : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMerge[Type][TileID.LunarBlockSolar] = true;
			Main.tileMerge[Type][TileID.LunarBlockVortex] = true;
			Main.tileMerge[Type][TileID.LunarBlockNebula] = true;
			Main.tileMerge[Type][TileID.LunarBlockStardust] = true;
			Main.tileMerge[TileID.LunarBlockSolar][Type] = true;
			Main.tileMerge[TileID.LunarBlockVortex][Type] = true;
			Main.tileMerge[TileID.LunarBlockNebula][Type] = true;
			Main.tileMerge[TileID.LunarBlockStardust][Type] = true;
			Main.tileLighted[Type] = true;
			dustType = 57;
			drop = mod.ItemType("NovaFragmentBlock");
			AddMapEntry(Color.Yellow);
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.8f;
			g = 0.7f;
			b = 0.3f;
		}
	}
}
