using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Mounts
{
	public class FlyingDutchman : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.buff = mod.BuffType("FlyingDutchman");
			mountData.heightBoost = 10;
			mountData.fallDamage = 0.5f;
			mountData.runSpeed = 5f;
			mountData.dashSpeed = 6f;
			mountData.flightTimeMax = 1200;
			mountData.fatigueMax = 0;
			mountData.jumpHeight = 40;
			mountData.acceleration = 0.19f;
			mountData.jumpSpeed = 6f;
			mountData.totalFrames = 8;
			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 20;
			}
			mountData.playerYOffsets = array;
			mountData.xOffset = 13;
			mountData.bodyFrame = 3;
			mountData.yOffset = -9;
			mountData.playerHeadOffset = 28;
			mountData.standingFrameCount = 8;
			mountData.standingFrameDelay = 6;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 8;
			mountData.runningFrameDelay = 25;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 8;
			mountData.flyingFrameDelay = 6;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 8;
			mountData.inAirFrameDelay = 6;
			mountData.inAirFrameStart = 0;
			mountData.idleFrameCount = 8;
			mountData.idleFrameDelay = 6;
			mountData.idleFrameStart = 0;
			mountData.idleFrameLoop = true;
			mountData.swimFrameCount = mountData.inAirFrameCount;
			mountData.swimFrameDelay = mountData.inAirFrameDelay;
			mountData.swimFrameStart = mountData.inAirFrameStart;
			if (Main.netMode != 2)
			{
				mountData.textureWidth = mountData.backTexture.Width + 20;
				mountData.textureHeight = mountData.backTexture.Height;
			}
		}
	}
}