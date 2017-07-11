using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Ice.Items {
public class GlacierArmchairTile : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
        TileObjectData.newTile.CoordinateHeights = new int[]{16, 16};
        TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
        TileObjectData.newTile.StyleWrapLimit = 2; //not really necessary but allows me to add more subtypes of chairs below the example chair texture
        TileObjectData.newTile.StyleMultiplier = 2; //same as above
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight; //allows me to place example chairs facing the same way as the player
        TileObjectData.addAlternate(1); //facing right will use the second texture style
        TileObjectData.addTile(Type);
	AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
	AddMapEntry(new Color(116, 150, 252));
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("GlacierArmchair"));
    }
}}
