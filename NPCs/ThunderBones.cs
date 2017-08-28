using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Tremor.Items;

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
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ThunderBonesBanner");
		}

		public override void AI()
		{
			if (Main.rand.Next(9) == 0)
				Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 180, 0f, 0f, 200, npc.color)].velocity *= 0.3f;
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(20) == 0)
				this.NewItem(mod.ItemType<Bonecrusher>());
			if (Main.rand.NextBool())
				this.NewItem(mod.ItemType<TearsofDeath>(), Main.rand.Next(1, 6));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore5"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TBGore5"), 1f);

				if (Main.netMode == 1) return;

				NPC.NewNPC((int)npc.position.X + 32, (int)npc.position.Y - 48, mod.NPCType<BoneFish>());
				NPC.NewNPC((int)npc.position.X + 16, (int)npc.position.Y - 48, mod.NPCType<BoneFish>());
				NPC.NewNPC((int)npc.position.X - 32, (int)npc.position.Y - 48, mod.NPCType<BoneFish>());
				NPC.NewNPC((int)npc.position.X - 16, (int)npc.position.Y - 48, mod.NPCType<BoneFish>());
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss3 && Main.bloodMoon && spawnInfo.spawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}