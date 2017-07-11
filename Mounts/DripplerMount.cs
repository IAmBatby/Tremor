using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Mounts
{
	public class DripplerMount : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.spawnDust = 5;
			mountData.buff = mod.BuffType("DripplerBuff");
			mountData.heightBoost = 20;
			mountData.flightTimeMax = 30;
			mountData.fatigueMax = 10;
			mountData.acceleration = 1f;
			mountData.jumpSpeed = 6f;
			mountData.fallDamage = 1f;
			mountData.runSpeed = 2f;
			mountData.blockExtraJumps = true;
			mountData.totalFrames = 8;
			mountData.constantJump = true;
			mountData.jumpHeight = 100;
			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 12;
			}
			mountData.playerYOffsets = array;
			mountData.xOffset = 10;
			mountData.bodyFrame = 3;
			mountData.yOffset = 19;
			mountData.inAirFrameStart = 0;
			mountData.idleFrameCount = 8;
			mountData.idleFrameDelay = 12;
			mountData.idleFrameStart = 0;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 8;
			mountData.flyingFrameDelay = 10;
			mountData.flyingFrameStart = 0;
			mountData.playerHeadOffset = 22;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 8;
			mountData.swimFrameCount = mountData.inAirFrameCount;
			mountData.swimFrameDelay = mountData.inAirFrameDelay;
			mountData.swimFrameStart = mountData.inAirFrameStart;
			mountData.standingFrameCount = 8;
			mountData.runningFrameDelay = 8;
			mountData.inAirFrameCount = 8;
			mountData.inAirFrameDelay = 10;
			mountData.idleFrameLoop = true;
			mountData.standingFrameDelay = 8;
		}

	}
}