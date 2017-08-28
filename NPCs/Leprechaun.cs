using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class Leprechaun : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leprechaun");
			Main.npcFrameCount[npc.type] = 14;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 500;
			npc.damage = 15;
			npc.defense = 14;
			npc.knockBackResist = 0f;
			npc.width = 28;
			npc.height = 46;
			npc.aiStyle = 87;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 3, 0, 0);
			animationType = NPCID.BigMimicHallow;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 31, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, 220, 1f);
				Gore.NewGore(npc.position, npc.velocity, 221, 1f);
				Gore.NewGore(npc.position, npc.velocity, 222, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.spawnTileY > Main.rockLayer ? 0.0007f : 0f;
	}
}