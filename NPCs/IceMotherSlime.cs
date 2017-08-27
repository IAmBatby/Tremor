using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class IceMotherSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Mother Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 120;
			npc.damage = 22;
			npc.defense = 4;
			npc.knockBackResist = 0.6f;
			npc.width = 32;
			npc.height = 22;
			animationType = 1;
			npc.aiStyle = 1;
			aiType = 141;
			npc.npcSlots = 0.1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 6, 50);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("IceMotherSlimeBanner");
		}

		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
				Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 80, 0f, 0f, 200, npc.color)].velocity *= 0.3f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
				}

				if (Main.netMode == 1) return;

				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 48, NPCID.IceSlime);
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 48, NPCID.IceSlime);
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 48, NPCID.IceSlime);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.spawnTileY < Main.worldSurface && spawnInfo.player.ZoneSnow ? 0.01f : 0f;
	}
}