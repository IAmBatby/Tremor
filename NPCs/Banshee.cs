using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class Banshee : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Banshee");
			Main.npcFrameCount[npc.type] = 9;
		}

		public override void SetDefaults()
		{
			npc.width = 50;
			npc.height = 62;
			npc.damage = 21;
			npc.defense = 10;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 5, 7);
			npc.knockBackResist = 0.3f;
			npc.aiStyle = 3;
			aiType = 529;
			animationType = 529;
			npc.buffImmune[20] = true;
			npc.buffImmune[31] = false;
			npc.buffImmune[24] = true;
			banner = npc.type;
			bannerItem = mod.ItemType("BansheeBanner");
			NPCID.Sets.TrailCacheLength[npc.type] = 5;
		}


		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width, Main.npcTexture[npc.type].Height * 0.8f);
			for (int k = 0; k < npc.oldPos.Length; k++)
			{
				SpriteEffects effect = SpriteEffects.None;
				if (npc.direction == 1) { effect = SpriteEffects.FlipHorizontally; }
				if (npc.direction == -1) { effect = SpriteEffects.None; }
				Vector2 drawPos = npc.oldPos[k] - Main.screenPosition;
				Color color = npc.GetAlpha(lightColor) * ((float)(npc.oldPos.Length - k) / (float)npc.oldPos.Length);
				Rectangle frame = new Rectangle(0, 0, 50, 62);
				frame.Y += 164 * (k / 60);


				spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, frame, color, 0, Vector2.Zero, npc.scale, effect, 1f);
			}
			return true;
		}

		public override void AI()
		{

			if (Main.rand.Next(500) == 0)
			{
				Main.PlaySound(101, (int)npc.position.X, (int)npc.position.Y, 1);
			}
			if (Main.rand.Next(500) == 0)
			{
				Main.PlaySound(100, (int)npc.position.X, (int)npc.position.Y, 1);
			}
			if (Main.rand.Next(500) == 0)
			{
				Main.PlaySound(102, (int)npc.position.X, (int)npc.position.Y, 1);
			}
			for (int num74 = npc.oldPos.Length - 1; num74 > 0; num74--)
			{
				npc.oldPos[num74] = npc.oldPos[num74 - 1];
			}
			npc.oldPos[0] = npc.position;
		}


		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 177, 2);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 178, 2);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 179, 2);
				};
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 180, 2);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 181, 2);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 182, 2);
				};
				if (Main.rand.Next(32) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThunderRay"));
				};
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BansheeGore1"), 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BansheeGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BansheeGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BansheeGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (Tremor.NoZoneAllowWater(spawnInfo)) && y > Main.rockLayer ? 0.004f : 0f;
		}

	}
}
