using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class HeaterOfWorldsTail : HeaterofWorldsPart
	{
		public override void SetDefaults()
		{
			npc.width = 30;
			npc.height = 62;	
		}

		public override void AI()
		{
			CheckSegments();
		}

		public override bool CheckActive()
		{
			return false;
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}
	}
}