using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class PyramidRider : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pyramid Rider");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 116;
			npc.damage = 20;
			npc.defense = 10;
			npc.knockBackResist = 0.6f;
			npc.width = 76;
			npc.height = 38;
			animationType = 508;
			npc.aiStyle = 26;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.value = Item.buyPrice(0, 0, 5, 0);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 18, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				if (Main.netMode == 1) return;

				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y + 55, NPCID.WalkingAntlion);
				NPC.NewNPC((int)npc.position.X - 22, (int)npc.position.Y + 55, mod.NPCType<PyramidHead>());
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneDesert && NPC.downedBoss1 && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.03f : 0f;
	}
}