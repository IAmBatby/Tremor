using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class Dragon_HeadB : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Dragon");
		}

		bool TailSpawned;

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
			npc.damage = 28;
			npc.npcSlots = 5f;
			npc.width = 78;
			npc.height = 132;
			npc.defense = 12;
			npc.lifeMax = 3100;
			npc.aiStyle = 6;
			npc.npcSlots = 1f;
			npc.noTileCollide = true;
			npc.behindTiles = true;
			npc.friendly = false;
			npc.dontTakeDamage = false;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[24] = true;
			npc.buffImmune[67] = true;
			npc.lavaImmune = true;
			music = MusicID.Boss2;
			npc.boss = true;
			bossBag = mod.ItemType("AncientDragonBag");
		}

		public override void NPCLoot()
		{

			if (Main.expertMode)
			{
				npc.DropBossBags();
			}

			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientDragonMask"));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientDragonTrophy"));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Helper.DropItem(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Drop(mod.ItemType("AncientTimesEdge"), 1, 1), new Drop(mod.ItemType("DragonHead"), 1, 1), new Drop(mod.ItemType("Swordstorm"), 1, 1), new Drop(0, 0, 0));
				}
				TremorWorld.downedAncientDragon = true;

			}
		}


		public override void AI()
		{
			npc.position += npc.velocity * (2 - 1);

			if (!TailSpawned)
			{
				int Previous = npc.whoAmI;
				for (int num36 = 0; num36 < 19; num36++)
				{
					int lol = 0;
					if (num36 >= 0 && num36 < 18)
					{
						lol = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.width / 2), mod.NPCType("Dragon_BodyB"), npc.whoAmI);
					}
					else
					{
						lol = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.width / 2), mod.NPCType("Dragon_LegB"), npc.whoAmI);
					}
					Main.npc[lol].realLife = npc.whoAmI;
					Main.npc[lol].ai[2] = npc.whoAmI;
					Main.npc[lol].ai[1] = Previous;
					Main.npc[Previous].ai[0] = lol;
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