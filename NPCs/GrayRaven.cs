using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class GrayRaven : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gray Raven");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.width = 36;
			npc.height = 26;
			npc.aiStyle = 17;
			npc.damage = 22;
			npc.defense = 5;
			npc.lifeMax = 58;
			npc.HitSound = SoundID.NPCHit1;
			npc.knockBackResist = 0.85f;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 50f;
			animationType = 301;
			bannerItem = mod.ItemType("GrayRavenBanner");
		}


		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RavenFeather"), Main.rand.Next(1, 3));
				}

			}
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			{
				player.AddBuff(30, 60, true);
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrayRavenGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrayRavenGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrayRavenGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrayRavenGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Helper.NoZoneAllowWater(spawnInfo)) && Main.hardMode && y > Main.rockLayer ? 0.01f : 0f;
		}
	}
}