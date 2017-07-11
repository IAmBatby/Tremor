using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Tiles
{
	public class CometiteOreTile : ModTile
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
			drop = mod.ItemType("CometiteOre");
			AddMapEntry(new Color(0, 191, 255));
			mineResist = 8f;
			minPick = 225;
		}

  public override bool CanExplode(int i, int j)
  {
   if (Main.tile[i, j].type == mod.TileType("CometiteOreTile"))
   {
    return false;
   }
   return false;
  }


    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        if(Main.rand.Next(10) == 0)
        {
            Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("ChargedCrystal"));
            
        }
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
	}
}