using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tremor.CogLord.NPCs
{
	/*
	 * npc.ai[0] = Index of the Cog Lord boss in the Main.npc array.
	 * npc.ai[1] = State manager.
	 * npc.ai[2] = Timer.
	 */

	public class CogLordHand : ModNPC
	{
		NPC cogLord => Main.npc[(int)npc.ai[0]];

		const float MaxDist = 250f;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Hand");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.width = 44;
			npc.height = 84;

			npc.damage = 80;
			npc.defense = 20;
			npc.lifeMax = 20000;
			npc.knockBackResist = 0f;

			npc.aiStyle = 12;

			npc.noGravity = true;
			npc.noTileCollide = true;

			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;

			npc.value = Item.buyPrice(0, 0, 5, 0);
		}
		
		public override void AI()
		{
			npc.dontTakeDamage = NPC.AnyNPCs(mod.NPCType<CogLordProbe>());

			if (npc.ai[1] == 0)
			{
				npc.damage = 80;

				if (npc.ai[2]++ >= 1000)
				{
					npc.ai[1] = 1;
					npc.ai[2] = 0;
				}
			}
			else if (npc.ai[1] == 1)
			{
				npc.dontTakeDamage = true;
				npc.damage = 120;

				if (npc.ai[2]++ >= 500)
				{
					npc.ai[1] = 0;
					npc.ai[2] = 0;
				}
			}				
			
			Vector2 Distance = npc.Center - cogLord.Center;
			if (Distance.Length() >= MaxDist)
			{
				Distance.Normalize();
				Distance *= MaxDist;
				npc.Center = cogLord.Center + Distance;
			}
		}

		public override void FindFrame(int frameHeight)
		{
			if (npc.ai[1] == 0)
				npc.frame.Y = 0;
			if (npc.ai[1] == 1)
				npc.frame.Y = frameHeight;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CogLordHand"), 1f);
		}

		public override bool PreNPCLoot() => false;
	}
}