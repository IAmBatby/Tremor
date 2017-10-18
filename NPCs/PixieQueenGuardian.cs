using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tremor.NPCs
{
	public class PixieQueenGuardian : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pixie Queen Guardian");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 200;
			npc.damage = 75;
			npc.defense = 25;
			npc.knockBackResist = 0f;
			npc.width = 28;
			npc.height = 30;
			animationType = 116;
			npc.aiStyle = 44;
			npc.npcSlots = 15f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.noGravity = true;
			npc.value = Item.buyPrice(0, 0, 0, 9);
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(3))
				player.AddBuff(BuffID.Confused, 1800, true);

			if (Main.rand.NextBool(2))
				player.AddBuff(BuffID.Slow, 1800, true);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
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
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, 0f, origin, npc.scale, effects, 0);

			return false;
		}
	}
}