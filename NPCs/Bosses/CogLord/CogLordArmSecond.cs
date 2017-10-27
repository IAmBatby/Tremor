﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.CogLord
{
	public class CogLordArmSecond : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 2;
		}

		//Int variables
		private int _animationRate = 6;

		private int _currentFrame;
		private int _timeToAnimation = 6;

		//Float variables
		private float _dist = 150;

		public override void SetDefaults()
		{
			npc.lifeMax = 1;
			npc.knockBackResist = 0.5f;
			npc.width = 112;
			npc.height = 34;
			npc.aiStyle = 0;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.dontTakeDamage = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 5, 0);
		}

		public override void AI()
		{
			if (--_timeToAnimation <= 0)
			{
				if (++_currentFrame > 2)
					_currentFrame = 1;
				_timeToAnimation = _animationRate;
				npc.frame = GetFrame(_currentFrame);
			}

			if ((Main.npc[(int)npc.ai[0]].type == mod.NPCType("CogLordGun") || Main.npc[(int)npc.ai[0]].type == mod.NPCType("CogLordHand")) && Main.npc[(int)npc.ai[0]].active)
			{
				npc.Center = Helper.CenterPoint(Helper.CenterPoint(Main.npc[(int)npc.ai[3]].Center, Main.npc[(int)npc.ai[0]].Center), Main.npc[(int)npc.ai[0]].Center);
				npc.rotation = Helper.rotateBetween2Points(Main.npc[(int)npc.ai[3]].Center, Main.npc[(int)npc.ai[0]].Center);
				if (npc.ai[1] == 0) npc.spriteDirection = -1;
				else npc.spriteDirection = 1;
			}
			else
				npc.life = -1;
		}

		private Rectangle GetFrame(int number)
		{
			return new Rectangle(0, npc.frame.Height * (number - 1), npc.frame.Width, npc.frame.Height);
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