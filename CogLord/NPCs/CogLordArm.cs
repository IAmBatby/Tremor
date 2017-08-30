using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.CogLord.NPCs
{
	public class CogLordArm : ModNPC
	{
		/// <summary>The Cog Lord boss NPC. Found using npc.ai[0]</summary>
		NPC cogLord => Main.npc[(int)npc.ai[0]];

		/// <summary>The Lower Arm npc for the corresponding arm side. Found using npc.ai[1]</summary>
		NPC lowerArm => Main.npc[(int)npc.ai[1]];

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.width = 104;
			npc.height = 38;

			npc.lifeMax = 1;
			npc.knockBackResist = 0.5f;

			npc.aiStyle = -1;

			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.dontTakeDamage = true;

			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
		}

		public override bool PreAI()
		{
			if (cogLord.active && cogLord.type == mod.NPCType<CogLord>())
			{
				npc.Center = Vector2.Lerp(npc.Center, Helper.CenterPoint(cogLord.Center, lowerArm.Center), 0.2F);
				npc.rotation = MathHelper.Lerp(npc.rotation, npc.rotation = Helper.rotateBetween2Points(cogLord.Center, lowerArm.Center), 0.2F);
			}
			else
				npc.active = false;

			return false;
		}

		public override void FindFrame(int frameHeight)
		{
			if(npc.frameCounter++ >= 15)
			{
				npc.frame.Y = (npc.frame.Y + frameHeight) % (Main.npcFrameCount[npc.type] * frameHeight);
				npc.frameCounter = 0;
			}

			npc.spriteDirection = npc.direction;
		}
	}
}