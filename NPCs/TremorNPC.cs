using Terraria.ID;

using System;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
    public class TremorNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {

            if (NPC.downedMoonlord)
            {
                if (npc.type == 147)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
                }
                if (npc.type == 150)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
                }
                if (npc.type == 154)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
                }
                if (npc.type == 155)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
                }
                if (npc.type == 161)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
                }
                if (npc.type == 167)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));

                }
                if (npc.type == 168)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));

                }
                if (npc.type == 169)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
                }
                if (npc.type == 184)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
                }
                if (npc.type == 185)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
                }
                if (npc.type == 197)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
                }
                if (npc.type == 206)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
                }
                if (npc.type == 431)
                {
                    if (Main.rand.Next(7) == 1)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));


              }
       }

            if (npc.type == 77 && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("TheRib"));
            }

            if (npc.type == 110 && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("TheRib"));
            }

            if (npc.type == 483 && Main.rand.Next(4) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("StoneofLife"));
            }

            if (npc.type == 481 && Main.rand.Next(4) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("StoneofLife"));
            }

            if (npc.type == 140 && Main.rand.Next(25) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PossessedHelmet"));
            }

            if (npc.type == 140 && Main.rand.Next(25) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PossessedChestplate"));
            }

            if (npc.type == 140 && Main.rand.Next(25) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PossessedGreaves"));
            }

            if (!Main.expertMode && npc.type == 127 && Main.rand.Next(6) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PrimeBlade"));
            }

            if (!Main.expertMode && npc.type == 134 && Main.rand.Next(6) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("Destructor"));
            }

            if (((npc.type == 381) || (npc.type == 382) || (npc.type == 383) || (npc.type == 385) || (npc.type == 386) ||
                 (npc.type == 388) || (npc.type == 389) || (npc.type == 390) || (npc.type == 391) || (npc.type == 520)) &&
                Main.rand.Next(500) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("Transistor"));
            }

            if (!Main.expertMode && npc.type == 113 && Main.rand.Next(1) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PieceofFlesh"), Main.rand.Next(8, 17));
            }

            if (npc.type == 489 && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("Stigmata"));
            }

            if (npc.type == 62 && Main.rand.Next(2) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("DemonBlood"));
            }

            if (npc.type == 66 && Main.rand.Next(2) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("DemonBlood"));
            }

            if (npc.type == 111 && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("LongBow"));
            }

            if (npc.type == 127 && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("BenderHead"));
            }

            if (npc.type == 125 && Main.rand.Next(5) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("BenderBody"));
            }

            if (npc.type == 126 && Main.rand.Next(5) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("BenderBody"));
            }

            if (npc.type == 134 && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("BenderLegs"));
            }

            if (npc.type == 42 && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ToxicHilt"));
            }

            if (npc.type == 231 && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ToxicHilt"));
            }

            if (npc.type == 232 && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ToxicHilt"));
            }

            if (npc.type == 233 && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ToxicHilt"));
            }

            if (npc.type == 234 && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ToxicHilt"));
            }

            if (npc.type == 235 && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ToxicHilt"));
            }

            if (npc.type == 6 && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PiercingQuartz"));
            }

            if (npc.type == 239 && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("Vertebrow"));
            }

            if (npc.type == 166 && Main.rand.Next(28) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("SwampClump"));
            }

            if (npc.type == 469 && Main.rand.Next(28) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("LeechingSeed"));
            }

            if (npc.type == 166 && Main.rand.Next(25) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("FiercePaw"));
            }

            if (npc.type == 460 && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ButcherMask"));
            }

            if (npc.type == 175 && Main.rand.Next(2) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ThornBall"), Main.rand.Next(6, 15));
            }

            if (npc.type == 164 && Main.rand.Next(40) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("Arachnophobia"));
            }

            if (npc.type == 165 && Main.rand.Next(40) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("Arachnophobia"));
            }

            if (!TremorWorld.downedMotherboard && Main.hardMode && Main.rand.Next(2500) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("MechanicalBrain"));
            }

            if (npc.type == 532 && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PetrifiedSpike"), Main.rand.Next(5, 10));
            }

            if (npc.type == 530 && Main.rand.Next(16) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ScorpionStinger"));
            }

            if (npc.type == 531 && Main.rand.Next(16) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ScorpionStinger"));
            }

            if (npc.type == 23 && Main.rand.Next(100) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("AncientMeteorHelmet"));
            }

            if (npc.type == 346 && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("SantaNK1Mask"));
            }

            if (npc.type == 345 && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("IceQueenMask"));
            }

            if (npc.type == 344 && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("EverscreamMask"));
            }

            if (npc.type == 327 && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PumpkingMask"));
            }

            if (npc.type == 328 && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PumpkingMask"));
            }

            if (npc.type == 325 && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("MourningWoodMask"));
            }

            if (npc.type == 491 && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PirateChest"));
            }

            if (!Main.expertMode && npc.type == 245 && Main.rand.Next(1) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("GolemCore"));
            }

            if (npc.type == 124 && Main.rand.Next(1) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ThrowingWrench"), Main.rand.Next(10, 20));
            }

            if (npc.type == 513 && Main.rand.Next(25) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("IonBlaster"));
            }

            if (npc.type == 513 && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PetrifiedSpike"), Main.rand.Next(5, 10));
            }

            if ((npc.type == 3 || npc.type == 132 || npc.type == 186 || npc.type == 187 || npc.type == 188 ||
                 npc.type == 189 || npc.type == 200 || npc.type == 132 || npc.type == 319 || npc.type == 320 ||
                 npc.type == 321 || npc.type == 331 || npc.type == 332 || npc.type == 430 || npc.type == 432 ||
                 npc.type == 433 || npc.type == 434 || npc.type == 435 || npc.type == 436) && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("UntreatedFlesh"));
            }

            if ((npc.type == 48 || npc.type == 75 || npc.type == 87) && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("AirFragment"));
            }

            if ((npc.type == 58 || npc.type == 65 || npc.type == 63 || npc.type == 64 || npc.type == 102 ||
                 npc.type == 103 || npc.type == 157) && Main.rand.Next(2) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("SeaFragment"));
            }

            if ((npc.type == 10 || npc.type == 95 || npc.type == 56 || npc.type == 153 || npc.type == 175 ||
                 npc.type == 176 || npc.type == 205 || npc.type == 231 || npc.type == 232 || npc.type == 233 ||
                 npc.type == 234 || npc.type == 235 || npc.type == 236 || npc.type == 237) && Main.rand.Next(4) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("EarthFragment"));
            }

            if ((npc.type == 24 || npc.type == 59 || npc.type == 60 || npc.type == 151 || npc.type == 62 ||
                 npc.type == 66) && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("FireFragment"));
            }

            if ((npc.type == 466 || npc.type == 467 || npc.type == 468 || npc.type == 463 || npc.type == 460) &&
                Main.rand.Next(1) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("DarkMatter"), Main.rand.Next(2, 3));
            }

            if (npc.type == 496 && Main.rand.Next(22) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PurpleShellmet"));
            }

            if (npc.type == 497 && Main.rand.Next(22) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("OrangeShellmet"));
            }

            if (npc.lifeMax > 100 && npc.lifeMax < 200 && Main.rand.Next(300) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("TinySai"));
            }
            if (npc.value > 100f && npc.value < 1000f && Main.rand.Next(300) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("RoyalClaymore"));
            }
            if (npc.lifeMax > 200 && npc.lifeMax < 500 && Main.rand.Next(300) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("MassiveHammer"));
            }
            if (npc.defense > 10 && npc.defense < 30 && Main.rand.Next(300) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("Crowbar"));
            }
            if (npc.damage < 200 && npc.damage > 80 && Main.hardMode && Main.rand.Next(300) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("Narsil"));
            }
            if (npc.boss == true && !Main.hardMode && Main.rand.Next(5) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("HeavenHelmet"));
            }
            if (npc.boss == true && !Main.hardMode && Main.rand.Next(5) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("HeavenBreastplate"));
            }
            if (npc.boss == true && !Main.hardMode && Main.rand.Next(5) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("HeavenLeggings"));
            }


            if (npc.type == 13 && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("CorruptorStaff"));
            }

            if (npc.type == 266 && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("CreeperStaff"));
            }

            if (Main.xMas && !Main.player[Main.myPlayer].HasItem(mod.ItemType("SuspiciousLookingPresent")) &&
                Main.rand.Next(250) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("SuspiciousLookingPresent"));
            }

            if (NPC.downedMoonlord && Main.rand.Next(250) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("SuspiciousBag"));
            }

            if (NPC.downedMoonlord && Main.player[Main.myPlayer].ZoneDungeon && Main.rand.Next(4) == 0)
            {
                if (npc.lifeMax > 200 && !Main.expertMode)
                {
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                        mod.ItemType("Phantaplasm"));
                }
                if (npc.lifeMax > 400 && Main.expertMode)
                {
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                        mod.ItemType("Phantaplasm"));
                }
            }

            if (npc.type == 7 && Main.rand.Next(26) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("CorruptorGun"));
            }
            if ((npc.type == 69 || npc.type == 508) && Main.rand.Next(6) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("AntlionShell"));
            }
            if (npc.type == 298 && Main.rand.Next(100) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("RedMask"));
            }

            if (npc.type == 494 && Main.rand.Next(29) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("RedClaw"));
            }
            if (npc.type == 495 && Main.rand.Next(29) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("GreenClaw"));
            }
            if ((npc.type == 498 || npc.type == 499 || npc.type == 500 || npc.type == 501 || npc.type == 502 ||
                 npc.type == 503 || npc.type == 504 || npc.type == 505 || npc.type == 506) && Main.rand.Next(2) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("SalamanderSkin"), Main.rand.Next(2));
            }

            if ((npc.type == 173) && Main.rand.Next(40) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("CrimCudgel"));
            }

            if ((npc.type == 4) && Main.rand.Next(10) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("TriangleMask"));
            }

            if ((npc.type == 35) && Main.rand.Next(6) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("TheArtifact"));
            }

            if (Main.eclipse && NPC.downedMoonlord && Main.rand.Next(10) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ToothofAbraxas"));
            }

            if ((npc.type == 125 || npc.type == 126 || npc.type == 127 || npc.type == 134) && NPC.downedMoonlord &&
                Main.rand.Next(1) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("CarbonSteel"), Main.rand.Next(6, 12));
            }

            if ((npc.type == 21 || npc.type == 449 || npc.type == 450 || npc.type == 451 || npc.type == 452 ||
                 npc.type == 322 || npc.type == 323 || npc.type == 324 || npc.type == 294 || npc.type == 295 ||
                 npc.type == 296 || npc.type == 201 || npc.type == 202 || npc.type == 20 || npc.type == 450 ||
                 npc.type == 451 || npc.type == 452) && WorldGen.shadowOrbSmashed && Main.rand.Next(8) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("RedSteelArmorPiece"));
            }

            if ((npc.type == 21 || npc.type == 449 || npc.type == 450 || npc.type == 451 || npc.type == 452 ||
                 npc.type == 322 || npc.type == 323 || npc.type == 324 || npc.type == 294 || npc.type == 295 ||
                 npc.type == 296 || npc.type == 201 || npc.type == 202 || npc.type == 20 || npc.type == 450 ||
                 npc.type == 451 || npc.type == 452) && WorldGen.shadowOrbSmashed && Main.rand.Next(8) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("FaultyRedSteelShield"));
            }

            if ((npc.type == 21 || npc.type == 449 || npc.type == 450 || npc.type == 451 || npc.type == 452 ||
                 npc.type == 322 || npc.type == 323 || npc.type == 324 || npc.type == 294 || npc.type == 295 ||
                 npc.type == 296 || npc.type == 201 || npc.type == 202 || npc.type == 20 || npc.type == 450 ||
                 npc.type == 451 || npc.type == 452) && WorldGen.shadowOrbSmashed && Main.rand.Next(8) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ChippyRedSteelSword"));
            }

            if ((npc.type == 489) && Main.rand.Next(24) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("TheBrain"));
            }

            if ((npc.type == 490) && Main.rand.Next(4) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("DrippingRoot"));
            }

            if ((npc.aiStyle == 1) && NPC.downedMoonlord && Main.rand.Next(60) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("DarkMass"));
            }

            if ((npc.type == 164 || npc.type == 165) && Main.rand.Next(5) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("SpiderMeat"), Main.rand.Next(1, 3));
            }

            if ((npc.type == 98 || npc.type == 94 || npc.type == 101 || npc.type == 170 || npc.type == 180 ||
                 npc.type == 182) && NPC.downedMoonlord && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ClusterShard"), Main.rand.Next(1, 2));
            }


            if ((npc.type == 175 || npc.type == 205 || npc.type == 226) && NPC.downedMoonlord && Main.rand.Next(4) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("DragonCapsule"), Main.rand.Next(1, 2));
            }

            if (npc.type == 290 && NPC.downedMoonlord && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PaladinHelmet"));
            }

            if (npc.type == 290 && NPC.downedMoonlord && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PaladinBreastplate"));
            }

            if (npc.type == 290 && NPC.downedMoonlord && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("PaladinGreaves"));
            }

            if (!Main.expertMode && npc.type == 35)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("TearsofDeath"), Main.rand.Next(1, 3));
            }

            if (npc.type == 169 && Main.rand.Next(5) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("FrostCore"), Main.rand.Next(1, 3));
            }

            if (npc.type == 431 && Main.rand.Next(8) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("FrostCore"), Main.rand.Next(1, 2));
            }

            if (npc.type == 161 && Main.rand.Next(8) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("FrostCore"), Main.rand.Next(1, 2));
            }

            if (npc.type == 477 && Main.rand.Next(4) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("BrokenHeroAmulet"));
            }

            if (npc.type == 32 && Main.rand.Next(50) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("WaterStorm"));
            }

            if (npc.type == 34 && Main.rand.Next(50) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("WaterStorm"));
            }

            if (npc.type == 34 && Main.rand.Next(40) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("KeyKnife"));
            }

            if (!Main.expertMode && npc.type == 4 && Main.rand.Next(5) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("EyeMonolith"));
            }

            if (!Main.expertMode && npc.type == 4 && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("MonsterTooth"), Main.rand.Next(20, 40));
            }

            if (npc.type == 167 && Main.rand.Next(32) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("NorthAxe"));
            }

            if (npc.type == 167 && Main.rand.Next(32) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("NorthHammer"));
            }

            if (npc.type == 167 && Main.rand.Next(32) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("NorthCutlass"));
            }

            if (npc.type == 82 && Main.rand.Next(40) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("WrathofWraith"));
            }

            if (npc.type == 439 && Main.rand.Next(1) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("AncientTablet"), Main.rand.Next(12, 22));
            }

            if (npc.type == 262 && Main.rand.Next(1) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("EssenseofJungle"), Main.rand.Next(2, 3));
            }

            if (npc.type == 370 && !Main.expertMode && Main.rand.Next(6) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("DukesCannon"), Main.rand.Next(2, 3));
            }

            if (npc.type == 138 && Main.rand.Next(35) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("CrystalSpear"), Main.rand.Next(2, 3));
            }

            if (npc.type == 137 && Main.rand.Next(35) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("CrystalSpear"), Main.rand.Next(2, 3));
            }

            if (npc.type == 39 && Main.rand.Next(40) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("GunBlade"), Main.rand.Next(2, 3));
            }

            if (npc.type == 346 && Main.rand.Next(1) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("SpiK3Ball"), Main.rand.Next(50, 100));
            }

            if (!NPC.downedMoonlord && (npc.type == 75 || npc.type ==  86 || npc.type ==  244 || npc.type ==  122 || npc.type ==  80 || npc.type ==  527) && Main.rand.Next(50) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("UnstableCrystal"));
            }

            if (npc.type ==  17 && Main.rand.Next(2) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("MoneySack"), Main.rand.Next(2,4));
            }

            if (npc.type == 398)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("MultidimensionalFragment"), Main.rand.Next(6,12));
            }

            if (!Main.expertMode && npc.type == 222 && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("YellowPuzzleFragment"));
            }

            if ((npc.type == 381 || npc.type == 382 || npc.type == 383 || npc.type == 385 ||  npc.type == 386 || npc.type == 387 || npc.type == 388 || npc.type == 389 || npc.type == 390) && Main.rand.Next(100) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("WarpPad"));
            }

            if ((npc.type == 273 || npc.type == 274 || npc.type == 275 || npc.type == 276 ||  npc.type == 269 || npc.type == 270 || npc.type == 271 || npc.type == 272 || npc.type == 277 || npc.type == 278 || npc.type == 279 || npc.type == 280 || npc.type == 283 || npc.type == 284 || npc.type == 281 || npc.type == 282 || npc.type == 285 || npc.type == 286) && Main.rand.Next(25) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("BottledSpirit"));
            }

            if ((npc.type == 134 || npc.type == 125 || npc.type == 126 || npc.type == 127) && NPC.downedMechBossAny && Main.rand.Next(10) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("FlaskCore"));
            }

            if (npc.type == 175 && Main.rand.Next(50) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("RichMahoganySeed"));
            }

            if (!Main.expertMode && npc.type == 126 && !NPC.AnyNPCs(125) && Main.rand.Next(6) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("MechaSprayer"));
            }

            if (!Main.expertMode && npc.type == 125 && !NPC.AnyNPCs(126) && Main.rand.Next(6) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("MechaSprayer"));
            }

            if (npc.type == 395 && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("MartianSprayer"));
            }

            if (npc.type == 370 && Main.rand.Next(1) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("DukeFlask"), Main.rand.Next(550,750));
            }

            if (npc.type == 120 && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("ChaosElement"));
            }
			
            if ((npc.type == 361 || npc.type == 445) && Main.rand.Next(33) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("FrogMask"));
            }			
            if (npc.type == 35 && Main.rand.Next(1) == 0)
            {
                Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,
                    mod.ItemType("CursedSoul"), Main.rand.Next(1,5));
            }	

