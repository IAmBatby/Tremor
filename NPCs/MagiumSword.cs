using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Tremor.NPCs
{

	public class MagiumSword : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magium Sword");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 30;
			npc.damage = 30;
			Main.npcFrameCount[npc.type] = 6;
			npc.defense = 24;
			npc.knockBackResist = 0f;
			npc.width = 34;
			npc.height = 34;
			animationType = 84;
			npc.aiStyle = 23;
			npc.noGravity = true;
			npc.npcSlots = 15f;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 0, 0);
		}


		public override void AI()
		{
			if (Main.rand.Next(6) == 0)
			{
				int num706 = Dust.NewDust(npc.position, npc.width, npc.height, 59, 0f, 0f, 200, npc.color, 2f);
				Main.dust[num706].velocity *= 0.3f;
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
			}
		}



	}
}