using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Mounts
{
	public class BrutalliskCrystal : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.spawnDust = 226;
            mountData.spawnDustNoGravity = true;
            mountData.buff = mod.BuffType("BrutalliskCrystal");
            mountData.heightBoost = 24;
            mountData.flightTimeMax = 999999999;
            mountData.fatigueMax = 999999999;
            mountData.fallDamage = 0f;
            mountData.usesHover = true;
            mountData.runSpeed = 14f;
            mountData.dashSpeed = 14f;
            mountData.acceleration = 1f;
            mountData.jumpHeight = 10;
            mountData.jumpSpeed = 8f;
            mountData.blockExtraJumps = true;
            mountData.totalFrames = 2;
            int[] array = new int[mountData.totalFrames];
            for (int num2 = 0; num2 < array.Length; num2++)
            {
                array[num2] = 16;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 10;
            mountData.bodyFrame = 3;
            mountData.yOffset = 25;
            mountData.playerHeadOffset = 22;
            mountData.standingFrameCount = 2;
            mountData.standingFrameDelay = 8;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 2;
            mountData.runningFrameDelay = 8;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 2;
            mountData.flyingFrameDelay = 10;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 2;
            mountData.inAirFrameDelay = 10;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 2;
            mountData.idleFrameDelay = 12;
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