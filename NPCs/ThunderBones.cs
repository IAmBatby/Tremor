using Terraria.ID;
using Terraria;
using Terraria.ModLoader;


namespace Tremor.NPCs
{

	public class ThunderBones : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thunder Bones");
			Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
		{
			aiType = 77;
			npc.lifeMax = 500;
			npc.damage = 30;
			npc.defense = 10;
			npc.knockBackResist = 0.3f;
			npc.width = 36;
			npc.height = 44;
			animationType = 482;
			npc.aiStyle = 3;
			npc.npcSlots = 0.6f;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 6, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("ThunderBonesBanner");
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Bonecrusher"));
				};
				if (Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TearsofDeath"), Main.rand.Next(1, 5));
				};
			}
		}
		public override void AI()
		{
			if (Main.rand.Next(9) == 0)
			{
				int num706 = Dust.NewDust(npc.position, npc.width, npc.height, 180, 0f, 0f, 200, npc.color, 1f);
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
				NPC.NewNPC((int)npc.position.X + 32, (int)npc.position.Y - 48, mod.NPCType("BoneFish"));
				NPC.NewNPC((int)npc.position.X + 16, (int)npc.position.Y - 48, mod.NPCType("BoneFish"));
				NPC.NewNPC((int)npc.position.X - 32, (int)npc.position.Y - 48, mod.NPCType("BoneFish"));
				NPC.NewNPC((int)npc.position.X - 16, (int)npc.position.Y - 48, mod.NPCType("BoneFish"));
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore5"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore5"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (Tremor.NoZoneAllowWater(spawnInfo)) && NPC.downedBoss3 && Main.bloodMoon && y < Main.worldSurface ? 0.01f : 0f;
		}


	}
}