if (npc.type == 398)
{
if(!TremorWorld.downedTremode) // Смотрим есть ли Тремод
{
			Main.NewText("Nightmares became reality!", 90, 0, 157); 
                        Main.NewText("The moon slowly drifts towards the Earth...", 0, 255, 255);


    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
    {
					int i2 = WorldGen.genRand.Next(0, Main.maxTilesX);
					int j2 = WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .45f));
					WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(3, 4), WorldGen.genRand.Next(3, 8), (ushort)mod.TileType("NightmareOreTile"));
    }

				for  (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
				{
					float value = (float)((double)k / ((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05));
					bool flag2 = false;
					int num = 0;
					while (!flag2)
					{
						if (TremorWorld.AddLunarRoots(WorldGen.genRand.Next(100, Main.maxTilesX + 120), WorldGen.genRand.Next((int)(WorldGen.worldSurfaceHigh + 20.0), Main.maxTilesY - 300)))
						{
							flag2 = true;
						}
						else
						{
							num++;
							if (num >= 10000)
							{
								flag2 = true;
							}
						}
					}
				}

        TremorWorld.downedTremode = true; // Врубаем Тремод
}
}


        }

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Merchant && Main.bloodMoon)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.RedPuzzleFragment>());
				nextSlot++;
			}
		}


        public override void SetDefaults(NPC npc)
        {
            if (npc.type == 46)
            {
                npc.lifeMax = 10;
            }

            if (npc.type == 140)
            {
                npc.lifeMax = 280;
            }

            if (npc.type == 82)
            {
                npc.lifeMax = 200;
            }

            if (npc.type == 141)
            {
                npc.lifeMax = 175;
            }

            if (npc.type == 45)
            {
                npc.lifeMax = 250;
            }

            if (npc.type == 58)
            {
                npc.lifeMax = 35;
            }

            if (npc.type == 49)
            {
                npc.lifeMax = 22;
            }

            if (npc.type == 93)
            {
                npc.lifeMax = 150;
            }

            if (npc.type == 77)
            {
                npc.lifeMax = 300;
            }

            if (npc.type == 110)
            {
                npc.lifeMax = 250;
            }

            if (npc.type == 63 && Main.hardMode)
            {
                npc.catchItem = 2436;
            }

            if (npc.type == 103 && Main.hardMode)
            {
                npc.catchItem = 2437;
            }

            if (npc.type == 64 && Main.hardMode)
            {
                npc.catchItem = 2438;
            }

//if(Main.player[Main.myPlayer].FindBuffIndex(mod.BuffType("CursedCoinBuff")) != -1 && Main.rand.Next(50) == 0) 
//{ 
//npc.color = new Color(255, 255, 0, 100); 
//npc.displayName = ("Luxuriant "+npc.displayName); 
//npc.value = (float)(npc.value * 10f); 
//}  

            if (NPC.downedMoonlord && npc.boss == false && npc.townNPC == false && npc.type >= 0 && npc.type <= 579)
            {
                npc.lifeMax = npc.lifeMax*2;
                npc.defense = npc.defense*2;
            }
        }
    }
}