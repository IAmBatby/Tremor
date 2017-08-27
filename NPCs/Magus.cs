using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;
using Tremor.Projectiles;

namespace Tremor.NPCs
{
	public class Magus : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magus");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 290;
			npc.damage = 65;
			npc.defense = 18;
			npc.knockBackResist = 0.3f;
			npc.width = 42;
			npc.height = 56;
			animationType = 29;
			npc.aiStyle = -1;
			npc.npcSlots = 15f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 1, 21);
		}
		
		public override void AI()
		{
			if ((int)Main.time % 180 == 0)
			{
				DoAI();
				Teleport();
			}
		}

		public void Teleport()
		{
			for (int i = 0; i < 10; i++)
				Main.dust[Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 68, npc.velocity.X + Main.rand.Next(-10, 10), npc.velocity.Y + Main.rand.Next(-10, 10), 5, npc.color, 2.6f)].noGravity = true;

			npc.position.X = (Main.player[npc.target].position.X - 500) + Main.rand.Next(1000);
			npc.position.Y = (Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000);
		}

		public void DoAI()
		{
			if (Main.netMode == 1) return;

			float SpeedX = Main.LocalPlayer.Center.X - npc.Center.X;
			float SpeedY = Main.LocalPlayer.Center.Y - npc.Center.Y;
			float Length = (float)Math.Sqrt(SpeedX * SpeedX + SpeedY * SpeedY);
			float Speed = 8;
			Length = Speed / Length;
			SpeedX = SpeedX * Length;
			SpeedY = SpeedY * Length;
			int Proj = Projectile.NewProjectile(npc.Center.X - 10f, npc.Center.Y, SpeedX, SpeedY, mod.ProjectileType<MagusBall>(), 14, 1f, Main.myPlayer);
			Main.projectile[Proj].timeLeft = 300;
			Main.projectile[Proj].netUpdate = true;
		}

		public override void FindFrame(int frameHeight)
		{
			if (npc.frameCounter++ >= 50)
			{
				npc.frame.Y = (npc.frame.Y + frameHeight) % (Main.npcFrameCount[npc.type] * frameHeight);
				npc.frameCounter = 0;
			}
		}

		public override void NPCLoot()
		{
			if (Main.invasionType == InvasionID.GoblinArmy)
			{
				Main.invasionSize -= 1;
				if (Main.invasionSize < 0)
					Main.invasionSize = 0;
				if (Main.netMode != 1)
					Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, Main.invasionSizeStart, InvasionID.GoblinArmy + 3, 0);
				if (Main.netMode == 2)
					NetMessage.SendData(78, -1, -1, null, Main.invasionProgress, Main.invasionProgressMax, Main.invasionProgressIcon, 0f, 0, 0, 0);
			}

			if (Main.rand.Next(50) == 0)
				this.NewItem(mod.ItemType<MagusTome>());
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.invasionType == InvasionID.GoblinArmy && Main.hardMode && spawnInfo.spawnTileY < Main.worldSurface ? 0.08f : 0f;
	}
}