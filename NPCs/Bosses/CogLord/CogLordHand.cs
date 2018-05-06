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
			npc.width = 60;
			npc.height = 60;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
		}

		const float MaxDist = 250f;

		public override void AI()
		{
			base.AI();

			npc.dontTakeDamage = NPC.AnyNPCs(mod.NPCType<CogLordProbe>());

			if (++npc.ai[3] < 1000)
				npc.damage = npc.defDamage;
			else
			{
				npc.dontTakeDamage = true;
				npc.damage = (int)(npc.defDamage * 1.5f);
			}

			if (npc.ai[3] > 1500)
				npc.ai[3] = 0;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frame = GetFrame(npc.ai[3] < 1000 ? 1 : 2);
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

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			base.PreDraw(spriteBatch, drawColor);
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2(25, 27);
			Vector2 drawPos = npc.Center - Main.screenPosition;
			SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, npc.dontTakeDamage ? Color.Yellow : Color.White, npc.rotation, origin * npc.scale, npc.scale, effects, 0);
			return false;
		}
	}
}