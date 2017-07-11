using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

//using Terraria.Content.Fonts;

namespace Tremor.ZombieEvent
{
	public class ZombieEventI : ModPlayer
	{
        public override void UpdateDead()
        {

        }

        public static readonly PlayerLayer MiscEffects = new PlayerLayer("Tremor", "MiscEffects", PlayerLayer.MiscEffectsFront, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("Tremor");
            CyberWrathInvasion modPlayer = drawPlayer.GetModPlayer<CyberWrathInvasion>(mod);

            Texture2D CyberWrathI = mod.GetTexture("Invasion/System/System1");
            Texture2D CyberWrathI1 = mod.GetTexture("Invasion/System/System2");
            Texture2D CyberWrathI2 = mod.GetTexture("Invasion/System/System3");
            Texture2D CyberWrathI3 = mod.GetTexture("Invasion/System/System4");
            Texture2D CyberWrathI4 = mod.GetTexture("Invasion/System/System5");
            Texture2D CyberWrathI5 = mod.GetTexture("Invasion/System/System6");
            Texture2D CyberWrathI6 = mod.GetTexture("Invasion/System/System7");
            Texture2D CyberWrathI7 = mod.GetTexture("Invasion/System/System8");
            Texture2D CyberWrathI8 = mod.GetTexture("Invasion/System/System9");
            Texture2D CyberWrathI9 = mod.GetTexture("Invasion/System/System10");
            Texture2D texture1 = mod.GetTexture("Invasion/System/System");
            SpriteBatch sb1 = Main.spriteBatch;

            int iH1 = texture1.Height;
            int iW1 = texture1.Width;

            int sX1 = 37;
            int sY1 = 30;

            int eH = CyberWrathI.Height;
            int eW = CyberWrathI.Width;

            int XX1 = ((24 - iW1) / 2) + Main.screenWidth - sX1;
            int YY1 = ((24 - iH1) / 2) + sY1 + (int)(280 * 1.4) + (24 - iW1) * (-1) + 20;

            int eX = XX1 - 333;
            int eY = YY1 - 430 + (24 - eW) * (-1);

            bool _number = true;
            int number = 1;
        });

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            MiscEffects.visible = true;
            layers.Add(MiscEffects);
            layers.Insert(0, MiscEffects);
        }

        public override void PostUpdateBuffs()
        {

        }

        public override void PostUpdate()
        {
	    bool First = true;
            const int XOffset = 1200;
            const int YOffset = 1200;

            CyberWrathInvasion modPlayer = player.GetModPlayer<CyberWrathInvasion>(mod);
            if (!ZWorld.ZInvasion)
            {
                ZWorld.ZPoints = 0;
            }

            if (ZWorld.ZPoints >= 100)
            {
                ZWorld.ZInvasion = false;
            }

            if (ZWorld.ZPoints > 100)
            {
                ZWorld.ZPoints = 100;
            }		

			if (!ZWorld.ZInvasion) 
			{ 
				ZWorld.ZPoints = 0; 
			} 

            if (ZWorld.ZInvasion) 
            { 
//Always
                if (Main.rand.Next(3000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Arsonist"));
                if (Main.rand.Next(700) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Deadling1")); 
                if (Main.rand.Next(700) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Deadling2")); 
                if (Main.rand.Next(700) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Deadling3")); 
                if (Main.rand.Next(2250) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("FatSack"));

if (Main.rand.Next(3000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Arsonist"));
                if (Main.rand.Next(700) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Deadling1")); 
                if (Main.rand.Next(700) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Deadling2")); 
                if (Main.rand.Next(700) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Deadling3")); 
                if (Main.rand.Next(2250) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("FatSack"));  
//EoC defeated
                if (NPC.downedBoss1 && Main.rand.Next(4000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("FarmerZombie")); 

                if (NPC.downedBoss1 && Main.rand.Next(4000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("FarmerZombie")); 
//EoW/BoC defeated
                if (NPC.downedBoss2 && Main.rand.Next(3000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Zombat")); 
                if (NPC.downedBoss2 && Main.rand.Next(8000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("DiceZombie")); 
                if (NPC.downedBoss2 && Main.rand.Next(5000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Zombeast")); 
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("PetrifiedZombie1")); 
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("PetrifiedZombie2")); 
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("PetrifiedZombie3")); 

                if (NPC.downedBoss2 && Main.rand.Next(3000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Zombat")); 
                if (NPC.downedBoss2 && Main.rand.Next(8000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("DiceZombie")); 
                if (NPC.downedBoss2 && Main.rand.Next(5000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Zombeast")); 
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("PetrifiedZombie1")); 
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("PetrifiedZombie2")); 
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("PetrifiedZombie3")); 
//Skeletron defeated
                if (NPC.downedBoss3 && Main.rand.Next(10000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Painmaker")); 
                if (NPC.downedBoss3 && Main.rand.Next(6000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("SpearZombie")); 
                if (NPC.downedBoss3 && Main.rand.Next(6000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Zombomber")); 

                if (NPC.downedBoss3 && Main.rand.Next(10000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Painmaker")); 
                if (NPC.downedBoss3 && Main.rand.Next(6000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("SpearZombie")); 
                if (NPC.downedBoss3 && Main.rand.Next(6000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Zombomber")); 
//Hardmode
                if (NPC.downedMechBossAny && Main.rand.Next(20000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Almagron")); 
                if (Main.hardMode && Main.rand.Next(15000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Cryptomage")); 
                if (Main.hardMode && Main.rand.Next(12500) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Dapperblook")); 
                if (Main.hardMode && Main.rand.Next(10000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Scourge")); 
                if (Main.hardMode && Main.rand.Next(8550) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Bonecing")); 
                if (Main.hardMode && Main.rand.Next(6000) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("TheHaunt")); 
                if (Main.hardMode && Main.rand.Next(4375) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("GhoulOfficer")); 
                if (Main.hardMode && Main.rand.Next(1055) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Corpse1")); 
                if (Main.hardMode && Main.rand.Next(1055) == 1) 
                NPC.NewNPC((int)player.Center.X + XOffset, (int)player.Center.Y, mod.NPCType("Corpse2")); 

                if (NPC.downedMechBossAny && Main.rand.Next(20000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Almagron")); 
                if (Main.hardMode && Main.rand.Next(15000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Cryptomage")); 
                if (Main.hardMode && Main.rand.Next(12500) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Dapperblook")); 
                if (Main.hardMode && Main.rand.Next(10000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Scourge")); 
                if (Main.hardMode && Main.rand.Next(8550) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Bonecing")); 
                if (Main.hardMode && Main.rand.Next(6000) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("TheHaunt")); 
                if (Main.hardMode && Main.rand.Next(4375) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("GhoulOfficer")); 
                if (Main.hardMode && Main.rand.Next(1055) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Corpse1")); 
                if (Main.hardMode && Main.rand.Next(1055) == 1) 
                NPC.NewNPC((int)player.Center.X - XOffset, (int)player.Center.Y, mod.NPCType("Corpse2")); 
            }
			
			if (Main.dayTime && ZWorld.ZInvasion)
            {
				Main.NewText("Undead creatures has been defeated!", 175, 75, 255);
                Main.NewText("The Night of Undead has ended!", 135, 17, 17);
                ZWorld.ZPoints = 0;
				ZWorld.ZInvasion = false;
            }
        }

        public override void UpdateBiomeVisuals()
        {
            bool usePurity = ZWorld.ZInvasion;
            player.ManageSpecialBiomeVisuals("Tremor:Zombie", usePurity);
        }
    }
}
