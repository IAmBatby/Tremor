using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Tiles {
public class DevilForge : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileTable[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
        TileObjectData.addTile(Type);
        animationFrameHeight = 36;
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Devil Forge");		
	AddMapEntry(new Color(179, 146, 113), name);
    }

public override void AnimateTile(ref int frame, ref int frameCounter)
{
    frameCounter++;
    if(frameCounter > 6)
    {
        frameCounter = 0;
        frame++;
        frame %= 4;
    }
}

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("DevilForge"));
    }
}}