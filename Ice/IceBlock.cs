using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice
{
	public class IceBlock : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = false;
			Main.tileLighted[Type] = false;
			dustType = 80;
			drop = 664;
			soundType = 21;
			soundStyle = 2;
			AddMapEntry(new Color(84, 166, 229));
			Main.tileMerge[Type][mod.TileType("IceOre")] = true;
			Main.tileMerge[Type][mod.TileType("VeryVeryIce")] = true;
			Main.tileMerge[Type][mod.TileType("DungeonBlock")] = true;
			Main.tileMerge[Type][161] = true;
			Main.tileMerge[Type][162] = true;
			Main.tileMerge[Type][163] = true;
			Main.tileMerge[Type][164] = true;
			Main.tileMerge[Type][147] = true;
		}

		public bool CanGrow(int i, int j)
		{
			bool flag = false;
			for (int x = 0; x < 3; x++)
				for (int y = 0; y < 3; y++)
				{
					if (!Main.tile[i - 1 + x, j - 1 + y].active())
						flag = true;
				}
			return flag;
		}

		/*public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Player player = Main.player[Main.myPlayer];
                int style = Main.tile[i, j].frameX / 15;
                string type;
                Main.player[Main.myPlayer].GetModPlayer<TremorPlayer>(mod).ZoneIce = true;
                TremorPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<TremorPlayer>(mod);
                modPlayer.ZoneIce = true;
            } 
        } */

		/*public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i - 1, j].type > 0 && CanGrow(i - 1, j))
            {
                Main.tile[i - 1, j].type = (ushort)mod.TileType("IceBlock");
            }
            if (Main.tile[i + 1, j].type > 0 && CanGrow(i + 1, j))
            {
                Main.tile[i + 1, j].type = (ushort)mod.TileType("IceBlock");
            }
            if (Main.tile[i, j - 1].type > 0 && CanGrow(i, j - 1))
            {
                Main.tile[i, j - 1].type = (ushort)mod.TileType("IceBlock");
            }
            if (Main.tile[i, j + 1].type > 0 && CanGrow(i, j + 1))
            {
                Main.tile[i, j + 1].type = (ushort)mod.TileType("IceBlock");
            }
        } */
	}
}