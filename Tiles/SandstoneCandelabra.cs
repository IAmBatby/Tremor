using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;


namespace Tremor.Tiles {
public class SandstoneCandelabra : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.StyleHorizontal = true;
        //TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.StyleWrapLimit = 36;
        TileObjectData.addTile(Type);
        dustType = 7;
        Main.tileLighted[Type] = true; 
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
	AddMapEntry(new Color(233, 211, 123));
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
            Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("SandstoneCandelabra"));
        }
    }
}}