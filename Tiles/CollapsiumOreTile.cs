using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Tiles
{
	public class CollapsiumOreTile : ModTile
{
    public override void SetDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
dustType = 62;
                                   soundType = 21;
                                   soundStyle = 2;
mineResist = 15f;
minPick = 250;
	AddMapEntry(new Color(255, 20, 147));
          drop = mod.ItemType("CollapsiumOre");

    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.9f;
        g = 0.1f;
        b = 0.5f;
    }

  public override bool CanExplode(int i, int j)
  {
   if (Main.tile[i, j].type == mod.TileType("CollapsiumOreTile"))
   {
    return false;
   }
   return false;
  }
}}