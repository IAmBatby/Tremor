using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;
using Tremor.Items.Souls;

namespace Tremor.NPCs
{
	public class NorthWind : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("North Wind");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 80;
			npc.damage = 15;
			npc.defense = 8;
			npc.knockBackResist = 0.7f;
			npc.width = 24;
			npc.height = 44;
			animationType = 82;
			npc.aiStyle = 22;
			npc.npcSlots = 0.4f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.alpha = 100;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 7, 15);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("NorthWindBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(2))
				this.NewItem(mod.ItemType<FrostCore>());
			if (NPC.downedMoonlord && Main.rand.NextBool(5))
				this.NewItem(mod.ItemType<IceSoul>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				}

				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && Main.cloudAlpha > 0f && spawnInfo.spawnTileY < Main.worldSurface && spawnInfo.player.ZoneSnow ? 0.06f : 0f;
	}
}