using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	public class GlacierWoodWallWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			drop = mod.ItemType("GlacierWoodWall");
			AddMapEntry(new Color(36, 43, 102));
		}

	}
}
