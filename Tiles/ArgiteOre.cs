using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Tiles
{
	public class ArgiteOre: ModTile
{
    public override void SetDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
        dustType = 44;
        soundType = 21;
        soundStyle = 2;
        minPick = 65; 
        AddMapEntry(new Color(95, 201, 64));
        drop = mod.ItemType("ArgiteOre");
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.5f;
        g = 0.5f;
        b = 0.5f;
    }

  public override bool CanExplode(int i, int j)
  {
   if (Main.tile[i, j].type == mod.TileType("ArgiteOre"))
   {
    return false;
   }
   return false;
  }
}}