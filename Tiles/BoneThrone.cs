using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Tiles
{
	public class BoneThrone : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
        TileObjectData.newTile.CoordinateHeights = new int[]{16, 16, 16, 16};
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 36;
        TileObjectData.addTile(Type);
        dustType = 7;
	AddMapEntry(new Color(120, 85, 60));
    }

public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if(Main.tile[i, j].frameX == 0 && Main.tile[i, j].frameY == 0)
        {
            Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("BoneThrone") );
        }
    }
}}