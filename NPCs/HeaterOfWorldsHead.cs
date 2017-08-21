using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items;

namespace Tremor.NPCs
{
	public abstract class HeaterofWorldsPart : ModNPC
	{
		public bool JustSpawned
		{
			get { return npc.localAI[0] == 0f; }
			set { npc.localAI[0] = value ? 0f : 1f; }
		}

		public NPC PrevSegment
		{
			get { return Main.npc[(int) npc.ai[1]]; }
		}

		public NPC ParentHead
		{
			get { return Main.npc[(int) npc.ai[2]]; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heater of Worlds");
			NPCID.Sets.TechnicallyABoss[npc.type] = true;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 6500;
			npc.damage = 39;
			npc.defense = 40;
			npc.aiStyle = 6;
			npc.npcSlots = 5f;
			npc.knockBackResist = 1f;
			music = 17;

			npc.noTileCollide = true;
			npc.behindTiles = true;
			npc.friendly = false;
			npc.noGravity = true;
			npc.dontTakeDamage = false;
			npc.dontCountMe = true;
			npc.lavaImmune = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Burning] = true;

			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath10;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.expertMode || Main.rand.NextBool())
			{
				player.AddBuff(BuffID.OnFire, 180);
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2(drawTexture.Width / 2 * 0.5f, drawTexture.Height / Main.npcFrameCount[npc.type] * 0.5f);

			Vector2 drawPos = new Vector2(
				npc.position.X - Main.screenPosition.X + npc.width / 2 - Main.npcTexture[npc.type].Width / 2 * npc.scale / 2f + origin.X * npc.scale,
				npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);

			SpriteEffects effects =
				npc.spriteDirection == -1
					? SpriteEffects.None
					: SpriteEffects.FlipHorizontally;

			spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);

			return false;
		}

		public void CheckSegments()
		{
			if (!PrevSegment.active
				|| !ParentHead.active)
			{
				npc.VanillaHitEffect();
				npc.HitEffect();
				NPCLoot();
				npc.life = 0;
				npc.timeLeft = 0;
				npc.active = false;
			}
		}
	}

	[AutoloadBossHead]
	public class HeaterOfWorldsHead : HeaterofWorldsPart
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			NPCID.Sets.TechnicallyABoss[npc.type] = false;
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			npc.width = 74;
			npc.height = 82;

			npc.boss = true;

			bossBag = mod.ItemType<HeaterOfWorldsBag>();
		}

		public override void AI()
		{
			SegmentBody();
			UpdatePosition();
			UpdateVelocity();
			SpawnAdds();
		}

		private void SpawnAdds()
		{
			int odds =
				Main.expertMode
					? 430
					: 490;

			if (Helper.Chance(odds))
			{
				NPC.NewNPC((int)npc.Center.X - 70, (int)npc.Center.Y, mod.NPCType<MagmaLeechHead>());
			}
		}

		private void UpdatePosition()
		{
			npc.position += npc.velocity;
		}

		private void UpdateVelocity()
		{
			if ((int)(Main.time % 180) == 0)
			{
				float from = npc.AngleFrom(Main.player[npc.target].Center);
				npc.velocity = new Vector2((float)Math.Cos(from), (float)Math.Sin(from)) * -7;
				npc.netUpdate = true;
			}
		}

		private void SegmentBody()
		{
			if (JustSpawned)
			{
				int previous = npc.whoAmI;
				const int segments = 25;

				for (int i = 0; i < segments; i++)
				{
					int type =
						i < segments - 1
							? mod.NPCType<HeaterOfWorldsBody>()
							: mod.NPCType<HeaterOfWorldsTail>();

					// whoAmI is only set in NPC.Update...not NewNPC
					// hence this manual work
					int segmentWhoAmI = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, type, ai1: previous, ai2: npc.whoAmI);
					NPC segment = Main.npc[segmentWhoAmI];
					segment.whoAmI = segmentWhoAmI;
					segment.realLife = npc.whoAmI;
					segment.active = true;
					previous = segmentWhoAmI;
				}

				JustSpawned = false;
			}
		}

		public override void NPCLoot()
		{
			ConvertTiles();
			DropLoot();
		}

		private void ConvertTiles()
		{
			Point16 center = npc.Center.ToTileCoordinates16();
			int halfLength = npc.width / 2 / 16 + 1;
			for (int x = center.X - halfLength; x <= center.X + halfLength; x++)
			{
				for (int y = center.Y - halfLength; y <= center.Y + halfLength; y++)
				{
					Tile tile = Main.tile[x, y];
					if ((x == center.X - halfLength 
						|| x == center.X + halfLength 
						|| y == center.Y - halfLength 
						|| y == center.Y + halfLength) 
						&& !tile.active())
					{
						tile.type = TileID.ObsidianBrick;
						tile.active(true);
					}
					tile.lava(false);
					tile.liquid = 0;
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.SendTileSquare(-1, x, y, 1);
					}
					else
					{
						WorldGen.SquareTileFrame(x, y);
					}
				}
			}
		}

		private void DropLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				if (Main.rand.NextBool())
					npc.SpawnItem((short)mod.ItemType<MoltenParts>());

				if (Main.rand.NextBool())
					npc.SpawnItem(ItemID.HealingPotion, Main.rand.Next(6, 18));

				if (Main.rand.NextBool())
					npc.SpawnItem(ItemID.ManaPotion, Main.rand.Next(6, 18));

				if (Main.rand.NextBool(7))
					npc.SpawnItem((short)mod.ItemType<HeaterOfWorldsMask>());
			}
			
			if (Main.rand.NextBool(10))
				npc.SpawnItem((short)mod.ItemType<HeaterOfWorldsTrophy>());

			TremorWorld.Boss.HeaterofWorlds.Downed(true);
		}
	}
}