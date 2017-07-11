using Terraria.ID;
using Terraria;
using System;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tremor.NPCs
{
	public class GogLordGog : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Gear");
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1;
			npc.damage = 100;
			npc.defense = 0;
			npc.knockBackResist = 1f;
			npc.width = 42;
			npc.height = 46;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.dontTakeDamage = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.value = Item.buyPrice(0, 1, 0, 0);
		}

		int timer = 0;
		public override void AI()
		{
			float Num1 = (float)Main.mouseTextColor / 200f - 0.35f;
			Num1 *= 0.5f;
			npc.scale = Num1 + 0.95f;
			timer++;
			npc.velocity.X = 0f;
			npc.velocity.Y = 0f;

			if (timer >= 200)
			{
				npc.alpha++;
				npc.alpha++;
			}

			if (npc.alpha >= 255)
			{
				npc.life = -1;
				npc.active = false;
				npc.checkDead();
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
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