using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{

	public class LittleMushroomBug : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Little Mushroom Bug");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 30;
			npc.damage = 28;
			npc.defense = 10;
			npc.knockBackResist = 0.2f;
			npc.width = 28;
			npc.height = 26;
			animationType = 2;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.aiStyle = 14;
			aiType = 49;
			npc.npcSlots = 5f;
			npc.HitSound = SoundID.NPCHit35;
			npc.DeathSound = SoundID.NPCDeath57;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 67, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 67, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 67, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
		}
	}
}