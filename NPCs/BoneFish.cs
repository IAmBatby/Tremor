using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class BoneFish : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Fish");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 40;
			npc.damage = 28;
			npc.defense = 6;
			npc.knockBackResist = 0.3f;
			npc.width = 38;
			npc.height = 26;
			animationType = 241;
			npc.aiStyle = 16;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 0, 3);
			banner = npc.type;
			bannerItem = mod.ItemType("BoneFishBanner");
			NPCID.Sets.TrailCacheLength[npc.type] = 5;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 154);
				};
			}
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
				Rectangle frame = new Rectangle(0, 0, 38, 26);
				frame.Y += 164 * (k / 60);


				spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, frame, color, 0, Vector2.Zero, npc.scale, effect, 1f);
			}
			return true;
		}

		public override void AI()
		{
			for (int num74 = npc.oldPos.Length - 1; num74 > 0; num74--)
			{
				npc.oldPos[num74] = npc.oldPos[num74 - 1];
			}
			npc.oldPos[0] = npc.position;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BoneFishGore"), 1f);
			}
		}

	}
}