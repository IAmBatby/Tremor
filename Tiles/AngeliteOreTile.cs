using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Tiles
{
	public class AngeliteOreTile : ModTile
{
    public override void SetDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
dustType = 57;
                                   soundType = 21;
                                   soundStyle = 2;
mineResist = 15f;
minPick = 250;
	AddMapEntry(new Color(0, 191, 255));
          drop = mod.ItemType("AngeliteOre");
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0f;
        g = 0.3f;
        b = 0.9f;
    }

  public override bool CanExplode(int i, int j)
  {
   if (Main.tile[i, j].type == mod.TileType("AngeliteOreTile"))
   {
    return false;
   }
   return false;
  }
}}