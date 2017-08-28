using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				if(Main.netMode != 1)
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 48, NPCID.IlluminantSlime);
			}
		}

		public override void AI()
		{
			Lighting.AddLight((int)npc.position.X / 16, (int)npc.position.Y / 16, 0.3f, 0f, 0.2f);

			for (int i = npc.oldPos.Length - 1; i > 0; i--)
				npc.oldPos[i] = npc.oldPos[i - 1];
			npc.oldPos[0] = npc.position;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width, Main.npcTexture[npc.type].Height * 0.8f);
			for (int k = 0; k < npc.oldPos.Length; k++)
			{
				SpriteEffects effect = npc.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
				Color color = npc.GetAlpha(lightColor) * ((npc.oldPos.Length - k) / (float)npc.oldPos.Length);
				Rectangle frame = new Rectangle(0, 0, 90, 42);
				frame.Y += 164 * (k / 60);

				spriteBatch.Draw(Main.npcTexture[npc.type], npc.oldPos[k] - Main.screenPosition, frame, color, 0, Vector2.Zero, npc.scale, effect, 1f);
			}
			return true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneHoly && spawnInfo.spawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}