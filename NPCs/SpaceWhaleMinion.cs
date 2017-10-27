using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class SpaceWhaleMinion : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Space Whale Minion");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.width = 72;
			npc.height = 62;
			npc.damage = 74;
			npc.defense = 80;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.lifeMax = 100;
			npc.npcSlots = 5f;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = Item.buyPrice(0, 0, 3, 12);
			npc.knockBackResist = 0.1f;
			npc.aiStyle = 74;
			aiType = 418;
			animationType = 23;
		}

		public override void AI()
		{
			if (Main.rand.NextBool(4))
				Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color, 2f)].velocity *= 0.3f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);

				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.6f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.6f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.6f);
				}

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SpaceWhaleMinionGore"), 1f);
			}
		}
	}
}
