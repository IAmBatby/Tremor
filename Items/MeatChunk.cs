using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.IO;

namespace Tremor.Items
{
	public class MeatChunk : ModItem
	{
		public override void SetDefaults()
		{

			item.rare = 3;
			item.maxStack = 30;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meat Chunk");
			Tooltip.SetDefault("");
		}

	}
}
