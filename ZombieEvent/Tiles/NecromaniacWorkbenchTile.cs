using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.ZombieEvent.Tiles
{
	public class NecromaniacWorkbenchTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new[]{ 16, 16 };
			TileObjectData.addTile(Type);
		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Necromaniac Workbench");			
			AddMapEntry(new Color(0, 77, 255), name);
                       adjTiles = new[]{mod.TileType("FleshWorkstationTile")};
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("NecromaniacWorkbench"));
		}
	}
}