using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Tiles {
public class GloomstoneLantern : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.Height = 2;
        TileObjectData.newTile.CoordinateHeights = new int[]{16, 16};
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.addTile(Type);
        dustType = -1;
        Main.tileLighted[Type] = true; 
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
	AddMapEntry(new Color(8, 91, 146));
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.9f;
        g = 0.9f;
        b = 0.9f;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        if(frameX == 0)
        {
            Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("GloomstoneLantern"));
        }
    }
}}