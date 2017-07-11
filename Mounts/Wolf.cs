using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Mounts {
public class Wolf: ModMountData
{
    public override void SetDefaults()
    {
        mountData.spawnDust = 57;
        mountData.buff = 118;
        mountData.heightBoost = 20;
        mountData.fallDamage = 0.5f;
        mountData.runSpeed = 11f;
        mountData.dashSpeed = 8f;
        mountData.flightTimeMax = 0;
        mountData.fatigueMax = 0;
        mountData.jumpHeight = 25;
        mountData.acceleration = 0.5f;
        mountData.jumpSpeed = 5f;
        mountData.blockExtraJumps = false;
        mountData.totalFrames = 7;
        mountData.constantJump = true;
        int[] array = new int[mountData.totalFrames];
        for (int l = 0; l < array.Length; l++)
        {
            array[l] = 20;
        } 
        mountData.playerYOffsets = array;
        mountData.xOffset = 13;
        mountData.bodyFrame = 3;
        mountData.yOffset = 15;
        mountData.playerHeadOffset = 22;
        mountData.standingFrameCount = 1;
        mountData.standingFrameDelay = 50;
        mountData.standingFrameStart = 0;
        mountData.runningFrameCount = 7;
        mountData.runningFrameDelay = 50;
        mountData.runningFrameStart = 0;
        mountData.flyingFrameCount = 0;
        mountData.flyingFrameDelay = 0;
        mountData.flyingFrameStart = 0;
        mountData.inAirFrameCount = 1;
        mountData.inAirFrameDelay = 12;
        mountData.inAirFrameStart = 0;
        mountData.idleFrameCount = 7;
        mountData.idleFrameDelay = 50;
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
}}