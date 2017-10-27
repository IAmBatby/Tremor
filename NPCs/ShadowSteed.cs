using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class ShadowSteed : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Steed");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.width = npc.height = 48;
			npc.lifeMax = 940;
			npc.damage = 75;
			npc.defense = 30;
			npc.knockBackResist = 0.2f;
			npc.HitSound = SoundID.NPCHit31;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.noTileCollide = true;
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			if (Main.expertMode)
				target.AddBuff(153, 180);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y,
				mod.NPCType("ShadowHandTwo"));
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y,
				mod.NPCType("ShadowHandTwo"));
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y,
				mod.NPCType("ShadowHandTwo"));
			}
		}

		public override bool PreAI()
		{
			npc.rotation = npc.velocity.ToRotation();

			npc.TargetClosest(true);
			Player targetPlayer = Main.player[npc.target];
			if (!targetPlayer.active || targetPlayer.dead)
			{
				npc.target = -1;
				npc.netUpdate = true;
			}
			else
			{
				float currentRot = npc.velocity.ToRotation();
				Vector2 direction = targetPlayer.Center - npc.Center;
				float targetAngle = direction.ToRotation();
				if (direction == Vector2.Zero)
				{
					targetAngle = currentRot;
				}

				float desiredRot = currentRot.AngleLerp(targetAngle, 0.06f);
				npc.velocity = new Vector2(npc.velocity.Length(), 0f).RotatedBy(desiredRot, default(Vector2));
			}
			return false;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter++;
			if (npc.frameCounter >= 5)
			{
				npc.frame.Y = (npc.frame.Y + frameHeight) % (Main.npcFrameCount[npc.type] * frameHeight);
				npc.frameCounter = 0;
			}
			// npc.spriteDirection = -npc.direction;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Texture2D texture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2(texture.Width * 0.5F, (texture.Height / Main.npcFrameCount[npc.type]) * 0.5F);
			SpriteEffects effects = npc.velocity.X < 0 ? SpriteEffects.FlipVertically : SpriteEffects.None;
			spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, origin, 1, effects, 0);

			return false;
		}
	}
}
