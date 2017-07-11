using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Tiles {
public class CoalBlock : ModTile
{
    public override void SetDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
dustType = 54;
	AddMapEntry(new Color(0, 0, 0));
          drop = mod.ItemType("Charcoal");
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.5f;
        g = 0.5f;
        b = 0.5f;
    }
}}