using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items;

namespace Tremor.NPCs
{
	public abstract class HeaterofWorldsPart : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heater of Worlds");
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 6500;
			npc.damage = 39;
			npc.defense = 40;
			//npc.knockBackResist = 0f;
			//npc.width = 74;
			//npc.height = 82;
			npc.aiStyle = 6;
			npc.npcSlots = 5f;
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

			//bossBag = mod.ItemType<HeaterOfWorldsBag>();
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
				player.AddBuff(BuffID.OnFire, 180, true);
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2(drawTexture.Width / 2 * 0.5F, drawTexture.Height / Main.npcFrameCount[npc.type] * 0.5f);

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
			if (!Main.npc[(int)npc.ai[1]].active)
			{
				npc.life = 0;
				npc.HitEffect();
				NPCLoot();
				npc.active = false;
			}
		}
	}

	[AutoloadBossHead]
	public class HeaterOfWorldsHead : HeaterofWorldsPart
	{
		public bool IsSegmented
		{
			get => npc.ai[0] == 1f;
			set => npc.ai[0] = value ? 1f : 0f;
		}

		public override void SetDefaults()
		{
			npc.width = 74;
			npc.height = 82;
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

			if (Main.rand.Next(odds) == 0)
			{
				NPC.NewNPC((int)npc.Center.X - 70, (int)npc.Center.Y, mod.NPCType<MagmaLeechHead>());
			}
		}

		private void UpdatePosition()
		{
			npc.position += npc.velocity * (2 - 1);
		}

		private void UpdateVelocity()
		{
			if ((int)(Main.time % 180) == 0)
			{
				Vector2 vector = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
				float birdRotation = (float)Math.Atan2(vector.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
				npc.velocity.X = (float)(Math.Cos(birdRotation) * 7) * -1;
				npc.velocity.Y = (float)(Math.Sin(birdRotation) * 7) * -1;
				npc.netUpdate = true;
			}
		}

		private void SegmentBody()
		{
			if (!IsSegmented)
			{
				int previous = npc.whoAmI;

				for (int i = 0; i < 25; i++)
				{
					int type =
						i < 24
							? mod.NPCType<HeaterOfWorldsBody>()
							: mod.NPCType<HeaterOfWorldsTail>();

					NPC segment = Main.npc[
						NPC.NewNPC((int) npc.position.X + npc.width / 2, (int) npc.position.Y + npc.width / 2, type, npc.whoAmI)];

					segment.realLife = npc.whoAmI;
					segment.ai[2] = npc.whoAmI;
					segment.ai[1] = previous;
					Main.npc[previous].ai[0] = segment.whoAmI;
					//NetMessage.SendData(23, -1, -1, "", segment.whoAmI, 0f, 0f, 0f, 0);
					previous = segment.whoAmI;
				}

				IsSegmented = true;
			}
		}

		public override void NPCLoot()
		{
			ConvertTiles();
			DropLoot();

			TremorWorld.downedHeaterofWorlds = true;
		}

		private void ConvertTiles()
		{
			int centerX = (int)(npc.position.X + npc.width / 2) / 16;
			int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
			int halfLength = npc.width / 2 / 16 + 1;
			for (int x = centerX - halfLength; x <= centerX + halfLength; x++)
			{
				for (int y = centerY - halfLength; y <= centerY + halfLength; y++)
				{
					if ((x == centerX - halfLength || x == centerX + halfLength || y == centerY - halfLength || y == centerY + halfLength) && !Main.tile[x, y].active())
					{
						Main.tile[x, y].type = TileID.ObsidianBrick;
						Main.tile[x, y].active(true);
					}
					Main.tile[x, y].lava(false);
					Main.tile[x, y].liquid = 0;
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.SendTileSquare(-1, x, y, 1);
					}
					else
					{
						WorldGen.SquareTileFrame(x, y, true);
					}
				}
			}
		}

		private void DropLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();

				if (Helper.Chance(10))
					npc.SpawnItem((short)mod.ItemType<HeaterOfWorldsTrophy>());
			}
			else
			{
				if (Main.rand.NextBool())
					npc.SpawnItem((short)mod.ItemType<MoltenParts>());

				if (Main.rand.NextBool())
					npc.SpawnItem(ItemID.HealingPotion, Main.rand.Next(6, 18));

				if (Main.rand.NextBool())
					npc.SpawnItem(ItemID.ManaPotion, Main.rand.Next(6, 18));

				if (Helper.Chance(7))
					npc.SpawnItem((short)mod.ItemType<HeaterOfWorldsMask>());

			}
		}
	}
}