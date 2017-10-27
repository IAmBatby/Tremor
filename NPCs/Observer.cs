using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{

	public class Observer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Observer");
			Main.npcFrameCount[npc.type] = 4;
		}
		
		const int ShootDamage = 20;
		const float ShootKN = 1.0f;
		const float ShootSpeed = 4;

		int TimeToShoot = 0;

		public override void SetDefaults()
		{
			npc.lifeMax = 2500;
			npc.damage = 80;
			npc.defense = 32;
			npc.knockBackResist = 0f;
			npc.width = 130;
			npc.height = 130;
			animationType = 82;
			npc.aiStyle = 22;
			npc.npcSlots = 0.5f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit31;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 55, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("ObserverBanner");

			TimeToShoot = 0;
		}

		public override void AI()
		{
			if (Main.netMode != 1 && TimeToShoot++ >= 250 && npc.target != -1)
			{
				Vector2 velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center) * ShootSpeed;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ProjectileID.DeathLaser, ShootDamage, ShootKN);
				TimeToShoot = 0;
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(15) == 0)
				this.NewItem(mod.ItemType<Spearaxe>());
			if (Main.rand.Next(15) == 0)
				this.NewItem(mod.ItemType<ScarredReaper>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ObserverGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ObserverGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ObserverGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ObserverGore4"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && Main.hardMode && Main.bloodMoon && spawnInfo.spawnTileY < Main.worldSurface ? 0.006f : 0f;
	}
}