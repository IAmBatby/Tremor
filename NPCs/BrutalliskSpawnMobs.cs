using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.ZombieEvent;
//using Terraria.Content.Fonts;

namespace Tremor.NPCs
{
	public class BrutalliskSpawnMobs : ModPlayer
	{
		public override void PostUpdate()
		{
			const int XOffset = 1200;
			const int YOffset = 1200;

			if (NPC.AnyNPCs(mod.NPCType("Brutallisk")))
			{
				if (Main.rand.Next(380) == 1)
					NPC.NewNPC((int)Main.player[Main.myPlayer].Center.X + XOffset, (int)Main.player[Main.myPlayer].Center.Y - YOffset, mod.NPCType("Quetzalcoatl"), 0, NPC.NewNPC((int)Main.player[Main.myPlayer].Center.X + XOffset, (int)Main.player[Main.myPlayer].Center.Y + YOffset, mod.NPCType("")));
				if (Main.rand.Next(380) == 1)
					NPC.NewNPC((int)Main.player[Main.myPlayer].Center.X - XOffset, (int)Main.player[Main.myPlayer].Center.Y - YOffset, mod.NPCType("Quetzalcoatl"), 0, NPC.NewNPC((int)Main.player[Main.myPlayer].Center.X + XOffset, (int)Main.player[Main.myPlayer].Center.Y + YOffset, mod.NPCType("")));
			}
		}
	}
}
