using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Tiles
{
	public class LunarRootTile : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        //TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 36;
        TileObjectData.addTile(Type);
        dustType = 7;
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.Table, TileObjectData.newTile.Width, 0);
	AddMapEntry(new Color(120, 85, 60));
			mineResist = 8f;
			minPick = 200;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        if(Main.rand.NextBool())
        {
            Item.NewItem(i * 16, j * 16, 16, 16, 3460, Main.rand.Next(1,3));
        }
        if(Main.rand.Next(2) == 0)
        {
            Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("LunarRoot"), Main.rand.Next(1,5));
        }
        if(Main.rand.Next(4) == 0)
        {
            Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("NightCore"), Main.rand.Next(1,2));
            
        }
    }

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.5f;
			g = 0.0f;
			b = 0.7f;
		}
}}