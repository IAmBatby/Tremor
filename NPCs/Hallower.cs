using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class Hallower : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallower");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 5000;
			npc.damage = 150;
			npc.defense = 70;
			npc.knockBackResist = 0.1f;
			npc.width = 40;
			npc.height = 40;
			animationType = 121;
			npc.aiStyle = 14;
			aiType = 75;
			npc.noGravity = true;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit5;
			npc.buffImmune[20] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[31] = false;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.value = Item.buyPrice(0, 0, 5, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("HallowerBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				this.NewItem(ItemID.PixieDust, 5);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
		}

		public override void AI()
		{
			if (Main.rand.NextBool(6))
				Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 55, 0f, 0f, 200, npc.color)].velocity *= 0.3f;
			if (Main.rand.Next(40) == 0)
				Main.PlaySound(27, (int)npc.position.X, (int)npc.position.Y, 1);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && NPC.downedMoonlord && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneHoly && spawnInfo.spawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}