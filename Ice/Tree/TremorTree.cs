using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace Tremor.Ice.Tree
{
	public class TremorTree : ModTree
	{
		private Mod mod => Tremor.instance;

		/* TODO: TreeCrash does not exist
		public override int CreateDust()
		{
			return mod.DustType<TreeCrash>();
		}
		*/

		public override int GrowthFXGore()
		{
			return mod.GetGoreSlot("Ice/Tree/TremorTreeFX");
		}

		public override int DropWood()
		{
			return mod.ItemType("GlacierWood");
		}

		public override Texture2D GetTexture()
		{
			return mod.GetTexture("Ice/Tree/TremorTree");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return mod.GetTexture("Ice/Tree/TremorTree_Branches");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
			return mod.GetTexture("Ice/Tree/TremorTree_Tops");
		}
	}
}