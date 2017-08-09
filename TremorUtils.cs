﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Tremor
{
	public static class TremorUtils
	{
		public static bool NextBool(this UnifiedRandom rand, int chance, int total)
		{
			return rand.Next(total) < chance;
		}

		public static void DrawNPCGlowMask(SpriteBatch spriteBatch, NPC npc, Texture2D texture)
		{
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
		}

		public static void DrawArmorGlowMask(EquipType type, Texture2D texture, PlayerDrawInfo info)
		{
			switch (type)
			{
				case EquipType.Head:
					{
						//Add if(!drawPlayer.invis) ?
						DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X) + ((info.drawPlayer.width - info.drawPlayer.bodyFrame.Width) / 2), (int)(info.position.Y - Main.screenPosition.Y) + info.drawPlayer.height - info.drawPlayer.bodyFrame.Height + 4) + info.drawPlayer.headPosition + info.headOrigin, info.drawPlayer.bodyFrame, info.headGlowMaskColor, info.drawPlayer.headRotation, info.headOrigin, 1f, info.spriteEffects, 0);
						drawData.shader = info.headArmorShader;
						Main.playerDrawData.Add(drawData);
					}
					return;
				case EquipType.Body:
					{
						int num2 = 0;//Add in backAcc stuff later
						Rectangle bodyFrame = info.drawPlayer.bodyFrame;
						int num123 = num2;
						bodyFrame.X += num123;
						bodyFrame.Width -= num123;
						if (info.drawPlayer.direction == -1)
						{
							num123 = 0;
						}
						if (!info.drawPlayer.invis)
						{
							DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X - (info.drawPlayer.bodyFrame.Width / 2) + (info.drawPlayer.width / 2) + num123), ((int)(info.position.Y - Main.screenPosition.Y + info.drawPlayer.height - info.drawPlayer.bodyFrame.Height + 4))) + info.drawPlayer.bodyPosition + new Vector2(info.drawPlayer.bodyFrame.Width / 2, info.drawPlayer.bodyFrame.Height / 2), bodyFrame, info.bodyGlowMaskColor, info.drawPlayer.bodyRotation, info.bodyOrigin, 1f, info.spriteEffects, 0);
							drawData.shader = info.bodyArmorShader;
							Main.playerDrawData.Add(drawData);
						}
					}
					return;
				case EquipType.Legs:
					{
						if (info.drawPlayer.shoe != 15 || info.drawPlayer.wearsRobe)
						{
							if (!info.drawPlayer.invis)
							{
								DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X - (info.drawPlayer.legFrame.Width / 2) + (info.drawPlayer.width / 2)), (int)(info.position.Y - Main.screenPosition.Y + info.drawPlayer.height - info.drawPlayer.legFrame.Height + 4)) + info.drawPlayer.legPosition + info.legOrigin, info.drawPlayer.legFrame, info.legGlowMaskColor, info.drawPlayer.legRotation, info.legOrigin, 1f, info.spriteEffects, 0);
								drawData.shader = info.legArmorShader;
								Main.playerDrawData.Add(drawData);
							}
						}
					}
					return;
			}
		}

		public static void DrawItemGlowMask(Texture2D texture, PlayerDrawInfo info)
		{
			Item item = info.drawPlayer.HeldItem;
			if (info.shadow != 0f || info.drawPlayer.frozen || ((info.drawPlayer.itemAnimation <= 0 || item.useStyle == 0) && (item.holdStyle <= 0 || info.drawPlayer.pulley)) || item.type <= 0 || info.drawPlayer.dead || item.noUseGraphic || (info.drawPlayer.wet && item.noWet))
			{
				return;
			}
			Main.playerDrawData.Add
			(
				new DrawData
				(
					texture, info.itemLocation - Main.screenPosition,
					new Rectangle(0, 0, texture.Width, texture.Height),
					new Color(250, 250, 250, item.alpha),
					info.drawPlayer.itemRotation,
					new Vector2
					(
						texture.Width * 0.5f * (1 - info.drawPlayer.direction),
						info.drawPlayer.gravDir == -1f ? 0 : texture.Height
					),
					item.scale, info.spriteEffects, 0
				)
			);
		}

		public static void DrawItemGlowMaskWorld(SpriteBatch spriteBatch, Item item, Texture2D texture, float rotation, float scale)
		{
			Main.spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width / 2,
					item.position.Y - Main.screenPosition.Y + item.height - (texture.Height / 2) + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				new Color(250, 250, 250, item.alpha), rotation,
				new Vector2(texture.Width / 2, texture.Height / 2),
				scale, SpriteEffects.None, 0f
			);
		}
	}
}
