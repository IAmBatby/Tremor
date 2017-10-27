using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	public class GlacierWoodTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			dustType = 80;
			AddMapEntry(new Color(0, 191, 255));
			drop = mod.ItemType("GlacierWood");
			Main.tileMerge[Type][mod.TileType("IceBlock")] = true;
			Main.tileMerge[Type][TileID.IceBlock] = true; // normal ice
			Main.tileMerge[Type][TileID.BreakableIce] = true; // thin ice
			Main.tileMerge[Type][TileID.CorruptIce] = true; // purple ice
			Main.tileMerge[Type][TileID.HallowedIce] = true; // pink ice
			Main.tileMerge[Type][TileID.SnowBlock] = true; // snow
		}

	}
}
