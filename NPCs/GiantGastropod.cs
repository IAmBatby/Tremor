using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class GiantGastropod : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Giant Gastropod");
			Main.npcFrameCount[npc.type] = 11;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 3200;
			npc.damage = 150;
			npc.defense = 70;
			npc.knockBackResist = 0.1f;
			npc.width = 40;
			npc.height = 40;
			animationType = 122;
			npc.aiStyle = 22;
			aiType = 122;
			npc.noGravity = true;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.buffImmune[20] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[31] = false;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.value = Item.buyPrice(0, 0, 12, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("GiantGastropodBanner");
		}

		public override void AI()
		{
			if (Main.rand.Next(4) == 0)
				Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 72, 0f, 0f, 200, npc.color)].velocity *= 0.3f;
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.NewItem(ItemID.Glowstick, 6);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 72, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 72, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 72, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for(int i = 0; i < 2; ++i)
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/GGGore{i+1}"), 1f);

				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 72, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 72, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && !Main.dayTime && NPC.downedMoonlord && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneHoly && spawnInfo.spawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}