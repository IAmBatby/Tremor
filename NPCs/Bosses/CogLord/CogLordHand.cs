using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.CogLord
{
	public class CogLordHand : HandAI
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Hand");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 20000;
			npc.damage = 80;
			npc.defense = 20;
			npc.knockBackResist = 0f;
			npc.width = 44;
			npc.height = 84;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.value = Item.buyPrice(0, 0, 5, 0);
		}

		const float MaxDist = 250f;

		public override void AI()
		{
			base.AI();

			npc.dontTakeDamage = NPC.AnyNPCs(mod.NPCType<CogLordProbe>());

			if (++npc.frameCounter < 1000)
				npc.damage = npc.defDamage;
			else
			{
				npc.dontTakeDamage = true;
				npc.damage = (int)(npc.defDamage * 1.5f);
			}

			if (npc.frameCounter > 1500)
				npc.frameCounter = 0;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frame = GetFrame(npc.frameCounter < 1000 ? 1 : 2);
		}

		private Rectangle GetFrame(int number)
		{
			return new Rectangle(0, npc.frame.Height * (number - 1), npc.frame.Width, npc.frame.Height);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CogLordHand"), 1f);
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