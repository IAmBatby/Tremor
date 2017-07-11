using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Tiles
{
	public class RedBrickChimney : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.addTile(Type);
        animationFrameHeight = 56;
        TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 18};
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
	AddMapEntry(new Color(117, 117, 117));
    }

public override void AnimateTile(ref int frame, ref int frameCounter)
{
    frameCounter++;
    if(frameCounter > 5)
    {
        frameCounter = 0;
        frame++;
        frame %= 6;
    }
}

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("RedBrickChimney"));
    }
}}