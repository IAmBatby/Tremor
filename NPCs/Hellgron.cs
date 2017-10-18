using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class Hellgron : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hellgron");
			Main.npcFrameCount[npc.type] = 14;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 200;
			npc.damage = 26;
			npc.defense = 16;
			npc.knockBackResist = 0.7f;
			npc.width = 44;
			npc.height = 36;
			animationType = 180;
			npc.aiStyle = 2;
			aiType = 180;
			npc.npcSlots = 0.8f;
			npc.noTileCollide = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[31] = false;
			npc.HitSound = SoundID.NPCHit27;
			npc.DeathSound = SoundID.NPCDeath30;
			npc.value = Item.buyPrice(0, 0, 25, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("HellgronBanner");
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
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellgronGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellgronGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellgronGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellgronGore3"), 1f);
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.6f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && spawnInfo.spawnTileY > Main.maxTilesY - 200 ? 0.03f : 0;
	}
}