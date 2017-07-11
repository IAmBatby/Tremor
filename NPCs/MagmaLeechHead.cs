using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class MagmaLeechHead : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magma Leech");
		}

		bool TailSpawned = false;

		public static int ShootRate = 20;
		const int ShootDamage = 58;
		const float ShootKN = 1.0f;
		const int ShootType = 100;
		const float ShootSpeed = 10;
		const int ShootCount = 5;
		const int spread = 2;
		const float spreadMult = 0.045f;

		const int ShootSound = 62;
		const int ShootSoundStyle = 1;

		int TimeToShoot = ShootRate;
		public override void SetDefaults()
		{
			npc.lifeMax = 250;
			npc.damage = 15;
			npc.defense = 10;
			npc.knockBackResist = 0f;
			npc.width = 74;
			npc.height = 82;
			npc.aiStyle = 6;
			npc.npcSlots = 1f;
			npc.noTileCollide = true;
			npc.behindTiles = true;
			npc.friendly = false;
			npc.dontTakeDamage = false;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.buffImmune[24] = true;
			npc.buffImmune[67] = true;
			npc.lavaImmune = true;
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.Next(1) == 0)
			{
				player.AddBuff(24, 180, true);
			}
		}


		public override void AI()
		{

			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color, 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color, 1f);
			}

			npc.position += npc.velocity * (2 - 1);

			if (!TailSpawned)
			{
				int Previous = npc.whoAmI;
				for (int num36 = 0; num36 < 14; num36++)
				{
					int lol = 0;
					if (num36 >= 0 && num36 < 13)
					{
						lol = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.width / 2), mod.NPCType("MagmaLeechBody"), npc.whoAmI);
					}
					else
					{
						lol = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.width / 2), mod.NPCType("MagmaLeechTail"), npc.whoAmI);
					}
					Main.npc[lol].realLife = npc.whoAmI;
					Main.npc[lol].ai[2] = (float)npc.whoAmI;
					Main.npc[lol].ai[1] = (float)Previous;
					Main.npc[Previous].ai[0] = (float)lol;
					//NetMessage.SendData(23, -1, -1, "", lol, 0f, 0f, 0f, 0);
					Previous = lol;
				}
				TailSpawned = true;
			}

			if ((int)(Main.time % 180) == 0)
			{
				Vector2 vector = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
				float birdRotation = (float)Math.Atan2(vector.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
				npc.velocity.X = (float)(Math.Cos(birdRotation) * 7) * -1;
				npc.velocity.Y = (float)(Math.Sin(birdRotation) * 7) * -1;
				npc.netUpdate = true;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);

			Vector2 drawPos = new Vector2(
				npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
				npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);

			SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);

			return false;
		}
	}
}