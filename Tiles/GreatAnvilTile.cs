using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Tiles
{
	public class GreatAnvilTile : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 36;
        TileObjectData.addTile(Type);
        dustType = 7;
		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Great Anvil");			
	AddMapEntry(new Color(162, 162, 162), name);
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        if(frameX == 0)
        {
            Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("GreatAnvil"));
        }
    }
}}