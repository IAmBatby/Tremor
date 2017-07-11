using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class MagiumFlyer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magium Flyer");
			Main.npcFrameCount[npc.type] = 4;
		}

		const int SpeedMulti = 3; // Множитель скорости

		public override void SetDefaults()
		{
			npc.lifeMax = 100;
			npc.damage = 30;
			npc.defense = 20;
			npc.knockBackResist = 0.0f;
			npc.width = 34;
			npc.height = 48;
			animationType = 93;
			npc.aiStyle = 14;
			npc.npcSlots = 1f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath4;
			npc.value = Item.buyPrice(0, 0, 6, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("MagiumFlayerBanner");
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
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 59, (float)hitDirection, -2f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 59, (float)hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 59, (float)hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 59, (float)hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 59, (float)hitDirection, -2f, 0, default(Color), 0.7f);
				}
			}
		}

	}
}