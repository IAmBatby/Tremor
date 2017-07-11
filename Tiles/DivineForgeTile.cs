using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Tiles {
public class DivineForgeTile : ModTile
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
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Divine Forge");		
	AddMapEntry(new Color(255, 20, 147), name);	
        adjTiles = new int[]{412,133,16,17,134};
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.9f;
        g = 0.1f;
        b = 0.5f;
    }

public override void AnimateTile(ref int frame, ref int frameCounter)
{
    frameCounter++;
    if(frameCounter > 8)
    {
        frameCounter = 0;
        frame++;
        frame %= 4;
    }
}

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("DivineForge"));
    }
}}