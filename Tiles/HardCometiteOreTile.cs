using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Tiles
{
	public class HardCometiteOreTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
                                   soundType = 21;
                                   soundStyle = 2;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			dustType = 27;
			drop = mod.ItemType("HardCometiteOre");
			AddMapEntry(new Color(255, 20, 147));
			mineResist = 12f;
			minPick = 225;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.5f;
			g = 0.0f;
			b = 0.7f;
		}

  public override bool CanExplode(int i, int j)
  {
   if (Main.tile[i, j].type == mod.TileType("HardCometiteOreTile"))
   {
    return false;
   }
   return false;
  }

    public override void NearbyEffects(int i, int j, bool closer)
    {
        if(closer)
        {
            Player player = Main.player[Main.myPlayer];
            int style = Main.tile[i, j].frameX / 100;
            string type;
            player.AddBuff(44, 60, true);
        }
    }
	}
}