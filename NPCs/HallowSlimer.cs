using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class HallowSlimer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallow Slimer");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 200;
			npc.damage = 25;
			npc.defense = 20;
			npc.knockBackResist = 0.5f;
			npc.width = 40;
			npc.height = 40;
			animationType = 121;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 5, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("HallowSlimerBanner");
			NPCID.Sets.TrailCacheLength[npc.type] = 5;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
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
				Color color = npc.GetAlpha(lightColor) * ((npc.oldPos.Length - k) / (float)npc.oldPos.Length);
				Rectangle frame = new Rectangle(0, 0, 90, 42);
				frame.Y += 164 * (k / 60);


				spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, frame, color, 0, Vector2.Zero, npc.scale, effect, 1f);
			}
			return true;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 48, 138);
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
			}
		}

		public override void AI()
		{
			for (int num72 = npc.oldPos.Length - 1; num72 > 0; num72--)
			{
				npc.oldPos[num72] = npc.oldPos[num72 - 1];
				Lighting.AddLight((int)npc.position.X / 16, (int)npc.position.Y / 16, 0.3f, 0f, 0.2f);
			}
			npc.oldPos[0] = npc.position;

		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneHoly && y < Main.worldSurface ? 0.01f : 0f;
		}
	}
}