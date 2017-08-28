using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.CogLord.NPCs
{
	public class CogLordArmSecond : ModNPC
	{
		/// <summary>The Hand (end) of the corresponding arm side. Found using npc.ai[0]</summary>
		NPC targetHand => Main.npc[(int)npc.ai[0]];
		/// <summary>The Upper Arm npc for the corresponding arm side. Found using npc.ai[1]</summary>
		NPC upperArm => Main.npc[(int)npc.ai[1]];

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.width = 112;
			npc.height = 34;

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
			if (targetHand.active && (targetHand.type == mod.NPCType<CogLordGun>() || targetHand.type == mod.NPCType<CogLordHand>()))
			{
				npc.Center = Vector2.Lerp(npc.Center, Helper.CenterPoint(Helper.CenterPoint(upperArm.Center, targetHand.Center), targetHand.Center), 0.2F);
				npc.rotation = MathHelper.Lerp(npc.rotation, Helper.rotateBetween2Points(upperArm.Center, targetHand.Center), 0.2F);
			}
			else
				npc.active = false;

			return false;
		}

		public override void FindFrame(int frameHeight)
		{
			if (npc.frameCounter++ >= 15)
			{
				npc.frame.Y = (npc.frame.Y + frameHeight) % (Main.npcFrameCount[npc.type] * frameHeight);
				npc.frameCounter = 0;
			}

			npc.spriteDirection = npc.direction;
		}
	}
}