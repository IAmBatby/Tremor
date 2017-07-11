using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Tiles {
public class BlastFurnace : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        //TileObjectData.newTile.CoordinateHeights = new int[]{16};
        TileObjectData.addTile(Type);
        animationFrameHeight = 54;
 Main.tileLighted[Type] = true; 
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Blast Furnace");		
	AddMapEntry(new Color(117, 117, 117), name);
        adjTiles = new int[]{TileID.Furnaces};
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.1f;
        g = 0.1f;
        b = 0.1f;
    }

public override void AnimateTile(ref int frame, ref int frameCounter)
{
    frameCounter++;
    if(frameCounter > 4)
    {
        frameCounter = 0;
        frame++;
        frame %= 8;
    }
}

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("BlastFurnace"));
    }
}}