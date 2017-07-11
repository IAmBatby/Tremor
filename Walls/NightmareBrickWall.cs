using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Walls {
public class NightmareBrickWall : ModWall
{
    public override void SetDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = mod.ItemType("NightmareBrickWall");
	AddMapEntry(new Color(90, 12, 157));
    }
}}