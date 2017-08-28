using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class FireBeetle : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Beetle");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 3000;
			npc.damage = 150;
			npc.defense = 72;
			npc.knockBackResist = 0.1f;
			npc.width = 40;
			npc.height = 40;
			animationType = 508;
			npc.aiStyle = 3;
			aiType = 508;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit41;
			npc.buffImmune[20] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[31] = false;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.value = Item.buyPrice(0, 0, 12, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("FireBeetleBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
				npc.NewItem(ItemID.HellstoneBar, 3);
			if (Main.rand.Next(2) == 0)
				npc.NewItem(mod.ItemType<FireFragment>(), 3);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FBGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FBGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FBGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FBGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FBGore2"), 1f);

				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && NPC.downedMoonlord && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}