using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Tiles {
public class FrostoneOreTile : ModTile
{
    public override void SetDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
dustType = 59;
	AddMapEntry(new Color(0, 0, 0));			
          drop = mod.ItemType("FrostoneOre");
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.1f;
        g = 0.1f;
        b = 0.7f;
    }
}}