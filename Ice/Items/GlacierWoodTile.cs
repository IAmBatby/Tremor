using System;
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
			Main.tileMerge[Type][161] = true;
			Main.tileMerge[Type][162] = true;
			Main.tileMerge[Type][163] = true;
			Main.tileMerge[Type][164] = true;
			Main.tileMerge[Type][147] = true;
		}

	}
}
