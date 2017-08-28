using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class FatFlinx : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fat Flinx");
			Main.npcFrameCount[npc.type] = 12;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 3000;
			npc.damage = 110;
			npc.defense = 45;
			npc.knockBackResist = 0.9f;
			npc.width = 46;
			npc.height = 46;
			animationType = 185;
			npc.aiStyle = 3;
			aiType = 166;
			npc.npcSlots = 0.3f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath23;
			npc.value = Item.buyPrice(0, 0, 9, 15);
		}

		public override void NPCLoot()
		{
			if (NPC.downedMoonlord && Main.rand.Next(5) == 0)
				npc.NewItem(mod.ItemType<IceSoul>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				}

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FFGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FFGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FFGore1"), 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.hardMode && NPC.downedMoonlord && spawnInfo.player.ZoneSnow && spawnInfo.spawnTileY > Main.rockLayer ? 0.1f : 0f;
	}
}