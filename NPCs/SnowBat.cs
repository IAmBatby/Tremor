using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class SnowBat : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snow Bat");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 30;
			npc.damage = 16;
			npc.defense = 5;
			npc.knockBackResist = 0.3f;
			npc.width = 22;
			npc.height = 18;
			animationType = 49;
			npc.aiStyle = 14;
			npc.npcSlots = 0.2f;
			npc.HitSound = SoundID.NPCHit1;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath4;
			npc.value = Item.buyPrice(0, 0, 2, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("SnowBatBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				this.NewItem(ItemID.SnowBlock);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
					Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
				}

				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 3f);
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 2f);
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 3f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && Main.cloudAlpha > 0f && spawnInfo.spawnTileY < Main.worldSurface && spawnInfo.player.ZoneSnow ? 0.01f : 0f;
	}
}