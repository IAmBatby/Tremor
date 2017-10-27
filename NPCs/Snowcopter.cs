using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class Snowcopter : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snowcopter");
			Main.npcFrameCount[npc.type] = 8;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 600;
			npc.damage = 55;
			npc.defense = 46;
			npc.knockBackResist = 0.1f;
			npc.width = 58;
			npc.height = 36;
			animationType = 347;
			npc.aiStyle = 62;
			aiType = 347;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.npcSlots = 3f;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 8, 7);
			banner = npc.type;
			bannerItem = mod.ItemType("SnowcopterBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, 61, 1f);
				Gore.NewGore(npc.position, npc.velocity, 61, 1f);
				Gore.NewGore(npc.position, npc.velocity, 62, 1f);
				Gore.NewGore(npc.position, npc.velocity, 62, 1f);
				Gore.NewGore(npc.position, npc.velocity, 63, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> NPC.AnyNPCs(NPCID.SnowBalla) && Main.hardMode && spawnInfo.spawnTileY < Main.worldSurface ? 0.06f : 0f;
	}
}